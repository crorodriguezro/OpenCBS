﻿using System.Collections.Generic;
using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.ArchitectureV2.Model;
using OpenCBS.CoreDomain.Accounting;

namespace OpenCBS.ArchitectureV2.Interface.View
{
    public interface IBatchRepaymentView : IView<IBatchRepaymentPresenterCallbacks>
    {
        void Run();
        void Stop();
        void SetLoans(List<Loan> loans);
        decimal GetTotal(int loanId);
        string GetComment(int loanId);
        string GetReceiptNumber(int loanId);
        List<int> SelectedLoanIds { get; }
        void EnableTotalEdit();
        void DisableTotalEdit();
        PaymentMethod SelectedPaymentMethod { get; set; }
        List<PaymentMethod> PaymentMethods { set; }
    }
}
