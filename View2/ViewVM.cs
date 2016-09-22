using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Controller;
namespace View
{
    public partial class ViewVM : Form, IBevViewVM, IPayViewVM
    {
        BeverageController _bevController;
        PaymentController _payController;
        List<CheckBox> _fundsToAdd = new List<CheckBox>();
        List<RadioButton> _sizeOptions = new List<RadioButton>();
        List<RadioButton> _bevOption = new List<RadioButton>();

        public ViewVM()
        {
            InitializeComponent();

            _fundsToAdd.Add(checkBoxPay05);
            _fundsToAdd.Add(checkBoxPay010);
            _fundsToAdd.Add(checkBoxPay025);
            _fundsToAdd.Add(checkBoxPay1);
            _fundsToAdd.Add(checkBoxPay5);
            _fundsToAdd.Add(checkBoxPay10);


            _sizeOptions.Add(radioBtnSizeLarge);
            _sizeOptions.Add(radioBtnSizeMedium);
            _sizeOptions.Add(radioBtnSizeSmall);

            _bevOption.Add(radioButtonCoffee);

            this.SizeEnabled(false);

            this.AddCreamEnables = false;
            this.AddSugarEnables = false;
            this.btnDispBev.Enabled = false;
            this.btnRetFunds.Enabled = false;
        }

        public void SetBevController(BeverageController controller)
        {
            _bevController = controller;
        }
        public void SetPaymentController(PaymentController controller)
        {
            _payController = controller;
        }

        #region EventHandlers for Bev
        private void radioBtnSizeSmall_CheckedChanged(object sender, EventArgs e)
        {
            _bevController.UpdateSize(SIZE_ENUM.SMALL);
        }

        private void radioBtnSizeMedium_CheckedChanged(object sender, EventArgs e)
        {
            _bevController.UpdateSize(SIZE_ENUM.MEDIUM);
        }

        private void radioBtnSizeLarge_CheckedChanged(object sender, EventArgs e)
        {
            _bevController.UpdateSize(SIZE_ENUM.LARGE);
        }

        private void radioBtnCoffee_CheckedChanged(object sender, EventArgs e)
        {
            radioBtnSizeSmall.Checked = true;
            _bevController.SelectedBevChanged(new Coffee());
            _bevController.UpdateSize(SIZE_ENUM.SMALL);

        }

        private void btnAddCream_Click(object sender, EventArgs e)
        {
            _bevController.AddCream(new Cream());

        }

        private void btnAddSugar_Click(object sender, EventArgs e)
        {
            _bevController.AddSugar(new Sugar());

        }

        public string BevInfo
        {
            set { lblBevInfo.Text = value; }
        }

        public string BevCost
        {
            set { lblTotalCost.Text = value.ToString(); }
        }


        public bool AddSugarEnables
        {
            get
            {
                return btnAddSugar.Enabled;
            }
            set
            {
                btnAddSugar.Enabled = value;
            }
        }

        public bool AddCreamEnables
        {
            get
            {
                return btnAddCream.Enabled;
            }
            set
            {
                btnAddCream.Enabled = value;
            }
        }

        public void SizeEnabled(bool enable)
        {
            _sizeOptions.ForEach(i => i.Enabled = enable);
        }

        public void SizeReset()
        {
            _sizeOptions.ForEach(i => i.Checked = false);
        }

        public void BevReset()
        {
            _bevOption.ForEach(i => i.Checked = false);
        }
        #endregion

        #region EventHandlers for Payment
        private void btnAddFunds_Click(object sender, EventArgs e)
        {

            var value = (checkBoxPay05.Checked ? .05 : 0) +
                (checkBoxPay010.Checked ? .10 : 0) +
                (checkBoxPay025.Checked ? .25 : 0) +
                (checkBoxPay1.Checked ? 1 : 0) +
                (checkBoxPay5.Checked ? 5 : 0) +
                (checkBoxPay10.Checked ? 10 : 0);
            _payController.AddFunds(value);
        }
        public void ResetFundsAdd()
        {
            _fundsToAdd.ForEach(i => i.Checked = false);
        }
        public double RemFunds
        {
            set { lblRemFunds.Text = value.ToString(); }
            get
            {
                double res = 0;
                if (Double.TryParse(lblRemFunds.Text, out res))
                {
                    return res;
                }
                return 0;
            }
        }

        #endregion

        #region Actions 
        private void btnDispenseBev_Click(object sender, EventArgs e)
        {
            _payController.SubstractFunds(_bevController.TotalCost);
            _bevController.Reset();
        }

        private void btnDispenseChange_Click(object sender, EventArgs e)
        {
            _payController.SubstractFunds(_payController.Funds);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // cancel Bev selection, not whole transaction
            _bevController.Reset();
        }

        public void UpdateDisBevButtons()
        {
            btnDispBev.Enabled = (_bevController.TotalCost > 0) && ((_payController.Funds - _bevController.TotalCost) > 0);
        }

        public void UpdateRefFundsButton()
        {
            btnRetFunds.Enabled = _payController.Funds > 0;
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
