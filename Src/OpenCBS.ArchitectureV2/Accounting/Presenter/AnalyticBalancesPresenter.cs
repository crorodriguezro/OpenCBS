using System;
using System.Linq;
using OpenCBS.ArchitectureV2.CommandData;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.ArchitectureV2.Message;
using OpenCBS.Extension.Accounting.Interface.Presenter;
using OpenCBS.Extension.Accounting.Interface.Repository;
using OpenCBS.Extension.Accounting.Interface.View;
using OpenCBS.Extension.Accounting.Message;

namespace OpenCBS.Extension.Accounting.Presenter
{
    public class AnalyticBalancesPresenter : IAnalyticBalancesPresenter, IAnalyticBalancesPresenterCallbacks
    {
        private readonly IAnalyticBalancesView _view;
        private readonly IAccountRepository _accountRepository;
        private readonly IApplicationController _applicationController;
        private string _code;
        private DateTime _from;
        private DateTime _to;
        private int _branchId;
        private bool _balancesOnly;

        public AnalyticBalancesPresenter(
            IAnalyticBalancesView view,
            IAccountRepository accountRepository,
            IApplicationController applicationController)
        {
            _view = view;
            _accountRepository = accountRepository;
            _applicationController = applicationController;
        }

        public void Run(string account, DateTime from, DateTime to, int branchId, bool balanceOnly = false)
        {
            _code = account;
            _from = from;
            _to = to;
            _branchId = branchId;
            _balancesOnly = balanceOnly;
            if (_balancesOnly)
            {
                _view.ShowBalancesOnly();
            }
            _applicationController.Subscribe<BookingSavedMessage>(this, m => Refresh());
            Refresh();
            _view.Attach(this);
            _applicationController.Publish(new ShowViewMessage(this, _view));
        }

        private void Refresh()
        {
            _view.SetBalances(_accountRepository
                .GetAnalyticBalances(_code, _from, _to, _branchId)
                .Where(i => !i.IsZero)
                .ToList());
        }

        public object View
        {
            get { return _view; }
        }

        public void ShowInExcel()
        {
            _applicationController.Execute(new PrintControlCommandData { Control = _view.Control });
        }

        public void DetachView()
        {
            _applicationController.Unsubscribe(this);
        }
    }
}
