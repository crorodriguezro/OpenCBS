using System;
using System.Collections.Generic;
using System.Data;
using OpenCBS.ArchitectureV2.Accounting.Interface.Repository;
using OpenCBS.ArchitectureV2.Accounting.Model;
using OpenCBS.ArchitectureV2.Accounting.Repository;
using OpenCBS.CoreDomain.Events.Saving;

namespace OpenCBS.ArchitectureV2.Accounting.Service
{
    public class BookingService : IBookingService
    {
        private IBookingRepository _repository;

        public BookingService(IBookingRepository repository)
        {
            _repository = repository;
        }

        public void SaveBookings(IEnumerable<Booking> entity, IDbTransaction tx = null)
        {
            if (entity == null) return;
            _repository.Save(entity, tx);
        }

        public void SaveBooking(Booking booking, IDbTransaction tx = null)
        {
            booking.Id = _repository.Save(booking, tx);
        }

        public void UpdateBookings(IEnumerable<Booking> entity, IDbTransaction tx = null)
        {
            if (entity == null) return;
            _repository.Update(entity, tx);
        }

        public void DeleteBooking(int bookingId, IDbTransaction tx = null)
        {
            _repository.Delete(bookingId, tx);
        }

        public decimal GetAccountBalance(DateTime date, Account account)
        {
            return _repository.GetAccountBalance(date, account);
        }

        public void DeleteBookingsByEvent(IDictionary<string, object> entity, IDbTransaction tx = null)
        {
            var eEvent = entity.ContainsKey("Event") ? (CoreDomain.Events.Loan.Event) entity["Event"] : null;
            if (eEvent == null) return;
            if (eEvent is SavingEvent)
            {
                _repository.DeleteBySavingEvent(eEvent.Id, tx);
                return;
            }
            var loanEventId = eEvent.ParentId ?? eEvent.Id;
            _repository.DeleteByLoanEvent(loanEventId, tx);
        }

        public Booking Get(int bookingId)
        {
            return _repository.Get(bookingId);
        }

        public IEnumerable<BookingDto> SelectBookings(DateTime from, DateTime to, Account debit, Account credit)
        {
            return from > to ? new List<BookingDto>() : _repository.SelectBookings(from, to, debit, credit);
        }

        public IEnumerable<Account> SelectAllAccounts()
        {
            return _repository.SelectAllAccounts();
        }

        public IBookingRepository Repository
        {
            set { _repository = value; }
        }

        public void CloseAccount(DateTime date, Account account, IDbTransaction tx = null)
        {
            _repository.CloseAccount(date, account, tx);
        }

        public void RecoverAccount(Account account, IDbTransaction tx = null)
        {
            _repository.RecoverAccount(account, tx);
        }
    }
}
