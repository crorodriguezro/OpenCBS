using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.CoreDomain;
using OpenCBS.CoreDomain.Accounting;
using OpenCBS.CoreDomain.Clients;
using OpenCBS.CoreDomain.Contracts.Savings;
using OpenCBS.CoreDomain.Events.Saving;
using OpenCBS.CoreDomain.Products;
using OpenCBS.Enums;
using OpenCBS.ExceptionsHandler;
using OpenCBS.Extensions;
using OpenCBS.MultiLanguageRessources;
using OpenCBS.Services;
using OpenCBS.Shared;

namespace OpenCBS.GUI.UserControl
{
    public partial class TernDepositUserControl : ClientControl, IDisposable
    {
        private readonly Client _client;
        private readonly ISavingProduct _product;
        private SavingBookContract _saving;
        public event EventHandler RefreshSaving;

        [ImportMany(typeof(ISavingsTabs), RequiredCreationPolicy = CreationPolicy.NonShared)]
        public List<ISavingsTabs> SavingsExtensions { get; set; }

        private readonly IApplicationController _applicationController;

        private SavingBookContract Saving
        {
            get { return _saving; }
            set { _saving = value; }
        }

        public TernDepositUserControl(ISavingProduct product, Client client, IApplicationController applicationController = null)
        {
            _client = client;
            _product = product;
            _applicationController = applicationController;

            _saving = new SavingBookContract(ServicesProvider.GetInstance().GetGeneralSettings(), User.CurrentUser, (SavingsBookProduct)_product);
            
            InitialFieldsForNewContract();

            SettingControl(true);
            buttonSaveSaving.Visible = true;
            SettingCancelLastEventButton();

            LoadSavingsExtensions();
        }

        public TernDepositUserControl(ISavingsContract saving, Client client, IApplicationController applicationController = null)
        {
            _saving = (SavingBookContract)saving;
            _client = client;
            _product = saving.Product;
            _applicationController = applicationController;

            InitialFieldsForNewContract(false);
            FillFieldsFromExistenceSaving();

            SettingControl(_saving.Status == OSavingsStatus.Pending);

            _dateCreatedLabel.Visible = dateTimeDateCreated.Visible = true;
            buttonSaveSaving.Visible = false;
            
            buttonStart.Visible = buttonUpdate.Visible = _saving.Status == OSavingsStatus.Pending;

            var lastEvent = _saving.Events.OrderBy(x => x.Date).LastOrDefault(x => x.Deleted == false);
            if (lastEvent != null && lastEvent.Code == "SVRE")
                SettingControlsAfterRenew();

            LoadSavingsExtensions();
        }

        #region FillControlsMethods

        private void InitialFieldsForNewContract(bool initialContractCode = true)
        {
            InitializeComponent();

            InitialOfficers();
            if (initialContractCode)
                InitialContractCode();
            InitialInitialAmount();
            InitialInterestRate();
            InitialNumberOfPeriod();
            InitialPersonalAccount();

            lbSavingBalanceValue.Text = _saving.Status == OSavingsStatus.Closed
                ? "0"
                : _saving.GetFmtBalance(true);
            SettingCancelLastEventButton();
            buttonSavingsClose.Visible = _saving.Status == OSavingsStatus.Active;
        }

        private void SettingControlsAfterSave()
        {
            FillFieldsFromExistenceSaving();
            SettingControl(true);
            lbSavingBalanceValue.Text = _saving.GetFmtBalance(true);
            SettingCancelLastEventButton();
            buttonSavingsClose.Visible = buttonSaveSaving.Visible = false;
            FillFieldStatus();
            dateTimeDateCreated.Value = _saving.CreationDate;
            _dateCreatedLabel.Visible = dateTimeDateCreated.Visible = buttonStart.Visible = buttonUpdate.Visible = true;
            InitialPersonalAccount();
        }

        private void SettingCancelLastEventButton()
        {
            var lastEvent = _saving.Events.OrderBy(x => x.Date).LastOrDefault(x => x.Deleted == false);
                btCancelLastSavingEvent.Visible = lastEvent != null && lastEvent.Code != "SVDE";
        }

        private void SettingControlsAfterCalcelLastEvent()
        {
            SettingCancelLastEventButton();

            buttonSavingsClose.Visible = true;

            FillFieldStatus();

            DisplaySavingEvent();
        }

        private void FillFieldStatus()
        {
            switch (_saving.Status)
            {
                case OSavingsStatus.Active:
                    groupBoxSaving.Text = @"Status: Active";
                    break;
                case OSavingsStatus.Pending:
                    groupBoxSaving.Text = @"Status: Pending";
                    break;
                case OSavingsStatus.Closed:
                    groupBoxSaving.Text = @"Status: Closed";
                    break;
                default:
                    groupBoxSaving.Text = User.CurrentUser.Name;
                    break;
            }
        }

