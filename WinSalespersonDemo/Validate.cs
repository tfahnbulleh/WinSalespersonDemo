using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinSalespersonDemo
{
   public class Validate
    {
        public bool Name(string firstName,string lastName)
        {
            if (firstName.Length<1 || lastName.Length<1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool NumberOfBoxes(int boxes)
        {
            if (boxes < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CommisionRate(double rate)
        {
            if (rate < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool HouseValue(double value)
        {
            if (value<0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
