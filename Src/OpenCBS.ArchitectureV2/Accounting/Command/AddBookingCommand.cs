using System;
using OpenCBS.ArchitectureV2.Accounting.CommandData;
using OpenCBS.ArchitectureV2.Accounting.Interface.Presenter;
using OpenCBS.ArchitectureV2.Interface;

namespace OpenCBS.ArchitectureV2.Accounting.Command
{
    public class AddBookingCommand : ArchitectureV2.Command.Command, ICommand<AddBookingCommandData>
    {
        private readonly Lazy<IBookingPresenter> _presenter;

        public AddBookingCommand(IApplicationController applicationController, Lazy<IBookingPresenter> presenter)
            : base(applicationController)
        {
            _presenter = presenter;
        }

        public void Execute(AddBookingCommandData commandData)
        {
            _presenter.Value.Run();
        }
    }
}
