using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OpenCBS.CoreDomain;
using OpenCBS.CoreDomain.Clients;
using OpenCBS.CoreDomain.Contracts.Savings;
using OpenCBS.CoreDomain.Events.Saving;
using OpenCBS.CoreDomain.Products;
using OpenCBS.Enums;
using OpenCBS.MultiLanguageRessources;
using OpenCBS.Services;

namespace OpenCBS.GUI.UserControl
{
    public partial class TernDepositUserControl : ClientControl, IDisposable
    {
        private Client _client;
        private ISavingProduct _product;
        private SavingBookContract _saving;

        public TernDepositUserControl(ISavingProduct product, Client client)
        {
            _client = client;
            _product = product;
            InitialFieldsForNewContract();
        }

        private void InitialFieldsForNewContract()
        {
            InitializeComponent();

            _saving = new SavingBookContract(ServicesProvider.GetInstance().GetGeneralSettings(),
                                                    User.CurrentUser, (SavingsBookProduct)_product);

            InitialOfficers();
            InitialContractCode();
            InitialInitialAmount();
            InitialInterestRate();
            InitialNumberOfPeriod();
            InitialPersonalAccount();
            DisplaySavingEvent();

            lbSavingBalanceValue.Text = _saving.GetFmtBalance(true);
            btCancelLastSavingEvent.Visible = _saving.Status == OSavingsStatus.Active || _saving.Status == OSavingsStatus.Closed;
            buttonSavingsOperations.Visible = _saving.Status == OSavingsStatus.Active;
        }

        private void InitialOfficers()
        {
            cmbSavingsOfficer.Items.Clear();
            cmbSavingsOfficer.Items.Add(User.CurrentUser);

            foreach (var subordinate in User.CurrentUser.Subordinates.Where(subordinate => !subordinate.IsDeleted))
                cmbSavingsOfficer.Items.Add(subordinate);

            cmbSavingsOfficer.SelectedIndex = 0;
        }

        private void InitialContractCode()
        {
            var numbersOfSavings = ServicesProvider.GetInstance().GetSavingServices().GetSavingCount(_client);
            var nextSavingsId = ServicesProvider.GetInstance().GetSavingServices().GetLastSavingsId() + 1;

            _saving.GenerateSavingCode(_client, numbersOfSavings, ServicesProvider.GetInstance().GetGeneralSettings().SavingsCodeTemplate, _client.Branch.Code);

            tBSavingCode.Text = _saving.Code + '/' + nextSavingsId;
        }

        private void InitialInitialAmount()
        {
            lbInitialAmountMinMax.Text = string.Format("{0}{1} {4}\r\n{2}{3} {4}",
                "Min ", _product.InitialAmountMin.GetFormatedValue(_product.Currency.UseCents),
                "Max ", _product.InitialAmountMax.GetFormatedValue(_product.Currency.UseCents),
                _product.Currency.Code);
            nudDownInitialAmount.Maximum = _product.InitialAmountMax == null ? 0 : _product.InitialAmountMax.Value;
            nudDownInitialAmount.Minimum = _product.InitialAmountMin == null ? 0 : _product.InitialAmountMin.Value;
            nudDownInitialAmount.Value = _product.InitialAmountMin == null ? 0 : _product.InitialAmountMin.Value;

            var clientPersonalAccount = _client.Savings.FirstOrDefault(x => x.Product.Type == OSavingProductType.PersonalAccount && x.Status == OSavingsStatus.Active);
            if (clientPersonalAccount != null)
            {
                var balance = clientPersonalAccount.GetBalance(dtpTernDepositDateStarted.Value);
                if (balance < nudDownInitialAmount.Maximum && balance > 0)
                    nudDownInitialAmount.Maximum = balance.Value;
            }
        }

        private void InitialInterestRate()
        {
            if (_product.InterestRate.HasValue)
            {
                nudDownInterestRate.Enabled = false;
                lbInterestRateMinMax.Text = string.Format("{0} %", _product.InterestRate*100);
                nudDownInterestRate.Maximum = _product.InterestRate == null ? 0 : (decimal)_product.InterestRate.Value*100;
                nudDownInterestRate.Minimum = _product.InterestRate == null ? 0 : (decimal)_product.InterestRate.Value*100;
            }
            else
            {
                lbInterestRateMinMax.Text = string.Format("{0}{1} %\r\n{2}{3} %",
                    "Min ", _product.InterestRateMin == null ? 0 : _product.InterestRateMin.Value*100,
                    "Max ", _product.InterestRateMax == null ? 0 : _product.InterestRateMax.Value*100);
                nudDownInterestRate.Maximum = _product.InterestRateMax == null ? 0 : (decimal)_product.InterestRateMax.Value*100;
                nudDownInterestRate.Minimum = _product.InterestRateMin == null ? 0 : (decimal)_product.InterestRateMin.Value*100;
                nudDownInterestRate.Enabled = nudDownInterestRate.Minimum != nudDownInterestRate.Maximum;
            }

            nudDownInterestRate.Enabled = nudDownInterestRate.Minimum != nudDownInterestRate.Maximum;
        }

