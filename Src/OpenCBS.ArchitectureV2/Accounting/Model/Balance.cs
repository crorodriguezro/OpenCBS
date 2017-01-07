namespace OpenCBS.Extension.Accounting.Model
{
    public class Balance
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Parent { get; set; }
        public decimal StartDebit { get; set; }
        public decimal StartCredit { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal EndDebit { get; set; }
        public decimal EndCredit { get; set; }

        public bool IsZero
        {
            get
            {
                return StartDebit == 0 && StartCredit == 0
                       && Debit == 0 && Credit == 0
                       && EndDebit == 0 && EndCredit == 0;
            }
        }
        public decimal Saldo
        {
            get { return EndDebit + EndCredit; }
        }
    }
}
