using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mini_ats.Telephone_Line;

namespace mini_ats.Ats_Database
{
    public class session{
        private telephone first;
        private telephone second;
        public telephone _first { get { return first; }  set { first = value; } }
        public telephone _second { get { return second; } set { second = value; } }

        public session(telephone _first, telephone _second){
            this._first = _first;
            this._second = _second;
        }
    }
}
