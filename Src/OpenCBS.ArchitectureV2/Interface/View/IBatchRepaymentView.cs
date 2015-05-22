using System.Collections.Generic;
using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.ArchitectureV2.Model;

namespace OpenCBS.ArchitectureV2.Interface.View
{
    public interface IBatchRepaymentView : IView<IBatchRepaymentPresenterCallbacks>
    {
        void Run();
        void SetLoans(List<Loan> loans);
    }
}
