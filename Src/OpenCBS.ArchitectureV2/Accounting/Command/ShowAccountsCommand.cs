using System;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.Extension.Accounting.CommandData;
using OpenCBS.Extension.Accounting.Interface.Presenter;

namespace OpenCBS.Extension.Accounting.Command
{
    public class ShowAccountsCommand : ArchitectureV2.Command.Command, ICommand<ShowAccountsCommandData>
    {
        private readonly Lazy<IAccountsPresenter> _presenter;

        public ShowAccountsCommand(IApplicationController applicationController, Lazy<IAccountsPresenter> presenter)
            : base(applicationController)
        {
            _presenter = presenter;
        }

        public void Execute(ShowAccountsCommandData commandData)
        {
            if (ActivateViewIfExists("AccountsView"))
            {
                return;
            }
            _presenter.Value.Run();
        }
    }
}
