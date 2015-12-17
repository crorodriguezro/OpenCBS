using System;
using OpenCBS.Shared;

namespace OpenCBS.CoreDomain.Events.Loan
{
    [Serializable]
    public class OutOfBalancePenaltyAccrualEvent : Event
    {
        public override string Code
        {
            get { return "APOE"; }
            set { _code = value; }
        }
        public OCurrency Penalty { get; set; }
        public DateTime InstallmentExpectedDate { get; set; }
    }
}
