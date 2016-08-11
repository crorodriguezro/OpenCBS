using System;
using OpenCBS.Enums;

namespace OpenCBS.CoreDomain.Events.Saving
{
    [Serializable]
    public class SavingTaxEvent : SavingNegativeEvent
    {
        public SavingTaxEvent()
        {
            _isDebit = true;
        }

        public override string Code
        {
            get { return OSavingEvents.Tax; }
        }

        public override string Description { get; set; }
    }
}