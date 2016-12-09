using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using OpenCBS.CoreDomain;
using OpenCBS.GUI.UserControl;

namespace OpenCBS.GUI.Configuration
{
    public partial class FrmEntryFees : SweetBaseForm
    {
        public FrmEntryFees()
        {
            InitializeComponent();

            FillEntryFee(Services.GetEntryFeeServices().GetAllEntryFee());
        }

        private void FillEntryFee(IEnumerable<EntryFee> entryFees)
        {
            listViewEntryFee.Items.Clear();

            foreach (var fee in entryFees)
            {
                var item = new ListViewItem(fee.Id.ToString()) { Tag = fee };
                item.SubItems.Add(fee.Name);
                item.SubItems.Add(fee.Min.HasValue ? fee.Min.Value.ToString(CultureInfo.CurrentCulture).TrimEnd('0').TrimEnd(',') : "");
                item.SubItems.Add(fee.Max.HasValue ? fee.Max.Value.ToString(CultureInfo.CurrentCulture).TrimEnd('0').TrimEnd(',') : "");
                item.SubItems.Add(fee.IsRate.ToString());
                item.SubItems.Add(fee.MaxSum.ToString().TrimEnd('0').TrimEnd(','));
                listViewEntryFee.Items.Add(item);
            }
        }
    }
}
