using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mini_ats.Ats_Database;
namespace mini_ats.Comparators
{
    class session_comparator : IComparer<session>
    {
        public int Compare(session x, session y)
        {
            if (x._first._number < y._first._number)
                return 1;

            else if (x._first._number > y._first._number)
                return -1;

            else
                return 0;
        }
    }
}
