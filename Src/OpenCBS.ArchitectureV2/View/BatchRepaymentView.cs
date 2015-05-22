using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.ArchitectureV2.Interface.View;
using OpenCBS.ArchitectureV2.Model;
using OpenCBS.Controls;

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
            public decimal Total { get; set; }
        }

        private IBatchRepaymentPresenterCallbacks _presenterCallbacks;

        public BatchRepaymentView()
        {
            InitializeComponent();
            _principalColumn.AspectToStringConverter =
            _interestColumn.AspectToStringConverter =
            _totalColumn.AspectToStringConverter = v => ((decimal) v).ToString("N0");
            ObjectListView.EditorRegistry.Register(typeof(decimal), delegate
            {
                var textBox = new AmountTextBox { AllowDecimalSeparator = false };
                return textBox;
            });
        }

        public void Run()
        {
            ShowDialog();
        }

        public void Attach(IBatchRepaymentPresenterCallbacks presenterCallbacks)
        {
            _presenterCallbacks = presenterCallbacks;
        }

        public void SetLoans(List<Loan> loans)
        {
            var items = loans.Select(x =>
            {
                var principal = _presenterCallbacks.GetDuePrincipal(x.Id);
                var interest = _presenterCallbacks.GetDueInterest(x.Id);
                var total = principal + interest;
                return new Item
                {
                    Id = x.Id,
                    ContractCode = x.ContractCode,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Principal = principal,
                    Interest = interest,
                    Total = total
                };
            });
            _loansListView.SetObjects(items);
        }
    }
}
