using System;
using OpenCBS.ArchitectureV2.Accounting.CommandData;
using OpenCBS.ArchitectureV2.Accounting.Interface.Presenter;
using OpenCBS.ArchitectureV2.Interface;

namespace OpenCBS.ArchitectureV2.Accounting.Command
{
    public class EditBookingCommand : ArchitectureV2.Command.Command, ICommand<EditBookingCommandData>
    {
        private readonly Lazy<IBookingPresenter> _presenter;

        public EditBookingCommand(IApplicationController applicationController, Lazy<IBookingPresenter> presenter)
            : base(applicationController)
        {
            _presenter = presenter;
        }

        public void Execute(EditBookingCommandData commandData)
        {
            _presenter.Value.Run(commandData.Id);
        }
    }
}
