using System.Collections.Generic;
using OpenCBS.ArchitectureV2.Interface.View;
using OpenCBS.Extension.Accounting.Interface.Presenter;
using OpenCBS.Extension.Accounting.Model;

namespace OpenCBS.Extension.Accounting.Interface.View
{
    public interface IAccountsView : IView<IAccountsPresenterCallbacks>
    {
        void SetAccounts(List<Account> accounts);
        Account SelectedAccount { get; }
        void AddButtonEnabled();
        void AddButtonDisabled();
        void EditButtonEnabled();
        void EditButtonDisabled();
        void DeleteButtonEnabled();
        void DeleteButtonDisabled();
    }
}
