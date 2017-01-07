using System;

namespace OpenCBS.Extension.Accounting.CommandData
{
    public class ShowAccountMovementsCommandData
    {
        public string Account { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
