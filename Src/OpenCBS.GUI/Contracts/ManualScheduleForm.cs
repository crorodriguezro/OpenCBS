// // Copyright © 2013 Open Octopus Ltd.
// //
// // This program is free software; you can redistribute it and/or modify
// // it under the terms of the GNU Lesser General Public License as published by
// // the Free Software Foundation; either version 2 of the License, or
// // (at your option) any later version.
// //
// // This program is distributed in the hope that it will be useful,
// // but WITHOUT ANY WARRANTY; without even the implied warranty of
// // MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// // GNU Lesser General Public License for more details.
// //
// // You should have received a copy of the GNU Lesser General Public License along
// // with this program; if not, write to the Free Software Foundation, Inc.,
// // 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
// //
// // Website: http://www.opencbs.com
// // Contact: contact@opencbs.com
// 
using System;
using System.Drawing;
using System.Windows.Forms;
using BrightIdeasSoftware;
using OpenCBS.CoreDomain.Contracts.Loans;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;
using OpenCBS.Enums;
using OpenCBS.Shared;

namespace OpenCBS.GUI.Contracts
{
    public partial class ManualScheduleForm : Form
    {
        private string _amountFormatString;
        private Installment _total;

        public Loan Loan { get; set; }

        public ManualScheduleForm()
        {
            InitializeComponent();
        }

        public ManualScheduleForm(Loan loan)
        {
            InitializeComponent();
            olvSchedule.RowFormatter = FormatRow;
            Loan = loan;
            InitializeSchedule();
        }

        private void InitializeSchedule()
        {
            _amountFormatString = Loan.UseCents ? "N2" : "N0";
            Setup();
            olvSchedule.SetObjects(Loan.InstallmentList);
            InitTotal();
            olvSchedule.AddObject(_total);
        }

        private void InitTotal()
        {
            decimal totalInterest = 0, totalPrincipal = 0, totalPaidInterests = 0, totalPaidCapital = 0;
            foreach (var installment in Loan.InstallmentList)
            {
                totalInterest += installment.InterestsRepayment.Value;
                totalPrincipal += installment.CapitalRepayment.Value;
                totalPaidCapital += installment.PaidCapital.Value;
                totalPaidInterests += installment.PaidInterests.Value;
            }
            var empty = new OCurrency();
            var date = new DateTime();
            _total = new Installment(
                date,
                totalInterest,
                totalPrincipal,
                totalPaidCapital,
                totalPaidInterests,
                empty,
                null,
                -1);
        }

        private void Setup()
        {
            dateColumn.AspectToStringConverter =
            paymentDateColumn.AspectToStringConverter = value =>
            {
                var date = (DateTime?)value;
                return (date.HasValue && date != new DateTime())
                            ? date.Value.ToString("dd.MM.yyyy")
                            : string.Empty;
            };
            principalColumn.AspectToStringConverter =
            interestColumn.AspectToStringConverter =
            paidPrincipalColumn.AspectToStringConverter =
            paidInterestColumn.AspectToStringConverter =
            totalColumn.AspectToStringConverter =
            olbColumn.AspectToStringConverter = value =>
            {
                var amount = (OCurrency)value;
                return amount.HasValue
                            ? amount.Value.ToString(_amountFormatString)
                            : string.Empty;
            };
            numberColumn.AspectToStringConverter = value =>
            {
                var i = (int)value;
                return i == -1 ? "Total" : value.ToString();
            };
            olvSchedule.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClick;
            olvSchedule.CellEditEnterChangesRows = true;
            olvSchedule.CellEditTabChangesRows = true;
        }

        private static void FormatRow(OLVListItem item)
        {
            var installment = (Installment)item.RowObject;
            if (installment == null) return;
            if (installment.IsPending) item.BackColor = Color.Orange;
            if (installment.IsRepaid) item.BackColor = Color.FromArgb(61, 153, 57);
            if (installment.IsPending || installment.IsRepaid) item.ForeColor = Color.White;
            if (installment.Number == -1) item.Font = new Font(item.Font, FontStyle.Bold);
        }

        private bool IsValidValue(CellEditEventArgs e)
        {
            var index = e.ListViewItem.Index;
            if (e.Column == dateColumn)
            {
                var newDate = Convert.ToDateTime(e.NewValue);
                if (index > 0 && newDate < Loan.InstallmentList[index - 1].ExpectedDate)
                    return false;
                if (index < Loan.InstallmentList.Count - 1 &&
                    newDate > Loan.InstallmentList[index + 1].ExpectedDate)
                    return false;
            }
            else if (e.Column == interestColumn)
            {
                decimal newInterest;
                return decimal.TryParse(e.NewValue.ToString(), out newInterest) &&
                       newInterest >= Loan.InstallmentList[index].PaidInterests.Value;
            }
            else if (e.Column == principalColumn)
            {
                decimal newPrincipal;
                return decimal.TryParse(e.NewValue.ToString(), out newPrincipal) &&
                       newPrincipal >= Loan.InstallmentList[index].PaidCapital.Value;
            }
            return true;
        }

