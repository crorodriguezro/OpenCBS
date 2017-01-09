using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using BrightIdeasSoftware;
using OpenCBS.ArchitectureV2.Accounting.Interface.Presenter;
using OpenCBS.ArchitectureV2.Accounting.Interface.View;
using OpenCBS.ArchitectureV2.Accounting.Model;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.ArchitectureV2.View;
using StructureMap;

namespace OpenCBS.ArchitectureV2.Accounting.View
{
    public partial class AccountsView : BaseView, IAccountsView
    {
        private List<Account> _accounts;

        [DefaultConstructor]
        public AccountsView(ITranslationService translationService)
            : base(translationService)
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            _accountsListView.RowFormatter = FormatRow;
            _accountsListView.CanExpandGetter = x =>
            {
                var account = (Account) x;
                return _accounts.Any(i => i.Parent == account.AccountNumber);
            };
            _accountsListView.ChildrenGetter = x =>
            {
                var account = (Account) x;
                return _accounts.Where(i => i.Parent == account.AccountNumber);
            };
        }

        private static void FormatRow(OLVListItem item)
        {
            var account = (Account) item.RowObject;
            if (account == null) return;
            if (account.Parent == null) item.Font = new Font(item.Font, FontStyle.Bold);
        }

        public void Attach(IAccountsPresenterCallbacks presenterCallbacks)
        {
            _addButton.Click += (sender, e) => presenterCallbacks.Add();
            _editButton.Click += (sender, e) => presenterCallbacks.Edit();
            _accountsListView.DoubleClick += (sender, e) => presenterCallbacks.Edit();
            _deleteButton.Click += (sender, e) => presenterCallbacks.Delete();
            FormClosing += (sender, e) => presenterCallbacks.DetachView();
        }

        public void SetAccounts(List<Account> accounts)
        {
            _accounts = accounts;
            var selectedAccount = _accountsListView.SelectedObject;
            var roots = _accounts.Where(i => i.Parent == null).ToList();
            _accountsListView.SetObjects(roots);
            foreach (var root in roots)
            {
                _accountsListView.Expand(root);
            }
            _accountsListView.SelectedObject = selectedAccount;
            _accountsListView.TopItemIndex = 0;
        }

        public Account SelectedAccount
        {
            get { return (Account) _accountsListView.SelectedObject; }
        }

        public void AddButtonEnabled()
        {
            _addButton.Enabled = true;
        }

        public void AddButtonDisabled()
        {
            _addButton.Enabled = false;
        }

        public void EditButtonEnabled()
        {
            _editButton.Enabled = true;
        }

        public void EditButtonDisabled()
        {
            _editButton.Enabled = false;
        }

        public void DeleteButtonEnabled()
        {
            _deleteButton.Enabled = true;
        }

        public void DeleteButtonDisabled()
        {
            _deleteButton.Enabled = false;
        }
    }
}