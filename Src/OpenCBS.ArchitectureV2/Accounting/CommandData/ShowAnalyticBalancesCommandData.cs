using System;

namespace OpenCBS.ArchitectureV2.Accounting.CommandData
{
    public class ShowAnalyticBalancesCommandData
    {
        public string Account { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int BranchId { get; set; }
        public bool BalancesOnly { get; set; }
    }
}
