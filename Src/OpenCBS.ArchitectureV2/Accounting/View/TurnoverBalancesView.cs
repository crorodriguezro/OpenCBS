using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.ArchitectureV2.View;
using OpenCBS.Extension.Accounting.Interface.Presenter;
using OpenCBS.Extension.Accounting.Interface.View;
using OpenCBS.Extension.Accounting.Model;
using StructureMap;

namespace OpenCBS.Extension.Accounting.View
{
    public partial class TurnoverBalancesView : BaseView, ITurnoverBalancesView
    {
        private readonly ITranslationService _translationService;
        private List<Balance> _balances;

        [DefaultConstructor]
        public TurnoverBalancesView(ITranslationService translationService)
            : base(translationService)
        {
            _translationService = translationService;
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            _turnoverBalancesListView.UseAlternatingBackColors = true;
            _turnoverBalancesListView.AlternateRowBackColor = Color.FromArgb(240, 240, 240);
            _turnoverBalancesListView.RowFormatter = FormatRow;
            _turnoverBalancesListView.CanExpandGetter = x =>
            {
                var balance = (Balance)x;
                return _balances.Any(i => i.Parent == balance.Code);
            };
            _turnoverBalancesListView.ChildrenGetter = x =>
            {
                var balance = (Balance)x;
                return _balances.Where(i => i.Parent == balance.Code);
            };
            _startDebitColumn.AspectToStringConverter =
                _startCreditColumn.AspectToStringConverter =
                _debitColumn.AspectToStringConverter =
                _creditColumn.AspectToStringConverter =
                _endDebitColumn.AspectToStringConverter =
                _endCreditColumn.AspectToStringConverter =
                _balanceColumn.AspectToStringConverter = value =>
                {
                    var amount = (decimal)value;
                    return amount.ToString("N2");
                };
            _branchComboBox.DisplayMember = "Value";
        }

        private static void FormatRow(OLVListItem item)
        {
            var balance = (Balance)item.RowObject;
            if (balance == null) return;
            if (balance.Parent == null) item.Font = new Font(item.Font, FontStyle.Bold);
        }

        public void Attach(ITurnoverBalancesPresenterCallbacks presenterCallbacks)
        {
            FormClosing += (sender, e) => presenterCallbacks.DetachView();
            _refreshButton.Click += (sender, e) => presenterCallbacks.Refresh();
            _turnoverBalancesListView.DoubleClick += (sender, e) => presenterCallbacks.ShowAccountMovements();
            _excelButton.Click += (sender, e) => presenterCallbacks.ShowInExcel();
            _showAnalyticButton.Click += (sender, e) => presenterCallbacks.ShowAnalytics();
            _checkBoxExpandAll.CheckedChanged += (sender, e) =>
            {
                if (_checkBoxExpandAll.Checked)
                {
                    _turnoverBalancesListView.ExpandAll();
                }
                else
                {
                    _turnoverBalancesListView.CollapseAll();
                }
            };
        }

        public Dictionary<int, string> Branches
        {
            set { _branchComboBox.DataSource = value.ToList(); }
        }

        public int BranchId
        {
            get { return ((KeyValuePair<int, string>)_branchComboBox.SelectedValue).Key; }
        }

        public DateTime From
        {
            get { return _fromDateTimePicker.Value; }
            set { _fromDateTimePicker.Value = value; }
        }

        public DateTime To
        {
            get { return _toDateTimePicker.Value; }
            set { _toDateTimePicker.Value = value; }
        }

        public void SetBalances(IList<Balance> balances)
        {
            _balances = balances.ToList();
            var roots = _balances.Where(i => i.Parent == null).ToList();
            _turnoverBalancesListView.SetObjects(roots);
            foreach (var root in roots)
            {
                _turnoverBalancesListView.Expand(root);
            }
        }

        public Control Control
        {
            get { return _turnoverBalancesListView; }
        }

        public void ShowBalancesOnly()
        {
            Name = "BalancesView";
            Text = _translationService.Translate("Balance Sheet");
            _balanceColumn.IsVisible = true;
            _startDebitColumn.IsVisible =
                _startCreditColumn.IsVisible =
                    _debitColumn.IsVisible =
                        _creditColumn.IsVisible =
                            _endCreditColumn.IsVisible =
                                _endDebitColumn.IsVisible = false;
            _turnoverBalancesListView.RebuildColumns();
            _fromDateTimePicker.Visible = false;
            _fromLabel.Visible = false;
            _toLabel.Text = _translationService.Translate("On");
        }

        public Balance SelectedBalance
        {
            get { return (Balance)_turnoverBalancesListView.SelectedObject; }
        }
    }
}
