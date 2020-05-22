using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_ats.Signals
{
    class signal_end : signal
    {
        private string type_of_signal = "END";
        public int caller_number { get; set; }
        public int interlocutor_number { get; set; }
        public string type { get { return type_of_signal; } set => throw new NotImplementedException(); }

        public signal_end(int caller_number, int interlocutor_number)
        {
            this.caller_number = caller_number;
            this.interlocutor_number = interlocutor_number;
        }
    }
}
