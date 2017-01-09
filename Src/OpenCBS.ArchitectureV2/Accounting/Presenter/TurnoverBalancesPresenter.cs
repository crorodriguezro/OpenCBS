using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using OpenCBS.ArchitectureV2.Accounting.CommandData;
using OpenCBS.ArchitectureV2.Accounting.Interface.Presenter;
using OpenCBS.ArchitectureV2.Accounting.Interface.Repository;
using OpenCBS.ArchitectureV2.Accounting.Interface.View;
using OpenCBS.ArchitectureV2.Accounting.Message;
using OpenCBS.ArchitectureV2.Accounting.Model;
using OpenCBS.ArchitectureV2.Accounting.View;
using OpenCBS.ArchitectureV2.CommandData;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.ArchitectureV2.Message;
using OpenCBS.Services;

namespace OpenCBS.ArchitectureV2.Accounting.Presenter
{
    public class TurnoverBalancesPresenter : ITurnoverBalancesPresenter, ITurnoverBalancesPresenterCallbacks
    {
        private readonly ITurnoverBalancesView _view;
        private readonly IAccountRepository _repository;
        private readonly IApplicationController _applicationController;
        private bool _balancesOnly;

        public TurnoverBalancesPresenter(
            ITurnoverBalancesView view,
            IAccountRepository repository,
            IApplicationController applicationController)
        {
            _view = view;
            _repository = repository;
            _applicationController = applicationController;
        }

        public void Run(bool balancesOnly = false)
        {
            _balancesOnly = balancesOnly;
            if (_balancesOnly)
            {
                _view.ShowBalancesOnly();
            }
            _applicationController.Subscribe<BookingSavedMessage>(this, m => Refresh());
            _applicationController.Subscribe<AccountSavedMessage>(this, m => Refresh());
            _view.Attach(this);
            var branches = new Dictionary<int, string> {{0, "All branches"}};
            foreach (var branch in ServicesProvider.GetInstance().GetBranchService().FindAllNonDeleted())
            {
                branches.Add(branch.Id, branch.Name);
            }
            _view.Branches = branches;
            Refresh();
            _applicationController.Publish(new ShowViewMessage(this, _view));
        }

        public object View
        {
            get { return _view; }
        }

        public void Refresh()
        {
            List<Balance> balances = null;
            var progressForm = new LoadingProgressForm();
            var bw = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true,
            };
            bw.DoWork += (obj, args) =>
            {
                balances =
                    _repository
                        .GetBalances(_view.From, _view.To, _view.BranchId)
                        .Where(i => !i.IsZero)
                        .ToList();
                balances = balances.FindAll(x => x.Code != "00");
                balances = balances.FindAll(x => x.Code != "0");
                bw.ReportProgress(100);
            };
            bw.RunWorkerCompleted += (obj, args) =>
            {
                _view.SetBalances(balances);
                progressForm.Close();
                return;
            };
            bw.RunWorkerAsync();
            progressForm.ShowDialog();
        }

        public void ShowAccountMovements()
        {
            if (_view.SelectedBalance == null) return;
            _applicationController.Execute(new ShowAccountMovementsCommandData
            {
                Account = _view.SelectedBalance.Code,
                From = _view.From,
                To = _view.To
            });
        }

        public void ShowInExcel()
        {
            _applicationController.Execute(new PrintControlCommandData {Control = _view.Control});
        }

        public void ShowAnalytics()
        {
            var account = _view.SelectedBalance;
            if (account == null) return;
            _applicationController.Execute(new ShowAnalyticBalancesCommandData
            {
                Account = account.Code,
                From = _view.From,
                To = _view.To,
                BranchId = _view.BranchId,
                BalancesOnly = _balancesOnly
            });
        }

        public void DetachView()
        {
            _applicationController.Unsubscribe(this);
        }
    }
}
