using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Accounting.Interface.Presenter;
using OpenCBS.ArchitectureV2.Accounting.Model;
using OpenCBS.ArchitectureV2.Accounting.Repository;
using OpenCBS.ArchitectureV2.Interface.View;
using OpenCBS.Extension.ExcelReports;

namespace OpenCBS.ArchitectureV2.Accounting.Interface.View
{
    public interface IBookingsView : IView<IBookingsPresenterCallbacks>
    {
        void SetBookings(IEnumerable<BookingDto> bookings);
        List<Report> Reports { set; }
        List<Account> Accounts { get; set; }
        BookingDto SelectedBooking { get; }
        void AddButtonEnabled();
        void AddButtonDisabled();
        void EditButtonEnabled();
        void EditButtonDisabled();
        void DeleteButtonEnabled();
        void DeleteButtonDisabled();
        void PrintButtonEnabled();
        void PrintButtonDisabled();
        DateTime DateFrom { get; set; }
        DateTime DateTo { get; set; }
        Account DebitAccount { get; set; }
        Account CreditAccount { get; set; }
        Control Control { get; }
        DialogResult ShowMessage(string message);
        void Show();
        void Refresh();
        void Close();
    }
}
