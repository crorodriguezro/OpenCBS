using System;
using OpenCBS.ArchitectureV2.Accounting.CommandData;
using OpenCBS.ArchitectureV2.Accounting.Interface.Presenter;
using OpenCBS.ArchitectureV2.Interface;

namespace OpenCBS.ArchitectureV2.Accounting.Command
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
