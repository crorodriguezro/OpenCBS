using System;
using System.Collections.Generic;
using System.Linq;
using OpenCBS.ArchitectureV2.Accounting.Interface.Presenter;
using OpenCBS.ArchitectureV2.Accounting.Interface.Repository;
using OpenCBS.ArchitectureV2.Accounting.Interface.View;
using OpenCBS.ArchitectureV2.Accounting.Message;
using OpenCBS.ArchitectureV2.Accounting.Model;
using OpenCBS.ArchitectureV2.CommandData;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.ArchitectureV2.Message;

namespace OpenCBS.ArchitectureV2.Accounting.Presenter
{
    public class AccountMovementsPresenter : IAccountMovementsPresenter, IAccountMovementsPresenterCallbacks
    {
        private readonly IAccountMovementsView _view;
        private readonly IBookingRepository _bookingRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IApplicationController _applicationController;

        public AccountMovementsPresenter(
            IAccountMovementsView view,
            IBookingRepository bookingRepository,
            IAccountRepository accountRepository,
            IApplicationController applicationController)
        {
            _view = view;
            _bookingRepository = bookingRepository;
            _accountRepository = accountRepository;
            _applicationController = applicationController;
        }

        public void Run()
        {
            _applicationController.Subscribe<BookingSavedMessage>(this,
                m => Refresh());
            _applicationController.Subscribe<AccountSavedMessage>(this,
                m => _view.Accounts = _accountRepository.SelectAllAccounts());
            _view.Accounts = _accountRepository.SelectAllAccounts();
            Refresh();
            _view.Attach(this);
            _applicationController.Publish(new ShowViewMessage(this, _view));
        }

        public void Run(string accountNumber, DateTime from, DateTime to)
        {
            _applicationController.Subscribe<BookingSavedMessage>(this,
                m => Refresh());
            _applicationController.Subscribe<AccountSavedMessage>(this,
                m => _view.Accounts = _accountRepository.SelectAllAccounts());
            _view.From = from;
            _view.To = to;
            _view.Accounts = _accountRepository.SelectAllAccounts();
            _view.Account = new Account {AccountNumber = accountNumber};
            Refresh();
            _view.Attach(this);
            _applicationController.Publish(new ShowViewMessage(this, _view));
        }

        public object View
        {
            get { return _view; }
        }

        public void Refresh()
        {
            _view.SetAccountMovements(GetAccountMovements());
        }

        public void ShowInExcel()
        {
            _applicationController.Execute(new PrintControlCommandData {Control = _view.Control});
        }

        private List<AccountMovement> GetAccountMovements()
        {
            var account = _view.Account;
            if (account == null) return null;
            var movements = _bookingRepository.GetAccountMovements(_view.From, _view.To, account).OrderBy(i => i.Date);
            var balance = _accountRepository.GetBalance(_view.From, account.AccountNumber);
            var balanceAmount = balance == null
                ? 0m
                : account.IsDebit
                    ? balance.StartDebit
                    : balance.StartCredit;
            foreach (var item in movements)
            {
                item.StartBalance = balanceAmount;
                balanceAmount = account.IsDebit
                    ? balanceAmount + item.DebitAmount - item.CreditAmount
                    : balanceAmount + item.CreditAmount - item.DebitAmount;
                item.EndBalance = balanceAmount;
            }
            return movements.ToList();
        }

        public void DetachView()
        {
            _applicationController.Unsubscribe(this);
        }
    }
}
