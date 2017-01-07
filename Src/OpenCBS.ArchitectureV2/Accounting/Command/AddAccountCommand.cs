using System;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.Extension.Accounting.CommandData;
using OpenCBS.Extension.Accounting.Interface.Presenter;

namespace OpenCBS.Extension.Accounting.Command
{
    public class AddAccountCommand : ArchitectureV2.Command.Command, ICommand<AddAccountCommandData>
    {
        private readonly Lazy<IAccountPresenter> _presenter;

        public AddAccountCommand(IApplicationController applicationController, Lazy<IAccountPresenter> presenter)
            : base(applicationController)
        {
            _presenter = presenter;
        }

        public void Execute(AddAccountCommandData commandData)
        {
            _presenter.Value.Run();
        }
    }
}
