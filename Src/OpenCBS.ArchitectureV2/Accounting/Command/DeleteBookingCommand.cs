using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.Extension.Accounting.CommandData;
using OpenCBS.Extension.Accounting.Message;
using OpenCBS.Extension.Accounting.Service;

namespace OpenCBS.Extension.Accounting.Command
{
    public class DeleteBookingCommand : ArchitectureV2.Command.Command, ICommand<DeleteBookingCommandData>
    {
        private readonly ITranslationService _translationService;
        private readonly IBookingService _bookingService;
        private readonly IApplicationController _applicationController;

        public DeleteBookingCommand(
            ITranslationService translationService, 
            IBookingService bookingService, 
            IApplicationController applicationController)
            : base(applicationController)
        {
            _translationService = translationService;
            _bookingService = bookingService;
            _applicationController = applicationController;
        }

        public void Execute(DeleteBookingCommandData commandData)
        {
            var message = _translationService.Translate("Are you sure you want to permanently delete this booking?");
            var title = _translationService.Translate("Delete Booking");
            var result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;
            _bookingService.DeleteBooking(commandData.Id);
            _applicationController.Publish(new BookingSavedMessage(this, null));
        }
    }
}
