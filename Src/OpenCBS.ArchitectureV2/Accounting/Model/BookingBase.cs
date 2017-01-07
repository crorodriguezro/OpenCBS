namespace OpenCBS.Extension.Accounting.Model
{
    public abstract class BookingBase
    {
        public Account Debit { get; set; }
        public Account Credit { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Doc1 { get; set; }
        public string Doc2 { get; set; }
    }
}
