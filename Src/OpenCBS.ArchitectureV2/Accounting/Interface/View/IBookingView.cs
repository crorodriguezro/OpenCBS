using System;
using System.Collections.Generic;
using OpenCBS.ArchitectureV2.Accounting.Interface.Presenter;
using OpenCBS.ArchitectureV2.Accounting.Model;
using OpenCBS.ArchitectureV2.Interface.View;
using OpenCBS.CoreDomain;

namespace OpenCBS.ArchitectureV2.Accounting.Interface.View
{
    public interface IBookingView : IView<IBookingPresenterCallbacks>
    {
        List<Account> Accounts { set; get; }
        List<Branch> Branches { get; set; }
        Booking Booking { get; set; }
        Account Debit { get; set; }
        Account Credit { get; set; }
        decimal Amount { get; set; }
        string Description { get; set; }
        DateTime Date { get; set; }
        Branch Branch { get; set; }
        bool SaveButtonEnabled { get; set; }
        void Warning(Account account, decimal amount);
        void Run();
        void Stop();
    }
}
