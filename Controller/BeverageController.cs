using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Model;
namespace Controller
{
    public class BeverageController
    {
        IBevViewVM _view;
        IBeverage _beverage;
        IList extras = new List<IExtraAddtions>();
                
        public BeverageController(IBevViewVM view)
        {
            _view = view;
            _view.SetBevController(this);

        }

        public void SelectedBevChanged(IBeverage bev)
        {
            _beverage = bev;
            _view.BevInfo = _beverage.BevDescription;
            _view.BevCost = _beverage.TotalCost.ToString();
            _view.AddCreamEnables = true;
            _view.AddSugarEnables = true;
            _view.SizeEnabled(true);
        }

        public SIZE_ENUM Size
        {
            set { _beverage.Size = value; }
            get { return _beverage.Size; }
        }

        public void UpdateSize(SIZE_ENUM size)
        {
            this.Size = size;
            _view.BevCost = _beverage.TotalCost.ToString();
            _view.UpdateDisBevButtons();
        }

        public void AddCream(IExtraAddtions extra)
        {
            _beverage.AddExtra(extra);
            _view.BevInfo = _beverage.BevDescription;
            _view.BevCost = _beverage.TotalCost.ToString();

            var numOfAdditionAdded = _beverage.Extras.Where(e => e.GetType() == extra.GetType()).Count();

            _view.AddCreamEnables = (numOfAdditionAdded < extra.MaxAllowed ? true : false);
            _view.UpdateDisBevButtons();

        }

         public void AddSugar(IExtraAddtions extra)
        {
            _beverage.AddExtra(extra);
            _view.BevInfo = _beverage.BevDescription;
            _view.BevCost = _beverage.TotalCost.ToString();

            var numOfAdditionAdded = _beverage.Extras.Where(e => e.GetType() == extra.GetType()).Count();

            _view.AddSugarEnables = (numOfAdditionAdded < extra.MaxAllowed ? true : false);
            _view.UpdateDisBevButtons();
        }

        public double TotalCost
        {
            get { return (_beverage != null ? _beverage.TotalCost : 0); }
        }

        public void Reset()
        {
            _beverage = null;
            _view.BevCost = String.Empty;
            _view.BevInfo = String.Empty;
           
            _view.UpdateDisBevButtons();
            _view.AddCreamEnables = false;
            _view.AddSugarEnables = false;
            _view.SizeEnabled(false);
            _view.SizeReset();
            _view.BevReset();
        }
    }
}
