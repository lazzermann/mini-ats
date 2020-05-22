using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_ats.Signals
{
    class signal_busy : signal{
        private string type_of_signal = "BUSY";
        private int number;
        public string type { get { return type_of_signal; } set => throw new NotImplementedException(); }
        public int _number { get { return number; } set { this.number = value; } }
        public signal_busy(int number) {
            this._number = number;
        }
    }
}
