using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mini_ats.Telephone_Line;
namespace mini_ats.Ats_Database
{
    public class pair
    {
        public telephone caller_phone;
        public telephone called_phone;
        public string digits;
        public int count;
        public pair(telephone phone, string digit)
        {
            this.caller_phone = phone;
            this.called_phone = null;
            digits = digit;
            count = 1;
        }
    }
}
