using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Controller
{
    public class PaymentController 
    {
        IPayViewVM _view;
        IPaymentFunds _funds = new Payment();
        public PaymentController(IPayViewVM view)
        {
            _view = view;
            _view.SetPaymentController(this);

        }
      
        public void AddFunds(double value)
        {
            _funds.AddFunds(value);
            _view.RemFunds += value;
            _view.UpdateDisBevButtons();
            _view.ResetFundsAdd();
            _view.UpdateRefFundsButton();
        }

        public void SubstractFunds(double value)
        {
            _funds.SubstractFunds(value);
            _view.RemFunds = (_view.RemFunds - value < 0) ? 0 : _view.RemFunds - value;
            _view.UpdateDisBevButtons();
            _view.UpdateRefFundsButton();
        }

        public double Funds
        {
            set { _funds.Funds = value; }
            get { return _funds.Funds; }
           
        }
    }
}
