using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_ats.Signals
{
    class signal_tube : signal
    {
        private string type_of_signal = "TUBE";
        public int caller_number { get; set; }
        public string type { get { return type_of_signal; } set => throw new NotImplementedException(); }
        public signal_tube(int number)
        {
            this.caller_number = number;
        }
    }
}
