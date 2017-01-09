using OpenCBS.ArchitectureV2.Accounting.View.UserControl;

namespace OpenCBS.ArchitectureV2.Accounting.View
{
    partial class BookingsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookingsView));
            this._buttonsToolStrip = new System.Windows.Forms.ToolStrip();
            this._addButton = new System.Windows.Forms.ToolStripButton();
            this._editButton = new System.Windows.Forms.ToolStripButton();
            this._deleteButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._printButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._printControlButton = new System.Windows.Forms.ToolStripButton();
            this.lblCredit = new System.Windows.Forms.Label();
            this.lblDebit = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._dateToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this._dateFromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this._bookingsListView = new BrightIdeasSoftware.FastObjectListView();
            this._dateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._debitColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._creditColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._amountColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._clientLastNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._clientFirstNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._descriptionColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._userColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._doc1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._doc2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._refreshButton = new System.Windows.Forms.Button();
            this._debitComboBox = new AutocompletionComboBox();
            this._creditComboBox = new AutocompletionComboBox();
            this._buttonsToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._bookingsListView)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonsToolStrip
            // 
            this._buttonsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._addButton,
            this._editButton,
            this._deleteButton,
            this.toolStripSeparator1,
            this._printButton,
            this.toolStripSeparator2,
            this._printControlButton});
            resources.ApplyResources(this._buttonsToolStrip, "_buttonsToolStrip");
            this._buttonsToolStrip.Name = "_buttonsToolStrip";
            // 
            // _addButton
            // 
            this._addButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this._addButton, "_addButton");
            this._addButton.Name = "_addButton";
            // 
            // _editButton
            // 
            this._editButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this._editButton, "_editButton");
            this._editButton.Name = "_editButton";
            // 
            // _deleteButton
            // 
            this._deleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this._deleteButton, "_deleteButton");
            this._deleteButton.Name = "_deleteButton";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // _printButton
            // 
            this._printButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this._printButton, "_printButton");
            this._printButton.Name = "_printButton";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // _printControlButton
            // 
            this._printControlButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._printControlButton.Image = global::OpenCBS.ArchitectureV2.Properties.Resources.page_white_excel;
            resources.ApplyResources(this._printControlButton, "_printControlButton");
            this._printControlButton.Name = "_printControlButton";
            // 
            // lblCredit
            // 
            resources.ApplyResources(this.lblCredit, "lblCredit");
            this.lblCredit.BackColor = System.Drawing.Color.Transparent;
            this.lblCredit.Name = "lblCredit";
            // 
            // lblDebit
            // 
            resources.ApplyResources(this.lblDebit, "lblDebit");
            this.lblDebit.BackColor = System.Drawing.Color.Transparent;
            this.lblDebit.Name = "lblDebit";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // _dateToDateTimePicker
            // 
            this._dateToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this._dateToDateTimePicker, "_dateToDateTimePicker");
            this._dateToDateTimePicker.Name = "_dateToDateTimePicker";
            // 
            // _dateFromDateTimePicker
            // 
            this._dateFromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this._dateFromDateTimePicker, "_dateFromDateTimePicker");
            this._dateFromDateTimePicker.Name = "_dateFromDateTimePicker";
            // 
            // _bookingsListView
            // 
            this._bookingsListView.AllColumns.Add(this._dateColumn);
            this._bookingsListView.AllColumns.Add(this._debitColumn);
            this._bookingsListView.AllColumns.Add(this._creditColumn);
            this._bookingsListView.AllColumns.Add(this._amountColumn);
            this._bookingsListView.AllColumns.Add(this._clientLastNameColumn);
            this._bookingsListView.AllColumns.Add(this._clientFirstNameColumn);
            this._bookingsListView.AllColumns.Add(this._descriptionColumn);
            this._bookingsListView.AllColumns.Add(this._userColumn);
            this._bookingsListView.AllColumns.Add(this._doc1);
            this._bookingsListView.AllColumns.Add(this._doc2);
            this._bookingsListView.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._bookingsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._dateColumn,
            this._debitColumn,
            this._creditColumn,
            this._amountColumn,
            this._clientLastNameColumn,
            this._clientFirstNameColumn,
            this._descriptionColumn,
            this._userColumn,
            this._doc1,
            this._doc2});
            resources.ApplyResources(this._bookingsListView, "_bookingsListView");
            this._bookingsListView.FullRowSelect = true;
            this._bookingsListView.GridLines = true;
            this._bookingsListView.Name = "_bookingsListView";
            this._bookingsListView.ShowGroups = false;
            this._bookingsListView.UseCellFormatEvents = true;
            this._bookingsListView.UseCompatibleStateImageBehavior = false;
            this._bookingsListView.UseFiltering = true;
            this._bookingsListView.View = System.Windows.Forms.View.Details;
            this._bookingsListView.VirtualMode = true;
            // 
            // _dateColumn
            // 
            this._dateColumn.AspectName = "Date";
            this._dateColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            resources.ApplyResources(this._dateColumn, "_dateColumn");
            // 
            // _debitColumn
            // 
            this._debitColumn.AspectName = "DebitAccount";
            resources.ApplyResources(this._debitColumn, "_debitColumn");
            // 
            // _creditColumn
            // 
            this._creditColumn.AspectName = "CreditAccount";
            resources.ApplyResources(this._creditColumn, "_creditColumn");
            // 
            // _amountColumn
            // 
            this._amountColumn.AspectName = "Amount";
            this._amountColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this._amountColumn, "_amountColumn");
            // 
            // _clientLastNameColumn
            // 
            this._clientLastNameColumn.AspectName = "ClientLastName";
            resources.ApplyResources(this._clientLastNameColumn, "_clientLastNameColumn");
            // 
            // _clientFirstNameColumn
            // 
            this._clientFirstNameColumn.AspectName = "ClientFirstName";
            resources.ApplyResources(this._clientFirstNameColumn, "_clientFirstNameColumn");
            // 
            // _descriptionColumn
            // 
            this._descriptionColumn.AspectName = "Description";
            resources.ApplyResources(this._descriptionColumn, "_descriptionColumn");
            // 
            // _userColumn
            // 
            this._userColumn.AspectName = "UserName";
            resources.ApplyResources(this._userColumn, "_userColumn");
            // 
            // _doc1
            // 
            this._doc1.AspectName = "Doc1";
            resources.ApplyResources(this._doc1, "_doc1");
            // 
            // _doc2
            // 
            this._doc2.AspectName = "Doc2";
            resources.ApplyResources(this._doc2, "_doc2");
            // 
            // _refreshButton
            // 
            this._refreshButton.BackColor = System.Drawing.Color.Transparent;
            this._refreshButton.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this._refreshButton, "_refreshButton");
            this._refreshButton.Image = global::OpenCBS.ArchitectureV2.Properties.Resources.arrow_refresh;
            this._refreshButton.Name = "_refreshButton";
            this._refreshButton.UseVisualStyleBackColor = false;
            // 
            // _debitComboBox
            // 
            this._debitComboBox.FormattingEnabled = true;
            resources.ApplyResources(this._debitComboBox, "_debitComboBox");
            this._debitComboBox.Name = "_debitComboBox";
            // 
            // _creditComboBox
            // 
            this._creditComboBox.FormattingEnabled = true;
            resources.ApplyResources(this._creditComboBox, "_creditComboBox");
            this._creditComboBox.Name = "_creditComboBox";
            // 
            // BookingsView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._creditComboBox);
            this.Controls.Add(this._debitComboBox);
            this.Controls.Add(this._refreshButton);
            this.Controls.Add(this._bookingsListView);
            this.Controls.Add(this.lblCredit);
            this.Controls.Add(this._dateFromDateTimePicker);
            this.Controls.Add(this.lblDebit);
            this.Controls.Add(this._dateToDateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._buttonsToolStrip);
            this.Name = "BookingsView";
            this._buttonsToolStrip.ResumeLayout(false);
            this._buttonsToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._bookingsListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker _dateToDateTimePicker;
        private System.Windows.Forms.DateTimePicker _dateFromDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDebit;
        private System.Windows.Forms.Label lblCredit;
        private System.Windows.Forms.ToolStrip _buttonsToolStrip;
        private System.Windows.Forms.ToolStripButton _addButton;
        private System.Windows.Forms.ToolStripButton _editButton;
        private System.Windows.Forms.ToolStripButton _deleteButton;
        private System.Windows.Forms.ToolStripDropDownButton _printButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton _printControlButton;
        private BrightIdeasSoftware.FastObjectListView _bookingsListView;
        private BrightIdeasSoftware.OLVColumn _dateColumn;
        private BrightIdeasSoftware.OLVColumn _debitColumn;
        private BrightIdeasSoftware.OLVColumn _creditColumn;
        private BrightIdeasSoftware.OLVColumn _amountColumn;
        private BrightIdeasSoftware.OLVColumn _clientLastNameColumn;
        private BrightIdeasSoftware.OLVColumn _clientFirstNameColumn;
        private BrightIdeasSoftware.OLVColumn _descriptionColumn;
        private BrightIdeasSoftware.OLVColumn _userColumn;
        private System.Windows.Forms.Button _refreshButton;
        private BrightIdeasSoftware.OLVColumn _doc1;
        private BrightIdeasSoftware.OLVColumn _doc2;
        private UserControl.AutocompletionComboBox _debitComboBox;
        private UserControl.AutocompletionComboBox _creditComboBox;
    }
}