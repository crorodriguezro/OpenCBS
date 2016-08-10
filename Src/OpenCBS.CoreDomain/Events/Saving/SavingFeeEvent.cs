using System;
using OpenCBS.Enums;

namespace OpenCBS.CoreDomain.Events.Saving
{
    [Serializable]
    public class SavingFeeEvent : SavingEvent
    {
        public override string Code
        {
            get { return OSavingEvents.Fee; }
        }

        public override string Description { get; set; }
    }
}