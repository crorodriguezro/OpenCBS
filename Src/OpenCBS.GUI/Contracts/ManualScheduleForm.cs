using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
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
        private Loan _loan;
        private string _amountFormatString;
        private Installment _total;
        
        public Loan Loan
        {
            get { return _loan; }
            set { _loan = value; }
        }        
        
        public ManualScheduleForm()
        {
            InitializeComponent();
        }

        public ManualScheduleForm(Loan pLoan)
        {
            InitializeComponent();
            olvSchedule.RowFormatter = FormatRow;
            _loan = pLoan;
            InitializeSchedule();
        }

        private void InitializeSchedule()
        {
            _amountFormatString = _loan.UseCents ? "N2" : "N0";
            Setup();
            olvSchedule.SetObjects(_loan.InstallmentList);
            InitTotal();
            olvSchedule.AddObject(_total);
        }

        private void InitTotal()
        {
            decimal totalInterest = 0, totalPrincipal = 0, totalPaidInterests = 0, totalPaidCapital = 0;
            foreach (Installment installment in _loan.InstallmentList)
            {
                totalInterest += installment.InterestsRepayment.Value;
                totalPrincipal += installment.CapitalRepayment.Value;
                totalPaidCapital += installment.PaidCapital.Value;
                totalPaidInterests += installment.PaidInterests.Value;
            }
            //for (int i = 0; i < scheduleObjectListView.Items.Count; i++)
            //{
            //    var installment = (Installment)scheduleObjectListView.GetItem(i).RowObject;
            //    totalInterest += installment.InterestsRepayment.Value;
            //    totalPrincipal += installment.CapitalRepayment.Value;
            //    totalPaidCapital += installment.PaidCapital.Value;
            //    totalPaidInterests += installment.PaidInterests.Value;
            //}
            OCurrency hasntValue = new OCurrency();
            DateTime date = new DateTime();
            _total = new Installment(date, totalInterest, totalPrincipal, totalPaidCapital, totalPaidInterests, hasntValue,
                                    null, -1);
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
                    var amount = (OCurrency)value;
                    return amount.HasValue
                               ? amount.Value.ToString(_amountFormatString, numberFormatInfo)
                               : string.Empty;
                };
            numberColumn.AspectToStringConverter = value =>
            {
                int i = (int)value;
                if (i == -1)
                    return "Total";
                return value.ToString();
            };
            olvSchedule.CellEditActivation = ObjectListView.CellEditActivateMode.DoubleClick;
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
            int index = e.ListViewItem.Index;
            if (e.Column == dateColumn)
            {
                DateTime newDate = Convert.ToDateTime(e.NewValue);
                if (index > 0 && newDate < _loan.InstallmentList[index - 1].ExpectedDate)
                    return false;
                if (index < olvSchedule.Items.Count - 1 && newDate > _loan.InstallmentList[index + 1].ExpectedDate)
                    return false;
            }
            else if (e.Column == interestColumn)
            {
                decimal newInterest;
                if (decimal.TryParse(e.NewValue.ToString(), out newInterest) &&
                    newInterest > _loan.InstallmentList[index].PaidInterests.Value)
                    return true;
                return false;
            }
            else if (e.Column == principalColumn)
            {
                decimal newPrincipal;
                if (decimal.TryParse(e.NewValue.ToString(), out newPrincipal) &&
                    newPrincipal > _loan.InstallmentList[index].PaidCapital.Value)
                    return true;
                return false;
            }
            return true;
        }

        private void HandleCellEditStarting(object sender, CellEditEventArgs e)
        {
            var installment = (Installment)e.RowObject;
            if (installment.Number == -1)
                e.Cancel = true;
            if (installment.IsRepaid)
                e.Cancel = true;
        }

        private void HandleCellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (!IsValidValue(e))
                e.Cancel = true;
            else
            {
                if (e.Column == interestColumn)
                {
                    var installment = (Installment) e.RowObject;
                    decimal amount;
                    if (decimal.TryParse(e.NewValue.ToString(), out amount))
                    {
                        _total.InterestsRepayment += amount - installment.InterestsRepayment;
                        installment.InterestsRepayment = amount;
                    }
                }
                if (e.Column == principalColumn)
                {
                    var installment = (Installment) e.RowObject;
                    decimal amount;
                    if (decimal.TryParse(e.NewValue.ToString(), out amount))
                    {
                        _total.CapitalRepayment += amount - installment.CapitalRepayment;
                        _loan.InstallmentList[e.ListViewItem.Index].CapitalRepayment = amount;
                    }
                    ScheduleRecalculation();
                }
                olvSchedule.RefreshObjects(_loan.InstallmentList);
                olvSchedule.RefreshObject(_total);

                btnOK.Enabled = _total.CapitalRepayment != _loan.Amount ? false : true;
                Color fg = _total.CapitalRepayment != _loan.Amount ? Color.Red : Color.Black;
                for (int i = 0; i <= _loan.InstallmentList.Count - 1; i++)
                    if (!_loan.InstallmentList[i].IsRepaid)
                    {
                        olvSchedule.Items[i].UseItemStyleForSubItems = false;
                        olvSchedule.Items[i].SubItems[principalColumn.Index].ForeColor = fg;
                        olvSchedule.RefreshObject(olvSchedule.GetItem(i));
                    }
            }
        }

        private void ScheduleRecalculation()
        {
            for (int i = 1; i < _loan.InstallmentList.Count; i++)
                _loan.InstallmentList[i].OLB = _loan.InstallmentList[i - 1].OLB -
                                               _loan.InstallmentList[i - 1].CapitalRepayment;
            if (_loan.Product.LoanType == OLoanTypes.Flat) return;
            for (int i = 1; i < _loan.InstallmentList.Count; i++)
                _loan.InstallmentList[i].InterestsRepayment = _loan.InstallmentList[i].OLB*_loan.InterestRate;
        }
    }
}
