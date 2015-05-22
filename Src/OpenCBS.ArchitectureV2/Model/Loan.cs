using System.Collections.Generic;

namespace OpenCBS.ArchitectureV2.Model
{
    public class Loan
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContractCode { get; set; }
        public List<Installment> Schedule { get; set; }
    }
}
