using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.ArchitectureV2.Interface.View;
using OpenCBS.ArchitectureV2.Model;
using OpenCBS.Controls;
using OpenCBS.CoreDomain.Accounting;
using OpenCBS.Services;

namespace OpenCBS.ArchitectureV2.View
{
    public partial class BatchRepaymentView : Form, IBatchRepaymentView
    {
        private class Item
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string ContractCode { get; set; }
            public decimal Principal { get; set; }
            public decimal Interest { get; set; }
            public DateTime ExpectedDate { get; set; } 
            public decimal Total { get; set; }
            public bool Selected { get; set; }
            public string ReceiptNumber { get; set; }
            public string Comment { get; set; }
        }

        private class TotalItem : Item
        {
            public new decimal Principal { get; set; }
            public new decimal Interest { get; set; }
            public new decimal Total { get; set; }
        }

        private IBatchRepaymentPresenterCallbacks _presenterCallbacks;
        private readonly TotalItem _totalItem = new TotalItem();
        private bool _canUpdateTotal = true;

        public BatchRepaymentView()
        {
            InitializeComponent();
            _principalColumn.AspectToStringConverter =
            _interestColumn.AspectToStringConverter =
            _totalColumn.AspectToStringConverter = v => ((decimal) v).ToString("N0");
            _totalColumn.AspectPutter = TotalAspectPutter;
            _expectedDateColumn.AspectToStringConverter = v => ((DateTime)v).Date.ToString("dd'/'MM'/'yyyy"); 
            _loansListView.RowFormatter = ItemRowFormatter;
            _loansListView.ItemChecked += OnItemChecked;
            _loansListView.CellEditStarting += OnCellEditStarting;
            FillComboBoxPaymentMethods();

            ObjectListView.EditorRegistry.Register(typeof(decimal), delegate
            {
                var textBox = new AmountTextBox { AllowDecimalSeparator = false };
                return textBox;
            });

            _totalItem.FirstName = "TOTAL";
            _loansListView.CheckBoxes = true;
        }

        private void FillComboBoxPaymentMethods()
        {
            List<PaymentMethod> paymentMethods =
                ServicesProvider.GetInstance().GetPaymentMethodServices().GetAllPaymentMethods();
            foreach (PaymentMethod method in paymentMethods)
            {
                cmbPaymentMethod.Items.Add(method);
            }
            Method = paymentMethods[0];
        }

        public void Run()
        {
            ShowDialog();
        }

        public void Attach(IBatchRepaymentPresenterCallbacks presenterCallbacks)
        {
            _presenterCallbacks = presenterCallbacks;
            _okButton.Click += (sender, e) => presenterCallbacks.Repay();
        }

        private void UpdateTotal()
        {
            if (!_canUpdateTotal)
            {
                return;
            }

            var principal = 0m;
            var interest = 0m;

            foreach (Item item in _loansListView.CheckedObjects)
            {
                if (item == _totalItem) continue;
                principal += item.Principal;
                interest += item.Interest;
            }

            _totalItem.Principal = principal;
            _totalItem.Interest = interest;
            _totalItem.Total = principal + interest;
            _loansListView.RefreshObject(_totalItem);
        }

        public void SetLoans(List<Loan> loans)
        {
            var items = loans.Select(x =>
            {
                var principal = _presenterCallbacks.GetDuePrincipal(x.Id);
                var interest = _presenterCallbacks.GetDueInterest(x.Id);
                var total = principal + interest;
                DateTime expectedDate = _presenterCallbacks.GetExpectedDate(x.Id);
                
                return new Item
                {
                    Id = x.Id,
                    ContractCode = x.ContractCode,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Principal = principal,
                    Interest = interest,
                    Total = total,
                    ExpectedDate = expectedDate
                };
            }).ToList();
            items.Add(_totalItem);
            _loansListView.SetObjects(items);
            UpdateTotal();
        }

        private void TotalAspectPutter(object rowObject, object value)
        {
            var item = (Item) rowObject;
            decimal total;
            if (decimal.TryParse(value.ToString(), out total))
            {
                var maxTotal = _presenterCallbacks.GetMaxDueTotal(item.Id);
                if (total > maxTotal)
                {
                    total = maxTotal;
                }
                item.Total = total;
                var amounts = _presenterCallbacks.DistributeTotal(item.Id, total);
                item.Principal = amounts[0];
                item.Interest = amounts[1];
            }
            _loansListView.RefreshObject(item);
            UpdateTotal();
        }

        private void ItemRowFormatter(OLVListItem item)
        {
            item.UseItemStyleForSubItems = false;
            var loan = (Item) item.RowObject;

            if (loan.Selected)
            {
                var selectedBackColor = Color.FromArgb(210, 241, 255);
                item.SubItems[0].BackColor = selectedBackColor;
                item.SubItems[1].BackColor = selectedBackColor;
                item.SubItems[2].BackColor = selectedBackColor;
                item.SubItems[3].BackColor = selectedBackColor;
                item.SubItems[4].BackColor = selectedBackColor;
                item.SubItems[5].BackColor = selectedBackColor;
                item.SubItems[6].BackColor = selectedBackColor;
            }

            if (loan == _totalItem)
            {
                item.Font = new Font(item.Font, FontStyle.Bold);
                item.SubItems[1].Font = item.Font;
                item.SubItems[2].Font = item.Font;
                item.SubItems[3].Font = item.Font;
                item.SubItems[4].Font = item.Font;
                item.SubItems[5].Text = string.Empty;
                item.SubItems[6].Font = item.Font;
            }
        }

        private void OnItemChecked(object sender, ItemCheckedEventArgs e)
        {
            var item = (OLVListItem) e.Item;
            var checkedItem = (Item) item.RowObject;
            if (checkedItem == _totalItem)
            {
                _canUpdateTotal = false;
                foreach (Item loanItem in _loansListView.Objects)
                {
                    loanItem.Selected = item.Checked;
                    //_loansListView.RefreshObject(loanItem);
                }
                _canUpdateTotal = true;
            }
            UpdateTotal();
        }

        private void OnCellEditStarting(object sender, CellEditEventArgs e)
        {
            if ((Item) e.RowObject == _totalItem)
            {
                e.Cancel = true;
            }
        }
        public void Stop()
        {
            Close();
        }
        public decimal GetTotal(int loanId)
        {
            return _loansListView.Objects.Cast<Item>().Where(x => x.Id == loanId).Select(x => x.Total).Single();
        }
        public string GetComment(int loanId)
        {
            return _loansListView.Objects.Cast<Item>().Where(x => x.Id == loanId).Select(x => x.Comment).Single();
        }
        public string GetReceiptNumber(int loanId)
        {
            return _loansListView.Objects.Cast<Item>().Where(x => x.Id == loanId).Select(x => x.ReceiptNumber).Single();
        }
        public List<int> SelectedLoanIds
        {
            get
            {
                return _loansListView.CheckedObjects.Cast<Item>().Where(x => x != _totalItem).Select(x => x.Id).ToList();
            }
        }
        public void EnableTotalEdit()
        {
            _totalColumn.IsEditable = true;
        }
        public void DisableTotalEdit()
        {
            _totalColumn.IsEditable = false;
        }

        public PaymentMethod Method
        {
            get { return (PaymentMethod)cmbPaymentMethod.SelectedItem; }
            set { cmbPaymentMethod.SelectedItem = value; }
        }
    }
}
