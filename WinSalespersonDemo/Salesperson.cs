using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinSalespersonDemo
{
   public abstract class Salesperson
    {
        private string _lastname;
        private string _firstName;

        public Salesperson(string lastName, string firstName)
        {
            _lastname = lastName;
            _firstName = firstName;
        }

        public string LastName
        {
            get { return _lastname; } set { _lastname = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public override string ToString()
        {
            string fullName= _firstName + " " + _lastname;
           
            return fullName;
        }
    }
}
