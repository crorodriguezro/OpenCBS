using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Forms;
using OpenCBS.Enums;

namespace OpenCBS.Extensions
{
    [Export(typeof(ILoanApprovalControl))]
    [ExportMetadata("Implementation", "Default")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class LoanApprovalUserControl : UserControl, ILoanApprovalControl
    {
        public LoanApprovalUserControl()
        {
            InitializeComponent();

            var statuses = new[]
            {
                OContractStatus.Pending,
                OContractStatus.Validated,
                OContractStatus.Refused,
                OContractStatus.Abandoned,
                OContractStatus.Deleted
            };
            var dict = statuses.ToDictionary(x => x, x => x);
            _statusComboBox.DisplayMember = "Value";
            _statusComboBox.ValueMember = "Key";
            _statusComboBox.DataSource = new BindingSource(dict, null);
            _statusComboBox.SelectedIndex = 0;

            _saveButton.Click += (sender, args) =>
            {
                if (SaveLoanApproval == null) return;
                SaveLoanApproval();
            };
        }

        public Control GetControl()
        {
            return this;
        }

        public string Comment
        {
            get { return _commentTextBox.Text; }
            set { _commentTextBox.Text = value; }
        }

        public string Code
        {
            get { return _codeTextBox.Text; }
            set { _codeTextBox.Text = value; }
        }

        public DateTime Date
        {
            get { return _dateTimePicker.Value; }
            set { _dateTimePicker.Value = value; }
        }

        public Action SaveLoanApproval { get; set; }

        public OContractStatus Status
        {
            get { return (OContractStatus) _statusComboBox.SelectedValue; }
            set
            {
                switch (value)
                {
                    case OContractStatus.Pending:
                    case OContractStatus.Postponed:
                    case OContractStatus.Refused:
                    case OContractStatus.Abandoned:
                    case OContractStatus.Deleted:
                    case OContractStatus.NonAccrual:
                        _statusComboBox.SelectedValue = value;
                        break;

                    case OContractStatus.Active:
                    case OContractStatus.Closed:
                    case OContractStatus.WrittenOff:
                    case OContractStatus.Validated:
                        _statusComboBox.SelectedValue = OContractStatus.Validated;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(string.Format("No such status: {0}", value.GetName()));
                }

                switch (value)
                {
                    case OContractStatus.Active:
                    case OContractStatus.Closed:
                    case OContractStatus.WrittenOff:
                        SetEnabled(false);
                        break;

                    default:
                        SetEnabled(true);
                        break;
                }
            }
        }

        private void SetEnabled(bool enabled)
        {
            _statusComboBox.Enabled = enabled;
            _codeTextBox.Enabled = enabled;
            _commentTextBox.Enabled = enabled;
            _dateTimePicker.Enabled = enabled;
            _saveButton.Enabled = enabled;
        }
    }
}
