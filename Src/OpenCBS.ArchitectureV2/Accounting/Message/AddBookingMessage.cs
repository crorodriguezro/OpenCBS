using OpenCBS.Extension.Accounting.Model;
using TinyMessenger;

namespace OpenCBS.Extension.Accounting.Message
{
    public class AddBookingMessage : ITinyMessage
    {
        public AddBookingMessage(object sender, Booking booking)
        {
            Sender = sender;
            Booking = booking;
        }

        public object Sender { get; private set; }

        public Booking Booking { get; private set; }
    }
}
