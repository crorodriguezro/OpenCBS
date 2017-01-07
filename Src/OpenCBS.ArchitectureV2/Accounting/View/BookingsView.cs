using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.ArchitectureV2.View;
using OpenCBS.Extension.Accounting.Interface.Presenter;
using OpenCBS.Extension.Accounting.Interface.View;
using OpenCBS.Extension.Accounting.Model;
using OpenCBS.Extension.Accounting.Repository;
using OpenCBS.Extension.ExcelReports;
using StructureMap;

namespace OpenCBS.Extension.Accounting.View
{
    public partial class BookingsView : BaseView, IBookingsView
    {
        [DefaultConstructor]
        public BookingsView(ITranslationService translationService)
            : base(translationService)
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            _debitComboBox.Format += Format;
            _creditComboBox.Format += Format;

            _dateColumn.AspectToStringConverter = value =>
            {
                var date = (DateTime?) value;
                return (date.HasValue)
                    ? date.Value.ToString("dd.MM.yyyy HH:mm")
                    : string.Empty;
            };
            _amountColumn.AspectToStringConverter = value =>
            {
                var amount = (decimal) value;
                return amount.ToString("N2");
            };
        }

        private static void Format(object sender, ListControlConvertEventArgs e)
        {
            var account = ((Account) e.ListItem);
            e.Value = account.AccountNumber + " " + account.Label;
        }

        public void Attach(IBookingsPresenterCallbacks callbacks)
        {
            _addButton.Click += (sender, e) => callbacks.Add();
            _editButton.Click += (sender, e) => callbacks.Edit();
            _bookingsListView.DoubleClick += (sender, e) => callbacks.Edit();
            _deleteButton.Click += (sender, e) => callbacks.OnDeleteBooking();
            _printButton.DropDownItemClicked += (sender, e) => callbacks.OnPrint(e.ClickedItem.Tag);
            _refreshButton.Click += (sender, e) => callbacks.Refresh();
            _bookingsListView.Click += (sender, e) => callbacks.OnCheck();
            _bookingsListView.ItemsChanged += (sender, e) => callbacks.OnCheck();
            _debitComboBox.SelectedValueChanged += (sender, e) => callbacks.OnFiltering();
            _creditComboBox.SelectedValueChanged += (sender, e) => callbacks.OnFiltering();
            _printControlButton.Click += (sender, e) => callbacks.OnControlPrint();
            FormClosing += (sender, e) => callbacks.DetachView();
            _dateFromDateTimePicker.ValueChanged += (sender, e) =>
            {
                if (_dateFromDateTimePicker.Value > _dateToDateTimePicker.Value)
                {
                    _dateToDateTimePicker.Value = _dateFromDateTimePicker.Value;
                }
            };
            _dateToDateTimePicker.ValueChanged += (sender, e) =>
            {
                if (_dateToDateTimePicker.Value < _dateFromDateTimePicker.Value)
                {
                    _dateFromDateTimePicker.Value = _dateToDateTimePicker.Value;
                }
            };
            _bookingsListView.RowFormatter = item =>
            {
                var booking = (BookingDto) item.RowObject;
                if (booking.LoanEventId == 0 && booking.SavingEventId == 0)
                {
                    item.BackColor = Color.FromArgb(255, 255, 128);
                }
            };
            _bookingsListView.RowFormatter = olvi =>
            {
                var booking = (BookingDto) olvi.RowObject;
                if (booking.IsDeleted)
                    olvi.ForeColor = Color.Silver;
            };
        }

        public Control Control
        {
            get { return _bookingsListView; }
        }

        public override void Refresh()
        {
            _bookingsListView.RefreshObjects((List<Booking>) _bookingsListView.Objects);
        }

        public void SetBookings(IEnumerable<BookingDto> bookings)
        {
            _bookingsListView.SetObjects(bookings);
        }

        public void AddButtonEnabled()
        {
            _addButton.Enabled = true;
        }

        public void AddButtonDisabled()
        {
            _addButton.Enabled = false;
        }

        public void EditButtonEnabled()
        {
            _editButton.Enabled = true;
        }

        public void EditButtonDisabled()
        {
            _editButton.Enabled = false;
        }

        public void DeleteButtonEnabled()
        {
            _deleteButton.Enabled = true;
        }

        public void DeleteButtonDisabled()
        {
            _deleteButton.Enabled = false;
        }

        public void PrintButtonEnabled()
        {
            _printButton.Enabled = true;
        }

        public void PrintButtonDisabled()
        {
            _printButton.Enabled = false;
        }

        public List<Report> Reports
        {
            set
            {
                foreach (var report in value)
                {
                    _printButton.DropDownItems.Add(new ToolStripMenuItem {Text = report.Title, Tag = report});
                }
            }
        }

        public List<Account> Accounts
        {
            get { return (List<Account>) _debitComboBox.DataSource; }
            set
            {
                _debitComboBox.DataSource = value;
                _creditComboBox.DataSource = new List<Account>(value);
            }
        }

        public BookingDto SelectedBooking
        {
            get { return (BookingDto) _bookingsListView.SelectedObject; }
        }


        public DateTime DateFrom
        {
            get { return _dateFromDateTimePicker.Value; }
            set { _dateFromDateTimePicker.Value = value; }
        }

        public DateTime DateTo
        {
            get { return _dateToDateTimePicker.Value; }
            set { _dateToDateTimePicker.Value = value; }
        }

        public Account DebitAccount
        {
            get { return (Account) _debitComboBox.SelectedItem; }
            set { _debitComboBox.SelectedItem = value; }
        }

        public Account CreditAccount
        {
            get { return (Account) _creditComboBox.SelectedItem; }
            set { _creditComboBox.SelectedItem = value; }
        }

        public DialogResult ShowMessage(string message)
        {
            return MessageBox.Show(message, @"Suggestion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
