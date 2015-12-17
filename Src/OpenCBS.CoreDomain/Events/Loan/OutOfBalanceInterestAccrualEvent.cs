using System;
using OpenCBS.Shared;

namespace OpenCBS.CoreDomain.Events.Loan
{
    [Serializable]
    public class OutOfBalanceInterestAccrualEvent : Event
    {
        public override string Code
        {
            get { return "AIOE"; }
            set { _code = value; }
        }
        public OCurrency Interest { get; set; }
        public DateTime InstallmentExpectedDate { get; set; }
    }
}
