using System.Collections.Generic;
using OpenCBS.ArchitectureV2.Accounting.Interface.Presenter;
using OpenCBS.ArchitectureV2.Accounting.Model;
using OpenCBS.ArchitectureV2.Interface.View;

namespace OpenCBS.ArchitectureV2.Accounting.Interface.View
{
    public interface IAccountView : IView<IAccountPresenterCallbacks>
    {
        List<Account> Accounts { get; set; }
        Account Account { get; set; }
        bool ParentEnabled { set; }
        void ParentCategory();
        void Run();
        void Stop();
        void DisableAccountNumber();
    }
}
