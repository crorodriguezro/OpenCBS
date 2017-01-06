using System.Collections.Generic;
using System.Windows.Forms;
using OpenCBS.GUI.UserControl;
using AccountingPaymentMethod = OpenCBS.CoreDomain.Accounting.PaymentMethod;

namespace OpenCBS.GUI.Configuration.PaymentMethod
{
    public partial class PaymentMethodForm : SweetBaseForm // todo transalte
    {
        private List<AccountingPaymentMethod> _paymentMethods;

        public PaymentMethodForm()
        {
            InitializeComponent();
            DisplayaddPaymentMethods();
        }

        public void DisplayaddPaymentMethods()
        {
            _listViewPaymentMethods.Items.Clear();

            _paymentMethods = Services.GetPaymentMethodServices().GetAllNonCashsPaymentMethods();

            foreach (var paymentMethod in _paymentMethods)
            {
                var item = new ListViewItem(paymentMethod.Id.ToString()) { Tag = paymentMethod };
                item.SubItems.Add(paymentMethod.Name);
                item.SubItems.Add(paymentMethod.Description);

                _listViewPaymentMethods.Items.Add(item);
            }
        }

        private void _buttonClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void _buttonAdd_Click(object sender, System.EventArgs e)
        {
            var addPaymentMethodForm = new PaymentMethodAddEdit(_paymentMethods);
            addPaymentMethodForm.ShowDialog();

            DisplayaddPaymentMethods();
        }

        private void _buttonEdit_Click(object sender, System.EventArgs e)
        {
            if (_listViewPaymentMethods.SelectedItems.Count != 0)
            {
                EditSelectedEntryFee();
                return;
            }

//            MessageBox.Show(GetString("needToSelectFee"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void EditSelectedEntryFee()
        {
            var editPaymentMethodForm = new PaymentMethodAddEdit((AccountingPaymentMethod)_listViewPaymentMethods.SelectedItems[0].Tag, _paymentMethods);
            editPaymentMethodForm.ShowDialog();

            DisplayaddPaymentMethods();
        }

        private void _listViewPaymentMethods_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditSelectedEntryFee();
        }
    }
}
