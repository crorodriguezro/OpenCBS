using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using OpenCBS.ArchitectureV2.CommandData;
using OpenCBS.ArchitectureV2.Event;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.CoreDomain;
using OpenCBS.CoreDomain.Accounting;
using OpenCBS.CoreDomain.Clients;
using OpenCBS.CoreDomain.Contracts;
using OpenCBS.CoreDomain.Contracts.Collaterals;
using OpenCBS.CoreDomain.Contracts.Guarantees;
using OpenCBS.CoreDomain.Contracts.Loans;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;
using OpenCBS.CoreDomain.Contracts.Savings;
using OpenCBS.CoreDomain.Events;
using OpenCBS.CoreDomain.Events.Loan;
using OpenCBS.CoreDomain.Events.Saving;
using OpenCBS.CoreDomain.FundingLines;
using OpenCBS.CoreDomain.Online;
using OpenCBS.CoreDomain.Products;
using OpenCBS.CoreDomain.Products.Collaterals;
using OpenCBS.Enums;
using OpenCBS.ExceptionsHandler;
using OpenCBS.Extensions;
using OpenCBS.GUI.Contracts;
using OpenCBS.GUI.Tools;
using OpenCBS.GUI.UserControl;
using OpenCBS.MultiLanguageRessources;
using OpenCBS.Reports;
using OpenCBS.Services;
using OpenCBS.Shared;
using OpenCBS.Shared.Settings;
using Group = OpenCBS.CoreDomain.Clients.Group;

namespace OpenCBS.GUI.Clients
{
    using ML = MultiLanguageStrings;
    public partial class LoanCalculator : SweetForm
    {
        #region *** Fields ***
        private LoanProduct _product;
        private Project _project;
        private Group _group;
        private Loan _credit;
        private Guarantee _guarantee;
        private Person _person;
        private readonly Form _mdiParent;

        private OClientTypes _oClientType;
        private PersonUserControl _personUserControl;
        private GroupUserControl _groupUserControl;
        private readonly bool _closeFormAfterSave;
        private List<LoanShare> _loanShares;
        private List<User> _users;
        private FundingLine _fundingLine;
        private Corporate _corporate;
        private CorporateUserControl _corporateUserControl;
        private List<FollowUp> _followUpList = new List<FollowUp>();
        private SavingsBookProduct _savingsBookProduct;
        private SavingBookContract _saving;
        private bool _toChangeAlignDate;
        private int? _gracePeriodOfLateFees;
        private string _title;
        private Client _client;
        private DateTime _firstInstallmentDate;

        OCurrency _totalGuarantorAmount = 0;
        OCurrency _totalCollateralAmount = 0;

        private List<Guarantor> _listGuarantors;
        private List<ContractCollateral> _collaterals;
        private string _typeOfFee;
        private DoubleValueRange _anticipatedTotalFeesValueRange;
        private DoubleValueRange _anticipatedPartialFeesValueRange;

        private DateTime _oldDisbursmentDate;
        private DateTime _oldFirstInstalmentDate;
        private bool _changeDisDateBool;

        [ImportMany(typeof(ILoanTabs), RequiredCreationPolicy = CreationPolicy.NonShared)]
        public List<ILoanTabs> LoanTabs { get; set; }

        [ImportMany(typeof(ISavingsTabs), RequiredCreationPolicy = CreationPolicy.NonShared)]
        public List<ISavingsTabs> SavingsExtensions { get; set; }

        [ImportMany(typeof(ILoanDetailsButton), RequiredCreationPolicy = CreationPolicy.NonShared)]
        public List<ILoanDetailsButton> LoanDetailsButtons { get; set; }

        [ImportMany(typeof(IPrintButtonContextMenuStrip), RequiredCreationPolicy = CreationPolicy.NonShared)]
        public List<IPrintButtonContextMenuStrip> PrintButtonContextMenuStrips { get; set; }

        [ImportMany(typeof(ILoanExtension))]
        public List<ILoanExtension> LoanExtensions { get; set; }

        [ImportMany(typeof(ILoanApprovalControl))]
        private Lazy<ILoanApprovalControl, IDictionary<string, object>>[] LoanApprovalControls { get; set; }

        private ILoanApprovalControl _loanApprovalControl;

        private readonly IApplicationController _applicationController;

        #endregion

        private LoanCalculator(IApplicationController applicationController = null)
        {
            InitializeComponent();

            MefContainer.Current.Bind(this);
            _applicationController = applicationController;

            _loanApprovalControl = (
                    from c in LoanApprovalControls
                    where
                        c.Metadata.ContainsKey("Implementation") &&
                        c.Metadata["Implementation"].ToString() != "Default"
                    select c.Value).FirstOrDefault();

            if (_loanApprovalControl == null)
            {
                // Otherwise, find the default one
                _loanApprovalControl = (
                                from c in LoanApprovalControls
                                where
                                    c.Metadata.ContainsKey("Implementation") &&
                                    c.Metadata["Implementation"].ToString() == "Default"
                                select c.Value).FirstOrDefault();
            }
            if (_loanApprovalControl == null)
            {
                throw new Exception("Cannot resolve loan approval container.");
            }
            
            var control = _loanApprovalControl.GetControl();
            control.Dock = DockStyle.Fill;

            this.dtpDateOfFirstInstallment.Format = DateTimePickerFormat.Custom;
            this.dtpDateOfFirstInstallment.CustomFormat = ApplicationSettings.GetInstance("").SHORT_DATE_FORMAT;
            this.dateLoanStart.Format = DateTimePickerFormat.Custom;
            this.dateLoanStart.CustomFormat = ApplicationSettings.GetInstance("").SHORT_DATE_FORMAT;
        }

        public LoanCalculator(
            OClientTypes pClientType,
            Form pMdiParent,
            bool pCloseFormAfterSave,
            IApplicationController applicationController = null)
            : this(applicationController)
        {
            _listGuarantors = new List<Guarantor>();
            _collaterals = new List<ContractCollateral>();
            _loanShares = new List<LoanShare>();
            _closeFormAfterSave = pCloseFormAfterSave;
            _mdiParent = pMdiParent;
            InitControls();
            _oClientType = pClientType;

            if (pClientType == OClientTypes.Person) _person = new Person();
            InitializeTitle("Loan Calculator");
        }

