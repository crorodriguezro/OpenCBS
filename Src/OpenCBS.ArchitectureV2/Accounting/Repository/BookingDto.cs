using System;
using OpenCBS.ArchitectureV2.Accounting.Model;
using OpenCBS.CoreDomain;

namespace OpenCBS.ArchitectureV2.Accounting.Repository
{
    public class BookingDto
    {
        public int Id { get; set; }
        public string DebitAccount { get; set; }
        public string CreditAccount { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int LoanEventId { get; set; }
        public int SavingEventId { get; set; }
        public int LoanId { get; set; }
        public int ClientId { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int BranchId { get; set; }
        public string Description { get; set; }
        public bool IsExported { get; set; }
        public bool IsDeleted { get; set; }
        public int AdvanceId { get; set; }
        public int StaffId { get; set; }
        public bool IsManualEditable { get; set; }
        public string Doc1 { get; set; }
        public string Doc2 { get; set; }

        public Booking Map()
        {
            return new Booking
            {
                Id = Id,
                Debit = new Account { AccountNumber = DebitAccount},
                Credit = new Account { AccountNumber = CreditAccount},
                Amount = Amount,
                Date = Date,
                LoanId = LoanId,
                LoanEventId = LoanEventId,
                SavingEventId = SavingEventId,
                ClientId = ClientId,
                ClientFirstName = ClientFirstName,
                ClientLastName = ClientLastName,
                User = new User {Id = UserId},
                Branch = new Branch { Id = BranchId },
                Description = Description,
                IsDeleted = IsDeleted,
                IsExported = IsExported,
                AdvanceId = AdvanceId,
                StaffId = StaffId,
                IsManualEditable = IsManualEditable,
                Doc1 = Doc1,
                Doc2 = Doc2
            };
        }
    }
}
