using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mini_ats.Telephone_Line;
using mini_ats.Signals;
namespace mini_ats.Ats_Database
{
    public class external_ats
    {
        const string DATA = "DATA";
        const string TUBE = "TUBE";
        const string TON = "TON";
        const string DIGIT = "DIGIT";
        const string END = "END";
        const string CALL = "CALL";
        const string BEGIN = "BEGIN";
        const string BUSY = "BUSY";
        const int external_numbers_range = 900;

        ats mini_ats;
        List<communication_line> special_line;

        public external_ats(ats mini_ats){
            this.mini_ats = mini_ats;
            this.mini_ats.commutate(this);
            special_line = new List<communication_line>();
            create_lines(mini_ats.dat.phones);
        }

        public void rescive_signal(signal siga){
            if (siga.type == TUBE){
                
                signal_ton tona = new signal_ton(false);
                tona.number = (siga as signal_tube).caller_number;

                if ((siga as signal_tube).caller_number >= external_numbers_range)
                {
                    resend_signal_to_ats(siga);
                }
                    
                else
                    resend_signal_to_ats(tona);
            }

            if(siga.type == DIGIT)
                resend_signal_to_ats(siga);
            

            if (siga.type == END){
                signal_ton tona = new signal_ton(true);
                
                if ((siga as signal_end).caller_number >= external_numbers_range)
                {
                    tona.number = (siga as signal_end).interlocutor_number;
                    resend_signal_to_ats(siga);
                }

                else{
                    tona.number = (siga as signal_end).interlocutor_number;
                    send_signal_to_phone(tona);
                }
            }

            if(siga.type == DATA){
                if ((siga as signal_data).interlocutor_number >= external_numbers_range)
                    send_signal_to_phone(siga);
                else
                    resend_signal_to_ats(siga);
            }

            if(siga.type == TON || siga.type == CALL || siga.type == BEGIN || siga.type == BUSY)
                send_signal_to_phone(siga);
            
            
        }

        

        private void send_signal_to_phone(signal siga){
            if(siga.type == DATA)
                special_line.Find(x => x._phone._number == (siga as signal_data).interlocutor_number).resend_signal_to_phone(siga);

            if (siga.type == CALL)
                special_line.Find(x => x._phone._number == (siga as signal_call)._number).resend_signal_to_phone(siga);

            if (siga.type == TON)
                special_line.Find(x => x._phone._number == (siga as signal_ton).number).resend_signal_to_phone(siga);
            

            if (siga.type == BEGIN)
                special_line.Find(x => x._phone._number == (siga as signal_begin).number).resend_signal_to_phone(siga);

            if (siga.type == BUSY)
                special_line.Find(x => x._phone._number == (siga as signal_busy)._number).resend_signal_to_phone(siga);
        }

        private void resend_signal_to_ats(signal siga){
            mini_ats.receive_signal(siga);
        }

        private void create_lines(List<telephone> phones){
            for(int i = 0; i < phones.Count; i++){
                if (phones[i]._number >= 900)
                    special_line.Add(new communication_line(phones[i], this));
            }
        }

        public void create_line(telephone phone){
            special_line.Add(new communication_line(phone, this));
        }
        
    }
}
