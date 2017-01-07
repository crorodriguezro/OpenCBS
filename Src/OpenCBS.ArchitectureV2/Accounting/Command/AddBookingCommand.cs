using System;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.Extension.Accounting.CommandData;
using OpenCBS.Extension.Accounting.Interface.Presenter;

namespace OpenCBS.Extension.Accounting.Command
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
