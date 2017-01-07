using System;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.Extension.Accounting.CommandData;
using OpenCBS.Extension.Accounting.Interface.Presenter;

namespace OpenCBS.Extension.Accounting.Command
{
    public class EditAccountCommand : ArchitectureV2.Command.Command, ICommand<EditAccountCommandData>
    {
        private readonly Lazy<IAccountPresenter> _presenter;

        public EditAccountCommand(IApplicationController applicationController, Lazy<IAccountPresenter> presenter)
            : base(applicationController)
        {
            _presenter = presenter;
        }

        public void Execute(EditAccountCommandData commandData)
        {
            _presenter.Value.Run(commandData.Account);
        }
    }
}