        private void InitControls()
        {
            ApplicationSettings dataParam = ApplicationSettings.GetInstance(string.Empty);
            int decimalPlaces = dataParam.InterestRateDecimalPlaces;
            nudInterestRate.DecimalPlaces = decimalPlaces;

            decimal increment = decimal.One;
            for (int exp = 0; exp < decimalPlaces; exp++)
                increment = decimal.Divide(increment, 10m);
            nudInterestRate.Increment = increment;


            var packages= ServiceProvider.GetProductServices().FindAllPackages(false, OClientTypes.Person);
       
            cmbPackages.DataSource = new BindingSource(packages.ToDictionary(val => val.Name, val => val), null);
            cmbPackages.DisplayMember = "Key";
            cmbPackages.ValueMember = "Value";

            _product = packages.FirstOrDefault();

            InitializeTabPageLoansDetails(_product);

        }

        public LoanCalculator(Person pPerson, Form pMdiParent, IApplicationController applicationController = null)
            : this(applicationController)
        {
            _mdiParent = pMdiParent;
            _person = pPerson;
            _client = pPerson;
            _listGuarantors = new List<Guarantor>();
            _collaterals = new List<ContractCollateral>();
            _loanShares = new List<LoanShare>();

            InitControls();
            _oClientType = OClientTypes.Person;
        }

        public Project Project
        {
            set { _project = value; }
        }

        private static IServices ServiceProvider
        {
            get { return ServicesProvider.GetInstance(); }
        }

        private static SavingServices SavingServices
        {
            get { return ServiceProvider.GetSavingServices(); }
        }

        public Person Person
        {
            get { return _person; }
        }

        private void InitializeTitle(string title)
        {
            if (_person != null)
            {
                Text = string.IsNullOrEmpty(title) ? MultiLanguageStrings.GetString(Ressource.ClientForm, "Person.Text") : title;
                if (_person.BadClient)
                {
                    Text += "  " + MultiLanguageStrings.GetString(Ressource.ClientForm, "Bad.Text");
                    lblTitle.BackColor = Color.Red;
                }
                else
                {
                    lblTitle.BackColor = Color.FromArgb(0, 81, 152);
                }
            }
            else if (_group != null)
            {
                Text = string.IsNullOrEmpty(title) ? MultiLanguageStrings.GetString(Ressource.ClientForm, "Group.Text") : title + " - (" + _group.LoanCycle + ")";

                if (_group.BadClient)
                {
                    Text += "  " + MultiLanguageStrings.GetString(Ressource.ClientForm, "Bad.Text");
                    lblTitle.BackColor = Color.Red;
                }
                else
                {
                    lblTitle.BackColor = Color.FromArgb(0, 81, 152);
                }
            }
            else
            {
                Text = string.IsNullOrEmpty(title) ? MultiLanguageStrings.GetString(Ressource.ClientForm, "Corporate.Text") : title;
                if (_corporate.BadClient)
                {
                    Text += "  " + MultiLanguageStrings.GetString(Ressource.ClientForm, "Bad.Text");
                    lblTitle.BackColor = Color.Red;
                }
                else
                {
                    lblTitle.BackColor = Color.FromArgb(0, 81, 152);
                }
            }
            _title = Text;
        }

        private void InitializeTabPageLoansDetails(LoanProduct pPackage)
        {
            _credit = new Loan(User.CurrentUser, ServicesProvider.GetInstance().GetGeneralSettings(),
                ServicesProvider.GetInstance().GetNonWorkingDate(),
                CoreDomainProvider.GetInstance().GetProvisioningTable());
            _credit.Product = pPackage;

            nudLoanAmount.Text = string.Empty;
            InitInstallmentType(pPackage.InstallmentType);
            InitScheduleType(pPackage.LoanType, pPackage.ScriptName);
            InitializePackageNumberOfInstallments(_credit,true);
            InitializePackageGracePeriod(_credit.Product, true);
            FillInstallmentListForScheduleControl("loanDetailsScheduleControl", _credit);
            InitializeFundingLine();
            _credit.FundingLine = _fundingLine;
            _credit.LoanOfficer = User.CurrentUser;
      
            SetPackageValuesForLoanDetails(_credit, true);
        }

        private void InitInstallmentType(InstallmentType installmentType)
        {
            _installmentTypeComboBox.Items.Clear();
            var items = ServicesProvider.GetInstance().GetProductServices().FindAllInstallmentTypes();
            var selectedIndex = 0;
            var i = 0;
            foreach (var item in items)
            {
                _installmentTypeComboBox.Items.Add(item);
                if (item.Id == installmentType.Id)
                {
                    selectedIndex = i;
                }
                i++;
            }
            _installmentTypeComboBox.SelectedIndex = selectedIndex;
            _installmentTypeComboBox.Enabled = installmentType.Id == 0;

            if (_credit.InstallmentType == null)
            {
                _credit.InstallmentType = (InstallmentType)_installmentTypeComboBox.SelectedItem;
            }
        }

        private void InitScheduleType(OLoanTypes loanType, string scriptName)
        {
            _scheduleTypeComboBox.Items.Clear();
            _scheduleTypeComboBox.Items.Add(GetString("FrmAddLoanProduct", "Flat.Text"));
            _scheduleTypeComboBox.Items.Add(GetString("FrmAddLoanProduct", "DecliningFixedPrincipal.Text"));
            _scheduleTypeComboBox.Items.Add(GetString("FrmAddLoanProduct", "DecliningFixedInstallments.Text"));

            var scripts = ServicesProvider.GetInstance().GetProductServices().SelectLoanProuctTypeScripts();
            foreach (var script in scripts)
            {
                _scheduleTypeComboBox.Items.Add(script);
            }

            var scheduleGeneratorNames =
                ServicesProvider.GetInstance().GetContractServices().GetScheduleGeneratorNames();
            foreach (var name in scheduleGeneratorNames)
            {
                _scheduleTypeComboBox.Items.Add(name);
            }

            switch (loanType)
            {
                case OLoanTypes.All:
                    _scheduleTypeComboBox.SelectedIndex = 0;
                    break;

                case OLoanTypes.Flat:
                    _scheduleTypeComboBox.SelectedIndex = 0;
                    break;

                case OLoanTypes.DecliningFixedPrincipal:
                    _scheduleTypeComboBox.SelectedIndex = 1;
                    break;

                case OLoanTypes.DecliningFixedInstallments:
                    _scheduleTypeComboBox.SelectedIndex = 2;
                    break;

                case OLoanTypes.CustomLoanType:
                    _scheduleTypeComboBox.Text = scriptName;
                    break;
            }

            _scheduleTypeComboBox.Enabled = loanType == OLoanTypes.All;
        }

