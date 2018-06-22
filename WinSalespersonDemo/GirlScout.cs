using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinSalespersonDemo
{
   public class GirlScout:Salesperson,ISellable
    {
        //instance vaariables
        private int _numberOfCookiesBoxesSold=0; //number of cookies boxes sold
        private string _summary; //sales summary

        //construcotr
        public GirlScout(int numberOdCookiesBoxesSold,string firstName,string lastName):base(lastName,firstName)
        {
            _numberOfCookiesBoxesSold = numberOdCookiesBoxesSold;
            SalesSpeech();
        }

        //get or set the value of instance variable _numberOfCookiesBoxesSold
        public int NumberOfCookiesBoxesSold
        {
            get
            {
                return _numberOfCookiesBoxesSold;
            }
            set
            {
                _numberOfCookiesBoxesSold = value;
            }
        }

        //return the value of instance varible _summary
        public  string Summary
        {
            get { return _summary; }
        }

        //implementation of interface method
        //method to make sales
        public void MakeSale()
        {
            _summary = "Girl Scout summary for " + base.ToString() + ":\n" +
                "Total cookies boxes sold: " + _numberOfCookiesBoxesSold;
        }

        //implementation of interface method
        //method return the sales speeech
        public string SalesSpeech()
        {
           return "Hi, my name is " + base.ToString() + " and I am selling Girl Scout Cookies.\n" +
                "Can I interest you in some cookies?\n" +
                "Thin Mints are my personal favorite.";     
        }
    }
}
