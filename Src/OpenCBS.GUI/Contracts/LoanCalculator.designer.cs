using System.Globalization;
using System.Windows.Forms;
using OpenCBS.GUI.UserControl;

namespace OpenCBS.GUI.Clients
{
    public partial class LoanCalculator
    {
        private SplitContainer splitContainer3;
        private Panel panelUserControl;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel2;
        private Label labelTitleRepayment;
        private Button buttonPrintSchedule;
        private Button buttonReschedule;
        private Button buttonRepay;
        private ColumnHeader columnHeaderDate;
        private ColumnHeader columnHeaderType;
        private ColumnHeader columnHeaderPrincipal;
        private ColumnHeader columnHeaderInterest;
        private ColumnHeader columnHeaderFees;
        private ColumnHeader columnHeader10;
        private TableLayoutPanel tableLayoutPanel3;
        private Button buttonLoanDisbursement;
        private SplitContainer splitContainer4;
        private SplitContainer splitContainer6;
        private Label labelExchangeRate;
        private TabPage tabPageLoansDetails;
        private GroupBox gbxLoanDetails;
        private Label lbLoanInterestRateMinMax;
        private Label labelLoanAmountMinMax;
        private NumericUpDown numericUpDownLoanGracePeriod;
        private Label labelLoanGracePeriod;
        private Label labelLoanStartDate;
        private DateTimePicker dateLoanStart;
        private Label labelLoanAmount;
        private Label labelLoanInterestRate;
        private Label labelLoanNbOfInstallments;
        private NumericUpDown nudLoanNbOfInstallments;
        private System.Windows.Forms.Button buttonLoanPreview;
        private System.ComponentModel.IContainer components;

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoanCalculator));
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.panelUserControl = new System.Windows.Forms.Panel();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.tabPageLoansDetails = new System.Windows.Forms.TabPage();
            this.loanDetailsButtonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonLoanPreview = new System.Windows.Forms.Button();
            this.gbxLoanDetails = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this._loanDetailsScheduleControl1 = new OpenCBS.Controls.ScheduleControl();
            this.label3 = new System.Windows.Forms.Label();
            this._scheduleTypeComboBox = new System.Windows.Forms.ComboBox();
            this._installmentTypeComboBox = new System.Windows.Forms.ComboBox();
            this._installmentTypeLabel = new System.Windows.Forms.Label();
            this.labelDateOffirstInstallment = new System.Windows.Forms.Label();
            this.labelLoanAmountMinMax = new System.Windows.Forms.Label();
            this.labelLoanNbOfInstallmentsMinMax = new System.Windows.Forms.Label();
            this.dtpDateOfFirstInstallment = new System.Windows.Forms.DateTimePicker();
            this.labelLoanGracePeriodMinMax = new System.Windows.Forms.Label();
            this.labelLoanAmount = new System.Windows.Forms.Label();
            this.labelLoanInterestRate = new System.Windows.Forms.Label();
            this.dateLoanStart = new System.Windows.Forms.DateTimePicker();
            this.labelLoanNbOfInstallments = new System.Windows.Forms.Label();
            this.labelLoanStartDate = new System.Windows.Forms.Label();
            this.lbLoanInterestRateMinMax = new System.Windows.Forms.Label();
            this.labelLoanGracePeriod = new System.Windows.Forms.Label();
            this.numericUpDownLoanGracePeriod = new System.Windows.Forms.NumericUpDown();
            this.nudLoanNbOfInstallments = new System.Windows.Forms.NumericUpDown();
            this.lblDay = new System.Windows.Forms.Label();
            this.nudLoanAmount = new System.Windows.Forms.NumericUpDown();
            this.nudInterestRate = new System.Windows.Forms.NumericUpDown();
            this._scheduleTypeLabel = new System.Windows.Forms.Label();
            this.cmbPackages = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dtpTernDepositDateEnd = new System.Windows.Forms.DateTimePicker();
            this.lblTernDepositDateStarted = new System.Windows.Forms.Label();
            this.lblNumberOfPeriods = new System.Windows.Forms.Label();
            this.nudNumberOfPeriods = new System.Windows.Forms.NumericUpDown();
            this.cmbRollover2 = new System.Windows.Forms.ComboBox();
            this.dtpTernDepositDateStarted = new System.Windows.Forms.DateTimePicker();
            this.lbRollover2 = new System.Windows.Forms.Label();
            this.lblTernDepositDateEnd = new System.Windows.Forms.Label();
            this.tbTargetAccount2 = new System.Windows.Forms.TextBox();
            this.lblTermTransferToAccount = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btSearchContract2 = new System.Windows.Forms.Button();
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.olvColumnSACExportedBalance = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnLACExportedBalance = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTitleRepayment = new System.Windows.Forms.Label();
            this.buttonPrintSchedule = new System.Windows.Forms.Button();
            this.buttonReschedule = new System.Windows.Forms.Button();
            this.buttonRepay = new System.Windows.Forms.Button();
            this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPrincipal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderInterest = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFees = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLoanDisbursement = new System.Windows.Forms.Button();
            this.labelExchangeRate = new System.Windows.Forms.Label();
            this.toolStripSeparatorCopy = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemEditComment = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCancelPending = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemConfirmPending = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.SuspendLayout();
            this.gbxLoanDetails.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLoanGracePeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLoanNbOfInstallments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLoanAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterestRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfPeriods)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer3
            // 
            resources.ApplyResources(this.splitContainer3, "splitContainer3");
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.panelUserControl);
            // 
            // panelUserControl
            // 
            resources.ApplyResources(this.panelUserControl, "panelUserControl");
            this.panelUserControl.Name = "panelUserControl";
            // 
            // splitContainer4
            // 
            resources.ApplyResources(this.splitContainer4, "splitContainer4");
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer6
            // 
            resources.ApplyResources(this.splitContainer6, "splitContainer6");
            this.splitContainer6.Name = "splitContainer6";
            // 
            // tabPageLoansDetails
            // 
            resources.ApplyResources(this.tabPageLoansDetails, "tabPageLoansDetails");
            this.tabPageLoansDetails.Name = "tabPageLoansDetails";
            // 
            // loanDetailsButtonsPanel
            // 
            resources.ApplyResources(this.loanDetailsButtonsPanel, "loanDetailsButtonsPanel");
            this.loanDetailsButtonsPanel.Name = "loanDetailsButtonsPanel";
            // 
            // buttonLoanPreview
            // 
            resources.ApplyResources(this.buttonLoanPreview, "buttonLoanPreview");
            this.buttonLoanPreview.Name = "buttonLoanPreview";
            this.buttonLoanPreview.Click += new System.EventHandler(this.buttonLoanPreview_Click);
            // 
            // gbxLoanDetails
            // 
            resources.ApplyResources(this.gbxLoanDetails, "gbxLoanDetails");
            this.gbxLoanDetails.Controls.Add(this.tableLayoutPanel4);
            this.gbxLoanDetails.Name = "gbxLoanDetails";
            this.gbxLoanDetails.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this._loanDetailsScheduleControl1, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this._scheduleTypeComboBox, 1, 6);
            this.tableLayoutPanel4.Controls.Add(this._installmentTypeComboBox, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this._installmentTypeLabel, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.labelDateOffirstInstallment, 0, 8);
            this.tableLayoutPanel4.Controls.Add(this.labelLoanAmountMinMax, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.labelLoanNbOfInstallmentsMinMax, 2, 4);
            this.tableLayoutPanel4.Controls.Add(this.dtpDateOfFirstInstallment, 1, 8);
            this.tableLayoutPanel4.Controls.Add(this.labelLoanGracePeriodMinMax, 2, 3);
            this.tableLayoutPanel4.Controls.Add(this.labelLoanAmount, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.labelLoanInterestRate, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.dateLoanStart, 1, 7);
            this.tableLayoutPanel4.Controls.Add(this.labelLoanNbOfInstallments, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.labelLoanStartDate, 0, 7);
            this.tableLayoutPanel4.Controls.Add(this.lbLoanInterestRateMinMax, 2, 2);
            this.tableLayoutPanel4.Controls.Add(this.labelLoanGracePeriod, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.numericUpDownLoanGracePeriod, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.nudLoanNbOfInstallments, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.lblDay, 2, 8);
            this.tableLayoutPanel4.Controls.Add(this.nudLoanAmount, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.nudInterestRate, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this._scheduleTypeLabel, 0, 6);
            this.tableLayoutPanel4.Controls.Add(this.cmbPackages, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonLoanPreview, 1, 9);
            this.tableLayoutPanel4.Controls.Add(this.btnPrint, 0, 9);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // _loanDetailsScheduleControl1
            // 
            resources.ApplyResources(this._loanDetailsScheduleControl1, "_loanDetailsScheduleControl1");
            this._loanDetailsScheduleControl1.Name = "_loanDetailsScheduleControl1";
            this.tableLayoutPanel4.SetRowSpan(this._loanDetailsScheduleControl1, 20);
            this._loanDetailsScheduleControl1.ShowOlbAfterRepayment = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Name = "label3";
            // 
            // _scheduleTypeComboBox
            // 
            this.tableLayoutPanel4.SetColumnSpan(this._scheduleTypeComboBox, 2);
            this._scheduleTypeComboBox.DisplayMember = "Name";
            this._scheduleTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._scheduleTypeComboBox.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this._scheduleTypeComboBox, "_scheduleTypeComboBox");
            this._scheduleTypeComboBox.Name = "_scheduleTypeComboBox";
            this._scheduleTypeComboBox.ValueMember = "Id";
            // 
            // _installmentTypeComboBox
            // 
            this.tableLayoutPanel4.SetColumnSpan(this._installmentTypeComboBox, 2);
            this._installmentTypeComboBox.DisplayMember = "Name";
            this._installmentTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._installmentTypeComboBox.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this._installmentTypeComboBox, "_installmentTypeComboBox");
            this._installmentTypeComboBox.Name = "_installmentTypeComboBox";
            this._installmentTypeComboBox.ValueMember = "Id";
            // 
            // _installmentTypeLabel
            // 
            resources.ApplyResources(this._installmentTypeLabel, "_installmentTypeLabel");
            this._installmentTypeLabel.BackColor = System.Drawing.Color.Transparent;
            this._installmentTypeLabel.Name = "_installmentTypeLabel";
            // 
            // labelDateOffirstInstallment
            // 
            resources.ApplyResources(this.labelDateOffirstInstallment, "labelDateOffirstInstallment");
            this.labelDateOffirstInstallment.BackColor = System.Drawing.Color.Transparent;
            this.labelDateOffirstInstallment.Name = "labelDateOffirstInstallment";
            // 
            // labelLoanAmountMinMax
            // 
            resources.ApplyResources(this.labelLoanAmountMinMax, "labelLoanAmountMinMax");
            this.labelLoanAmountMinMax.BackColor = System.Drawing.Color.Transparent;
            this.labelLoanAmountMinMax.Name = "labelLoanAmountMinMax";
            // 
            // labelLoanNbOfInstallmentsMinMax
            // 
            resources.ApplyResources(this.labelLoanNbOfInstallmentsMinMax, "labelLoanNbOfInstallmentsMinMax");
            this.labelLoanNbOfInstallmentsMinMax.BackColor = System.Drawing.Color.Transparent;
            this.labelLoanNbOfInstallmentsMinMax.Name = "labelLoanNbOfInstallmentsMinMax";
            // 
            // dtpDateOfFirstInstallment
            // 
            resources.ApplyResources(this.dtpDateOfFirstInstallment, "dtpDateOfFirstInstallment");
            this.dtpDateOfFirstInstallment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateOfFirstInstallment.Name = "dtpDateOfFirstInstallment";
            // 
            // labelLoanGracePeriodMinMax
            // 
            resources.ApplyResources(this.labelLoanGracePeriodMinMax, "labelLoanGracePeriodMinMax");
            this.labelLoanGracePeriodMinMax.BackColor = System.Drawing.Color.Transparent;
            this.labelLoanGracePeriodMinMax.Name = "labelLoanGracePeriodMinMax";
            // 
            // labelLoanAmount
            // 
            resources.ApplyResources(this.labelLoanAmount, "labelLoanAmount");
            this.labelLoanAmount.BackColor = System.Drawing.Color.Transparent;
            this.labelLoanAmount.Name = "labelLoanAmount";
            // 
            // labelLoanInterestRate
            // 
            resources.ApplyResources(this.labelLoanInterestRate, "labelLoanInterestRate");
            this.labelLoanInterestRate.BackColor = System.Drawing.Color.Transparent;
            this.labelLoanInterestRate.Name = "labelLoanInterestRate";
            // 
            // dateLoanStart
            // 
            resources.ApplyResources(this.dateLoanStart, "dateLoanStart");
            this.dateLoanStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateLoanStart.Name = "dateLoanStart";
            this.dateLoanStart.ValueChanged += new System.EventHandler(this.dateLoanStart_ValueChanged);
            // 
            // labelLoanNbOfInstallments
            // 
            this.labelLoanNbOfInstallments.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.labelLoanNbOfInstallments, "labelLoanNbOfInstallments");
            this.labelLoanNbOfInstallments.Name = "labelLoanNbOfInstallments";
            // 
            // labelLoanStartDate
            // 
            resources.ApplyResources(this.labelLoanStartDate, "labelLoanStartDate");
            this.labelLoanStartDate.BackColor = System.Drawing.Color.Transparent;
            this.labelLoanStartDate.Name = "labelLoanStartDate";
            // 
            // lbLoanInterestRateMinMax
            // 
            resources.ApplyResources(this.lbLoanInterestRateMinMax, "lbLoanInterestRateMinMax");
            this.lbLoanInterestRateMinMax.Name = "lbLoanInterestRateMinMax";
            // 
            // labelLoanGracePeriod
            // 
            resources.ApplyResources(this.labelLoanGracePeriod, "labelLoanGracePeriod");
            this.labelLoanGracePeriod.BackColor = System.Drawing.Color.Transparent;
            this.labelLoanGracePeriod.Name = "labelLoanGracePeriod";
            // 
            // numericUpDownLoanGracePeriod
            // 
            resources.ApplyResources(this.numericUpDownLoanGracePeriod, "numericUpDownLoanGracePeriod");
            this.numericUpDownLoanGracePeriod.ForeColor = System.Drawing.SystemColors.WindowText;
            this.numericUpDownLoanGracePeriod.Name = "numericUpDownLoanGracePeriod";
            // 
            // nudLoanNbOfInstallments
            // 
            resources.ApplyResources(this.nudLoanNbOfInstallments, "nudLoanNbOfInstallments");
            this.nudLoanNbOfInstallments.Name = "nudLoanNbOfInstallments";
            // 
            // lblDay
            // 
            resources.ApplyResources(this.lblDay, "lblDay");
            this.lblDay.Name = "lblDay";
            // 
            // nudLoanAmount
            // 
            resources.ApplyResources(this.nudLoanAmount, "nudLoanAmount");
            this.nudLoanAmount.Name = "nudLoanAmount";
            // 
            // nudInterestRate
            // 
            this.nudInterestRate.DecimalPlaces = 10;
            this.nudInterestRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            resources.ApplyResources(this.nudInterestRate, "nudInterestRate");
            this.nudInterestRate.Name = "nudInterestRate";
            // 
            // _scheduleTypeLabel
            // 
            resources.ApplyResources(this._scheduleTypeLabel, "_scheduleTypeLabel");
            this._scheduleTypeLabel.Name = "_scheduleTypeLabel";
            // 
            // cmbPackages
            // 
            this.cmbPackages.DisplayMember = "Name";
            this.cmbPackages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPackages.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.cmbPackages, "cmbPackages");
            this.cmbPackages.Name = "cmbPackages";
            this.cmbPackages.ValueMember = "Id";
            this.cmbPackages.SelectedIndexChanged += new System.EventHandler(this.cmbPackages_SelectedIndexChanged);
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dtpTernDepositDateEnd
            // 
            resources.ApplyResources(this.dtpTernDepositDateEnd, "dtpTernDepositDateEnd");
            this.dtpTernDepositDateEnd.Name = "dtpTernDepositDateEnd";
            // 
            // lblTernDepositDateStarted
            // 
            resources.ApplyResources(this.lblTernDepositDateStarted, "lblTernDepositDateStarted");
            this.lblTernDepositDateStarted.Name = "lblTernDepositDateStarted";
            // 
            // lblNumberOfPeriods
            // 
            resources.ApplyResources(this.lblNumberOfPeriods, "lblNumberOfPeriods");
            this.lblNumberOfPeriods.Name = "lblNumberOfPeriods";
            // 
            // nudNumberOfPeriods
            // 
            resources.ApplyResources(this.nudNumberOfPeriods, "nudNumberOfPeriods");
            this.nudNumberOfPeriods.Name = "nudNumberOfPeriods";
            // 
            // cmbRollover2
            // 
            this.cmbRollover2.DisplayMember = "id";
            this.cmbRollover2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRollover2.FormattingEnabled = true;
            resources.ApplyResources(this.cmbRollover2, "cmbRollover2");
            this.cmbRollover2.Name = "cmbRollover2";
            this.cmbRollover2.ValueMember = "rollover";
            // 
            // dtpTernDepositDateStarted
            // 
            resources.ApplyResources(this.dtpTernDepositDateStarted, "dtpTernDepositDateStarted");
            this.dtpTernDepositDateStarted.Name = "dtpTernDepositDateStarted";
            // 
            // lbRollover2
            // 
            resources.ApplyResources(this.lbRollover2, "lbRollover2");
            this.lbRollover2.Name = "lbRollover2";
            // 
            // lblTernDepositDateEnd
            // 
            resources.ApplyResources(this.lblTernDepositDateEnd, "lblTernDepositDateEnd");
            this.lblTernDepositDateEnd.Name = "lblTernDepositDateEnd";
            // 
            // tbTargetAccount2
            // 
            resources.ApplyResources(this.tbTargetAccount2, "tbTargetAccount2");
            this.tbTargetAccount2.Name = "tbTargetAccount2";
            // 
            // lblTermTransferToAccount
            // 
            resources.ApplyResources(this.lblTermTransferToAccount, "lblTermTransferToAccount");
            this.lblTermTransferToAccount.Name = "lblTermTransferToAccount";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // btSearchContract2
            // 
            resources.ApplyResources(this.btSearchContract2, "btSearchContract2");
            this.btSearchContract2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(56)))));
            this.btSearchContract2.Name = "btSearchContract2";
            this.btSearchContract2.UseVisualStyleBackColor = true;
            // 
            // columnHeader26
            // 
            resources.ApplyResources(this.columnHeader26, "columnHeader26");
            // 
            // olvColumnSACExportedBalance
            // 
            this.olvColumnSACExportedBalance.AspectName = "Id";
            this.olvColumnSACExportedBalance.IsVisible = false;
            resources.ApplyResources(this.olvColumnSACExportedBalance, "olvColumnSACExportedBalance");
            // 
            // olvColumnLACExportedBalance
            // 
            this.olvColumnLACExportedBalance.AspectName = "Id";
            this.olvColumnLACExportedBalance.IsVisible = false;
            resources.ApplyResources(this.olvColumnLACExportedBalance, "olvColumnLACExportedBalance");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // labelTitleRepayment
            // 
            resources.ApplyResources(this.labelTitleRepayment, "labelTitleRepayment");
            this.labelTitleRepayment.Name = "labelTitleRepayment";
            // 
            // buttonPrintSchedule
            // 
            this.buttonPrintSchedule.BackColor = System.Drawing.Color.Gainsboro;
            resources.ApplyResources(this.buttonPrintSchedule, "buttonPrintSchedule");
            this.buttonPrintSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(56)))));
            this.buttonPrintSchedule.Name = "buttonPrintSchedule";
            this.buttonPrintSchedule.UseVisualStyleBackColor = false;
            // 
            // buttonReschedule
            // 
            this.buttonReschedule.BackColor = System.Drawing.Color.Gainsboro;
            resources.ApplyResources(this.buttonReschedule, "buttonReschedule");
            this.buttonReschedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(56)))));
            this.buttonReschedule.Name = "buttonReschedule";
            this.buttonReschedule.UseVisualStyleBackColor = false;
            // 
            // buttonRepay
            // 
            this.buttonRepay.BackColor = System.Drawing.Color.Gainsboro;
            resources.ApplyResources(this.buttonRepay, "buttonRepay");
            this.buttonRepay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(56)))));
            this.buttonRepay.Name = "buttonRepay";
            this.buttonRepay.UseVisualStyleBackColor = false;
            // 
            // columnHeaderDate
            // 
            resources.ApplyResources(this.columnHeaderDate, "columnHeaderDate");
            // 
            // columnHeaderType
            // 
            resources.ApplyResources(this.columnHeaderType, "columnHeaderType");
            // 
            // columnHeaderPrincipal
            // 
            resources.ApplyResources(this.columnHeaderPrincipal, "columnHeaderPrincipal");
            // 
            // columnHeaderInterest
            // 
            resources.ApplyResources(this.columnHeaderInterest, "columnHeaderInterest");
            // 
            // columnHeaderFees
            // 
            resources.ApplyResources(this.columnHeaderFees, "columnHeaderFees");
            // 
            // columnHeader10
            // 
            resources.ApplyResources(this.columnHeader10, "columnHeader10");
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // buttonLoanDisbursement
            // 
            resources.ApplyResources(this.buttonLoanDisbursement, "buttonLoanDisbursement");
            this.buttonLoanDisbursement.Name = "buttonLoanDisbursement";
            // 
            // labelExchangeRate
            // 
            resources.ApplyResources(this.labelExchangeRate, "labelExchangeRate");
            this.labelExchangeRate.Name = "labelExchangeRate";
            // 
            // toolStripSeparatorCopy
            // 
            this.toolStripSeparatorCopy.Name = "toolStripSeparatorCopy";
            resources.ApplyResources(this.toolStripSeparatorCopy, "toolStripSeparatorCopy");
            // 
            // toolStripMenuItemEditComment
            // 
            this.toolStripMenuItemEditComment.Name = "toolStripMenuItemEditComment";
            resources.ApplyResources(this.toolStripMenuItemEditComment, "toolStripMenuItemEditComment");
            // 
            // toolStripMenuItemCancelPending
            // 
            this.toolStripMenuItemCancelPending.Name = "toolStripMenuItemCancelPending";
            resources.ApplyResources(this.toolStripMenuItemCancelPending, "toolStripMenuItemCancelPending");
            // 
            // toolStripMenuItemConfirmPending
            // 
            this.toolStripMenuItemConfirmPending.Name = "toolStripMenuItemConfirmPending";
            resources.ApplyResources(this.toolStripMenuItemConfirmPending, "toolStripMenuItemConfirmPending");
            // 
            // LoanSimulationForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.loanDetailsButtonsPanel);
            this.Controls.Add(this.gbxLoanDetails);
            this.Name = "LoanSimulationForm";
            this.Controls.SetChildIndex(this.gbxLoanDetails, 0);
            this.Controls.SetChildIndex(this.loanDetailsButtonsPanel, 0);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            this.gbxLoanDetails.ResumeLayout(false);
            this.gbxLoanDetails.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLoanGracePeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLoanNbOfInstallments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLoanAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterestRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfPeriods)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            _product = null;
            _project = null;
            _credit = null;
            _guarantee = null;
            _person = null;
            _personUserControl = null;
            _groupUserControl = null;

            _loanShares = null;
            _users = null;
            _fundingLine = null;
            _corporate = null;
            _corporateUserControl = null;
            _followUpList = null;
            _savingsBookProduct = null;
            _saving = null;

            _client = null;

            _listGuarantors = null;
            _collaterals = null;

            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        private Label labelDateOffirstInstallment;
        private DateTimePicker dtpDateOfFirstInstallment;
        private ColumnHeader columnHeader26;
        private Label labelLoanNbOfInstallmentsMinMax;
        private Label labelLoanGracePeriodMinMax;
        private ToolStripSeparator toolStripSeparatorCopy;
        private ToolStripMenuItem toolStripMenuItemEditComment;
        private ToolStripMenuItem toolStripMenuItemCancelPending;
        private ToolStripMenuItem toolStripMenuItemConfirmPending;
        private BrightIdeasSoftware.OLVColumn olvColumnLACExportedBalance;
        private BrightIdeasSoftware.OLVColumn olvColumnSACExportedBalance;
        private FlowLayoutPanel loanDetailsButtonsPanel;
        private TableLayoutPanel tableLayoutPanel4;
        private Label lblDay;
        private NumericUpDown nudLoanAmount;
        private NumericUpDown nudInterestRate;
        private readonly Calendar targetCalendar = new PersianCalendar();
        private readonly Calendar currentCalendar = new GregorianCalendar();
        private Label lblNumberOfPeriods;
        private NumericUpDown nudNumberOfPeriods;
        private Label lblTermTransferToAccount;
        private TextBox tbTargetAccount2;
        private Button btSearchContract2;
        private Label lbRollover2;
        private ComboBox cmbRollover2;
        private ComboBox _installmentTypeComboBox;
        private Label _installmentTypeLabel;
        private Label _scheduleTypeLabel;
        private ComboBox _scheduleTypeComboBox;
        private Label lblTernDepositDateStarted;
        private DateTimePicker dtpTernDepositDateStarted;
        private DateTimePicker dtpTernDepositDateEnd;
        private Label lblTernDepositDateEnd;
        private TextBox textBox1;
        private Label label2;
        private ComboBox cmbPackages;
        private Label label3;
        private Controls.ScheduleControl _loanDetailsScheduleControl1;
        private Button btnPrint;
    }
}
