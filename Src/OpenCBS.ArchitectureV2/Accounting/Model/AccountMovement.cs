using System;

namespace OpenCBS.ArchitectureV2.Accounting.Model
{
    public class AccountMovement
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal StartBalance { get; set; }
        public string Debit { get; set; }
        public decimal DebitAmount { get; set; }
        public string Credit { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal EndBalance { get; set; }

        public decimal Amount
        {
            get { return DebitAmount + CreditAmount; }
        }
    }
}
