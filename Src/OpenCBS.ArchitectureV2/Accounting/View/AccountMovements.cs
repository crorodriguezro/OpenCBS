using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Accounting.Interface.Presenter;
using OpenCBS.ArchitectureV2.Accounting.Interface.View;
using OpenCBS.ArchitectureV2.Accounting.Model;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.ArchitectureV2.View;
using StructureMap;

namespace OpenCBS.ArchitectureV2.Accounting.View
{
    public partial class AccountMovementsView : BaseView, IAccountMovementsView
    {
        [DefaultConstructor]
        public AccountMovementsView(ITranslationService translationService)
            : base(translationService)
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            _accountMovementsListView.UseAlternatingBackColors = true;
            _accountMovementsListView.AlternateRowBackColor = Color.FromArgb(240, 240, 240);
            _amountColumn.AspectToStringConverter =
                _startBalanceColum.AspectToStringConverter =
                    _endBalanceColumn.AspectToStringConverter = value =>
                    {
                        var amount = (decimal) value;
                        return amount.ToString("N2");
                    };

            _accountComboBox.Format += Format;
        }

        private static void Format(object sender, ListControlConvertEventArgs e)
        {
            var account = ((Account) e.ListItem);
            e.Value = account.AccountNumber + " " + account.Label;
        }

        public void Attach(IAccountMovementsPresenterCallbacks presenterCallbacks)
        {
            _refreshButton.Click += (sender, e) => presenterCallbacks.Refresh();
            _excelButton.Click += (sender, e) => presenterCallbacks.ShowInExcel();
            FormClosing += (sender, e) => presenterCallbacks.DetachView();
        }

        public void SetAccountMovements(List<AccountMovement> accountMovements)
        {
            var selectedBooking = _accountMovementsListView.SelectedObject;
            _accountMovementsListView.SetObjects(accountMovements);
            _accountMovementsListView.SelectedObject = selectedBooking;
        }

        public Control Control
        {
            get { return _accountMovementsListView; }
        }

        public DateTime From
        {
            get { return _fromDateTimePicker.Value.Date; }
            set { _fromDateTimePicker.Value = value; }
        }

        public DateTime To
        {
            get { return _toDateTimePicker.Value.Date; }
            set { _toDateTimePicker.Value = value; }
        }

        public Account Account
        {
            get { return (Account) _accountComboBox.SelectedItem; }
            set
            {
                _accountComboBox.SelectedItem =
                    ((List<Account>) _accountComboBox.DataSource).FirstOrDefault(
                        i => i.AccountNumber == value.AccountNumber);
            }
        }

        public List<Account> Accounts
        {
            set
            {
                var selected = (Account) _accountComboBox.SelectedItem;
                _accountComboBox.DataSource = value;
                if (selected != null)
                    _accountComboBox.SelectedItem =
                        (value).FirstOrDefault(i => i.AccountNumber == selected.AccountNumber);
            }
        }
    }
}
