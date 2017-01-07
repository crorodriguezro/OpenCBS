using System.Collections.Generic;
using OpenCBS.ArchitectureV2.Interface.View;
using OpenCBS.Extension.Accounting.Interface.Presenter;
using OpenCBS.Extension.Accounting.Model;

namespace OpenCBS.Extension.Accounting.Interface.View
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
