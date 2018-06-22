using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinSalespersonDemo
{
   public class RealEstateSalesperson:Salesperson, ISellable
    {
        //instance variables
        private double _totalValueSold; //total value sold
        private double _totalCommisionEarned; //commision earned
        private double _commisionRate; //commission rate
        private string _summary; //sales summary

        //constructor
        public RealEstateSalesperson(double commisionRate,string firstName,string lastName):base(lastName,firstName)
        {
            _commisionRate = commisionRate;
            _totalCommisionEarned = 0;
            _totalValueSold = 0;
        }

        //get or set the value of instance variable _totalValueSold
        public double TotalValueSold { get { return _totalValueSold; } set { _totalValueSold = value; } }

        //get the value of instance variable _totalCommisionEarned
        public double TotalCommisionEarned { get { return _totalCommisionEarned; } }

        //get the value of instance variable _commisionRate
        public double CommsionRate
        {
            get
            {
                CommisionEarned(); //method call
                return _commisionRate;
            }           
        }


        //method to make sale
        //before this method is call, make sure to call TotalValueSold set property
        public void MakeSale()
        {
            CommisionEarned();//method call
        }

        //implementation of interface method
        //method return the sales speeech
        public string SalesSpeech()
        {
            return  "Hi my name is "+base.ToString()+" and I would like to discuss\n" +
                "some amazing real estate properties that have become available.\n" +
                "How does that sound?!";
        }

        //method to set the value of commission earned
        private void CommisionEarned()
        {
            this._totalCommisionEarned = (this._commisionRate / 100) * _totalValueSold;
        }

        public string Summary()
        {
           return  "Real estate summary for " + base.ToString() + ":\n" +
                "Total home value sold: " + _totalValueSold.ToString("C", CultureInfo.CurrentCulture) + "\n" +
                "Total commission earned: " + _totalCommisionEarned.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}
