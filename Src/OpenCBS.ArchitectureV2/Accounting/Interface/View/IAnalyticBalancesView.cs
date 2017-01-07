using System.Collections.Generic;
using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Interface.View;
using OpenCBS.Extension.Accounting.Interface.Presenter;
using OpenCBS.Extension.Accounting.Model;

namespace OpenCBS.Extension.Accounting.Interface.View
{
    public interface IAnalyticBalancesView : IView<IAnalyticBalancesPresenterCallbacks>
    {
        void SetBalances(List<Balance> balances);
        void ShowBalancesOnly();
        Control Control { get; }
    }
}
