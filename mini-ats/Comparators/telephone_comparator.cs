using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mini_ats.Telephone_Line;
namespace mini_ats.Comparators
{
    class telephone_comparator : IComparer<telephone>
    {
        public int Compare(telephone x, telephone y)
        {
            if (x._number < y._number)
                return 1;

            else if (x._number > y._number)
                return -1;

            else
                return 0;
        }
    }
}
