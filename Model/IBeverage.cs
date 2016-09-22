using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Model
{
    public enum SIZE_ENUM { SMALL, MEDIUM, LARGE };
    public interface IBeverage
    {
        
        double Cost { get; }
        string Description { get; }
        SIZE_ENUM Size { get; set; }
        List<IExtraAddtions> Extras { get; set; }
        void AddExtra(IExtraAddtions extra);
        double TotalCost { get; }
        string BevDescription { get; }
    }
}
