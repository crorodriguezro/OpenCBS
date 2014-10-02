using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.CoreDomain.Accounting;
using OpenCBS.CoreDomain.Contracts.Loans;

namespace OpenCBS.ArchitectureV2.Interface.View
{
    public interface IRepaymentView : IView<IRepaymentPresenterCallbacks>
    {
        void Run();
        void Stop();
        void ShowExtraColumn();

        Loan Loan { set; }
        List<PaymentMethod> PaymentMethods { set; }
        Dictionary<int, string> PaymentTypes { set; }
        decimal Amount { get; set; }
        decimal Principal { get; set; }
        decimal PrincipalMax { get; set; }
        decimal Interest { get; set; }
        decimal Penalty { get; set; }
        decimal BounceFee { get; set; }
        DateTime Date { get; set; }
        bool OkButtonEnabled { get; set; }
        string Comment { get; set; }
        string Title { set; }
        PaymentMethod SelectedPaymentMethod { get; set; }
        int SelectedPaymentTypeId { get; set; }
        string Description { set; }
        DialogResult DialogResult { get; set; }
    }
}
