using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.ArchitectureV2.View;
using OpenCBS.Extension.Accounting.Interface.Presenter;
using OpenCBS.Extension.Accounting.Interface.View;
using OpenCBS.Extension.Accounting.Model;

namespace OpenCBS.Extension.Accounting.View
{
    public partial class AnalyticBalancesView : BaseView, IAnalyticBalancesView
    {
        public AnalyticBalancesView(ITranslationService translationService)
            : base(translationService)
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            _analyticBalancesListView.UseAlternatingBackColors = true;
            _analyticBalancesListView.AlternateRowBackColor = Color.FromArgb(240, 240, 240);
            _startDebitColumn.AspectToStringConverter =
                _startCreditColumn.AspectToStringConverter =
                _debitColumn.AspectToStringConverter =
                _creditColumn.AspectToStringConverter =
                _endDebitColumn.AspectToStringConverter =
                _endCreditColumn.AspectToStringConverter =
                _saldoColumn.AspectToStringConverter = v => ((decimal)v).ToString("N2");
        }

        public void Attach(IAnalyticBalancesPresenterCallbacks presenterCallbacks)
        {
            _excelButton.Click += (sender, e) => presenterCallbacks.ShowInExcel();
            FormClosing += (sender, e) => presenterCallbacks.DetachView();
        }

        public void SetBalances(List<Balance> balances)
        {
            _analyticBalancesListView.SetObjects(balances);
        }

        public void ShowBalancesOnly()
        {
            Name = "AnalyticBalancesWithoutTurnoverView";
            _saldoColumn.IsVisible = true;
            _startDebitColumn.IsVisible =
                _startCreditColumn.IsVisible =
                    _debitColumn.IsVisible =
                        _creditColumn.IsVisible =
                            _endCreditColumn.IsVisible =
                                _endDebitColumn.IsVisible = false;
            _analyticBalancesListView.RebuildColumns();
        }

        public Control Control
        {
            get { return _analyticBalancesListView; }
        }
    }
}
