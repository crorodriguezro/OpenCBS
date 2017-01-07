using System;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.Extension.Accounting.CommandData;
using OpenCBS.Extension.Accounting.Interface.Presenter;

namespace OpenCBS.Extension.Accounting.Command
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
