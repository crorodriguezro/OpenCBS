// Copyright © 2013 Open Octopus Ltd.
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
//
// Website: http://www.opencbs.com
// Contact: contact@opencbs.com

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;
using OpenCBS.CoreDomain.Contracts.Loans;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;
using OpenCBS.Shared;

namespace OpenCBS.Controls
{
    public partial class ScheduleControl : UserControl
    {
        private string _amountFormatString;
        private bool _useTotalRow;

        public ScheduleControl(bool useTotalRow=false)
        {
            _useTotalRow = useTotalRow;
            InitializeComponent();
            Setup();
            scheduleObjectListView.RowFormatter = FormatRow;
        }

        public void SetScheduleFor(Loan loan)
        {
            olbColumn.AspectName = ShowOlbAfterRepayment ? "OLBAfterRepayment" : "OLB";
            _amountFormatString = loan.UseCents ? "N2" : "N0";
            scheduleObjectListView.SetObjects(loan.InstallmentList);
            if (_useTotalRow && loan.InstallmentList != null && loan.InstallmentList.Count > 0)
                scheduleObjectListView.AddObject(CalculateTotalRow(loan.InstallmentList));
        }

        public object CalculateTotalRow(List<Installment> installmentList)
        {
            var capitalRepayment = installmentList.Sum(x => x.CapitalRepayment.Value);
            var totalRow = new
            {
                ExpectedDate  = string.Empty,
                Number = "Total",
                InterestsRepayment = installmentList.Sum(x => x.InterestsRepayment.Value),
                PaidInterests = installmentList.Sum(x => x.PaidInterests.Value),
                CapitalRepayment = capitalRepayment,
                PaidCapital = installmentList.Sum(x => x.PaidCapital.Value),
                ExtraAmount2 = installmentList.Sum(x => x.ExtraAmount2.HasValue ? x.ExtraAmount2.Value : 0),
                OLB = capitalRepayment,
                OLBAfterRepayment = capitalRepayment,
                AmountHasToPayWithInterest = installmentList.Sum(x => x.AmountHasToPayWithInterest.Value),

                Commission = string.Empty,
                PaidDate = string.Empty,
                LateDays = string.Empty,
                Comment = string.Empty,
                ExtraAmount1 = string.Empty
            };

            return totalRow;
        }

        public void SetScheduleFor(List<Installment> installmentList)
        {
            olbColumn.AspectName = ShowOlbAfterRepayment ? "OLBAfterRepayment" : "OLB";
            scheduleObjectListView.SetObjects(installmentList);
        }

        private void Setup()
        {
            dateColumn.AspectToStringConverter =
            paymentDateColumn.AspectToStringConverter = value =>
            {
                if (!_useTotalRow || (_useTotalRow && value is DateTime))
                {
                    var date = (DateTime?) value;
                    return date.HasValue ? date.Value.ToShortDateString() : string.Empty;
                }
                else
                {
                    return value != null ? value.ToString() : string.Empty;
                }
            };
            principalColumn.AspectToStringConverter =
            interestColumn.AspectToStringConverter =
            extraColumn.AspectToStringConverter =
            paidPrincipalColumn.AspectToStringConverter =
            paidInterestColumn.AspectToStringConverter =
            paidExtraColumn.AspectToStringConverter =
            olbColumn.AspectToStringConverter =
            extra_amount_1.AspectToStringConverter =
            extra_amount_2.AspectToStringConverter =
            totalColumn.AspectToStringConverter = value =>
            {
                if (!_useTotalRow || (_useTotalRow && value is OCurrency))
                {
                    var amount = (OCurrency) value;
                    return amount.Value.ToString(_amountFormatString);
                }
                else
                {
                    var amount = (decimal?)value;
                    return amount!=null? amount.Value.ToString(_amountFormatString) :string.Empty;
                }
            };
            _scheduleContextMenuStrip.Click += (sender, e) => _CopyData();
            extraColumn.IsVisible = false;
            paidExtraColumn.IsVisible = false;
            extra_amount_1.IsVisible = false;
            extra_amount_2.IsVisible = false;
            scheduleObjectListView.RebuildColumns();
        }

        private void FormatRow(OLVListItem item)
        {
            if (!_useTotalRow || (_useTotalRow && item.RowObject is Installment))
            {
                var installment = (Installment) item.RowObject;
                if (installment == null) return;
                if (installment.IsPending) item.BackColor = Color.Orange;
                if (installment.IsRepaid) item.BackColor = Color.FromArgb(61, 153, 57);
                if (installment.IsPending || installment.IsRepaid) item.ForeColor = Color.White;
                if (installment.LateDays > 0 && !(installment.IsPending || installment.IsRepaid))
                    item.ForeColor = Color.Red;
            }
            else
            {
                item.Font = new Font(item.Font, FontStyle.Bold);
            }
        }

        public void ShowExtraColumn()
        {
            extraColumn.IsVisible = true;
            paidExtraColumn.IsVisible = true;
            extra_amount_1.IsVisible = true;
            extra_amount_2.IsVisible = true;
            scheduleObjectListView.RebuildColumns();
        }

        private void _CopyData()
        {
            var buffer = new StringBuilder();
            for (var i = 0; i < scheduleObjectListView.Columns.Count; i++)
            {
                buffer.Append(scheduleObjectListView.Columns[i].Text);
                buffer.Append("\t");
            }
            buffer.Append("\n");

            for (int i = 0; i < scheduleObjectListView.Items.Count; i++)
            {
                for (int j = 0; j < scheduleObjectListView.Items[i].SubItems.Count; j++)
                {
                    buffer.Append(scheduleObjectListView.Items[i].SubItems[j].Text);
                    buffer.Append("\t");
                }
                buffer.Append("\n");
            }

            Clipboard.SetText(buffer.ToString());
            _scheduleContextMenuStrip.Visible = false;
        }

        public bool UseTotalRow
        {
            get { return _useTotalRow;}
            set { _useTotalRow = value; }
        }

        public bool ShowOlbAfterRepayment { get; set; }

        public ObjectListView Control { get { return scheduleObjectListView; } }
    }
}
