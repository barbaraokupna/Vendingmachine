using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Controller
{
    public interface IPayViewVM
    {
        void SetPaymentController(PaymentController controller);
        double RemFunds { get;  set; }

        void UpdateDisBevButtons();
        void ResetFundsAdd();
        void UpdateRefFundsButton();
    }
}
