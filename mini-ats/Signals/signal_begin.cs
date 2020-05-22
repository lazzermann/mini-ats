using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_ats.Signals
{
    class signal_begin : signal
    {
        private string type_of_signal = "BEGIN";
        public string type { get { return type_of_signal; } set => throw new NotImplementedException(); }
        public int number { get; set; }
        public signal_begin(int number) {
            this.number = number;
        }
    }
}
