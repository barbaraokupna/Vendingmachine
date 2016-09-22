using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Controller
{
    public interface IBevViewVM
    {
        void SetBevController(BeverageController controller);

        string BevInfo { set; }
        string BevCost { set; }

        bool AddSugarEnables { get; set; }
        bool AddCreamEnables { get; set; }

        void UpdateDisBevButtons();
        void SizeEnabled(bool enable);

        void SizeReset();
        void BevReset();

    }
}
