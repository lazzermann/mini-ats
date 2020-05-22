using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mini_ats.Signals;
using mini_ats.Ats_Database;

namespace mini_ats.Telephone_Line
{
    public class communication_line
    {
        telephone phone;
        ats machine;
        external_ats town_ats;

       public telephone _phone { get { return phone; } set => throw new NotImplementedException();}

        public communication_line() { }
        public communication_line(ref telephone phone) {
            this.phone = phone;
            this.phone.comutate(this);
        }

        public communication_line(telephone phone, ats machine){
            this.machine = machine;
            this.phone = phone;
            this.phone.comutate(this);
        }

        public communication_line(telephone phone, external_ats _external_ats){
            this.phone = phone;
            this.town_ats = _external_ats;
            this.phone.comutate(this);
        }

        public void resend_signal_to_ats(signal siga){
            if (machine != null)
                this.machine.receive_signal(siga);
            else
                resend_signal_to_extend_ats(siga);
        }

        public void resend_signal_to_phone(signal siga){
            this.phone.receive_signal(siga);
        }

        public void resend_signal_to_extend_ats(signal siga){
            this.town_ats.rescive_signal(siga);
        }
    }
}
