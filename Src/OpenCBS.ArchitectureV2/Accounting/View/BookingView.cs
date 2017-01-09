using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Accounting.Interface.Presenter;
using OpenCBS.ArchitectureV2.Accounting.Interface.View;
using OpenCBS.ArchitectureV2.Accounting.Model;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.ArchitectureV2.View;
using OpenCBS.CoreDomain;

namespace OpenCBS.ArchitectureV2.Accounting.View
{
    public partial class BookingView : BaseView, IBookingView
    {
        private readonly string _err;

        public BookingView(ITranslationService translationService)
            : base(translationService)
        {
            InitializeComponent();
            Setup();
            _err = translationService.Translate("Please fill the required field");
        }

        private void Setup()
        {
            _debitCombobox.Format += Format;
            _creditCombobox.Format += Format;
            Load += (sender, e) => Validation();
            _debitCombobox.SelectedValueChanged += (sender, e) => Validation();
            _creditCombobox.SelectedValueChanged += (sender, e) => Validation();
            _debitCombobox.TextChanged += (sender, e) => Validation();
            _creditCombobox.TextChanged += (sender, e) => Validation();
            _amountNumericUpDown.ValueChanged += (sender, e) => Validation();
        }

        private static void Format(object sender, ListControlConvertEventArgs e)
        {
            var account = ((Account)e.ListItem);
            e.Value = account.AccountNumber + " " + account.Label;
        }

        public void Warning(Account account, decimal amount)
        {
            MessageBox.Show(@"Not enough fund is " + account.AccountNumber +
                                       @" current fund is " + amount.ToString("N2"));
        }

        public void Run()
        {
            ShowDialog();
        }

        public void Stop()
        {
            Close();
        }

        private void Validation()
        {
            var enabled = true;
            _error.Clear();
            if (Credit == null)
            {
                _error.SetError(_creditCombobox, _err);
                enabled = false;
            }
            if (Debit == null)
            {
                _error.SetError(_debitCombobox, _err);
                enabled = false;
            }
            if (_amountNumericUpDown.Value <= 0)
            {
                _error.SetError(_amountNumericUpDown, _err);
                enabled = false;
            }
            SaveButtonEnabled = enabled;
        }

        public void Attach(IBookingPresenterCallbacks callbacks)
        {
            _okButton.Click += (sender, e) => callbacks.Save();
        }

        public List<Account> Accounts
        {
            get { return (List<Account>)_debitCombobox.DataSource; }
            set
            {
                _debitCombobox.DataSource = value;
                _creditCombobox.DataSource = new List<Account>(value);
            }
        }

        public User User { get; set; }

        public List<Branch> Branches
        {
            get { return (List<Branch>) _branchComboBox.DataSource; }
            set { _branchComboBox.DataSource = value; }
        }

        public Booking Booking { get; set; }

        public Account Debit
        {
            get { return (Account)_debitCombobox.SelectedItem; }
            set
            {
                _debitCombobox.SelectedItem =
                    ((List<Account>)_debitCombobox.DataSource).FirstOrDefault(
                        i => i.AccountNumber == value.AccountNumber);
            }
        }

        public Account Credit
        {
            get { return (Account)_creditCombobox.SelectedItem; }
            set
            {
                _creditCombobox.SelectedItem =
                    ((List<Account>)_creditCombobox.DataSource).FirstOrDefault(
                        i => i.AccountNumber == value.AccountNumber);
            }
        }

        public decimal Amount
        {
            get { return _amountNumericUpDown.Value; }
            set { _amountNumericUpDown.Value = value; }
        }

        public string Description
        {
            get { return _descriptionTextBox.Text; }
            set { _descriptionTextBox.Text = value; }
        }

        public DateTime Date
        {
            get { return _dateTimePicker.Value; }
            set { _dateTimePicker.Value = value; }
        }

        public Branch Branch
        {
            get { return (Branch) _branchComboBox.SelectedItem; }
            set { _branchComboBox.SelectedItem = Branches.Where(i => i.Id == value.Id).ToList().First(); }
        }

        public bool SaveButtonEnabled
        {
            get { return _okButton.Enabled; }
            set { _okButton.Enabled = value; }
        }
    }
}
