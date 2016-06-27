using TinyMessenger;

namespace OpenCBS.ArchitectureV2.Event
{
    public class DisbursementNotification : ITinyMessage
    {
        public DisbursementNotification(object sender, int loanId)
        {
            Sender = sender;
            LoanId = loanId;
        }
        public object Sender { get; private set; }
        public int LoanId { get; set; }
    }
}