        private void HandleCellEditStarting(object sender, CellEditEventArgs e)
        {
            var installment = (Installment)e.RowObject;
            if (installment.Number == -1 || installment.IsRepaid) e.Cancel = true;
        }

        private void HandleCellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (!IsValidValue(e))
            {
                e.Cancel = true;
                return;
            }
            if (e.Column == dateColumn)
            {
                var installment = (Installment)e.RowObject;
                DateTime date;
                if (DateTime.TryParse(e.NewValue.ToString(), out date))
                    installment.ExpectedDate = date;
                ScheduleRecalculation(e.ListViewItem.Index);
            }
            if (e.Column == interestColumn)
            {
                var installment = (Installment)e.RowObject;
                decimal amount;
                if (decimal.TryParse(e.NewValue.ToString(), out amount))
                {
                    _total.InterestsRepayment += amount - installment.InterestsRepayment;
                    installment.InterestsRepayment = amount;
                }
            }
            if (e.Column == principalColumn)
            {
                var installment = (Installment)e.RowObject;
                decimal amount;
                if (decimal.TryParse(e.NewValue.ToString(), out amount))
                {
                    _total.CapitalRepayment += amount - installment.CapitalRepayment;
                    Loan.InstallmentList[e.ListViewItem.Index].CapitalRepayment = amount;
                }
                ScheduleRecalculation(e.ListViewItem.Index);
            }
            olvSchedule.RefreshObjects(Loan.InstallmentList);
            olvSchedule.RefreshObject(_total);

            btnOK.Enabled = _total.CapitalRepayment == Loan.Amount;
            var foreColor = _total.CapitalRepayment != Loan.Amount ? Color.Red : Color.Black;
            for (var i = 0; i <= Loan.InstallmentList.Count - 1; i++)
                if (!Loan.InstallmentList[i].IsRepaid)
                {
                    olvSchedule.Items[i].UseItemStyleForSubItems = false;
                    olvSchedule.Items[i].SubItems[principalColumn.Index].ForeColor = foreColor;
                    olvSchedule.RefreshObject(olvSchedule.GetItem(i));
                }
        }

        private void ScheduleRecalculation(int indexOfChangedItem)
        {
            for (var i = 1; i < Loan.InstallmentList.Count; i++)
                Loan.InstallmentList[i].OLB = Loan.InstallmentList[i - 1].OLB -
                                               Loan.InstallmentList[i - 1].CapitalRepayment;
            if (Loan.Product.LoanType == OLoanTypes.Flat) return;
            if (Loan.Product.LoanType == OLoanTypes.DecliningFixedPrincipalWithRealInterest)
            {
                int daysInTheYear = 0;
                for (int i = 1; i <= 12; i++)
                    daysInTheYear += DateTime.DaysInMonth(Loan.AlignDisbursementDate.Date.Year, i);

                int days;
                if (indexOfChangedItem == 0)
                    days = (Loan.InstallmentList[0].ExpectedDate - Loan.AlignDisbursementDate).Days;
                else
                    days =
                        (Loan.InstallmentList[indexOfChangedItem].ExpectedDate -
                         Loan.InstallmentList[indexOfChangedItem - 1].ExpectedDate).Days;

                Loan.InstallmentList[indexOfChangedItem].InterestsRepayment =
                    Loan.InstallmentList[indexOfChangedItem].OLB*Loan.InterestRate/
                    daysInTheYear*days;
                for (int i = indexOfChangedItem + 1; i < Loan.NbOfInstallments - 1; i++)
                {
                    days = (Loan.InstallmentList[i].ExpectedDate - Loan.InstallmentList[i - 1].ExpectedDate).Days;
                    Loan.InstallmentList[i].InterestsRepayment = Loan.InstallmentList[i].OLB*Loan.InterestRate/
                                                                 daysInTheYear*days;
                }
            }
            else
                for (var i = indexOfChangedItem; i < Loan.InstallmentList.Count; i++)
                    Loan.InstallmentList[i].InterestsRepayment = Loan.InstallmentList[i].OLB*Loan.InterestRate;
        }
    }
}
