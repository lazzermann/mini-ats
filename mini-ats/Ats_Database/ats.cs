using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mini_ats.Telephone_Line;
using mini_ats.Signals;

namespace mini_ats.Ats_Database
{

    public class ats
    {
        const string DATA = "DATA";
        const string TUBE = "TUBE";
        const string TON = "TON";
        const string DIGIT = "DIGIT";
        const string END = "END";
        const int external_number = 9;
        const int external_numbers_range = 900;

        List<communication_line> communication_lines_list { get; set; }
        List<pair> prepared_sessions;
        database session_list;
        external_ats town_ats;

        public database dat { get { return session_list; } set => throw new NotImplementedException(); }
        public ats(){
            communication_lines_list = new List<communication_line>();
            prepared_sessions = new List<pair>();
        }

        public ats(List<telephone> telephones){
            communication_lines_list = new List<communication_line>();
            prepared_sessions = new List<pair>();
            create_lines(telephones);
        }

        public void commutate(database basa){
            session_list = basa;
        }

        public void commutate(external_ats town_ats){
            this.town_ats = town_ats;
        }

        public void create_lines(List<telephone> telephones){
            for (int i = 0; i < telephones.Count; i++){
                if(telephones[i]._number < external_numbers_range)
                    communication_lines_list.Add(new communication_line(telephones[i], this));
            }
        }

        public void add_line(telephone phone){
            if (phone._number < external_numbers_range)
                communication_lines_list.Add(new communication_line(phone, this));
            else
                town_ats.create_line(phone);
        }

        private void send_signal_type_ton(signal siga, int number) {
            if(number >= external_numbers_range)
            {
                (siga as signal_ton).number = number;
                town_ats.rescive_signal(siga);
                return;
            }

            communication_lines_list.Find(x => x._phone._number == number).resend_signal_to_phone(siga);
        }

        private void send_signal_type_data(signal siga) {
            signal_data si = siga as signal_data;
            if(si.interlocutor_number >= external_numbers_range)
            {
                town_ats.rescive_signal(siga);
                return;
            }

            communication_lines_list.Find(x => x._phone._number == si.interlocutor_number).resend_signal_to_phone(siga);
        }

        private void send_signal_type_busy(signal siga){
            signal_busy s = siga as signal_busy;
            
            if(s._number >= external_numbers_range)
            {
                town_ats.rescive_signal(s);
                return;
            }

            communication_lines_list.Find(x => x._phone._number == s._number).resend_signal_to_phone(siga);
        }

        private void send_signal_type_call(signal siga){
            signal_call call = siga as signal_call;
            if (call._number >= external_numbers_range)
            {
                town_ats.rescive_signal(siga);
                return;
            }
            communication_lines_list.Find(x => x._phone._number == call._number).resend_signal_to_phone(siga);
        }

        private void send_signal_type_begin(signal siga){
            if ((siga as signal_begin).number >= external_numbers_range)
            {
                town_ats.rescive_signal(siga);
                return;
            }

            communication_lines_list.Find(x => x._phone._number == (siga as signal_begin).number).resend_signal_to_phone(siga);
        }

        private void add_or_prepare_session(signal siga) {
            signal_digit dig = siga as signal_digit;
            pair temp = prepared_sessions.Find(x => x.caller_phone._number == dig.caller_number);
            
            if (prepared_sessions.Contains(temp)){
                int i = prepared_sessions.FindIndex(x => x.caller_phone._number == dig.caller_number);
                prepared_sessions[i].count += 1;
                prepared_sessions[i].digits += Convert.ToString(dig._digit);
            }

            else{

                if (dig._digit == external_number){
                    signal_tube tub = new signal_tube(dig.caller_number);
                    town_ats.rescive_signal(tub);
                }

                pair prepared_session = new pair(session_list.phones.Find(x => x._number == dig.caller_number), Convert.ToString(dig._digit));
                prepared_sessions.Add(prepared_session);
                return;
            }

            if(temp.count == 3){
                communication_line com = communication_lines_list.Find(x => x._phone._number == Convert.ToInt32(temp.digits));

                if (session_list.phone_exsist(Convert.ToInt32(temp.digits)))
                {
                    if (session_list.is_on_session(Convert.ToInt32(temp.digits)))
                    {

                        send_signal_type_busy(new signal_busy(temp.caller_phone._number));
                        prepared_sessions.Remove(temp);
                    }

                    else
                    {
                        int r = prepared_sessions.FindIndex(x => x == temp);
                        prepared_sessions[r].called_phone = session_list.get_phone(Convert.ToInt32(temp.digits));
                        send_signal_type_call(new signal_call(false, temp.caller_phone._number, temp.called_phone._number));
                        send_signal_type_call(new signal_call(true, temp.called_phone._number, temp.caller_phone._number));
                    }

                }

                else{
                    send_signal_type_busy(new signal_busy(temp.caller_phone._number));
                    prepared_sessions.Remove(temp);
                }
          

            }
        }

        private void commutate_lines(pair ses){
            session_list.add_session(new session(ses.caller_phone, ses.called_phone));
            send_signal_type_begin(new signal_begin(ses.caller_phone._number));
            send_signal_type_begin(new signal_begin(ses.called_phone._number));
            prepared_sessions.Remove(ses);
        }

       private void delete_session(signal siga){
            session_list.delete_session((siga as signal_end).caller_number);
            prepared_sessions.Remove(prepared_sessions.Find(x => x.caller_phone._number == (siga as signal_end).caller_number || x.called_phone._number == (siga as signal_end).caller_number));
            
           if((siga as signal_end).interlocutor_number != -1)
                send_signal_type_ton(new signal_ton(true), (siga as signal_end).interlocutor_number);
       }
        

        public void receive_signal(signal siga){
            
            if (siga.type == TUBE){
                signal_tube tuba = siga as signal_tube;
                
                if (prepared_sessions.Contains(prepared_sessions.Find(x => x.called_phone._number == tuba.caller_number)))
                    commutate_lines(prepared_sessions.Find(x => x.called_phone._number == tuba.caller_number));    
                
                else
                    send_signal_type_ton(new signal_ton(false), tuba.caller_number);
            }

            if (siga.type == TON)
                send_signal_type_ton(siga, (siga as signal_ton).number);

            if(siga.type == DATA)
                send_signal_type_data(siga);

            if (siga.type == DIGIT)
                add_or_prepare_session(siga);

            if (siga.type == END) 
                delete_session(siga);
            
        }
    }
}
