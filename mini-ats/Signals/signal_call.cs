using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_ats.Signals
{
    class signal_call : signal
    {
        private string type_of_signal = "CALL";
        public bool is_ringing { get; set; }
        public int number_of_interlocutor { get; set; }
        public int _number { get; set; }
        public string type { get { return type_of_signal; } set => throw new NotImplementedException(); }

        public signal_call(bool call_mode, int number, int number_of_interlocutor)
        {
            this.is_ringing = call_mode;
            this._number = number;
            this.number_of_interlocutor = number_of_interlocutor;
        }
    }
}
