using System;
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

        private Loan GetLoan(int loanId)
        {
            var loan = _loans.Find(x => x.Id == loanId);
            if (loan == null)
            {
                throw new ApplicationException(string.Format("Loan identified by id={0} not found.", loanId));
            }
            return loan;
        }

        public decimal GetDuePrincipal(int loanId)
        {
            var loan = GetLoan(loanId);
            var date = TimeProvider.Today;
            return loan
                .Schedule
                .FindAll(x => x.ExpectedDate <= date)
                .Sum(x => x.Principal - x.PaidPrincipal);
        }

        public decimal GetDueInterest(int loanId)
        {
            var loan = GetLoan(loanId);
            var date = TimeProvider.Today;
            return loan
                .Schedule
                .FindAll(x => x.ExpectedDate <= date)
                .Sum(x => x.Interest - x.PaidInterest);
        }

        public decimal[] DistributeTotal(int loanId, decimal total)
        {
            var loan = GetLoan(loanId);
            var installments = loan.Schedule.Where(x => !x.Repaid).ToList();
            var principal = 0m;
            var interest = 0m;
            foreach (var installment in installments)
            {
                if (installment.UnpaidInterest > total)
                {
                    interest += total;
                    break;
                }
                total -= installment.UnpaidInterest;
                interest += installment.UnpaidInterest;
                installment.PaidInterest = installment.Interest;

                if (installment.UnpaidPrincipal > total)
                {
                    principal += total;
                    break;
                }
                total -= installment.UnpaidPrincipal;
                principal += installment.UnpaidPrincipal;
                installment.PaidPrincipal = installment.Principal;
            }

            return new[] { principal, interest };
        }


        public decimal GetMaxDueTotal(int loanId)
        {
            var loan = GetLoan(loanId);
            return loan.Schedule.Sum(x => x.Principal + x.Interest - x.PaidPrincipal - x.PaidInterest);
        }
    }
}
