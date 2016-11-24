using OpenCBS.Shared;

namespace OpenCBS.CoreDomain.Events.Loan
{
    public class BounceWriteOffEvent : Event
    {
        public override string Code
        {
            get { return "BWOE"; }
            set { base.Code = value; }
        }

        public OCurrency Amount { get; set; }
    }
}
