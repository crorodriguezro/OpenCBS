using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCBS.CoreDomain.Contracts
{
    [Serializable]
    public class ReassignContractItem
    {
        public char Type;

        public int LoanId;

        public string LoanCode;

        public string LoanStatus;

        public string ClientFirstName;

        public string ClientLastName;

        public decimal Amount;

        public decimal OLB;

        public decimal InterestRate;

        public DateTime CreationDate;

        public DateTime StartDate;

        public DateTime CloseDate;

        public string InstallmentTypes;

        public string DistrictName;

        public DateTime EffectDate;
    }
}
