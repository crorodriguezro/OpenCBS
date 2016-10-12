namespace OpenCBS.GUI.UserControl
{
    partial class TernDepositUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControlSavingsDetails = new System.Windows.Forms.TabControl();
            this.tabPageSavingsEvents = new System.Windows.Forms.TabPage();
            this.lvSavingEvent = new System.Windows.Forms.ListView();
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCancelDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtpTernDepositDateEnd = new System.Windows.Forms.DateTimePicker();
            this.lblTernDepositDateStarted = new System.Windows.Forms.Label();
            this.lblNumberOfPeriods = new System.Windows.Forms.Label();
            this.nudNumberOfPeriods = new System.Windows.Forms.NumericUpDown();
            this.lblLimitOfTermDepositPeriod = new System.Windows.Forms.Label();
            this.dtpTernDepositDateStarted = new System.Windows.Forms.DateTimePicker();
            this.lblTernDepositDateEnd = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonSaveSaving = new System.Windows.Forms.Button();
            this.pnlSavingsButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonSavingsClose = new System.Windows.Forms.Button();
            this.btCancelLastSavingEvent = new System.Windows.Forms.Button();
            this.btnPrintSavings = new OpenCBS.GUI.UserControl.PrintButton();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonRenew = new System.Windows.Forms.Button();
            this.groupBoxSaving = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.nudExpectedAmount = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tBSavingCode = new System.Windows.Forms.TextBox();
            this.lBSavingBalance = new System.Windows.Forms.Label();
            this.lbSavingBalanceValue = new System.Windows.Forms.Label();
            this.lBSavingAvBalance = new System.Windows.Forms.Label();
            this.lbSavingAvBalanceValue = new System.Windows.Forms.Label();
            this._currentAccountLabel = new System.Windows.Forms.Label();
            this._currentAccountTextBox = new System.Windows.Forms.TextBox();
            this._dateCreatedLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSavingsOfficer = new System.Windows.Forms.ComboBox();
            this.labelInitialAmount = new System.Windows.Forms.Label();
            this.nudDownInitialAmount = new System.Windows.Forms.NumericUpDown();
            this.lbInitialAmountMinMax = new System.Windows.Forms.Label();
            this.labelInterestRate = new System.Windows.Forms.Label();
            this.nudDownInterestRate = new System.Windows.Forms.NumericUpDown();
            this.lbInterestRateMinMax = new System.Windows.Forms.Label();
            this._dateCreatedValueLabel = new System.Windows.Forms.Label();
            this.dateTimeDateCreated = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControlSavingsDetails.SuspendLayout();
            this.tabPageSavingsEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfPeriods)).BeginInit();
            this.flowLayoutPanel9.SuspendLayout();
            this.pnlSavingsButtons.SuspendLayout();
            this.groupBoxSaving.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExpectedAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDownInitialAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDownInterestRate)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSavingsDetails
            // 
            this.tabControlSavingsDetails.Controls.Add(this.tabPageSavingsEvents);
            this.tabControlSavingsDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSavingsDetails.ItemSize = new System.Drawing.Size(55, 25);
            this.tabControlSavingsDetails.Location = new System.Drawing.Point(3, 269);
            this.tabControlSavingsDetails.Name = "tabControlSavingsDetails";
            this.tabControlSavingsDetails.SelectedIndex = 0;
            this.tabControlSavingsDetails.Size = new System.Drawing.Size(1316, 326);
            this.tabControlSavingsDetails.TabIndex = 74;
            // 
            // tabPageSavingsEvents
            // 
            this.tabPageSavingsEvents.Controls.Add(this.lvSavingEvent);
            this.tabPageSavingsEvents.Location = new System.Drawing.Point(4, 29);
            this.tabPageSavingsEvents.Name = "tabPageSavingsEvents";
            this.tabPageSavingsEvents.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSavingsEvents.Size = new System.Drawing.Size(1308, 293);
            this.tabPageSavingsEvents.TabIndex = 0;
            this.tabPageSavingsEvents.Text = "Events";
            // 
            // lvSavingEvent
            // 
            this.lvSavingEvent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader27,
            this.columnHeader15,
            this.columnHeader28,
            this.columnHeader29,
            this.columnHeader24,
            this.colCancelDate});
            this.lvSavingEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSavingEvent.FullRowSelect = true;
            this.lvSavingEvent.GridLines = true;
            this.lvSavingEvent.Location = new System.Drawing.Point(3, 3);
            this.lvSavingEvent.Name = "lvSavingEvent";
            this.lvSavingEvent.Size = new System.Drawing.Size(1302, 287);
            this.lvSavingEvent.TabIndex = 0;
            this.lvSavingEvent.UseCompatibleStateImageBehavior = false;
            this.lvSavingEvent.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Date";
            this.columnHeader21.Width = 140;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Debit";
            this.columnHeader22.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader22.Width = 79;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "Credit";
            this.columnHeader23.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader23.Width = 89;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "Transfer";
            this.columnHeader27.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader27.Width = 112;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Code";
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "Savings method";
            this.columnHeader28.Width = 110;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "User";
            this.columnHeader29.Width = 150;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "Description";
            this.columnHeader24.Width = 287;
            // 
            // colCancelDate
            // 
            this.colCancelDate.Text = "Cancel Date";
            this.colCancelDate.Width = 130;
            // 
            // dtpTernDepositDateEnd
            // 
            this.dtpTernDepositDateEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpTernDepositDateEnd.Enabled = false;
            this.dtpTernDepositDateEnd.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtpTernDepositDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTernDepositDateEnd.Location = new System.Drawing.Point(598, 141);
            this.dtpTernDepositDateEnd.Name = "dtpTernDepositDateEnd";
            this.dtpTernDepositDateEnd.Size = new System.Drawing.Size(197, 22);
            this.dtpTernDepositDateEnd.TabIndex = 9;
            // 
            // lblTernDepositDateStarted
            // 
            this.lblTernDepositDateStarted.AutoSize = true;
            this.lblTernDepositDateStarted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTernDepositDateStarted.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lblTernDepositDateStarted.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTernDepositDateStarted.Location = new System.Drawing.Point(434, 106);
            this.lblTernDepositDateStarted.Name = "lblTernDepositDateStarted";
            this.lblTernDepositDateStarted.Size = new System.Drawing.Size(158, 32);
            this.lblTernDepositDateStarted.TabIndex = 9;
            this.lblTernDepositDateStarted.Text = "Date started";
            this.lblTernDepositDateStarted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNumberOfPeriods
            // 
            this.lblNumberOfPeriods.AutoSize = true;
            this.lblNumberOfPeriods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumberOfPeriods.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lblNumberOfPeriods.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNumberOfPeriods.Location = new System.Drawing.Point(434, 74);
            this.lblNumberOfPeriods.Name = "lblNumberOfPeriods";
            this.lblNumberOfPeriods.Size = new System.Drawing.Size(158, 32);
            this.lblNumberOfPeriods.TabIndex = 0;
            this.lblNumberOfPeriods.Text = "Number of periods";
            this.lblNumberOfPeriods.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudNumberOfPeriods
            // 
            this.nudNumberOfPeriods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudNumberOfPeriods.Location = new System.Drawing.Point(598, 77);
            this.nudNumberOfPeriods.Name = "nudNumberOfPeriods";
            this.nudNumberOfPeriods.Size = new System.Drawing.Size(197, 20);
            this.nudNumberOfPeriods.TabIndex = 1;
            this.nudNumberOfPeriods.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNumberOfPeriods.ValueChanged += new System.EventHandler(this.nudNumberOfPeriods_ValueChanged);
            // 
            // lblLimitOfTermDepositPeriod
            // 
            this.lblLimitOfTermDepositPeriod.AutoSize = true;
            this.lblLimitOfTermDepositPeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLimitOfTermDepositPeriod.Font = new System.Drawing.Font("Arial", 7.5F);
            this.lblLimitOfTermDepositPeriod.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLimitOfTermDepositPeriod.Location = new System.Drawing.Point(801, 74);
            this.lblLimitOfTermDepositPeriod.Name = "lblLimitOfTermDepositPeriod";
            this.lblLimitOfTermDepositPeriod.Size = new System.Drawing.Size(94, 32);
            this.lblLimitOfTermDepositPeriod.TabIndex = 7;
            this.lblLimitOfTermDepositPeriod.Text = "Limit of the period";
            this.lblLimitOfTermDepositPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTernDepositDateStarted
            // 
            this.dtpTernDepositDateStarted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpTernDepositDateStarted.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtpTernDepositDateStarted.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTernDepositDateStarted.Location = new System.Drawing.Point(598, 109);
            this.dtpTernDepositDateStarted.Name = "dtpTernDepositDateStarted";
            this.dtpTernDepositDateStarted.Size = new System.Drawing.Size(197, 22);
            this.dtpTernDepositDateStarted.TabIndex = 8;
            this.dtpTernDepositDateStarted.ValueChanged += new System.EventHandler(this.PeriodValueChanged);
            // 
            // lblTernDepositDateEnd
            // 
            this.lblTernDepositDateEnd.AutoSize = true;
            this.lblTernDepositDateEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTernDepositDateEnd.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lblTernDepositDateEnd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTernDepositDateEnd.Location = new System.Drawing.Point(434, 138);
            this.lblTernDepositDateEnd.Name = "lblTernDepositDateEnd";
            this.lblTernDepositDateEnd.Size = new System.Drawing.Size(158, 26);
            this.lblTernDepositDateEnd.TabIndex = 10;
            this.lblTernDepositDateEnd.Text = "Contract end date";
            this.lblTernDepositDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(3, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 26);
            this.label2.TabIndex = 12;
            this.label2.Text = "Expected Amount";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel9
            // 
            this.flowLayoutPanel9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel9.Controls.Add(this.buttonSaveSaving);
            this.flowLayoutPanel9.Controls.Add(this.pnlSavingsButtons);
            this.flowLayoutPanel9.Controls.Add(this.btnPrintSavings);
            this.flowLayoutPanel9.Controls.Add(this.buttonStart);
            this.flowLayoutPanel9.Controls.Add(this.buttonUpdate);
            this.flowLayoutPanel9.Controls.Add(this.buttonRenew);
            this.flowLayoutPanel9.Location = new System.Drawing.Point(3, 209);
            this.flowLayoutPanel9.Name = "flowLayoutPanel9";
            this.flowLayoutPanel9.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.flowLayoutPanel9.Size = new System.Drawing.Size(1316, 54);
            this.flowLayoutPanel9.TabIndex = 75;
            // 
            // buttonSaveSaving
            // 
            this.buttonSaveSaving.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonSaveSaving.Location = new System.Drawing.Point(3, 13);
            this.buttonSaveSaving.Name = "buttonSaveSaving";
            this.buttonSaveSaving.Size = new System.Drawing.Size(110, 28);
            this.buttonSaveSaving.TabIndex = 1;
            this.buttonSaveSaving.Text = "Save";
            this.buttonSaveSaving.Click += new System.EventHandler(this.Save);
            // 
            // pnlSavingsButtons
            // 
            this.pnlSavingsButtons.AutoSize = true;
            this.pnlSavingsButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlSavingsButtons.Controls.Add(this.buttonSavingsClose);
            this.pnlSavingsButtons.Controls.Add(this.btCancelLastSavingEvent);
            this.pnlSavingsButtons.Location = new System.Drawing.Point(116, 10);
            this.pnlSavingsButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSavingsButtons.Name = "pnlSavingsButtons";
            this.pnlSavingsButtons.Size = new System.Drawing.Size(357, 34);
            this.pnlSavingsButtons.TabIndex = 73;
            // 
            // buttonSavingsClose
            // 
            this.buttonSavingsClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSavingsClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonSavingsClose.Location = new System.Drawing.Point(3, 3);
            this.buttonSavingsClose.Name = "buttonSavingsClose";
            this.buttonSavingsClose.Size = new System.Drawing.Size(140, 28);
            this.buttonSavingsClose.TabIndex = 0;
            this.buttonSavingsClose.Text = "Close";
            this.buttonSavingsClose.Click += new System.EventHandler(this.Close);
            // 
            // btCancelLastSavingEvent
            // 
            this.btCancelLastSavingEvent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btCancelLastSavingEvent.Location = new System.Drawing.Point(149, 3);
            this.btCancelLastSavingEvent.Name = "btCancelLastSavingEvent";
            this.btCancelLastSavingEvent.Size = new System.Drawing.Size(205, 28);
            this.btCancelLastSavingEvent.TabIndex = 1;
            this.btCancelLastSavingEvent.Text = "Cancel Last Operation";
            this.btCancelLastSavingEvent.Click += new System.EventHandler(this.CancelLastEvent);
            // 
            // btnPrintSavings
            // 
            this.btnPrintSavings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrintSavings.Image = global::OpenCBS.GUI.Properties.Resources.bullet_arrow_down;
            this.btnPrintSavings.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintSavings.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrintSavings.Location = new System.Drawing.Point(476, 13);
            this.btnPrintSavings.Name = "btnPrintSavings";
            this.btnPrintSavings.ReportInitializer = null;
            this.btnPrintSavings.Size = new System.Drawing.Size(108, 28);
            this.btnPrintSavings.TabIndex = 74;
            this.btnPrintSavings.Text = "Print";
            this.btnPrintSavings.UseVisualStyleBackColor = true;
            this.btnPrintSavings.Visible = false;
            // 
            // buttonStart
            // 
            this.buttonStart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonStart.Location = new System.Drawing.Point(590, 13);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(110, 28);
            this.buttonStart.TabIndex = 75;
            this.buttonStart.Text = "Start";
            this.buttonStart.Visible = false;
            this.buttonStart.Click += new System.EventHandler(this.Start);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonUpdate.Location = new System.Drawing.Point(706, 13);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(110, 28);
            this.buttonUpdate.TabIndex = 76;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.Visible = false;
            this.buttonUpdate.Click += new System.EventHandler(this.Update);
            // 
            // buttonRenew
            // 
            this.buttonRenew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonRenew.Location = new System.Drawing.Point(822, 13);
            this.buttonRenew.Name = "buttonRenew";
            this.buttonRenew.Size = new System.Drawing.Size(99, 28);
            this.buttonRenew.TabIndex = 77;
            this.buttonRenew.Text = "Renew";
            this.buttonRenew.Visible = false;
            this.buttonRenew.Click += new System.EventHandler(this.Renew);
            // 
            // groupBoxSaving
            // 
            this.groupBoxSaving.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxSaving.Controls.Add(this.tableLayoutPanel5);
            this.groupBoxSaving.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSaving.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSaving.Name = "groupBoxSaving";
            this.groupBoxSaving.Size = new System.Drawing.Size(1316, 200);
            this.groupBoxSaving.TabIndex = 73;
            this.groupBoxSaving.TabStop = false;
            this.groupBoxSaving.Text = "admin";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel5.ColumnCount = 9;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.dtpTernDepositDateEnd, 4, 5);
            this.tableLayoutPanel5.Controls.Add(this.nudExpectedAmount, 1, 5);
            this.tableLayoutPanel5.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblTernDepositDateStarted, 3, 3);
            this.tableLayoutPanel5.Controls.Add(this.label3, 8, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblTernDepositDateEnd, 3, 5);
            this.tableLayoutPanel5.Controls.Add(this.dtpTernDepositDateStarted, 4, 3);
            this.tableLayoutPanel5.Controls.Add(this.tBSavingCode, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel5.Controls.Add(this.lblLimitOfTermDepositPeriod, 5, 2);
            this.tableLayoutPanel5.Controls.Add(this.nudNumberOfPeriods, 4, 2);
            this.tableLayoutPanel5.Controls.Add(this.lblNumberOfPeriods, 3, 2);
            this.tableLayoutPanel5.Controls.Add(this.lBSavingBalance, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.lbSavingBalanceValue, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.lBSavingAvBalance, 3, 1);
            this.tableLayoutPanel5.Controls.Add(this.lbSavingAvBalanceValue, 4, 1);
            this.tableLayoutPanel5.Controls.Add(this._currentAccountLabel, 6, 1);
            this.tableLayoutPanel5.Controls.Add(this._currentAccountTextBox, 7, 1);
            this.tableLayoutPanel5.Controls.Add(this._dateCreatedLabel, 6, 0);
            this.tableLayoutPanel5.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.cmbSavingsOfficer, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.labelInitialAmount, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.nudDownInitialAmount, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.lbInitialAmountMinMax, 2, 2);
            this.tableLayoutPanel5.Controls.Add(this.labelInterestRate, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.nudDownInterestRate, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.lbInterestRateMinMax, 2, 3);
            this.tableLayoutPanel5.Controls.Add(this._dateCreatedValueLabel, 0, 6);
            this.tableLayoutPanel5.Controls.Add(this.dateTimeDateCreated, 7, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.tableLayoutPanel5.RowCount = 7;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1310, 181);
            this.tableLayoutPanel5.TabIndex = 73;
            // 
            // nudExpectedAmount
            // 
            this.nudExpectedAmount.DecimalPlaces = 2;
            this.nudExpectedAmount.Enabled = false;
            this.nudExpectedAmount.Location = new System.Drawing.Point(120, 141);
            this.nudExpectedAmount.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudExpectedAmount.Name = "nudExpectedAmount";
            this.nudExpectedAmount.Size = new System.Drawing.Size(160, 20);
            this.nudExpectedAmount.TabIndex = 11;
            this.nudExpectedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(3, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 32);
            this.label9.TabIndex = 5;
            this.label9.Text = "Code";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(1164, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 75;
            this.label3.Text = "Empty label";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Visible = false;
            // 
            // tBSavingCode
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.tBSavingCode, 2);
            this.tBSavingCode.Location = new System.Drawing.Point(120, 13);
            this.tBSavingCode.Name = "tBSavingCode";
            this.tBSavingCode.ReadOnly = true;
            this.tBSavingCode.Size = new System.Drawing.Size(308, 20);
            this.tBSavingCode.TabIndex = 0;
            // 
            // lBSavingBalance
            // 
            this.lBSavingBalance.AutoSize = true;
            this.lBSavingBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lBSavingBalance.Font = new System.Drawing.Font("Arial", 15F);
            this.lBSavingBalance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lBSavingBalance.Location = new System.Drawing.Point(434, 10);
            this.lBSavingBalance.Name = "lBSavingBalance";
            this.lBSavingBalance.Size = new System.Drawing.Size(158, 32);
            this.lBSavingBalance.TabIndex = 8;
            this.lBSavingBalance.Text = "Balance";
            this.lBSavingBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbSavingBalanceValue
            // 
            this.lbSavingBalanceValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSavingBalanceValue.Font = new System.Drawing.Font("Arial", 15F);
            this.lbSavingBalanceValue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbSavingBalanceValue.Location = new System.Drawing.Point(598, 10);
            this.lbSavingBalanceValue.Name = "lbSavingBalanceValue";
            this.lbSavingBalanceValue.Size = new System.Drawing.Size(197, 32);
            this.lbSavingBalanceValue.TabIndex = 8;
            this.lbSavingBalanceValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lBSavingAvBalance
            // 
            this.lBSavingAvBalance.AutoSize = true;
            this.lBSavingAvBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lBSavingAvBalance.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lBSavingAvBalance.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lBSavingAvBalance.Location = new System.Drawing.Point(434, 42);
            this.lBSavingAvBalance.Name = "lBSavingAvBalance";
            this.lBSavingAvBalance.Size = new System.Drawing.Size(158, 32);
            this.lBSavingAvBalance.TabIndex = 59;
            this.lBSavingAvBalance.Text = "Personal account balance";
            this.lBSavingAvBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbSavingAvBalanceValue
            // 
            this.lbSavingAvBalanceValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSavingAvBalanceValue.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lbSavingAvBalanceValue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbSavingAvBalanceValue.Location = new System.Drawing.Point(598, 42);
            this.lbSavingAvBalanceValue.Name = "lbSavingAvBalanceValue";
            this.lbSavingAvBalanceValue.Size = new System.Drawing.Size(197, 32);
            this.lbSavingAvBalanceValue.TabIndex = 60;
            this.lbSavingAvBalanceValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _currentAccountLabel
            // 
            this._currentAccountLabel.AutoSize = true;
            this._currentAccountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._currentAccountLabel.Font = new System.Drawing.Font("Arial", 9.75F);
            this._currentAccountLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._currentAccountLabel.Location = new System.Drawing.Point(901, 42);
            this._currentAccountLabel.Name = "_currentAccountLabel";
            this._currentAccountLabel.Size = new System.Drawing.Size(101, 32);
            this._currentAccountLabel.TabIndex = 61;
            this._currentAccountLabel.Text = "Current Account";
            this._currentAccountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _currentAccountTextBox
            // 
            this._currentAccountTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._currentAccountTextBox.Location = new System.Drawing.Point(1008, 45);
            this._currentAccountTextBox.Name = "_currentAccountTextBox";
            this._currentAccountTextBox.ReadOnly = true;
            this._currentAccountTextBox.Size = new System.Drawing.Size(150, 20);
            this._currentAccountTextBox.TabIndex = 65;
            // 
            // _dateCreatedLabel
            // 
            this._dateCreatedLabel.AutoSize = true;
            this._dateCreatedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dateCreatedLabel.Font = new System.Drawing.Font("Arial", 9.75F);
            this._dateCreatedLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._dateCreatedLabel.Location = new System.Drawing.Point(901, 10);
            this._dateCreatedLabel.Name = "_dateCreatedLabel";
            this._dateCreatedLabel.Size = new System.Drawing.Size(101, 32);
            this._dateCreatedLabel.TabIndex = 66;
            this._dateCreatedLabel.Text = "Date created";
            this._dateCreatedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._dateCreatedLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Savings officer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSavingsOfficer
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.cmbSavingsOfficer, 2);
            this.cmbSavingsOfficer.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbSavingsOfficer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSavingsOfficer.FormattingEnabled = true;
            this.cmbSavingsOfficer.Location = new System.Drawing.Point(120, 45);
            this.cmbSavingsOfficer.Name = "cmbSavingsOfficer";
            this.cmbSavingsOfficer.Size = new System.Drawing.Size(160, 21);
            this.cmbSavingsOfficer.TabIndex = 3;
            // 
            // labelInitialAmount
            // 
            this.labelInitialAmount.AutoSize = true;
            this.labelInitialAmount.BackColor = System.Drawing.Color.Transparent;
            this.labelInitialAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInitialAmount.Font = new System.Drawing.Font("Arial", 9.75F);
            this.labelInitialAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelInitialAmount.Location = new System.Drawing.Point(3, 74);
            this.labelInitialAmount.Name = "labelInitialAmount";
            this.labelInitialAmount.Size = new System.Drawing.Size(111, 32);
            this.labelInitialAmount.TabIndex = 3;
            this.labelInitialAmount.Text = "Initial amount";
            this.labelInitialAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudDownInitialAmount
            // 
            this.nudDownInitialAmount.DecimalPlaces = 2;
            this.nudDownInitialAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudDownInitialAmount.ImeMode = System.Windows.Forms.ImeMode.On;
            this.nudDownInitialAmount.Location = new System.Drawing.Point(120, 77);
            this.nudDownInitialAmount.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudDownInitialAmount.Name = "nudDownInitialAmount";
            this.nudDownInitialAmount.Size = new System.Drawing.Size(160, 20);
            this.nudDownInitialAmount.TabIndex = 1;
            this.nudDownInitialAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudDownInitialAmount.ValueChanged += new System.EventHandler(this.CalculateExpectedAmount);
            // 
            // lbInitialAmountMinMax
            // 
            this.lbInitialAmountMinMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbInitialAmountMinMax.Font = new System.Drawing.Font("Arial", 7.5F);
            this.lbInitialAmountMinMax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbInitialAmountMinMax.Location = new System.Drawing.Point(286, 74);
            this.lbInitialAmountMinMax.Name = "lbInitialAmountMinMax";
            this.lbInitialAmountMinMax.Size = new System.Drawing.Size(142, 32);
            this.lbInitialAmountMinMax.TabIndex = 1;
            this.lbInitialAmountMinMax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelInterestRate
            // 
            this.labelInterestRate.AutoSize = true;
            this.labelInterestRate.BackColor = System.Drawing.Color.Transparent;
            this.labelInterestRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInterestRate.Font = new System.Drawing.Font("Arial", 9.75F);
            this.labelInterestRate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelInterestRate.Location = new System.Drawing.Point(3, 106);
            this.labelInterestRate.Name = "labelInterestRate";
            this.labelInterestRate.Size = new System.Drawing.Size(111, 32);
            this.labelInterestRate.TabIndex = 12;
            this.labelInterestRate.Text = "Interest rate ";
            this.labelInterestRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudDownInterestRate
            // 
            this.nudDownInterestRate.DecimalPlaces = 2;
            this.nudDownInterestRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudDownInterestRate.Location = new System.Drawing.Point(120, 109);
            this.nudDownInterestRate.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudDownInterestRate.Name = "nudDownInterestRate";
            this.nudDownInterestRate.Size = new System.Drawing.Size(160, 20);
            this.nudDownInterestRate.TabIndex = 4;
            this.nudDownInterestRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudDownInterestRate.ValueChanged += new System.EventHandler(this.CalculateExpectedAmount);
            // 
            // lbInterestRateMinMax
            // 
            this.lbInterestRateMinMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbInterestRateMinMax.Font = new System.Drawing.Font("Arial", 7.5F);
            this.lbInterestRateMinMax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbInterestRateMinMax.Location = new System.Drawing.Point(286, 106);
            this.lbInterestRateMinMax.Name = "lbInterestRateMinMax";
            this.lbInterestRateMinMax.Size = new System.Drawing.Size(142, 32);
            this.lbInterestRateMinMax.TabIndex = 49;
            this.lbInterestRateMinMax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _dateCreatedValueLabel
            // 
            this._dateCreatedValueLabel.AutoSize = true;
            this._dateCreatedValueLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this._dateCreatedValueLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._dateCreatedValueLabel.Location = new System.Drawing.Point(3, 164);
            this._dateCreatedValueLabel.Name = "_dateCreatedValueLabel";
            this._dateCreatedValueLabel.Size = new System.Drawing.Size(0, 8);
            this._dateCreatedValueLabel.TabIndex = 67;
            this._dateCreatedValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimeDateCreated
            // 
            this.dateTimeDateCreated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimeDateCreated.Enabled = false;
            this.dateTimeDateCreated.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.dateTimeDateCreated.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeDateCreated.Location = new System.Drawing.Point(1008, 13);
            this.dateTimeDateCreated.Name = "dateTimeDateCreated";
            this.dateTimeDateCreated.Size = new System.Drawing.Size(150, 22);
            this.dateTimeDateCreated.TabIndex = 76;
            this.dateTimeDateCreated.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBoxSaving, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControlSavingsDetails, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel9, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1322, 598);
            this.tableLayoutPanel1.TabIndex = 76;
            // 
            // TernDepositUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TernDepositUserControl";
            this.Size = new System.Drawing.Size(1322, 598);
            this.tabControlSavingsDetails.ResumeLayout(false);
            this.tabPageSavingsEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfPeriods)).EndInit();
            this.flowLayoutPanel9.ResumeLayout(false);
            this.flowLayoutPanel9.PerformLayout();
            this.pnlSavingsButtons.ResumeLayout(false);
            this.groupBoxSaving.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExpectedAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDownInitialAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDownInterestRate)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlSavingsDetails;
        private System.Windows.Forms.DateTimePicker dtpTernDepositDateEnd;
        private System.Windows.Forms.Label lblTernDepositDateStarted;
        private System.Windows.Forms.Label lblNumberOfPeriods;
        private System.Windows.Forms.NumericUpDown nudNumberOfPeriods;
        private System.Windows.Forms.Label lblLimitOfTermDepositPeriod;
        private System.Windows.Forms.DateTimePicker dtpTernDepositDateStarted;
        private System.Windows.Forms.Label lblTernDepositDateEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPageSavingsEvents;
        private System.Windows.Forms.ListView lvSavingEvent;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ColumnHeader columnHeader29;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader colCancelDate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel9;
        private System.Windows.Forms.Button buttonSaveSaving;
        private System.Windows.Forms.FlowLayoutPanel pnlSavingsButtons;
        private System.Windows.Forms.Button buttonSavingsClose;
        private System.Windows.Forms.Button btCancelLastSavingEvent;
        private PrintButton btnPrintSavings;
        private System.Windows.Forms.GroupBox groupBoxSaving;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tBSavingCode;
        private System.Windows.Forms.Label lBSavingBalance;
        private System.Windows.Forms.Label lbSavingBalanceValue;
        private System.Windows.Forms.Label lBSavingAvBalance;
        private System.Windows.Forms.Label lbSavingAvBalanceValue;
        private System.Windows.Forms.Label _currentAccountLabel;
        private System.Windows.Forms.TextBox _currentAccountTextBox;
        private System.Windows.Forms.Label _dateCreatedLabel;
        private System.Windows.Forms.Label _dateCreatedValueLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSavingsOfficer;
        private System.Windows.Forms.Label labelInitialAmount;
        private System.Windows.Forms.NumericUpDown nudDownInitialAmount;
        private System.Windows.Forms.Label lbInitialAmountMinMax;
        private System.Windows.Forms.Label labelInterestRate;
        private System.Windows.Forms.NumericUpDown nudDownInterestRate;
        private System.Windows.Forms.Label lbInterestRateMinMax;
        private System.Windows.Forms.NumericUpDown nudExpectedAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker dateTimeDateCreated;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonRenew;
    }
}
