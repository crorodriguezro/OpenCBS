using System;
using OpenCBS.ArchitectureV2.Accounting.CommandData;
using OpenCBS.ArchitectureV2.Accounting.Interface.Presenter;
using OpenCBS.ArchitectureV2.Interface;

namespace OpenCBS.ArchitectureV2.Accounting.Command
{
    public class ShowBookingsCommand : ArchitectureV2.Command.Command, ICommand<ShowBookingsCommandData>
    {
        private readonly Lazy<IBookingsPresenter> _presenter;

        public ShowBookingsCommand(IApplicationController applicationController, Lazy<IBookingsPresenter> presenter)
            : base(applicationController)
        {
            _presenter = presenter;
        }

        public void Execute(ShowBookingsCommandData commandData)
        {
            if (ActivateViewIfExists("BookingsView"))
            {
                return;
            }
            _presenter.Value.Run();
        }
    }
}
