using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mini_ats.Telephone_Line;
namespace mini_ats.Comparators
{
    class communication_line_comparator : IComparer<communication_line>
    {
        public int Compare(communication_line x, communication_line y)
        {
            if (x._phone._number < y._phone._number)
                return 1;

            else if (x._phone._number > y._phone._number)
                return -1;

            else
                return 0;
        }
    }
}
