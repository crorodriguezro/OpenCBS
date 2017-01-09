using System;
using OpenCBS.ArchitectureV2.Accounting.Repository;
using OpenCBS.CoreDomain;

namespace OpenCBS.ArchitectureV2.Accounting.Model
{
    public class Booking : BookingBase, ICloneable
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int LoanEventId { get; set; }
        public int SavingEventId { get; set; }
        public int LoanId { get; set; }
        public int ClientId { get; set; }
        public string ClientLastName { get; set; }
        public string ClientFirstName { get; set; }
        public User User { get; set; }
        public Branch Branch { get; set; }
        public bool IsExported { get; set; }
        public bool IsDeleted { get; set; }
        public int AdvanceId { get; set; }
        public int StaffId { get; set; }
        public bool IsManualEditable { get; set; }
        public object Clone()
        {
            return MemberwiseClone();
        }

        public BookingDto Map()
        {
            return new BookingDto
            {
                Id = Id,
                DebitAccount = Debit.AccountNumber,
                CreditAccount = Credit.AccountNumber,
                Amount = Amount,
                Date = Date,
                LoanId = LoanId,
                LoanEventId = LoanEventId,
                SavingEventId = SavingEventId,
                ClientId = ClientId,
                ClientLastName = ClientLastName,
                ClientFirstName = ClientFirstName,
                UserId = User.Id,
                BranchId = Branch.Id,
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