        private void SettingControlsAfterStart()
        {
            FillFieldsFromExistenceSaving();
            SettingControl(false);
            lbSavingBalanceValue.Text = _saving.GetFmtBalance(true);
            buttonSaveSaving.Visible = buttonUpdate.Visible = buttonStart.Visible = false;
            SettingCancelLastEventButton();
            buttonSavingsClose.Visible = true;
            FillFieldStatus();
            dateTimeDateCreated.Value = _saving.CreationDate;
            _dateCreatedLabel.Visible = dateTimeDateCreated.Visible = true;
            InitialPersonalAccount();
        }

        private void SettingControlsAfterClose()
        {
            FillFieldsFromExistenceSaving();
            SettingControl(false);
            lbSavingBalanceValue.Text = @"0";
            buttonSavingsClose.Visible = buttonSaveSaving.Visible = buttonUpdate.Visible = buttonStart.Visible = false;
            SettingCancelLastEventButton();
            FillFieldStatus();
        }

        private void SettingControlsAfterRenew(bool settingInitialAmount = true)
        {
            buttonStart.Visible = buttonUpdate.Visible = nudDownInitialAmount.Enabled = true;
            buttonRenew.Visible = nudDownInterestRate.Enabled = dtpTernDepositDateStarted.Enabled = dtpTernDepositDateStarted.Enabled = nudNumberOfPeriods.Enabled = false;

            dtpTernDepositDateStarted.Value = TimeProvider.Now;

            var postingEvent = _saving.Events.FirstOrDefault(x => x.Deleted == false && x.Code == "SDTE");
            var previousExpecredAmount = postingEvent != null
                ? postingEvent.Amount
                : nudExpectedAmount.Value;
            if (settingInitialAmount)
            {
                InitialInitialAmount();
                nudDownInitialAmount.Value = previousExpecredAmount.Value;
            }
        }