        private void InitializeFundingLine()
        {
            _fundingLine = _product.FundingLine;
        }

        private void InitializeLabelMinMax()
        {
            labelLoanAmountMinMax.Text = String.Empty;
            lbLoanInterestRateMinMax.Text = String.Empty;


            labelLoanNbOfInstallmentsMinMax.Text = String.Empty;
            labelLoanGracePeriodMinMax.Text = String.Empty;
        }

        private void SetPackageValuesForLoanDetails(Loan pLoan, bool pForCreation)
        {
            gbxLoanDetails.Text = MultiLanguageStrings.GetString(Ressource.CreditContractForm, "LoanType.Text") + pLoan.Product.Name;
            if (pForCreation)
            {
                dateLoanStart.Value = TimeProvider.Today;
            }
            else
            {
                _toChangeAlignDate = false;
                dateLoanStart.Value = _credit.StartDate;
                _toChangeAlignDate = true;
            }
            _oldDisbursmentDate = dateLoanStart.Value;
            dtpDateOfFirstInstallment.Value = pForCreation ? GetFirstInstallmentDate() : _credit.FirstInstallmentDate;
            _oldFirstInstalmentDate = dtpDateOfFirstInstallment.Value;
            InitializeLabelMinMax();
            InitializePackageGracePeriod(pLoan.Product, pForCreation);
            InitializeAmount(pLoan, pForCreation);
            InitializePackageInterestRate(pLoan, pForCreation);
            //InitializePackageFundingLineAndCorporate(pLoan.Product.FundingLine, _credit.FundingLine, pForCreation, comboBoxLoanFundingLine);
            InitializePackageNumberOfInstallments(pLoan, pForCreation);
            //InitializePackageAnticipatedTotalRepaymentsPenalties(pLoan.Product, pForCreation);
            //InitializePackageAnticipatedPartialRepaymentsPenalties(pLoan.Product, pForCreation);
            //InitializePackageNonRepaymentPenalties(pLoan.Product, pForCreation);
            //InitializePackageLoanCompulsorySavings(pLoan.Product, pForCreation);
            _changeDisDateBool = false;
        }

        private void InitializePackageFundingLineAndCorporate(Object packageObj, Object creditObj, bool pForCreation,
                                                               ComboBox cmbFundingCorporateDetails)
        {
            cmbFundingCorporateDetails.Enabled = true;
            cmbFundingCorporateDetails.ForeColor = Color.Black;
            cmbFundingCorporateDetails.Font = new Font(Font, FontStyle.Regular);

            if (pForCreation)
            {
                if (packageObj != null)
                {
                    cmbFundingCorporateDetails.Text = packageObj.ToString();
                    cmbFundingCorporateDetails.Tag = packageObj;
                    return;
                }
                cmbFundingCorporateDetails.Enabled = true;
                cmbFundingCorporateDetails.Text = "";
                cmbFundingCorporateDetails.Tag = null;
                return;
            }
            if (creditObj != null)
            {
                cmbFundingCorporateDetails.Text = creditObj.ToString();
                cmbFundingCorporateDetails.Tag = creditObj;
                return;
            }
            cmbFundingCorporateDetails.Text = MultiLanguageStrings.GetString(Ressource.ClientForm, "ContractIsReadOnly.Text");
            cmbFundingCorporateDetails.ForeColor = System.Drawing.Color.Red;
            cmbFundingCorporateDetails.Font = new Font(this.Font, FontStyle.Bold);
            MessageBox.Show(MultiLanguageStrings.GetString(Ressource.ClientForm, "ContractIsReadOnly.Text"));
            cmbFundingCorporateDetails.Tag = null;
        }

