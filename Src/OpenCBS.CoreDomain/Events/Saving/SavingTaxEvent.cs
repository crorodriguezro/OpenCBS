using System;
using OpenCBS.Enums;

namespace OpenCBS.CoreDomain.Events.Saving
{
    [Serializable]
    public class SavingTaxEvent : SavingEvent
    {
        public override string Code
        {
            get { return OSavingEvents.Tax; }
        }

        public override string Description { get; set; }
    }
}