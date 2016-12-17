using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using OpenCBS.GUI.UserControl;
using Fee = OpenCBS.CoreDomain.EntryFee;

namespace OpenCBS.GUI.Configuration.EntryFee
{
    public partial class EntryFeesForm : SweetBaseForm
    {
        private List<Fee> _entryFees;

        public EntryFeesForm()
        {
            InitializeComponent();

            DisplayEntryFee();
        }

        public void DisplayEntryFee()
        {
            _listViewEntryFee.Items.Clear();

            _entryFees = Services.GetEntryFeeServices().SelectAllEntryFee();

            foreach (var fee in _entryFees)
            {
                if(!_checkBoxShowDeleted.Checked && fee.IsDeleted)
                    continue;

                var item = new ListViewItem(fee.Id.ToString()) { Tag = fee };
                item.SubItems.Add(fee.Name);
                item.SubItems.Add(fee.Min.HasValue ? fee.Min.Value.ToString(CultureInfo.CurrentCulture).TrimEnd('0').TrimEnd(',') : "");
                item.SubItems.Add(fee.Max.HasValue ? fee.Max.Value.ToString(CultureInfo.CurrentCulture).TrimEnd('0').TrimEnd(',') : "");
                item.SubItems.Add(fee.IsRate.ToString());
                item.SubItems.Add(fee.MaxSum.ToString().TrimEnd('0').TrimEnd(','));

                if (fee.IsDeleted)
                {
                    item.BackColor = Color.FromArgb(188, 209, 199);
                    item.ForeColor = Color.White;
                }

                _listViewEntryFee.Items.Add(item);
            }
        }

        private void _buttonClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void _buttonAdd_Click(object sender, System.EventArgs e)
        {
            var addEntryFeeForm = new EntryFeeAddEdit(_entryFees);
            addEntryFeeForm.ShowDialog();

            DisplayEntryFee();
        }

        private void _buttonEdit_Click(object sender, System.EventArgs e)
        {
            if (_listViewEntryFee.SelectedItems.Count != 0)
            {
                EditSelectedEntryFee();
                return;
            }

            MessageBox.Show(GetString("needToSelectFee"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void _listViewEntryFee_DoubleClick(object sender, System.EventArgs e)
        {
            EditSelectedEntryFee();
        }

        private void EditSelectedEntryFee()
        {
            var addEntryFeeForm = new EntryFeeAddEdit((Fee)_listViewEntryFee.SelectedItems[0].Tag, _entryFees);
            addEntryFeeForm.ShowDialog();

            DisplayEntryFee();
        }

        private void _checkBoxShowDeleted_CheckedChanged(object sender, System.EventArgs e)
        {
            DisplayEntryFee();
        }

        private void _buttonDelete_Click(object sender, System.EventArgs e)
        {
            if (_listViewEntryFee.SelectedItems.Count != 0)
            {
                //todo handle case if some product use this entry fee

                if (MessageBox.Show(GetString(@"areUSure"), GetString("deleteSelectedEntryFee"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Services.GetEntryFeeServices().DeleteEntryfee((Fee)_listViewEntryFee.SelectedItems[0].Tag);
                    DisplayEntryFee();
                }
                return;
            }

            MessageBox.Show(GetString("needToSelectFee"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