        private void InitializePackageNumberOfInstallments(Loan credit, bool pForCreation)
        {
            if (pForCreation)
            {
                nudLoanNbOfInstallments.Enabled = true;
                if (credit.Product.CycleId == null)//if product doesn't use a loan cycle
                {
                    nudLoanNbOfInstallments.Enabled = true;
                    if (credit.Product.NbOfInstallments.HasValue)
                    {
                        nudLoanNbOfInstallments.Minimum = credit.Product.NbOfInstallments.Value;
                        nudLoanNbOfInstallments.Maximum = credit.Product.NbOfInstallments.Value;
                        labelLoanNbOfInstallmentsMinMax.Text = string.Format("{0}{1}\r\n{2}{3}",
                         MultiLanguageStrings.GetString(Ressource.CreditContractForm, "min.Text"),
                         credit.Product.NbOfInstallments.Value,
                         MultiLanguageStrings.GetString(Ressource.CreditContractForm, "max.Text"),
                         credit.Product.NbOfInstallments.Value);
                        nudLoanNbOfInstallments.Value = credit.Product.NbOfInstallments.Value;
                    }
                    else
                    {
                        nudLoanNbOfInstallments.Minimum = credit.Product.NbOfInstallmentsMin.Value;
                        nudLoanNbOfInstallments.Maximum = credit.Product.NbOfInstallmentsMax.Value;
                        labelLoanNbOfInstallmentsMinMax.Text = string.Format("{0}{1}\r\n{2}{3}",
                         MultiLanguageStrings.GetString(Ressource.CreditContractForm, "min.Text"),
                         credit.Product.NbOfInstallmentsMin.Value,
                         MultiLanguageStrings.GetString(Ressource.CreditContractForm, "max.Text"),
                         credit.Product.NbOfInstallmentsMax.Value);
                        nudLoanNbOfInstallments.Value = credit.Product.NbOfInstallmentsMin.Value;
                    }
                }
                else //product uses a loan cycle
                {
                    nudLoanNbOfInstallments.Minimum = credit.Product.NbOfInstallmentsMin.Value;
                    nudLoanNbOfInstallments.Maximum = credit.Product.NbOfInstallmentsMax.Value;
                    labelLoanNbOfInstallmentsMinMax.Text = string.Format("{0}{1}\r\n{2}{3}",
                     MultiLanguageStrings.GetString(Ressource.CreditContractForm, "min.Text"),
                     credit.Product.NbOfInstallmentsMin.Value,
                     MultiLanguageStrings.GetString(Ressource.CreditContractForm, "max.Text"),
                     credit.Product.NbOfInstallmentsMax.Value);
                    nudLoanNbOfInstallments.Value = credit.Product.NbOfInstallmentsMin.Value;
                }
            }
            else//it is an existing contract
            {
                if (credit.Product.CycleId == null)//contract doesn't use loan cycles
                {
                    if (!credit.Product.NbOfInstallments.HasValue)//if it is range value
                    {
                        try
                        {
                            nudLoanNbOfInstallments.Minimum = credit.Product.NbOfInstallmentsMin.Value;
                            nudLoanNbOfInstallments.Maximum = credit.Product.NbOfInstallmentsMax.Value;
                            labelLoanNbOfInstallmentsMinMax.Text = string.Format("{0}{1}\r\n{2}{3}",
                             MultiLanguageStrings.GetString(Ressource.CreditContractForm, "min.Text"),
                             credit.Product.NbOfInstallmentsMin.Value,
                             MultiLanguageStrings.GetString(Ressource.CreditContractForm, "max.Text"),
                             credit.Product.NbOfInstallmentsMax.Value);
                            nudLoanNbOfInstallments.Value = credit.NbOfInstallments;
                        }
                        catch
                        {
                            nudLoanNbOfInstallments.Minimum = nudLoanNbOfInstallments.Maximum = credit.NbOfInstallments;
                            nudLoanNbOfInstallments.Value = credit.NbOfInstallments;
                        }
                    }
                    else
                    {
                        try
                        {
                            nudLoanNbOfInstallments.Minimum = credit.Product.NbOfInstallments.Value;
                            nudLoanNbOfInstallments.Maximum = credit.Product.NbOfInstallments.Value;
                            labelLoanNbOfInstallmentsMinMax.Text = string.Format("{0}{1}\r\n{2}{3}",
                             MultiLanguageStrings.GetString(Ressource.CreditContractForm, "min.Text"),
                             credit.Product.NbOfInstallments.Value,
                             MultiLanguageStrings.GetString(Ressource.CreditContractForm, "max.Text"),
                             credit.Product.NbOfInstallments.Value);
                            nudLoanNbOfInstallments.Value = credit.NbOfInstallments;
                        }
                        catch
                        {
                            nudLoanNbOfInstallments.Minimum = nudLoanNbOfInstallments.Maximum = credit.NbOfInstallments;
                            nudLoanNbOfInstallments.Value = credit.NbOfInstallments;
                        }
                    }
                }
                else //contract uses loan cycle
                {
                    try
                    {
                        nudLoanNbOfInstallments.Minimum = credit.NmbOfInstallmentsMin.Value;
                        nudLoanNbOfInstallments.Maximum = credit.NmbOfInstallmentsMin.Value;
                        labelLoanNbOfInstallmentsMinMax.Text = string.Format("{0}{1}\r\n{2}{3}",
                         MultiLanguageStrings.GetString(Ressource.CreditContractForm, "min.Text"),
                         credit.Product.NbOfInstallmentsMin.Value,
                         MultiLanguageStrings.GetString(Ressource.CreditContractForm, "max.Text"),
                         credit.Product.NbOfInstallmentsMax.Value);
                        nudLoanNbOfInstallments.Value = credit.NbOfInstallments;
                    }
                    catch
                    {
                        nudLoanNbOfInstallments.Minimum = nudLoanNbOfInstallments.Maximum = credit.NbOfInstallments;
                        nudLoanNbOfInstallments.Value = credit.NbOfInstallments;
                    }
                }
            }
        }

