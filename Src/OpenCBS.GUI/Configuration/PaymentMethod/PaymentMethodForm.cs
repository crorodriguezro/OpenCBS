using System.Collections.Generic;
using System.Windows.Forms;
using OpenCBS.GUI.UserControl;
using AccountingPaymentMethod = OpenCBS.CoreDomain.Accounting.PaymentMethod;

namespace OpenCBS.GUI.Configuration.PaymentMethod
{
    public partial class PaymentMethodForm : SweetBaseForm
    {
        private List<AccountingPaymentMethod> _paymentMethods;

        public PaymentMethodForm()
        {
            InitializeComponent();
            DisplayEntryFee();
        }

        public void DisplayEntryFee()
        {
            _listViewPaymentMethods.Items.Clear();

            _paymentMethods = Services.GetPaymentMethodServices().GetAllPaymentMethods();

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
    }
}