        private void InitialNumberOfPeriod()
        {
            nudNumberOfPeriods.Minimum = ((SavingsBookProduct)_product).TermDepositPeriodMin == null ? 0 : ((SavingsBookProduct)_product).TermDepositPeriodMin.Value;
            nudNumberOfPeriods.Maximum = ((SavingsBookProduct)_product).TermDepositPeriodMax == null ? 0 : ((SavingsBookProduct)_product).TermDepositPeriodMax.Value;
            nudNumberOfPeriods.Value = nudNumberOfPeriods.Minimum;

            lblLimitOfTermDepositPeriod.Text = string.Format("Min: {0}\nMax: {1}", nudNumberOfPeriods.Minimum, nudNumberOfPeriods.Maximum);
        }

        private void InitialPersonalAccount()
        {
            var clientPersonalAccount = _client.Savings.FirstOrDefault(x => x.Product.Type == OSavingProductType.PersonalAccount && x.Status == OSavingsStatus.Active);

            if (clientPersonalAccount != null)
            {
                buttonSaveSaving.Enabled = true;

                var currency = _product.Currency.Code;
                var balance = clientPersonalAccount.GetBalance(dtpTernDepositDateStarted.Value);
                if(balance <= 0 || balance < nudDownInitialAmount.Minimum)
                    buttonSaveSaving.Enabled = false;
                lbSavingAvBalanceValue.Text = string.Format("{0} {1}", balance, currency);

                using (var sqlTransaction = DatabaseConnection.GetConnection().BeginTransaction())
                {
                    try
                    {
                        _currentAccountTextBox.Text = ServicesProvider.GetInstance().GetSavingServices().GetAlreadyHaveClientCurrentAccount(_client.Id, sqlTransaction);
                    }
                    catch (Exception error)
                    {
                        sqlTransaction.Rollback();
                        throw new Exception(error.Message);
                    }
                }
            }
            else
            {
                buttonSaveSaving.Enabled = false;
                lbSavingAvBalanceValue.Text = @"Absent";
                lbSavingAvBalanceValue.Font = new Font(lbSavingAvBalanceValue.Font, FontStyle.Bold);
                lbSavingAvBalanceValue.ForeColor = Color.Red;
            }
        }

        private void DisplaySavingEvent()
        {
            lvSavingEvent.Items.Clear();
            IEnumerable<SavingEvent> events = _saving.Events.OrderBy(item => item.Date.Date);

            bool useCents = _saving.Product.Currency.UseCents;
            foreach (SavingEvent e in events)
            {
                ListViewItem item = new ListViewItem(e.Date.ToString("dd/MM/yyyy HH:mm:ss"));
                string amt = e.Amount.GetFormatedValue(useCents);
                item.SubItems.Add(e.IsDebit ? amt : string.Empty);
                item.SubItems.Add(e.IsDebit ? string.Empty : amt);
                item.SubItems.Add(e.ExtraInfo);
                item.SubItems.Add(e.Code);
                string method;
                if (e.SavingsMethod.HasValue)
                    method = MultiLanguageStrings.GetString("SavingsOperationForm", e.SavingsMethod + ".Text");
                else
                    method = e.PaymentsMethod == null
                        ? "-"
                        : MultiLanguageStrings.GetString("SavingsOperationForm", e.PaymentsMethod.Name + ".Text");
                item.SubItems.Add(method);
                item.SubItems.Add(e.User.Name);
                item.SubItems.Add(e.Description);
                item.SubItems.Add(e.CancelDate.HasValue ? e.CancelDate.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty);

                if (e.IsPending)
                {
                    item.BackColor = Color.Orange;
                    item.ForeColor = Color.White;
                }

                if (e.Deleted)
                {
                    item.BackColor = Color.FromArgb(188, 209, 199);
                    item.ForeColor = Color.White;
                }

                item.Tag = e;
                lvSavingEvent.Items.Add(item);
            }
        }

        private void PeriodValueChanged(object sender, EventArgs e)
        {
            // TODO: HARDCODE: we always use month period (haven't cases for week, year etc.)
            dtpTernDepositDateEnd.Value = dtpTernDepositDateStarted.Value.AddMonths(Convert.ToInt32(nudNumberOfPeriods.Value));
        }

        private void CalculateExpectedAmount(object sender, EventArgs e)
        {
//            nudExpectedAmount.Value = nudDownInitialAmount.Value * nudDownInterestRate.Value * nudNumberOfPeriods.Value;
        }

        private void nudNumberOfPeriods_ValueChanged(object sender, EventArgs e)
        {
            PeriodValueChanged(sender, e);
            CalculateExpectedAmount(sender, e);
        }
    }
}
