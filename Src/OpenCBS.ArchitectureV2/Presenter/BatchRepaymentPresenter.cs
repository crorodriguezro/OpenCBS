using System.Collections.Generic;
using System.Linq;
using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.ArchitectureV2.Interface.Repository;
using OpenCBS.ArchitectureV2.Interface.View;
using OpenCBS.ArchitectureV2.Model;
using OpenCBS.Shared;

namespace OpenCBS.ArchitectureV2.Presenter
{
    public class BatchRepaymentPresenter : IBatchRepaymentPresenter, IBatchRepaymentPresenterCallbacks
    {
        private readonly IBatchRepaymentView _view;
        private readonly ILoanRepository _loanRepository;
        private List<Loan> _loans;

        public BatchRepaymentPresenter(
            IBatchRepaymentView view,
            ILoanRepository loanRepository)
        {
            _view = view;
            _loanRepository = loanRepository;
        }

        public void Run(int villageBankId)
        {
            _view.Attach(this);
            _loans = _loanRepository.GetVillageBankLoans(villageBankId);
            _view.SetLoans(_loans);
            _view.Run();
        }

        public object View
        {
            get { return _view; }
        }

        public decimal GetDuePrincipal(int loanId)
        {
            var loan = _loans.Find(x => x.Id == loanId);
            if (loan == null)
            {
                return 0;
            }
            var date = TimeProvider.Today;
            return loan
                .Schedule
                .FindAll(x => x.ExpectedDate <= date)
                .Sum(x => x.Principal - x.PaidPrincipal);
        }

        public decimal GetDueInterest(int loanId)
        {
            var loan = _loans.Find(x => x.Id == loanId);
            if (loan == null)
            {
                return 0;
            }
            var date = TimeProvider.Today;
            return loan
                .Schedule
                .FindAll(x => x.ExpectedDate <= date)
                .Sum(x => x.Interest - x.PaidInterest);
        }
    }
}
