﻿using System;
using Octopus.Enums;
using Octopus.Shared;

namespace Octopus.CoreDomain.Events.Saving
{
    [Serializable]
    public class SavingCreditTransferEvent : SavingTransferEvent
    {
        public override string Code
        {
            get { return OSavingEvents.CreditTransfer; }
        }

        public override OCurrency GetAmountForBalance()
        {
            return Amount;
        }

        public override string ExtraInfo
        {
            get
            {
                return string.Format("from {0}", RelatedContractCode);
            }
        }
    }
}