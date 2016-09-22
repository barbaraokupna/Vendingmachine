using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;
using Controller;
namespace VengingMachine
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            ViewVM dialog = new ViewVM();
            PaymentController payController = new PaymentController(dialog);
            BeverageController bevController = new BeverageController(dialog);
            dialog.ShowDialog();


        }
    }
}
