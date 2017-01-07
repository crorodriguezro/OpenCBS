using System;
using System.Collections.Generic;
using System.Data;
using OpenCBS.CoreDomain.Events.Loan;
using OpenCBS.CoreDomain.Events.Saving;
using OpenCBS.Extension.Accounting.Interface.Repository;
using OpenCBS.Extension.Accounting.Model;
using OpenCBS.Extension.Accounting.Repository;

namespace OpenCBS.Extension.Accounting.Service
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
            var eEvent = entity.ContainsKey("Event") ? (Event) entity["Event"] : null;
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
