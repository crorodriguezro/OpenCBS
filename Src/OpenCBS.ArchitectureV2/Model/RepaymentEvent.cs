using System;

namespace OpenCBS.ArchitectureV2.Model
{
    public class RepaymentEvent
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int LoanId { get; set; }
        public int UserId { get; set; }
        public DateTime EventDate { get; set; }
        public int InstallmentNumber { get; set; }
        public int LateDays { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public string Comment { get; set; }
        public string ReceiptNumber { get; set; }
    }
}
