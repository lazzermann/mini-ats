using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_ats.Signals
{
    class signal_ton : signal
    {
        private string type_of_signal = "TON";
        public string type { get { return type_of_signal; } set => throw new NotImplementedException(); }
        public bool is_ready { get;  set; }
        public int number { get; set; }
        public signal_ton(bool is_end_of_call) {
            is_ready = is_end_of_call;
        }
    }
}
