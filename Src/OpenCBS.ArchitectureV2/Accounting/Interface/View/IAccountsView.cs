using System.Collections.Generic;
using OpenCBS.ArchitectureV2.Accounting.Interface.Presenter;
using OpenCBS.ArchitectureV2.Accounting.Model;
using OpenCBS.ArchitectureV2.Interface.View;

namespace OpenCBS.ArchitectureV2.Accounting.Interface.View
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
