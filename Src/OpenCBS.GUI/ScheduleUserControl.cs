using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using BrightIdeasSoftware;
using OpenCBS.CoreDomain.Contracts.Loans;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;
using OpenCBS.Shared;

namespace OpenCBS.GUI
{
    public partial class ScheduleUserControl : System.Windows.Forms.UserControl
    {
        private string _amountFormatString;
        public Installment total;
        public ScheduleUserControl()
        {
            InitializeComponent();
            Load += (sender, args) => Setup();
            scheduleObjectListView.RowFormatter = FormatRow;
            scheduleObjectListView.CellEditStarting += new CellEditEventHandler(this.HandleCellEditStarting);
            scheduleObjectListView.CellEditFinishing+=new CellEditEventHandler(this.HandleCellEditFinishing);
        }

        public void SetScheduleFor(Loan loan)
        {
            _amountFormatString = loan.UseCents ? "N2" : "N0";
            Setup();
            scheduleObjectListView.SetObjects(loan.InstallmentList);
            InitTotal();
            scheduleObjectListView.AddObject(total);
        }

        private void InitTotal()
        {
            decimal totalInterest = 0, totalPrincipal = 0, totalPaidInterests = 0, totalPaidCapital = 0;
            for (int i = 0; i < scheduleObjectListView.Items.Count; i++)
            {
                var installment = (Installment)scheduleObjectListView.GetItem(i).RowObject;
                totalInterest += installment.InterestsRepayment.Value;
                totalPrincipal += installment.CapitalRepayment.Value;
                totalPaidCapital += installment.PaidCapital.Value;
                totalPaidInterests += installment.PaidInterests.Value;
            }
            OCurrency hasntValue = new OCurrency();
            DateTime date = new DateTime();
            total = new Installment(date, totalInterest, totalPrincipal, totalPaidCapital, totalPaidInterests, hasntValue,
                                    null, -1);
        }
        private void Setup()
        {
            dateColumn.AspectToStringConverter =
                paymentDateColumn.AspectToStringConverter = value =>
                    {
                        var date = (DateTime?) value;
                        return (date.HasValue && date != new DateTime())
                                   ? date.Value.ToString("dd.MM.yyyy")
                                   : string.Empty;
                    };
            var numberFormatInfo = new NumberFormatInfo
                {
                    NumberGroupSeparator = " ",
                    NumberDecimalSeparator = ",",
                };
            principalColumn.AspectToStringConverter =
                interestColumn.AspectToStringConverter =
                paidPrincipalColumn.AspectToStringConverter =
                paidInterestColumn.AspectToStringConverter =
                totalColumn.AspectToStringConverter =
                olbColumn.AspectToStringConverter = value =>
                    {
                        var amount = (OCurrency) value;
                        return amount.HasValue
                                   ? amount.Value.ToString(_amountFormatString, numberFormatInfo)
                                   : string.Empty;
                    };
            numberColumn.AspectToStringConverter = value =>
                {
                    int i = (int) value;
                    if (i == -1)
                        return "Total";
                    return value.ToString();
                };
            scheduleObjectListView.CellEditActivation = ObjectListView.CellEditActivateMode.DoubleClick;
        }

        private static void FormatRow(OLVListItem item)
        {
            var installment = (Installment)item.RowObject;
            if (installment == null) return;
            if (installment.IsPending) item.BackColor = Color.Orange;
            if (installment.IsRepaid) item.BackColor = Color.FromArgb(61, 153, 57);
            if (installment.IsPending || installment.IsRepaid) item.ForeColor = Color.White;
            if (installment.Number == -1) item.Font = new Font(item.Font,FontStyle.Bold);
        }

        private bool CheckValue(CellEditEventArgs e)
        {
            if (e.Column == dateColumn)
            {
                DateTime newDate = Convert.ToDateTime(e.NewValue);
                int index = e.ListViewItem.Index;
                if (index > 0)
                {
                    DateTime previousInstallmentDate;
                    var installment = (Installment)scheduleObjectListView.GetItem(index - 1).RowObject;
                    DateTime.TryParse(installment.ExpectedDate.ToString(),
                        out previousInstallmentDate);
                    if (newDate < previousInstallmentDate)
                        return false;
                }
                if (index < scheduleObjectListView.Items.Count - 1)
                {
                    DateTime nextInstallmentDate;
                    var installment = (Installment)scheduleObjectListView.GetItem(index + 1).RowObject;
                    DateTime.TryParse(installment.ExpectedDate.ToString(),
                        out nextInstallmentDate);
                    if (newDate > nextInstallmentDate)
                        return false;
                }
            }
            return true;
        }

        private void HandleCellEditStarting(object sender, CellEditEventArgs e)
        {
            var installment = (Installment) e.RowObject;
            if (!installment.PaidInterests.HasValue)
            {
                e.Cancel = true;
                return;
            }
            if (installment.IsRepaid)
                e.Cancel = true;
        }

        private void HandleCellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (!CheckValue(e))
                e.Cancel = true;
            if (e.Column == interestColumn)
            {
                var installment = (Installment)e.RowObject;
                decimal amount;
                if (decimal.TryParse(e.NewValue.ToString(), out amount))
                {
                    total.InterestsRepayment += amount - installment.InterestsRepayment;
                    installment.InterestsRepayment = amount;
                }
            }
            if (e.Column == principalColumn)
            {
                var installment = (Installment)e.RowObject;
                decimal amount;
                if (decimal.TryParse(e.NewValue.ToString(), out amount))
                {
                    total.CapitalRepayment += amount - installment.CapitalRepayment;
                    installment.CapitalRepayment = amount;
                }
            }
            scheduleObjectListView.RefreshObject(e.RowObject);
            scheduleObjectListView.RefreshObject(
                scheduleObjectListView.GetItem(scheduleObjectListView.Items.Count - 1).RowObject);

        }
    }
}
