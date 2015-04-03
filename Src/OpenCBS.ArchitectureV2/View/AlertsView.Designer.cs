namespace OpenCBS.ArchitectureV2.View
{
    partial class AlertsView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertsView));
            this._alertsListView = new BrightIdeasSoftware.FastObjectListView();
            this._contractCodeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._statusColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._dateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._lateDaysColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._amountColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._clientNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._loanOfficerColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._cityColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._addressColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._phoneColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._branchColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._loansDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this._performingLoansItem = new System.Windows.Forms.ToolStripMenuItem();
            this._lateLoansItem = new System.Windows.Forms.ToolStripMenuItem();
            this._pendingLoansItem = new System.Windows.Forms.ToolStripMenuItem();
            this._validatedLoansItem = new System.Windows.Forms.ToolStripMenuItem();
            this._postponedLoansItem = new System.Windows.Forms.ToolStripMenuItem();
            this._savingsDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this._pendingSavingsItem = new System.Windows.Forms.ToolStripMenuItem();
            this._overdraftSavingsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._searchTextBox = new System.Windows.Forms.ToolStripTextBox();
            this._reloadButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._clearSearchButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this._alertsListView)).BeginInit();
            this._toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _alertsListView
            // 
            this._alertsListView.AllColumns.Add(this._contractCodeColumn);
            this._alertsListView.AllColumns.Add(this._statusColumn);
            this._alertsListView.AllColumns.Add(this._dateColumn);
            this._alertsListView.AllColumns.Add(this._lateDaysColumn);
            this._alertsListView.AllColumns.Add(this._amountColumn);
            this._alertsListView.AllColumns.Add(this._clientNameColumn);
            this._alertsListView.AllColumns.Add(this._loanOfficerColumn);
            this._alertsListView.AllColumns.Add(this._cityColumn);
            this._alertsListView.AllColumns.Add(this._addressColumn);
            this._alertsListView.AllColumns.Add(this._phoneColumn);
            this._alertsListView.AllColumns.Add(this._branchColumn);
            this._alertsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._contractCodeColumn,
            this._statusColumn,
            this._dateColumn,
            this._lateDaysColumn,
            this._amountColumn,
            this._clientNameColumn,
            this._loanOfficerColumn,
            this._cityColumn,
            this._addressColumn,
            this._phoneColumn,
            this._branchColumn});
            this._alertsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._alertsListView.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._alertsListView.FullRowSelect = true;
            this._alertsListView.GridLines = true;
            this._alertsListView.Location = new System.Drawing.Point(0, 25);
            this._alertsListView.MultiSelect = false;
            this._alertsListView.Name = "_alertsListView";
            this._alertsListView.ShowGroups = false;
            this._alertsListView.Size = new System.Drawing.Size(715, 271);
            this._alertsListView.TabIndex = 2;
            this._alertsListView.UseCompatibleStateImageBehavior = false;
            this._alertsListView.View = System.Windows.Forms.View.Details;
            this._alertsListView.VirtualMode = true;
            // 
            // _contractCodeColumn
            // 
            this._contractCodeColumn.AspectName = "ContractCode";
            this._contractCodeColumn.Text = "Contract Code";
            this._contractCodeColumn.Width = 200;
            // 
            // _statusColumn
            // 
            this._statusColumn.AspectName = "Status";
            this._statusColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._statusColumn.Text = "Status";
            this._statusColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._statusColumn.Width = 100;
            // 
            // _dateColumn
            // 
            this._dateColumn.AspectName = "Date";
            this._dateColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._dateColumn.Text = "Date";
            this._dateColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._dateColumn.Width = 100;
            // 
            // _lateDaysColumn
            // 
            this._lateDaysColumn.AspectName = "LateDays";
            this._lateDaysColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._lateDaysColumn.Text = "Late Days";
            this._lateDaysColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._lateDaysColumn.Width = 80;
            // 
            // _amountColumn
            // 
            this._amountColumn.AspectName = "Amount";
            this._amountColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._amountColumn.Text = "Amount";
            this._amountColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._amountColumn.Width = 100;
            // 
            // _clientNameColumn
            // 
            this._clientNameColumn.AspectName = "ClientName";
            this._clientNameColumn.Text = "Client";
            this._clientNameColumn.Width = 200;
            // 
            // _loanOfficerColumn
            // 
            this._loanOfficerColumn.AspectName = "LoanOfficer";
            this._loanOfficerColumn.Text = "Loan Officer";
            this._loanOfficerColumn.Width = 200;
            // 
            // _cityColumn
            // 
            this._cityColumn.AspectName = "City";
            this._cityColumn.Text = "City";
            this._cityColumn.Width = 150;
            // 
            // _addressColumn
            // 
            this._addressColumn.AspectName = "Address";
            this._addressColumn.Text = "Address";
            this._addressColumn.Width = 150;
            // 
            // _phoneColumn
            // 
            this._phoneColumn.AspectName = "Phone";
            this._phoneColumn.Text = "Phone";
            this._phoneColumn.Width = 150;
            // 
            // _branchColumn
            // 
            this._branchColumn.AspectName = "BranchName";
            this._branchColumn.Text = "Branch";
            this._branchColumn.Width = 150;
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._reloadButton,
            this.toolStripSeparator2,
            this._loansDropDownButton,
            this._savingsDropDownButton,
            this.toolStripSeparator1,
            this._searchTextBox,
            this._clearSearchButton});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(715, 25);
            this._toolStrip.TabIndex = 4;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _loansDropDownButton
            // 
            this._loansDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._loansDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._performingLoansItem,
            this._lateLoansItem,
            this._pendingLoansItem,
            this._validatedLoansItem,
            this._postponedLoansItem});
            this._loansDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("_loansDropDownButton.Image")));
            this._loansDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._loansDropDownButton.Name = "_loansDropDownButton";
            this._loansDropDownButton.Size = new System.Drawing.Size(83, 22);
            this._loansDropDownButton.Text = "Show Loans";
            // 
            // _performingLoansItem
            // 
            this._performingLoansItem.Name = "_performingLoansItem";
            this._performingLoansItem.Size = new System.Drawing.Size(152, 22);
            this._performingLoansItem.Text = "Performing";
            // 
            // _lateLoansItem
            // 
            this._lateLoansItem.Name = "_lateLoansItem";
            this._lateLoansItem.Size = new System.Drawing.Size(152, 22);
            this._lateLoansItem.Text = "Late";
            // 
            // _pendingLoansItem
            // 
            this._pendingLoansItem.Name = "_pendingLoansItem";
            this._pendingLoansItem.Size = new System.Drawing.Size(152, 22);
            this._pendingLoansItem.Text = "Pending";
            // 
            // _validatedLoansItem
            // 
            this._validatedLoansItem.Name = "_validatedLoansItem";
            this._validatedLoansItem.Size = new System.Drawing.Size(152, 22);
            this._validatedLoansItem.Text = "Validated";
            // 
            // _postponedLoansItem
            // 
            this._postponedLoansItem.Name = "_postponedLoansItem";
            this._postponedLoansItem.Size = new System.Drawing.Size(152, 22);
            this._postponedLoansItem.Text = "Postponed";
            // 
            // _savingsDropDownButton
            // 
            this._savingsDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._savingsDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._pendingSavingsItem,
            this._overdraftSavingsItem});
            this._savingsDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("_savingsDropDownButton.Image")));
            this._savingsDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._savingsDropDownButton.Name = "_savingsDropDownButton";
            this._savingsDropDownButton.Size = new System.Drawing.Size(92, 22);
            this._savingsDropDownButton.Text = "Show Savings";
            // 
            // _pendingSavingsItem
            // 
            this._pendingSavingsItem.Name = "_pendingSavingsItem";
            this._pendingSavingsItem.Size = new System.Drawing.Size(152, 22);
            this._pendingSavingsItem.Text = "Pending";
            // 
            // _overdraftSavingsItem
            // 
            this._overdraftSavingsItem.Name = "_overdraftSavingsItem";
            this._overdraftSavingsItem.Size = new System.Drawing.Size(152, 22);
            this._overdraftSavingsItem.Text = "Overdraft";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _searchTextBox
            // 
            this._searchTextBox.Name = "_searchTextBox";
            this._searchTextBox.Size = new System.Drawing.Size(200, 25);
            // 
            // _reloadButton
            // 
            this._reloadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._reloadButton.Image = ((System.Drawing.Image)(resources.GetObject("_reloadButton.Image")));
            this._reloadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._reloadButton.Name = "_reloadButton";
            this._reloadButton.Size = new System.Drawing.Size(23, 22);
            this._reloadButton.Text = "toolStripButton1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // _clearSearchButton
            // 
            this._clearSearchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._clearSearchButton.Image = ((System.Drawing.Image)(resources.GetObject("_clearSearchButton.Image")));
            this._clearSearchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._clearSearchButton.Name = "_clearSearchButton";
            this._clearSearchButton.Size = new System.Drawing.Size(23, 22);
            this._clearSearchButton.Text = "Clear Search";
            // 
            // AlertsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 296);
            this.Controls.Add(this._alertsListView);
            this.Controls.Add(this._toolStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "AlertsView";
            this.Text = "Alerts";
            ((System.ComponentModel.ISupportInitialize)(this._alertsListView)).EndInit();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.FastObjectListView _alertsListView;
        private BrightIdeasSoftware.OLVColumn _contractCodeColumn;
        private BrightIdeasSoftware.OLVColumn _statusColumn;
        private BrightIdeasSoftware.OLVColumn _clientNameColumn;
        private BrightIdeasSoftware.OLVColumn _loanOfficerColumn;
        private BrightIdeasSoftware.OLVColumn _dateColumn;
        private BrightIdeasSoftware.OLVColumn _amountColumn;
        private BrightIdeasSoftware.OLVColumn _addressColumn;
        private BrightIdeasSoftware.OLVColumn _cityColumn;
        private BrightIdeasSoftware.OLVColumn _phoneColumn;
        private BrightIdeasSoftware.OLVColumn _branchColumn;
        private BrightIdeasSoftware.OLVColumn _lateDaysColumn;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton _loansDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem _performingLoansItem;
        private System.Windows.Forms.ToolStripMenuItem _lateLoansItem;
        private System.Windows.Forms.ToolStripMenuItem _pendingLoansItem;
        private System.Windows.Forms.ToolStripMenuItem _validatedLoansItem;
        private System.Windows.Forms.ToolStripMenuItem _postponedLoansItem;
        private System.Windows.Forms.ToolStripDropDownButton _savingsDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem _pendingSavingsItem;
        private System.Windows.Forms.ToolStripMenuItem _overdraftSavingsItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox _searchTextBox;
        private System.Windows.Forms.ToolStripButton _reloadButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton _clearSearchButton;
    }
}