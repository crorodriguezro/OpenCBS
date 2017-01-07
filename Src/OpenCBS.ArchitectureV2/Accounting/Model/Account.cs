using System;

namespace OpenCBS.Extension.Accounting.Model
{
    public enum AccountType : byte
    {
        Category = 1,
        Group = 2,
        Subgroup = 3,
        Balance = 4,
        Analytic = 5
    }

    public class Account : ICloneable
    {
        public string AccountNumber { get; set; }
        public string Label { get; set; }
        public bool IsDebit { get; set; }
        public AccountType Type { get; set; }
        public string Parent { get; set; }
        public int Lft { get; set; }
        public int Rgt { get; set; }
        public bool CanBeNegative { get; set; }
        public bool IsDirect { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CloseDate { get; set; }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
