using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Accounting.Interface.Presenter;
using OpenCBS.ArchitectureV2.Accounting.Interface.Repository;
using OpenCBS.ArchitectureV2.Accounting.Interface.View;
using OpenCBS.ArchitectureV2.Accounting.Message;
using OpenCBS.ArchitectureV2.Accounting.Model;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.ArchitectureV2.Presenter;

namespace OpenCBS.ArchitectureV2.Accounting.Presenter
{
    public class AccountPresenter : IAccountPresenter, IAccountPresenterCallbacks
    {
        private readonly IAccountView _view;
        private readonly IAccountRepository _accountRepository;
        private readonly IApplicationController _applicationController;
        private bool _isNew;

        public AccountPresenter(
            IAccountView view,
            IAccountRepository accountRepository,
            IApplicationController applicationController)
        {
            _view = view;
            _accountRepository = accountRepository;
            _applicationController = applicationController;
        }

        public void Run(Account account)
        {
            _view.Attach(this);
            var accounts = _accountRepository.SelectAllAccounts();
            _view.Accounts = accounts;
            _isNew = true;
            var enabled = true;
            if (account != null)
            {
                _view.Account = account;
                _isNew = false;
                enabled = false;
            }

            if (!_isNew)
            {
                _view.DisableAccountNumber();
            }

            _view.ParentEnabled = enabled;
            _view.ParentCategory();
            _view.Run();
        }

        public object View
        {
            get { return _view; }
        }

        public void Save()
        {
            var account = _view.Account;
            if (_isNew)
            {
                if (!_accountRepository.Exists(account))
                {
                    _accountRepository.Save(account);
                }
                else
                {
                    ITranslationService translationService = new TranslationService();
                    MessageBox.Show(translationService.Translate("Account is already created."));
                }
            }
            else
            {
                _accountRepository.Update(account);
            }
            _view.Stop();

            _applicationController.Publish(new AccountSavedMessage(this, account));
        }
    }
}
