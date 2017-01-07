using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.ArchitectureV2.View;
using OpenCBS.Extension.Accounting.Interface.Presenter;
using OpenCBS.Extension.Accounting.Interface.View;
using OpenCBS.Extension.Accounting.Model;

namespace OpenCBS.Extension.Accounting.View
{
    public partial class AccountView : BaseView, IAccountView
    {
        public AccountView(ITranslationService translationService)
            : base(translationService)
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            _parentComboBox.Format += (sender, e) =>
            {
                var account = ((Account) e.ListItem);
                e.Value = account.AccountNumber + " " + account.Label;
            };
            _parentComboBox.KeyDown += EnterKeyPressed;
            _accountNumberTextBox.KeyDown += EnterKeyPressed;
            _labelTextBox.KeyDown += EnterKeyPressed;
            _accountTypeComboBox.KeyDown += EnterKeyPressed;
            _accountTypeComboBox.DataSource = Enum.GetValues(typeof (AccountType));
        }

        private void EnterKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl((Control) sender, true, true, true, true);
            }
        }

        public void Attach(IAccountPresenterCallbacks presenterCallbacks)
        {
            _okButton.Click += (sender, e) => presenterCallbacks.Save();
            _accountTypeComboBox.SelectedValueChanged += (x, e) => ParentCategory();
        }

        public void ParentCategory()
        {
            if ((AccountType) _accountTypeComboBox.SelectedItem == AccountType.Category)
            {
                _parentComboBox.Enabled = false;
                _parentComboBox.Text = null;
                return;
            }
            _parentComboBox.Enabled = true;
        }

        public List<Account> Accounts
        {
            get { return (List<Account>) _parentComboBox.DataSource; }
            set { _parentComboBox.DataSource = value; }
        }

        public Account Account
        {
            get
            {
                return new Account
                {
                    AccountNumber = _accountNumberTextBox.Text,
                    Label = _labelTextBox.Text,
                    Type = (AccountType) _accountTypeComboBox.SelectedItem,
                    IsDebit = _isDebitCheckBox.Checked,
                    IsDirect = _directCheckBox.Checked,
                    Parent =
                        _parentComboBox.SelectedItem != null
                            ? ((Account) _parentComboBox.SelectedItem).AccountNumber
                            : null
                };
            }
            set
            {
                _accountNumberTextBox.Text = value.AccountNumber;
                _labelTextBox.Text = value.Label;
                _accountTypeComboBox.SelectedItem = value.Type;
                _isDebitCheckBox.Checked = value.IsDebit;
                _parentComboBox.SelectedItem = Accounts.Find(x => x.AccountNumber == value.Parent);
                _directCheckBox.Checked = value.IsDirect;
            }
        }

        public bool ParentEnabled
        {
            set { _parentComboBox.Enabled = value; }
        }

        public void DisableAccountNumber()
        {
            _accountNumberTextBox.Enabled = false;
        }

        public void Run()
        {
            ShowDialog();
        }

        public void Stop()
        {
            Close();
        }
    }
}
