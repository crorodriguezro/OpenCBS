using System;

namespace OpenCBS.ArchitectureV2.Accounting.CommandData
{
    public class ShowAccountMovementsCommandData
    {
        public string Account { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
