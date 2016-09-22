using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public interface IExtraAddtions 
    {
        string Description{get;}
        double Cost {get;}
        int MaxAllowed { get; }
    }

    public class Cream : IExtraAddtions
    {
        public double Cost
        {
            get
            {
                return 0.50;
            }
        }

        public string Description
        {
            get
            {
                return "Cream";
            }
        }
        public int MaxAllowed
        {
            get
            {
                return 3;
            }
        }
    
    }

    public class Sugar : IExtraAddtions
    {
        public double Cost
        {
            get
            {
                return 0.25;
            }
        }

        public string Description
        {
            get
            {
                return "Sugar";
            }
        }

        public int MaxAllowed
        {
            get
            {
                return 3;
            }
        }
    }

}
