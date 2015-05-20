namespace OpenCBS.ArchitectureV2.View
{
    partial class VillageBankView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VillageBankView));
            this._tabList = new Cyotek.Windows.Forms.TabList();
            this._detailsPage = new Cyotek.Windows.Forms.TabListPage();
            this._membersPage = new Cyotek.Windows.Forms.TabListPage();
            this._loansPage = new Cyotek.Windows.Forms.TabListPage();
            this._membersListView = new BrightIdeasSoftware.FastObjectListView();
            this._memberFirstNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._memberLastNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._memberPassportColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._memberLoanCycleColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._memberActiveColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._tabList.SuspendLayout();
            this._membersPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._membersListView)).BeginInit();
            this.SuspendLayout();
            // 
            // _tabList
            // 
            this._tabList.Controls.Add(this._detailsPage);
            this._tabList.Controls.Add(this._membersPage);
            this._tabList.Controls.Add(this._loansPage);
            this._tabList.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabList.Location = new System.Drawing.Point(0, 0);
            this._tabList.Name = "_tabList";
            this._tabList.Size = new System.Drawing.Size(858, 390);
            this._tabList.TabIndex = 0;
            // 
            // _detailsPage
            // 
            this._detailsPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this._detailsPage.Name = "_detailsPage";
            this._detailsPage.Size = new System.Drawing.Size(700, 382);
            this._detailsPage.TabIndex = 0;
            this._detailsPage.Text = "Details";
            // 
            // _membersPage
            // 
            this._membersPage.Controls.Add(this._membersListView);
            this._membersPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this._membersPage.Name = "_membersPage";
            this._membersPage.Size = new System.Drawing.Size(700, 382);
            this._membersPage.TabIndex = 1;
            this._membersPage.Text = "Members";
            // 
            // _loansPage
            // 
            this._loansPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this._loansPage.Name = "_loansPage";
            this._loansPage.Size = new System.Drawing.Size(700, 382);
            this._loansPage.TabIndex = 2;
            this._loansPage.Text = "Loans";
            // 
            // _membersListView
            // 
            this._membersListView.AllColumns.Add(this._memberFirstNameColumn);
            this._membersListView.AllColumns.Add(this._memberLastNameColumn);
            this._membersListView.AllColumns.Add(this._memberPassportColumn);
            this._membersListView.AllColumns.Add(this._memberLoanCycleColumn);
            this._membersListView.AllColumns.Add(this._memberActiveColumn);
            this._membersListView.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._membersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._memberFirstNameColumn,
            this._memberLastNameColumn,
            this._memberPassportColumn,
            this._memberLoanCycleColumn,
            this._memberActiveColumn});
            this._membersListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._membersListView.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._membersListView.FullRowSelect = true;
            this._membersListView.GridLines = true;
            this._membersListView.Location = new System.Drawing.Point(0, 0);
            this._membersListView.MultiSelect = false;
            this._membersListView.Name = "_membersListView";
            this._membersListView.ShowGroups = false;
            this._membersListView.Size = new System.Drawing.Size(700, 382);
            this._membersListView.TabIndex = 3;
            this._membersListView.UseAlternatingBackColors = true;
            this._membersListView.UseCompatibleStateImageBehavior = false;
            this._membersListView.View = System.Windows.Forms.View.Details;
            this._membersListView.VirtualMode = true;
            // 
            // _memberFirstNameColumn
            // 
            this._memberFirstNameColumn.AspectName = "FirstName";
            this._memberFirstNameColumn.Text = "First Name";
            this._memberFirstNameColumn.Width = 150;
            // 
            // _memberLastNameColumn
            // 
            this._memberLastNameColumn.AspectName = "LastName";
            this._memberLastNameColumn.Text = "Last Name";
            this._memberLastNameColumn.Width = 150;
            // 
            // _memberPassportColumn
            // 
            this._memberPassportColumn.AspectName = "Passport";
            this._memberPassportColumn.Text = "Passport";
            this._memberPassportColumn.Width = 150;
            // 
            // _memberLoanCycleColumn
            // 
            this._memberLoanCycleColumn.AspectName = "LoanCycle";
            this._memberLoanCycleColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._memberLoanCycleColumn.Text = "Loan Cycle";
            this._memberLoanCycleColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._memberLoanCycleColumn.Width = 100;
            // 
            // _memberActiveColumn
            // 
            this._memberActiveColumn.AspectName = "Active";
            this._memberActiveColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._memberActiveColumn.Text = "Active";
            this._memberActiveColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._memberActiveColumn.Width = 100;
            // 
            // VillageBankView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 390);
            this.Controls.Add(this._tabList);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VillageBankView";
            this.Text = "Village Bank";
            this._tabList.ResumeLayout(false);
            this._membersPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._membersListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cyotek.Windows.Forms.TabList _tabList;
        private Cyotek.Windows.Forms.TabListPage _detailsPage;
        private Cyotek.Windows.Forms.TabListPage _membersPage;
        private Cyotek.Windows.Forms.TabListPage _loansPage;
        private BrightIdeasSoftware.FastObjectListView _membersListView;
        private BrightIdeasSoftware.OLVColumn _memberFirstNameColumn;
        private BrightIdeasSoftware.OLVColumn _memberLastNameColumn;
        private BrightIdeasSoftware.OLVColumn _memberPassportColumn;
        private BrightIdeasSoftware.OLVColumn _memberLoanCycleColumn;
        private BrightIdeasSoftware.OLVColumn _memberActiveColumn;
    }
}