        private void InitializePackageInterestRate(Loan credit, bool pForCreation)
        {
            LoanProduct creditProduct = credit.Product;
            string annualType = "";

            if (pForCreation) //if it is new contract
            {
                nudInterestRate.Enabled = true;
                if (!creditProduct.UseLoanCycle) //if product doesn't use any loan cycles
                {
                    if (!creditProduct.InterestRate.HasValue) //if interest rate is a range value
                    {
                        decimal? interestRateMin = creditProduct.InterestRateMin * 100;
                        decimal? interestRateMax = creditProduct.InterestRateMax * 100;
                        nudInterestRate.Minimum = interestRateMin.Value;
                        nudInterestRate.Maximum = interestRateMax.Value;
                        lbLoanInterestRateMinMax.Text = string.Format("{0}{1}\r\n{2}{3}",
                            annualType + MultiLanguageStrings.GetString(Ressource.CreditContractForm, "min.Text"),
                            ServicesHelper.ConvertNullableDecimalToString(interestRateMin.Value, false),
                            MultiLanguageStrings.GetString(Ressource.CreditContractForm, "max.Text"),
                            ServicesHelper.ConvertNullableDecimalToString(interestRateMax.Value, false));
                        nudInterestRate.Value = interestRateMin.Value;
                    }
                    else// if interest rate is a fixed value
                    {
                        decimal? interestRate = creditProduct.InterestRate * 100;
                        nudInterestRate.Minimum = nudInterestRate.Maximum = creditProduct.InterestRate.Value * 100;
                        nudInterestRate.Value = interestRate.Value;
                        lbLoanInterestRateMinMax.Text = string.Format("{0}{1}\r\n{2}{3}",
                            annualType + MultiLanguageStrings.GetString(Ressource.CreditContractForm, "min.Text"),
                            ServicesHelper.ConvertNullableDecimalToString(interestRate.Value, false),
                            MultiLanguageStrings.GetString(Ressource.CreditContractForm, "max.Text"),
                            ServicesHelper.ConvertNullableDecimalToString(interestRate.Value, false));
                    }
                }
                else //if product uses a loan cycle
                {
                    decimal? interestRateMin = creditProduct.InterestRateMin * 100;
                    decimal? interestRateMax = creditProduct.InterestRateMax * 100;
                    nudInterestRate.Minimum = interestRateMin.Value;
                    nudInterestRate.Maximum = interestRateMax.Value;
                    lbLoanInterestRateMinMax.Text = string.Format("{0}{1}\r\n{2}{3}",
                        annualType + MultiLanguageStrings.GetString(Ressource.CreditContractForm, "min.Text"),
                        ServicesHelper.ConvertNullableDecimalToString(interestRateMin.Value, false),
                        MultiLanguageStrings.GetString(Ressource.CreditContractForm, "max.Text"),
                        ServicesHelper.ConvertNullableDecimalToString(interestRateMax.Value, false));
                    nudInterestRate.Value = interestRateMin.Value;
                }
            }
            else // if it is an existing contract
            {
                //if contract doesn't use a loan cycle
                if (credit.LoanCycle == null && credit.InterestRateMin == null && credit.InterestRateMax == null)
                {
                    try
                    {
                        decimal? interestRateMin = creditProduct.InterestRateMin * 100;
                        decimal? interestRateMax = creditProduct.InterestRateMax * 100;
                        nudInterestRate.Minimum = interestRateMin.Value;
                        nudInterestRate.Maximum = interestRateMax.Value;
                        lbLoanInterestRateMinMax.Text = string.Format("{0}{1}\r\n{2}{3}",
                            annualType + MultiLanguageStrings.GetString(Ressource.CreditContractForm, "min.Text"),
                            ServicesHelper.ConvertNullableDecimalToString(interestRateMin.Value, false),
                            MultiLanguageStrings.GetString(Ressource.CreditContractForm, "max.Text"),
                            ServicesHelper.ConvertNullableDecimalToString(interestRateMax.Value, false));
                        nudInterestRate.Value = credit.InterestRate * 100;
                    }
                    catch
                    {
                        nudInterestRate.Minimum = nudInterestRate.Maximum = credit.InterestRate * 100;
                        nudInterestRate.Value = credit.InterestRate * 100;
                    }

                }
                else //contract uses a loan cycle
                {
                    try
                    {
                        decimal? interestRateMin = creditProduct.InterestRateMin * 100;
                        decimal? interestRateMax = creditProduct.InterestRateMax * 100;
                        nudInterestRate.Minimum = interestRateMin.Value;
                        nudInterestRate.Maximum = interestRateMax.Value;
                        lbLoanInterestRateMinMax.Text = string.Format("{0}{1}\r\n{2}{3}",
                            annualType + MultiLanguageStrings.GetString(Ressource.CreditContractForm, "min.Text"),
                            ServicesHelper.ConvertNullableDecimalToString(interestRateMin.Value, false),
                            MultiLanguageStrings.GetString(Ressource.CreditContractForm, "max.Text"),
                            ServicesHelper.ConvertNullableDecimalToString(interestRateMax.Value, false));
                        nudInterestRate.Value = credit.InterestRate * 100;
                    }
                    catch
                    {
                        nudInterestRate.Minimum = nudInterestRate.Maximum = credit.InterestRate * 100;
                        nudInterestRate.Value = credit.InterestRate * 100;
                    }
                }
            }
        }

        private DecimalValueRange _amountValueRange;
        private void InitializeAmount(Loan credit, bool pForCreation)
        {
            if (pForCreation) //if it is new contract
            {
                nudLoanAmount.DecimalPlaces = (credit.Product.Currency.UseCents || _credit.UseCents) ? 2 : 0;
                if (!credit.Product.UseLoanCycle) //If product doesn't use any loan cycle
                {
                    if (!credit.Product.Amount.HasValue) //if credit amount is a range value
                    {
                        try
                        {
                            _amountValueRange = new DecimalValueRange(credit.Product.AmountMin, credit.Product.AmountMax);
                            nudLoanAmount.Enabled = true;
                            labelLoanAmountMinMax.SetRangeText(_amountValueRange.Min, _amountValueRange.Max);
                            nudLoanAmount.Minimum = _amountValueRange.Min.Value;
                            nudLoanAmount.Maximum = _amountValueRange.Max.Value;
                            nudLoanAmount.Value = _amountValueRange.Min.Value;
                        }
                        catch
                        {
                            nudLoanAmount.Minimum = nudLoanAmount.Maximum = credit.Amount.Value;
                            nudLoanAmount.Value = credit.Amount.Value;
                        }
                    }
                    else //if credit amount is a fixed value
                    {
                        try
                        {
                            _amountValueRange = new DecimalValueRange(credit.Product.Amount);
                            OCurrency valueCurrency = _amountValueRange.Value;
                            decimal value = valueCurrency.Value;
                            labelLoanAmountMinMax.SetRangeText(valueCurrency);
                            nudLoanAmount.Minimum = value;
                            nudLoanAmount.Maximum = value;
                            nudLoanAmount.Value = value;
                            nudLoanAmount.Enabled = false;
                        }
                        catch
                        {
                            nudLoanAmount.Minimum = nudLoanAmount.Maximum = credit.Amount.Value;
                            nudLoanAmount.Value = credit.Amount.Value;
                        }
                    }
                }
                else //if product uses loan cycles
                {
                    _amountValueRange = new DecimalValueRange(credit.Product.AmountMin, credit.Product.AmountMax);
                    nudLoanAmount.Enabled = true;
                    labelLoanAmountMinMax.SetRangeText(_amountValueRange.Min, _amountValueRange.Max);
                    nudLoanAmount.Minimum = _amountValueRange.Min.Value;
                    nudLoanAmount.Maximum = _amountValueRange.Max.Value;
                    nudLoanAmount.Value = _amountValueRange.Min.Value;
                }
            }
            else //if it is an existing contract
            {
                nudLoanAmount.DecimalPlaces = (credit.Product.Currency.UseCents) ? 2 : 0;

                if (credit.LoanCycle == null && !credit.AmountMin.HasValue && !credit.AmountMax.HasValue)//if contract doesn't use any loan cycles
                {
                    if (credit.Product.Amount.HasValue)//if credit amount is a fixed value
                    {
                        try
                        {
                            _amountValueRange = new DecimalValueRange(credit.Product.Amount);
                            labelLoanAmountMinMax.SetRangeText(_amountValueRange.Value);
                            nudLoanAmount.Minimum = nudLoanAmount.Maximum = _amountValueRange.Value.Value;
                        }
                        catch (Exception)
                        {
                            nudLoanAmount.Minimum = nudLoanAmount.Maximum = credit.Amount.Value;
                            nudLoanAmount.Value = credit.Amount.Value;
                        }

                    }
                    else //if credit amount is range vale
                    {
                        try
                        {
                            _amountValueRange = new DecimalValueRange(credit.Product.AmountMin, credit.Product.AmountMax);
                            labelLoanAmountMinMax.SetRangeText(_amountValueRange.Min, _amountValueRange.Max);
                            nudLoanAmount.Minimum = _amountValueRange.Min.Value;
                            nudLoanAmount.Maximum = _amountValueRange.Max.Value;
                            nudLoanAmount.Value = credit.Amount.Value;
                        }
                        catch
                        {
                            nudLoanAmount.Minimum = nudLoanAmount.Maximum = credit.Amount.Value;
                            nudLoanAmount.Value = credit.Amount.Value;
                        }
                    }
                }
                else //if product  uses loan cycles
                {
                    try
                    {
                        _amountValueRange = new DecimalValueRange(credit.AmountMin, credit.AmountMax);
                        nudLoanAmount.Enabled = true;
                        labelLoanAmountMinMax.SetRangeText(_amountValueRange.Min, _amountValueRange.Max);
                        nudLoanAmount.Minimum = _amountValueRange.Min.Value;
                        nudLoanAmount.Maximum = _amountValueRange.Max.Value;
                        nudLoanAmount.Value = credit.Amount.Value;
                    }
                    catch
                    {
                        nudLoanAmount.Minimum = nudLoanAmount.Maximum = credit.Amount.Value;
                        nudLoanAmount.Value = credit.Amount.Value;
                    }
                }
            }

            nudLoanAmount.Text = nudLoanAmount.Value.ToString(); //Workaround for text emptyness
        }