        private void FillFieldsFromExistenceSaving()
        {
            if (_saving == null)
                return;

            tBSavingCode.Text = _saving.Code;
            cmbSavingsOfficer.SelectedItem = _saving.SavingsOfficer;
            nudDownInitialAmount.Value = _saving.InitialAmount.Value;
            nudDownInterestRate.Value = Convert.ToDecimal(_saving.InterestRate);
            nudNumberOfPeriods.Value = _saving.NumberOfPeriods;
            dtpTernDepositDateStarted.Value = _saving.StartDate == null ? dtpTernDepositDateStarted.MinDate : _saving.StartDate.Value;
            dateTimeDateCreated.Value = _saving.CreationDate;
            buttonRenew.Visible = _saving.Status == OSavingsStatus.Closed;
            SettingCancelLastEventButton();
            FillFieldStatus();
            DisplaySavingEvent();
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

            var useCents = _saving.Product.Currency.UseCents;
            foreach (var e in events)
            {
                var item = new ListViewItem(e.Date.ToString("dd/MM/yyyy HH:mm:ss"));
                var amt = e.Amount.GetFormatedValue(useCents);
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

            if (sender is DateTimePicker)
                InitialPersonalAccount();
        }

        private void CalculateExpectedAmount(object sender, EventArgs e)
        {
            nudExpectedAmount.Value = nudDownInitialAmount.Value / 100 * nudDownInterestRate.Value / 12 * nudNumberOfPeriods.Value + nudDownInitialAmount.Value;
        }

        private void nudNumberOfPeriods_ValueChanged(object sender, EventArgs e)
        {
            PeriodValueChanged(sender, e);
            CalculateExpectedAmount(sender, e);
        }

        private void SettingControl(bool enable)
        {
            cmbSavingsOfficer.Enabled = cmbSavingsOfficer.Enabled = nudDownInitialAmount.Enabled = nudDownInterestRate.Enabled
                = nudNumberOfPeriods.Enabled = dtpTernDepositDateStarted.Enabled = enable;

            Invalidate();
            Refresh();
        }

        #endregion

        #region MainMethods

        public void Save(object sender, EventArgs e)
        {
            var sqlTransac = DatabaseConnection.GetConnection().BeginTransaction(IsolationLevel.ReadUncommitted);
            try
            {
                _saving.EntryFees = 0m;
                _saving.UseTermDeposit = true;
                _saving.Product = (SavingsBookProduct)_product;
                _saving.Code = tBSavingCode.Text;
                _saving.SavingsOfficer = (User)cmbSavingsOfficer.SelectedItem;
                _saving.InitialAmount = nudDownInitialAmount.Value;
                _saving.InterestRate = Convert.ToDouble(nudDownInterestRate.Value);
                _saving.NumberOfPeriods = Convert.ToInt32(nudNumberOfPeriods.Value);
                _saving.CreationDate = TimeProvider.Now;
                _saving.StartDate = dtpTernDepositDateStarted.Value;
                _saving.Status = OSavingsStatus.Pending;
                _saving.ClosedDate = dtpTernDepositDateEnd.Value;

                _saving.Id = ServicesProvider.GetInstance().GetSavingServices().SaveTermDeposit(_saving, _client, null, sqlTransac);
                foreach (var extension in SavingsExtensions) extension.Save(_saving, sqlTransac);

                sqlTransac.Commit();

                _saving = ServicesProvider.GetInstance().GetSavingServices().GetSaving(_saving.Id);

                _client.AddSaving(_saving);

                if (RefreshSaving != null)
                    RefreshSaving(this, e);

                SettingControlsAfterSave();
            }
            catch (Exception error)
            {
                sqlTransac.Rollback();
                throw new Exception(error.Message);
            }
        }

        private void Start(object sender, EventArgs e)
        {
            var clientPersonalAccount = _client.Savings.FirstOrDefault(x => x.Product.Type == OSavingProductType.PersonalAccount && x.Status == OSavingsStatus.Active);

            try
            {
                ServicesProvider.GetInstance().GetSavingServices().ValidateWithdrawal(_saving.InitialAmount, clientPersonalAccount, _saving.StartDate.Value,
                "System withdraw operation for initial term deposit", User.CurrentUser, Teller.CurrentTeller, new PaymentMethod());
            }
            catch (Exception)
            {
                MessageBox.Show(@"Incorrect withdrawal amount for personal account");
                return;
            }

            var sqlTransac = DatabaseConnection.GetConnection().BeginTransaction(IsolationLevel.ReadUncommitted);
            try
            {
                
                if (clientPersonalAccount != null)
                {
                    ServicesProvider.GetInstance().GetSavingServices().WithdrawWithTransaction(clientPersonalAccount, _saving.StartDate.Value, _saving.InitialAmount
                            , "System withdraw operation for initial term deposit", _saving.SavingsOfficer,
                            Teller.CurrentTeller, new PaymentMethod(), sqlTransac);
                }
                else
                    throw new Exception("Can't find personal account");

                ServicesProvider.GetInstance().GetSavingServices().DepositWithTransaction(_saving, dtpTernDepositDateStarted.Value, _saving.InitialAmount, "Initial deposit",
                        User.CurrentUser, false, OSavingsMethods.Cash, new PaymentMethod(), null, Teller.CurrentTeller, sqlTransac, true);

                _saving.Status = OSavingsStatus.Active;
                ServicesProvider.GetInstance().GetSavingServices().UpdateStatusWithTransaction(_saving, sqlTransac);

                sqlTransac.Commit();

                _saving = ServicesProvider.GetInstance().GetSavingServices().GetSaving(_saving.Id);

                if (RefreshSaving != null)
                    RefreshSaving(this, e);

                SettingControlsAfterStart();
            }
            catch (Exception error)
            {
                sqlTransac.Rollback();
                throw new Exception(error.Message);
            }
        }

        private void Update(object sender, EventArgs e)
        {
            var sqlTransac = DatabaseConnection.GetConnection().BeginTransaction(IsolationLevel.ReadUncommitted);
            try
            {
                _saving.SavingsOfficer = (User)cmbSavingsOfficer.SelectedItem;
                _saving.InitialAmount = nudDownInitialAmount.Value;
                _saving.InterestRate = Convert.ToDouble(nudDownInterestRate.Value);
                _saving.NumberOfPeriods = Convert.ToInt32(nudNumberOfPeriods.Value);
                _saving.CreationDate = TimeProvider.Now;
                _saving.StartDate = dtpTernDepositDateStarted.Value;
                _saving.ClosedDate = dtpTernDepositDateEnd.Value;

                ServicesProvider.GetInstance().GetSavingServices().UpdateSaving(_saving, _client, sqlTransac);
                
                sqlTransac.Commit();

                _saving = ServicesProvider.GetInstance().GetSavingServices().GetSaving(_saving.Id);

                if (RefreshSaving != null)
                    RefreshSaving(this, e);

                SettingControlsAfterSave();

                var lastEvent = _saving.Events.OrderBy(x => x.Date).LastOrDefault(x => x.Deleted == false);
                if (lastEvent != null && lastEvent.Code == "SVRE")
                    SettingControlsAfterRenew(false);
            }
            catch (Exception error)
            {
                sqlTransac.Rollback();
                throw new Exception(error.Message);
            }
        }

        private void CancelLastEvent(object sender, EventArgs e)
        {
            try
            {
                if (!_saving.HasCancelableEvents()) return;

                const string message = "Confirm CancelLast Event";
                const string caption = "Confirm";
                var res = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);
                if (res != DialogResult.Yes) return;

                var frm = new FrmDeleteEventComment();
                var result = frm.ShowDialog();
                if (result != DialogResult.OK) return;

                ServicesProvider.GetInstance().GetSavingServices().CancelLastEvent(_saving, User.CurrentUser, frm.Comment);

                _saving = ServicesProvider.GetInstance().GetSavingServices().GetSaving(_saving.Id);

                SettingControlsAfterCalcelLastEvent();

                if (RefreshSaving != null)
                    RefreshSaving(this, e);
            }
            catch (Exception ex)
            {
                new frmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }
        }

