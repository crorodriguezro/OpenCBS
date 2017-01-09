using System;
using System.Collections.Generic;
using System.Data;
using OpenCBS.ArchitectureV2.Accounting.Model;
using OpenCBS.ArchitectureV2.Accounting.Repository;

namespace OpenCBS.ArchitectureV2.Accounting.Interface.Repository
{
    public interface IBookingRepository
    {
        void Save(IEnumerable<Booking> entity, IDbTransaction tx = null);
        int Save(Booking entity, IDbTransaction tx = null);
        void Update(IEnumerable<Booking> entity, IDbTransaction tx = null);
        void Delete(int bookingId, IDbTransaction tx = null);
        void DeleteByLoanEvent(int loanEventId, IDbTransaction tx = null);
        void DeleteBySavingEvent(int savingEventId, IDbTransaction tx = null);
        Booking Get(int id);
        IEnumerable<BookingDto> SelectBookings(DateTime from, DateTime to, Account debit, Account credit);
        IEnumerable<Account> SelectAllAccounts();
        List<AccountMovement> GetAccountMovements(DateTime from, DateTime to, Account account = null);
        void CloseAccount(DateTime date, Account account, IDbTransaction tx = null);
        void RecoverAccount(Account accoun, IDbTransaction tx = null);
        int GetLoanId(int savingId);
        decimal GetAccountBalance(DateTime date, Account account);
    }
}