        private void InitializePackageGracePeriod(LoanProduct pPackage, bool pForCreation)
        {
            if (!pPackage.GracePeriod.HasValue) //Min and Max
            {
                numericUpDownLoanGracePeriod.Enabled = true;
                if (pForCreation)
                {
                    numericUpDownLoanGracePeriod.Minimum = pPackage.GracePeriodMin.Value;
                    numericUpDownLoanGracePeriod.Maximum = pPackage.GracePeriodMax.Value;
                }
                labelLoanGracePeriodMinMax.Text = string.Format("{0}{1}\r\n{2}{3}",
                                MultiLanguageStrings.GetString(Ressource.CreditContractForm, "min.Text"),
                                pPackage.GracePeriodMin.Value,
                                MultiLanguageStrings.GetString(Ressource.CreditContractForm, "max.Text"),
                                pPackage.GracePeriodMax.Value);
                if (!pForCreation) numericUpDownLoanGracePeriod.Value = _credit.GracePeriod.Value;
            }
            else //value
            {

                numericUpDownLoanGracePeriod.Enabled = false;
                numericUpDownLoanGracePeriod.Minimum = pForCreation ? pPackage.GracePeriod.Value : (_credit.GracePeriod ?? 0);
                numericUpDownLoanGracePeriod.Maximum = pForCreation ? pPackage.GracePeriod.Value : (_credit.GracePeriod ?? 0);
                numericUpDownLoanGracePeriod.Value = pForCreation ? pPackage.GracePeriod.Value : (_credit.GracePeriod ?? 0);
            }
        }
        
        private void buttonLoanPreview_Click(object sender, EventArgs e)
        {
            Preview();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Preview();
            Print();
        }

        private OLoanTypes GetScheduleType()
        {
            switch (_scheduleTypeComboBox.SelectedIndex)
            {
                case 0:
                    return OLoanTypes.Flat;

                case 1:
                    return OLoanTypes.DecliningFixedPrincipal;

                case 2:
                    return OLoanTypes.DecliningFixedInstallments;

                default:
                    return OLoanTypes.CustomLoanType;
            }
        }

        private string GetScriptName()
        {
            if (_scheduleTypeComboBox.SelectedIndex >= 3)
            {
                return _scheduleTypeComboBox.Text;
            }
            return null;
        }

        private Loan CreateLoan()
        {
            var credit = new Loan(_product,
                                       ServicesHelper.ConvertStringToDecimal(nudLoanAmount.Text, _product.UseCents),
                                       nudInterestRate.Value / 100m,
                                       Convert.ToInt32(nudLoanNbOfInstallments.Value),
                                       Convert.ToInt32(numericUpDownLoanGracePeriod.Value),
                                       dateLoanStart.Value,
                                       dtpDateOfFirstInstallment.Value,
                                       User.CurrentUser,
                                       ServicesProvider.GetInstance().GetGeneralSettings(),
                                       ServicesProvider.GetInstance().GetNonWorkingDate(),
                                       CoreDomainProvider.GetInstance().GetProvisioningTable())
            {
                Guarantors = _listGuarantors,
                Collaterals = _collaterals,
                LoanShares = _loanShares,
                InstallmentType = (InstallmentType)_installmentTypeComboBox.SelectedItem,
                ScheduleType = GetScheduleType(),
                ScriptName = GetScriptName()
            };
            credit.LoanOfficer = User.CurrentUser;
            credit.FundingLine = _fundingLine;
            credit.EconomicActivityId = 1;
            credit.InstallmentList = ServicesProvider.GetInstance().GetContractServices().SimulateScheduleCreation(credit);

            _toChangeAlignDate = false;
            credit.FirstInstallmentDate = dtpDateOfFirstInstallment.Value;
            _toChangeAlignDate = true;

            _firstInstallmentDate = dtpDateOfFirstInstallment.Value;

            credit.AlignDisbursementDate = credit.CalculateAlignDisbursementDate(_firstInstallmentDate);

            //credit.AnticipatedTotalRepaymentPenalties = ServicesHelper.ConvertStringToNullableDouble(textBoxLoanAnticipatedTotalFees.Text, true, -1).Value;
            //credit.AnticipatedPartialRepaymentPenalties = ServicesHelper.ConvertStringToNullableDouble(tbLoanAnticipatedPartialFees.Text, true, -1).Value;
            //credit.NonRepaymentPenalties.InitialAmount = ServicesHelper.ConvertStringToNullableDouble(textBoxLoanLateFeesOnAmount.Text, true, -1).Value;
            //credit.NonRepaymentPenalties.OLB = ServicesHelper.ConvertStringToNullableDouble(textBoxLoanLateFeesOnOLB.Text, true, -1).Value;
            //credit.NonRepaymentPenalties.OverDueInterest = ServicesHelper.ConvertStringToNullableDouble(textBoxLoanLateFeesOnOverdueInterest.Text, true, -1).Value;
            //credit.NonRepaymentPenalties.OverDuePrincipal = ServicesHelper.ConvertStringToNullableDouble(textBoxLoanLateFeesOnOverduePrincipal.Text, true, -1).Value;
            credit.GracePeriod = Convert.ToInt32(numericUpDownLoanGracePeriod.Value);
            credit.GracePeriodOfLateFees = Convert.ToInt32(_gracePeriodOfLateFees);

            credit.LoanEntryFeesList = new List<LoanEntryFee>();

            if (credit.Product.CycleId != null)
            {
                credit.AmountMin = _product.AmountMin;
                credit.AmountMax = _product.AmountMax;
                credit.InterestRateMin = _product.InterestRateMin;
                credit.InterestRateMax = _product.InterestRateMax;
                credit.NmbOfInstallmentsMin = _product.NbOfInstallmentsMin;
                credit.NmbOfInstallmentsMax = _product.NbOfInstallmentsMax;
                credit.LoanCycle = _client.LoanCycle;
            }

            //credit.Insurance = decimal.Parse(tbInsurance.Text);
            if (_credit != null && _credit.ScheduleChangedManually)
            {
                credit.ScheduleChangedManually = _credit.ScheduleChangedManually;
                credit.InstallmentList = _credit.InstallmentList;
            }
            //credit.EconomicActivity = eacLoan.Activity;
            return credit;
        }