        private void Close(object sender, EventArgs e)
        {
            var totalAmount = TimeProvider.Now.Date >= dtpTernDepositDateEnd.Value.Date
                    ? nudExpectedAmount.Value
                    : _saving.InitialAmount;

            var postingEvent = _saving.Events.FirstOrDefault(x => x.Deleted == false && x.Code == "SIPE" && x.Amount == nudExpectedAmount.Value - _saving.InitialAmount);
            if (totalAmount == nudExpectedAmount.Value && postingEvent == null)
            {
                MessageBox.Show(@"Correct posting event was not found");
                return;
            }

            var sqlTransac = DatabaseConnection.GetConnection().BeginTransaction(IsolationLevel.ReadUncommitted);
            try
            {
                var clientPersonalAccount = _client.Savings.FirstOrDefault(x => x.Product.Type == OSavingProductType.PersonalAccount && x.Status == OSavingsStatus.Active);
                if(clientPersonalAccount == null)
                    throw new Exception("Can't find personal account");

                ServicesProvider.GetInstance().GetSavingServices().CloseAndTransferWithTransaction(_saving, clientPersonalAccount, TimeProvider.Now, User.CurrentUser, totalAmount
                    , true, Teller.CurrentTeller, sqlTransac);
                
                _saving.Status = OSavingsStatus.Closed;
                ServicesProvider.GetInstance().GetSavingServices().UpdateStatusWithTransaction(_saving, sqlTransac);

                sqlTransac.Commit();

                _saving = ServicesProvider.GetInstance().GetSavingServices().GetSaving(_saving.Id);

                if (RefreshSaving != null)
                    RefreshSaving(this, e);

                SettingControlsAfterClose();

                DisplaySavingEvent();
            }
            catch (Exception error)
            {
                sqlTransac.Rollback();
                throw new Exception(error.Message);
            }
        }

        private void Renew(object sender, EventArgs e)
        {
            var sqlTransac = DatabaseConnection.GetConnection().BeginTransaction(IsolationLevel.ReadUncommitted);
            try
            {
                ServicesProvider.GetInstance().GetSavingServices().ReopenWithTransaction(0m, _saving, TimeProvider.Now, User.CurrentUser, _client, sqlTransac);

                _saving.Status = OSavingsStatus.Pending;
                ServicesProvider.GetInstance().GetSavingServices().UpdateStatusWithTransaction(_saving, sqlTransac);

                sqlTransac.Commit();

                _saving = ServicesProvider.GetInstance().GetSavingServices().GetSaving(_saving.Id);

                if (RefreshSaving != null)
                    RefreshSaving(this, e);

                SettingControlsAfterRenew(); //todo

                DisplaySavingEvent();
            }
            catch (Exception error)
            {
                sqlTransac.Rollback();
                throw new Exception(error.Message);
            }
        }

        #endregion

        private void LoadSavingsExtensions()
        {
            foreach (var extension in SavingsExtensions)
            {
                var pages = extension.GetTabPages(_saving);
                if (null == pages) continue;
                foreach (var page in pages) page.Tag = true; // mark as extension
                tabControlSavingsDetails.TabPages.AddRange(pages);
            }
            var tabs = _applicationController.GetAllInstances<ISavingsTabs>();
            foreach (var tab in tabs)
            {
                if (SavingsExtensions.Any(i => i.GetType() == tab.GetType())) continue;
                var pages = tab.GetTabPages(_saving);
                if (pages == null) continue;
                tabControlSavingsDetails.TabPages.AddRange(pages);
                SavingsExtensions.Add(tab);
            }
        }
    }
}