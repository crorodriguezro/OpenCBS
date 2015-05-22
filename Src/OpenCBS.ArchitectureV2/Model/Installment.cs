using System;

namespace OpenCBS.ArchitectureV2.Model
{
    public class Installment
    {
        public int ContractId { get; set; }
        public int Number { get; set; }
        public decimal Principal { get; set; }
        public decimal PaidPrincipal { get; set; }
        public decimal Interest { get; set; }
        public decimal PaidInterest { get; set; }
        public DateTime ExpectedDate { get; set; }
    }
}