        private Loan CreateAndSetContract()
        {
            if (_credit == null)
            {
                _credit = CreateLoan();
            }
            else if (_credit.Id == 0)
            {
                _credit = CreateLoan();
            }
            else
            {
                _credit.Guarantors = _listGuarantors;
                _credit.Collaterals = _collaterals;
                _credit.LoanShares = _loanShares;
                _credit.Amount = ServicesHelper.ConvertStringToDecimal(nudLoanAmount.Text, _credit.UseCents);
                _credit.StartDate = dateLoanStart.Value;
                _credit.FirstInstallmentDate = dtpDateOfFirstInstallment.Value;
                dtpDateOfFirstInstallment.Value = _credit.FirstInstallmentDate;
                _credit.InterestRate = ServicesHelper.ConvertStringToNullableDecimal(nudInterestRate.Text, true, -1).Value;
                _credit.NbOfInstallments = Convert.ToInt32(nudLoanNbOfInstallments.Value);
                _credit.InstallmentType = (InstallmentType)_installmentTypeComboBox.SelectedItem;
                _credit.ScheduleType = GetScheduleType();
                _credit.ScriptName = GetScriptName();
                if (_credit.ContractStatus == OContractStatus.Pending)
                {
                    _credit.AlignDisbursementDate = _credit.CalculateAlignDisbursementDate(_credit.FirstInstallmentDate);
                }

                //_credit.AnticipatedTotalRepaymentPenalties = ServicesHelper.ConvertStringToNullableDouble(textBoxLoanAnticipatedTotalFees.Text, true, -1).Value;
                //_credit.AnticipatedPartialRepaymentPenalties = ServicesHelper.ConvertStringToNullableDouble(tbLoanAnticipatedPartialFees.Text, true, -1).Value;
                //_credit.NonRepaymentPenalties.InitialAmount = ServicesHelper.ConvertStringToNullableDouble(textBoxLoanLateFeesOnAmount.Text, true, -1).Value;
                //_credit.NonRepaymentPenalties.OLB = ServicesHelper.ConvertStringToNullableDouble(textBoxLoanLateFeesOnOLB.Text, true, -1).Value;
                //_credit.NonRepaymentPenalties.OverDueInterest = ServicesHelper.ConvertStringToNullableDouble(textBoxLoanLateFeesOnOverdueInterest.Text, true, -1).Value;
                //_credit.NonRepaymentPenalties.OverDuePrincipal = ServicesHelper.ConvertStringToNullableDouble(textBoxLoanLateFeesOnOverduePrincipal.Text, true, -1).Value;
                _credit.GracePeriod = Convert.ToInt32(numericUpDownLoanGracePeriod.Value);
                _credit.GracePeriodOfLateFees = _gracePeriodOfLateFees;

                _credit.LoanOfficer = User.CurrentUser;
                _credit.LoanInitialOfficer = _credit.LoanOfficer;

                if (!_credit.Disbursed && !_credit.ScheduleChangedManually)
                    _credit.InstallmentList =
                        ServicesProvider.GetInstance().GetContractServices().SimulateScheduleCreation(_credit);
            }

            return _credit;
        }

        private Loan Preview()
        {
            try
            {
                Loan credit = CreateAndSetContract();
                ServicesProvider.GetInstance().GetContractServices().CheckLoanFilling(credit);
                DisplayInstallments(ref credit);

                var extentions = _applicationController.GetAllInstances<IClientFormInitializer>();
                foreach (var extention in extentions)
                {
                    extention.Refresh(this);
                }
                return credit;
            }
            catch (Exception ex)
            {
                new frmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }

            return null;
        }

        public void Print()
        {
            _applicationController.Execute(new ExtendedPrintControlCommandData { Control = _loanDetailsScheduleControl1.Control , AdditionalValues = GetReportData(), StartPosition = "A8"});

        }

        private Dictionary<string,string> GetReportData()
        {
            var result = new Dictionary<string, string>();
            result.Add("B1", "Name of product:");
            result.Add("C1", _product.Name);

            result.Add("B2", "Amount:");
            result.Add("C2", _credit.Amount.ToString());

            result.Add("B3", "Grace period:");
            result.Add("C3", _credit.GracePeriod.ToString());

            result.Add("B4", "Number of installments:");
            result.Add("C4", _credit.NbOfInstallments.ToString());

            result.Add("B5", "Installment type:");
            result.Add("C5", _credit.InstallmentType.Name);

            result.Add("B6", "Schedule type:");
            result.Add("C6", GetString("FrmAddLoanProduct", _credit.ScheduleType+".Text"));

            return result;
        }
        private void DisplayInstallments(ref Loan pCredit)
        {
            FillInstallmentListForScheduleControl("loanDetailsScheduleControl", _credit);
            if (ApplicationSettings.GetInstance(User.CurrentUser.Md5).ShowExtraInterestColumn)
                _loanDetailsScheduleControl1.ShowExtraColumn();
            if (pCredit.InstallmentList.Count == 0)
            {
                pCredit.Product = _product;
            }
        }

