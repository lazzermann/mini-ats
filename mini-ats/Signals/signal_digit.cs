using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_ats.Signals
{
    class signal_digit : signal
    {
        private string type_of_signal = "DIGIT";
        public int caller_number { get; set; }
        public int _digit { get; set; }
        public string type { get { return type_of_signal; } set => throw new NotImplementedException();   }
        

        public signal_digit(int digit, int caller_number){
            _digit = digit;
            this.caller_number = caller_number;
        }
    }
}
