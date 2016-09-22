using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Payment :IPaymentFunds
    {
        private double _amount = 0;
        public void AddFunds(double amount)
        {
            _amount += amount;
        }

        public void SubstractFunds(double amount)
        {
            _amount -= amount;
        }

        public double Funds
        {
            get
            {
               return _amount;
            }
            set
            {
                _amount = value;
            }
        }
    }
}
