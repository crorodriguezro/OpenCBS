using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Interface.View;
using OpenCBS.Extension.Accounting.Interface.Presenter;
using OpenCBS.Extension.Accounting.Model;

namespace OpenCBS.Extension.Accounting.Interface.View
{
    public interface ITurnoverBalancesView : IView<ITurnoverBalancesPresenterCallbacks>
    {
        void ShowBalancesOnly();
        Balance SelectedBalance { get; }
        Dictionary<int, string> Branches { set; }
        int BranchId { get; }
        DateTime From { get; set; }
        DateTime To { get; set; }
        void SetBalances(IList<Balance> balances);
        Control Control { get; }
    }
}
