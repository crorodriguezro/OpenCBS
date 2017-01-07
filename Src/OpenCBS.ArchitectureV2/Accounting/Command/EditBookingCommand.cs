using System;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.Extension.Accounting.CommandData;
using OpenCBS.Extension.Accounting.Interface.Presenter;

namespace OpenCBS.Extension.Accounting.Command
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
