using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Model
{
    public class Coffee : IBeverage
    {
        private SIZE_ENUM _size = SIZE_ENUM.SMALL;
        List<IExtraAddtions> _extrasList = new List<IExtraAddtions>();
        public double Cost
        {
            get
            {
                switch (_size)
                {
                    case SIZE_ENUM.LARGE:
                        return 2.25;
                    case SIZE_ENUM.MEDIUM:
                        return 2.00;
                    default:
                        return 1.75;
                }
            }
        }

        public string Description
        {
            get { return "Coffee"; }
        }

        public SIZE_ENUM Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public List<IExtraAddtions> Extras
        {
            get { return _extrasList; }
            set { _extrasList = value; }
        }

        public void AddExtra(IExtraAddtions extra)
        {
            _extrasList.Add(extra);
        }

        public double TotalCost
        {
            get
            {
                var cost = this.Cost;
                cost += _extrasList.Sum(i => i.Cost);
                return cost;
            }
        }

        public string BevDescription
        {
            get
            {
                var desc = this.Description;
                foreach (IExtraAddtions item in _extrasList)
                {
                    desc = String.Format("{0}, {1}", desc, item.Description);
                }

                return desc;
            }
        }
    }
}

