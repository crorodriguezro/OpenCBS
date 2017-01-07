using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.CoreDomain;
using OpenCBS.Extension.Accounting.CommandData;
using OpenCBS.Extension.Accounting.Interface.Presenter;
using OpenCBS.Extension.Accounting.Interface.Repository;
using OpenCBS.Extension.Accounting.Interface.View;
using OpenCBS.Extension.Accounting.Message;
using OpenCBS.Extension.Accounting.Model;
using OpenCBS.Extension.Accounting.Service;
using OpenCBS.Services;

namespace OpenCBS.Extension.Accounting.Presenter
{
    public class BookingPresenter : IBookingPresenter, IBookingPresenterCallbacks
    {
        private readonly IBookingView _view;
        private readonly IBookingService _bookingService;
        private readonly IAccountRepository _accountRepository;
        private readonly IApplicationController _applicationController;

        public BookingPresenter(
            IBookingView view,
            IBookingService bookingService,
            IAccountRepository accountRepository,
            IApplicationController applicationController)
        {
            _view = view;
            _bookingService = bookingService;
            _accountRepository = accountRepository;
            _applicationController = applicationController;
            Initialize();
        }

        public void Initialize()
        {
            _view.SaveButtonEnabled = false;
        }

        public object View
        {
            get { return _view; }
        }

        public void Run(int? bookingId)
        {
            _view.Accounts = _accountRepository.SelectAllAccounts().Where(i => i.IsDirect).ToList();
            _view.Branches = User.CurrentUser.Branches.ToList();
            if (bookingId != null)
            {
                var booking = _bookingService.Get(bookingId.Value);
                _view.Booking = booking;
                _view.Amount = booking.Amount;
                _view.Debit = booking.Debit;
                _view.Credit = booking.Credit;
                _view.Description = booking.Description;
                _view.Date = booking.Date;
                _view.Branch = booking.Branch;
            }
            _view.Attach(this);
            _view.Run();
        }

        public void Save()
        {
            var debitAmount = _bookingService.GetAccountBalance(_view.Date, _view.Debit);
            var creditAmount = _bookingService.GetAccountBalance(_view.Date, _view.Credit);
            if (!_view.Debit.IsDebit)
            {
                if (!_view.Debit.CanBeNegative)
                    if (debitAmount < Convert.ToDecimal(_view.Amount))
                    {
                        _view.Warning(_view.Debit, debitAmount);
                        return;
                    }
            }
            if (_view.Credit.IsDebit)
            {
                if (!_view.Credit.CanBeNegative)
                    if (creditAmount < Convert.ToDecimal(_view.Amount))
                    {
                        _view.Warning(_view.Credit, creditAmount);
                        return;
                    }
            }

            if (_view.Booking == null) _view.Booking = new Booking();
            _view.Booking.Amount = _view.Amount;
            _view.Booking.Debit = _view.Debit;
            _view.Booking.Credit = _view.Credit;
            _view.Booking.Description = _view.Description;
            _view.Booking.Date = _view.Date;
            _view.Booking.Branch = _view.Branch;
            _view.Booking.User = User.CurrentUser;
            _view.Booking.ClientFirstName = "-";
            _view.Booking.ClientLastName = "-";
            _view.Booking.IsManualEditable = true;
            _view.Stop();
            _applicationController.Publish(new AddBookingMessage(this, _view.Booking));
        }
    }
}
