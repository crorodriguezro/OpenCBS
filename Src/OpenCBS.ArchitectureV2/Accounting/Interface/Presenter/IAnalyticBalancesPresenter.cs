using System;
using OpenCBS.ArchitectureV2.Interface.Presenter;

namespace OpenCBS.ArchitectureV2.Accounting.Interface.Presenter
{
    public interface IAnalyticBalancesPresenter : IPresenter
    {
        void Run(string account, DateTime from, DateTime to, int branchId, bool balancesOnly = false);
    }
}
