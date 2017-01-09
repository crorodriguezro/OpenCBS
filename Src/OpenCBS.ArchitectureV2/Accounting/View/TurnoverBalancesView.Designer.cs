namespace OpenCBS.ArchitectureV2.Accounting.View
{
    partial class TurnoverBalancesView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TurnoverBalancesView));
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._excelButton = new System.Windows.Forms.ToolStripButton();
            this._showAnalyticButton = new System.Windows.Forms.ToolStripButton();
            this._turnoverBalancesListView = new BrightIdeasSoftware.TreeListView();
            this._codeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._nameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._startDebitColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._startCreditColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._debitColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._creditColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._endDebitColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._endCreditColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._balanceColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._fromLabel = new System.Windows.Forms.Label();
            this._toLabel = new System.Windows.Forms.Label();
            this._toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this._fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this._branchComboBox = new System.Windows.Forms.ComboBox();
            this._branchLabel = new System.Windows.Forms.Label();
            this._refreshButton = new System.Windows.Forms.Button();
            this._checkBoxExpandAll = new System.Windows.Forms.CheckBox();
            this._toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._turnoverBalancesListView)).BeginInit();
            this.SuspendLayout();
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._excelButton,
            this._showAnalyticButton});
            resources.ApplyResources(this._toolStrip, "_toolStrip");
            this._toolStrip.Name = "_toolStrip";
            // 
            // _excelButton
            // 
            this._excelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._excelButton.Image = global::OpenCBS.ArchitectureV2.Properties.Resources.page_white_excel;
            resources.ApplyResources(this._excelButton, "_excelButton");
            this._excelButton.Name = "_excelButton";
            // 
            // _showAnalyticButton
            // 
            this._showAnalyticButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this._showAnalyticButton, "_showAnalyticButton");
            this._showAnalyticButton.Name = "_showAnalyticButton";
            // 
            // _turnoverBalancesListView
            // 
            this._turnoverBalancesListView.AllColumns.Add(this._codeColumn);
            this._turnoverBalancesListView.AllColumns.Add(this._nameColumn);
            this._turnoverBalancesListView.AllColumns.Add(this._startDebitColumn);
            this._turnoverBalancesListView.AllColumns.Add(this._startCreditColumn);
            this._turnoverBalancesListView.AllColumns.Add(this._debitColumn);
            this._turnoverBalancesListView.AllColumns.Add(this._creditColumn);
            this._turnoverBalancesListView.AllColumns.Add(this._endDebitColumn);
            this._turnoverBalancesListView.AllColumns.Add(this._endCreditColumn);
            this._turnoverBalancesListView.AllColumns.Add(this._balanceColumn);
            this._turnoverBalancesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._codeColumn,
            this._nameColumn,
            this._startDebitColumn,
            this._startCreditColumn,
            this._debitColumn,
            this._creditColumn,
            this._endDebitColumn,
            this._endCreditColumn});
            resources.ApplyResources(this._turnoverBalancesListView, "_turnoverBalancesListView");
            this._turnoverBalancesListView.FullRowSelect = true;
            this._turnoverBalancesListView.GridLines = true;
            this._turnoverBalancesListView.Name = "_turnoverBalancesListView";
            this._turnoverBalancesListView.OwnerDraw = true;
            this._turnoverBalancesListView.ShowGroups = false;
            this._turnoverBalancesListView.UseCompatibleStateImageBehavior = false;
            this._turnoverBalancesListView.View = System.Windows.Forms.View.Details;
            this._turnoverBalancesListView.VirtualMode = true;
            // 
            // _codeColumn
            // 
            this._codeColumn.AspectName = "Code";
            resources.ApplyResources(this._codeColumn, "_codeColumn");
            // 
            // _nameColumn
            // 
            this._nameColumn.AspectName = "Name";
            resources.ApplyResources(this._nameColumn, "_nameColumn");
            // 
            // _startDebitColumn
            // 
            this._startDebitColumn.AspectName = "StartDebit";
            this._startDebitColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this._startDebitColumn, "_startDebitColumn");
            // 
            // _startCreditColumn
            // 
            this._startCreditColumn.AspectName = "StartCredit";
            this._startCreditColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this._startCreditColumn, "_startCreditColumn");
            // 
            // _debitColumn
            // 
            this._debitColumn.AspectName = "Debit";
            this._debitColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this._debitColumn, "_debitColumn");
            // 
            // _creditColumn
            // 
            this._creditColumn.AspectName = "Credit";
            this._creditColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this._creditColumn, "_creditColumn");
            // 
            // _endDebitColumn
            // 
            this._endDebitColumn.AspectName = "EndDebit";
            this._endDebitColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this._endDebitColumn, "_endDebitColumn");
            // 
            // _endCreditColumn
            // 
            this._endCreditColumn.AspectName = "EndCredit";
            this._endCreditColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this._endCreditColumn, "_endCreditColumn");
            // 
            // _balanceColumn
            // 
            this._balanceColumn.AspectName = "Saldo";
            this._balanceColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._balanceColumn.IsVisible = false;
            resources.ApplyResources(this._balanceColumn, "_balanceColumn");
            // 
            // _fromLabel
            // 
            resources.ApplyResources(this._fromLabel, "_fromLabel");
            this._fromLabel.BackColor = System.Drawing.Color.Transparent;
            this._fromLabel.Name = "_fromLabel";
            // 
            // _toLabel
            // 
            resources.ApplyResources(this._toLabel, "_toLabel");
            this._toLabel.BackColor = System.Drawing.Color.Transparent;
            this._toLabel.Name = "_toLabel";
            // 
            // _toDateTimePicker
            // 
            this._toDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this._toDateTimePicker, "_toDateTimePicker");
            this._toDateTimePicker.Name = "_toDateTimePicker";
            // 
            // _fromDateTimePicker
            // 
            this._fromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this._fromDateTimePicker, "_fromDateTimePicker");
            this._fromDateTimePicker.Name = "_fromDateTimePicker";
            // 
            // _branchComboBox
            // 
            this._branchComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._branchComboBox.FormattingEnabled = true;
            resources.ApplyResources(this._branchComboBox, "_branchComboBox");
            this._branchComboBox.Name = "_branchComboBox";
            // 
            // _branchLabel
            // 
            resources.ApplyResources(this._branchLabel, "_branchLabel");
            this._branchLabel.BackColor = System.Drawing.Color.Transparent;
            this._branchLabel.Name = "_branchLabel";
            // 
            // _refreshButton
            // 
            this._refreshButton.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this._refreshButton, "_refreshButton");
            this._refreshButton.FlatAppearance.BorderSize = 0;
            this._refreshButton.Image = global::OpenCBS.ArchitectureV2.Properties.Resources.arrow_refresh;
            this._refreshButton.Name = "_refreshButton";
            this._refreshButton.UseVisualStyleBackColor = false;
            // 
            // _checkBoxExpandAll
            // 
            resources.ApplyResources(this._checkBoxExpandAll, "_checkBoxExpandAll");
            this._checkBoxExpandAll.Name = "_checkBoxExpandAll";
            this._checkBoxExpandAll.UseVisualStyleBackColor = true;
            // 
            // TurnoverBalancesView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._checkBoxExpandAll);
            this.Controls.Add(this._refreshButton);
            this.Controls.Add(this._branchLabel);
            this.Controls.Add(this._branchComboBox);
            this.Controls.Add(this._fromLabel);
            this.Controls.Add(this._toLabel);
            this.Controls.Add(this._toDateTimePicker);
            this.Controls.Add(this._fromDateTimePicker);
            this.Controls.Add(this._turnoverBalancesListView);
            this.Controls.Add(this._toolStrip);
            this.Name = "TurnoverBalancesView";
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._turnoverBalancesListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _toolStrip;
        private BrightIdeasSoftware.TreeListView _turnoverBalancesListView;
        private BrightIdeasSoftware.OLVColumn _codeColumn;
        private BrightIdeasSoftware.OLVColumn _nameColumn;
        private BrightIdeasSoftware.OLVColumn _startDebitColumn;
        private BrightIdeasSoftware.OLVColumn _startCreditColumn;
        private BrightIdeasSoftware.OLVColumn _debitColumn;
        private BrightIdeasSoftware.OLVColumn _creditColumn;
        private BrightIdeasSoftware.OLVColumn _endDebitColumn;
        private BrightIdeasSoftware.OLVColumn _endCreditColumn;
        private System.Windows.Forms.Label _fromLabel;
        private System.Windows.Forms.Label _toLabel;
        private System.Windows.Forms.DateTimePicker _toDateTimePicker;
        private System.Windows.Forms.DateTimePicker _fromDateTimePicker;
        private System.Windows.Forms.ComboBox _branchComboBox;
        private System.Windows.Forms.Label _branchLabel;
        private System.Windows.Forms.Button _refreshButton;
        private System.Windows.Forms.ToolStripButton _excelButton;
        private BrightIdeasSoftware.OLVColumn _balanceColumn;
        private System.Windows.Forms.ToolStripButton _showAnalyticButton;
        private System.Windows.Forms.CheckBox _checkBoxExpandAll;
    }
}