        private void FillInstallmentListForScheduleControl(string nameOfSchedule, Loan credit)
        {
            var ifShowTotalRowInSchedule = ServicesProvider.GetInstance().GetGeneralSettings().IsShowTotalRowInSchedule;
            if (ifShowTotalRowInSchedule)
            {
                var installmentList = credit.InstallmentList;
                installmentList.RemoveAll(x => x.ExpectedDate == DateTime.MaxValue);
                if (installmentList.Count > 0)
                {
                    installmentList.Add(new Installment());
                    installmentList.LastOrDefault().Number = 0;
                    installmentList.LastOrDefault().ExpectedDate = DateTime.MaxValue;
                    installmentList.LastOrDefault().InterestsRepayment = 0;
                    installmentList.LastOrDefault().InterestsRepayment =
                        installmentList.Sum(x => x.InterestsRepayment.Value);
                    installmentList.LastOrDefault().PaidInterests = 0;
                    installmentList.LastOrDefault().PaidInterests = installmentList.Sum(x => x.PaidInterests.Value);
                    installmentList.LastOrDefault().CapitalRepayment = 0;
                    installmentList.LastOrDefault().CapitalRepayment = installmentList.Sum(x => x.CapitalRepayment.Value);
                    installmentList.LastOrDefault().PaidCapital = 0;
                    installmentList.LastOrDefault().PaidCapital = installmentList.Sum(x => x.PaidCapital.Value);
                    installmentList.LastOrDefault().ExtraAmount2 = 0;
                    installmentList.LastOrDefault().ExtraAmount2 = installmentList.Sum(x => x.ExtraAmount2.Value);
                    installmentList.LastOrDefault().OLB = installmentList.LastOrDefault().CapitalRepayment;
                }
                else
                    ifShowTotalRowInSchedule = false;
            }

            _loanDetailsScheduleControl1.SetScheduleFor(credit);

            if (ifShowTotalRowInSchedule)
            {
                Control controls = _loanDetailsScheduleControl1.Controls.Find("scheduleObjectListView", true)[0];
                if (controls != null)
                {
                    var schedule = ((ObjectListView) controls);
                    if (schedule.Items.Count > 0)
                        schedule.Items[schedule.Items.Count - 1].Font =
                            new Font(schedule.Items[schedule.Items.Count - 1].Font, FontStyle.Bold);
                }
            }
        }

        private void cmbPackages_SelectedIndexChanged(object sender, EventArgs e)
        {
            var keyValuePair = (KeyValuePair<string, LoanProduct>) cmbPackages.SelectedItem;
            _product = keyValuePair.Value;
            InitializeTabPageLoansDetails(_product);

        }

        private DateTime GetFirstInstallmentDate()
        {
            DateTime date = dateLoanStart.Value;

            bool isSet = false;

            if (_credit.InstallmentType != null)
            {
                if (_credit.InstallmentType.NbOfDays > 0)
                {
                    date = date.AddDays(_credit.InstallmentType.NbOfDays);
                }

                if (_credit.InstallmentType.NbOfMonths > 0)
                {
                    date = date.AddMonths(_credit.InstallmentType.NbOfMonths);
                }

                isSet = true;
            }

            if (_product != null && !isSet)
            {
                if (_product.InstallmentType.NbOfDays > 0)
                {
                    date = date.AddDays(_product.InstallmentType.NbOfDays);
                }

                if (_product.InstallmentType.NbOfMonths > 0)
                {
                    date = date.AddMonths(_product.InstallmentType.NbOfMonths);
                }
            }

            if (_group != null)
            {
                if (_group.MeetingDay.HasValue)
                {
                    int delta = ServicesProvider.GetInstance().GetGeneralSettings().IsIncrementalDuringDayOff ? 1 : -1;
                    while (date.DayOfWeek != _group.MeetingDay)
                    {
                        date = date.AddDays(delta);
                    }

                    date = ServicesProvider.GetInstance().GetNonWorkingDate().GetTheNearestValidDate(date,
                                                                                                     ServicesProvider.
                                                                                                         GetInstance().
                                                                                                         GetGeneralSettings().
                                                                                                         IsIncrementalDuringDayOff,
                                                                                                     ServicesProvider.
                                                                                                         GetInstance().
                                                                                                         GetGeneralSettings().
                                                                                                         DoNotSkipNonWorkingDays,
                                                                                                     false);
                }
            }
            return date;
        }

        private void dateLoanStart_ValueChanged(object sender, EventArgs e)
        {
            _changeDisDateBool = true;
            dtpDateOfFirstInstallment.Value = GetFirstInstallmentDate();
            _oldFirstInstalmentDate = dtpDateOfFirstInstallment.Value;
            try
            {
                if (_oldDisbursmentDate.Date != dateLoanStart.Value.Date && _oldDisbursmentDate != new DateTime(1, 1, 1))
                    ServicesProvider.GetInstance().GetContractServices().ModifyDisbursementDate(
                        dateLoanStart.Value.Date);

                if (dateLoanStart.Value > dtpDateOfFirstInstallment.Value)
                {
                    dtpDateOfFirstInstallment.Value = dateLoanStart.Value;
                }

                if (_credit != null && _credit.Product != null && _toChangeAlignDate)
                {
                    _credit.AlignDisbursementDate = _credit.CalculateAlignDisbursementDate(dtpDateOfFirstInstallment.Value);
                    _firstInstallmentDate = dtpDateOfFirstInstallment.Value;
                }

                lblDay.Text = dtpDateOfFirstInstallment.Value.Date.DayOfWeek.ToString();
                _oldDisbursmentDate = dateLoanStart.Value.Date;
            }
            catch (Exception ex)
            {
                dateLoanStart.Value = _oldDisbursmentDate;
                new frmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
                throw;
            }
        }

        private void dtpDateOfFirstInstallment_ValueChanged(object sender, EventArgs e)
        {
            lblDay.Text = dtpDateOfFirstInstallment.Value.Date.DayOfWeek.ToString();
        }
    }
}
