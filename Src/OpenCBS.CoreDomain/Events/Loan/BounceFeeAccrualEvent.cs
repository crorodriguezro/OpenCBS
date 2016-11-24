using OpenCBS.Shared;

namespace OpenCBS.CoreDomain.Events.Loan
{
    public class BounceFeeAccrualEvent : Event
    {
        public override string Code
        {
            get { return "BFAE"; }
            set { base.Code = value; }
        }

        public OCurrency BounceFee { get; set; }
    }
}
