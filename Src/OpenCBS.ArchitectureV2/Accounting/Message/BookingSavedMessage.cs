using OpenCBS.ArchitectureV2.Accounting.Model;
using TinyMessenger;

namespace OpenCBS.ArchitectureV2.Accounting.Message
{
    public class BookingSavedMessage : ITinyMessage
    {
        public BookingSavedMessage(object sender, Booking booking)
        {
            Sender = sender;
            Booking = booking;
        }

        public object Sender { get; private set; }

        public Booking Booking { get; private set; }
    }
}
