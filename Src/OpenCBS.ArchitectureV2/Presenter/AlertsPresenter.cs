using System.Collections.Generic;
using System.ComponentModel;
using OpenCBS.ArchitectureV2.Command;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.ArchitectureV2.Interface.Repository;
using OpenCBS.ArchitectureV2.Interface.View;
using OpenCBS.ArchitectureV2.Message;
using OpenCBS.CoreDomain;
using OpenCBS.Enums;
using OpenCBS.Shared;

namespace OpenCBS.ArchitectureV2.Presenter
{
    public class AlertsPresenter : IAlertsPresenter, IAlertsPresenterCallbacks
    {
        private readonly IAlertsView _view;
        private readonly IErrorView _errorView;
        private readonly IApplicationController _applicationController;
        private readonly ILoanRepository _loanRepository;

        private List<Model.Alert> _alerts; 

        public AlertsPresenter(
            IAlertsView view,
            IErrorView errorView,
            IApplicationController applicationController,
            ILoanRepository loanRepository)
        {
            _view = view;
            _errorView = errorView;
            _applicationController = applicationController;
            _loanRepository = loanRepository;
        }

        public void Run()
        {
            _view.Attach(this);
            _applicationController.Publish(new ShowViewMessage(this, _view));
            _applicationController.Publish(new AlertsShownMessage(this));
            ReloadAlerts();
        }

        public object View
        {
            get { return _view; }
        }

        public void DetachView()
        {
            _applicationController.Publish(new AlertsHiddenMessage(this));
        }

        public void Refresh()
        {
            var alerts = _alerts.FindAll(x =>
                _view.ShowPerformingLoans && x.IsLoan && x.Status == OContractStatus.Active && x.LateDays == 0 ||
                _view.ShowLateLoans && x.IsLoan && x.Status == OContractStatus.Active && x.LateDays > 0 ||
                _view.ShowPendingLoans && x.IsLoan && x.Status == OContractStatus.Pending ||
                _view.ShowValidatedLoans && x.IsLoan && x.Status == OContractStatus.Validated ||
                _view.ShowPostponedLoans && x.IsLoan && x.Status == OContractStatus.Postponed ||
                _view.ShowPendingSavings && x.IsSaving && x.Status == OContractStatus.Pending ||
                _view.ShowOverdraftSavings && x.IsSaving && x.Amount < 0);
            _view.SetAlerts(alerts);
            _view.SetTitle(string.Format("Alerts ({0})", alerts.Count));
        }

        private void ReloadAlerts()
        {
            var bw = new BackgroundWorker();
            bw.DoWork += (sender, e) =>
            {
                e.Result = _loanRepository.GetAlerts(TimeProvider.Now, User.CurrentUser.Id);
            };
            bw.RunWorkerCompleted += (sender, e) =>
            {
                _view.StopProgress();
                if (e.Error != null)
                {
                    _errorView.Run(e.Error.Message);
                    return;
                }
                _alerts = (List<Model.Alert>) e.Result;
                Refresh();
            };
            _view.StartProgress();
            _view.SetTitle("Alerts (loading...)");
            bw.RunWorkerAsync();
        }
    }
}
