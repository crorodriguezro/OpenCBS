using OpenCBS.ArchitectureV2.Accounting.View.UserControl;

namespace OpenCBS.ArchitectureV2.Accounting.View
{
    partial class AccountMovementsView
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
            this._accountMovementsListView = new BrightIdeasSoftware.FastObjectListView();
            this._dateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._descriptionColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._startBalanceColum = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._debitColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._creditColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._amountColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._endBalanceColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._excelButton = new System.Windows.Forms.ToolStripButton();
            this._fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this._toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._debitLabel = new System.Windows.Forms.Label();
            this._refreshButton = new System.Windows.Forms.Button();
            this._accountComboBox = new AutocompletionComboBox();
            ((System.ComponentModel.ISupportInitialize)(this._accountMovementsListView)).BeginInit();
            this._toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _accountMovementsListView
            // 
            this._accountMovementsListView.AllColumns.Add(this._dateColumn);
            this._accountMovementsListView.AllColumns.Add(this._descriptionColumn);
            this._accountMovementsListView.AllColumns.Add(this._startBalanceColum);
            this._accountMovementsListView.AllColumns.Add(this._debitColumn);
            this._accountMovementsListView.AllColumns.Add(this._creditColumn);
            this._accountMovementsListView.AllColumns.Add(this._amountColumn);
            this._accountMovementsListView.AllColumns.Add(this._endBalanceColumn);
            this._accountMovementsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._dateColumn,
            this._descriptionColumn,
            this._startBalanceColum,
            this._debitColumn,
            this._creditColumn,
            this._amountColumn,
            this._endBalanceColumn});
            this._accountMovementsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._accountMovementsListView.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._accountMovementsListView.FullRowSelect = true;
            this._accountMovementsListView.GridLines = true;
            this._accountMovementsListView.Location = new System.Drawing.Point(0, 25);
            this._accountMovementsListView.MultiSelect = false;
            this._accountMovementsListView.Name = "_accountMovementsListView";
            this._accountMovementsListView.ShowGroups = false;
            this._accountMovementsListView.Size = new System.Drawing.Size(929, 394);
            this._accountMovementsListView.TabIndex = 0;
            this._accountMovementsListView.UseCompatibleStateImageBehavior = false;
            this._accountMovementsListView.View = System.Windows.Forms.View.Details;
            this._accountMovementsListView.VirtualMode = true;
            // 
            // _dateColumn
            // 
            this._dateColumn.AspectName = "Date";
            this._dateColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._dateColumn.Text = "Date";
            this._dateColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._dateColumn.Width = 120;
            // 
            // _descriptionColumn
            // 
            this._descriptionColumn.AspectName = "Description";
            this._descriptionColumn.Text = "Description";
            this._descriptionColumn.Width = 200;
            // 
            // _startBalanceColum
            // 
            this._startBalanceColum.AspectName = "StartBalance";
            this._startBalanceColum.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._startBalanceColum.Text = "Start Balance";
            this._startBalanceColum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._startBalanceColum.Width = 120;
            // 
            // _debitColumn
            // 
            this._debitColumn.AspectName = "Debit";
            this._debitColumn.Text = "Debit";
            this._debitColumn.Width = 100;
            // 
            // _creditColumn
            // 
            this._creditColumn.AspectName = "Credit";
            this._creditColumn.Text = "Credit";
            this._creditColumn.Width = 100;
            // 
            // _amountColumn
            // 
            this._amountColumn.AspectName = "Amount";
            this._amountColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._amountColumn.Text = "Amount";
            this._amountColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._amountColumn.Width = 100;
            // 
            // _endBalanceColumn
            // 
            this._endBalanceColumn.AspectName = "EndBalance";
            this._endBalanceColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._endBalanceColumn.Text = "End Balance";
            this._endBalanceColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._endBalanceColumn.Width = 120;
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._excelButton});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(929, 25);
            this._toolStrip.TabIndex = 1;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _excelButton
            // 
            this._excelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._excelButton.Image = global::OpenCBS.ArchitectureV2.Properties.Resources.page_white_excel;
            this._excelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._excelButton.Name = "_excelButton";
            this._excelButton.Size = new System.Drawing.Size(23, 22);
            this._excelButton.Text = "Excel";
            // 
            // _fromDateTimePicker
            // 
            this._fromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._fromDateTimePicker.Location = new System.Drawing.Point(503, 1);
            this._fromDateTimePicker.Name = "_fromDateTimePicker";
            this._fromDateTimePicker.Size = new System.Drawing.Size(100, 23);
            this._fromDateTimePicker.TabIndex = 2;
            // 
            // _toDateTimePicker
            // 
            this._toDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._toDateTimePicker.Location = new System.Drawing.Point(649, 1);
            this._toDateTimePicker.Name = "_toDateTimePicker";
            this._toDateTimePicker.Size = new System.Drawing.Size(100, 23);
            this._toDateTimePicker.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(622, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(462, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "From";
            // 
            // _debitLabel
            // 
            this._debitLabel.AutoSize = true;
            this._debitLabel.BackColor = System.Drawing.Color.Transparent;
            this._debitLabel.Location = new System.Drawing.Point(48, 4);
            this._debitLabel.Name = "_debitLabel";
            this._debitLabel.Size = new System.Drawing.Size(52, 15);
            this._debitLabel.TabIndex = 6;
            this._debitLabel.Text = "Account";
            // 
            // _refreshButton
            // 
            this._refreshButton.BackColor = System.Drawing.Color.Transparent;
            this._refreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._refreshButton.FlatAppearance.BorderSize = 0;
            this._refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._refreshButton.Image = global::OpenCBS.ArchitectureV2.Properties.Resources.arrow_refresh;
            this._refreshButton.Location = new System.Drawing.Point(755, 1);
            this._refreshButton.Name = "_refreshButton";
            this._refreshButton.Size = new System.Drawing.Size(23, 23);
            this._refreshButton.TabIndex = 13;
            this._refreshButton.UseVisualStyleBackColor = false;
            // 
            // _accountComboBox
            // 
            this._accountComboBox.FormattingEnabled = true;
            this._accountComboBox.Location = new System.Drawing.Point(106, 1);
            this._accountComboBox.Name = "_accountComboBox";
            this._accountComboBox.Size = new System.Drawing.Size(350, 23);
            this._accountComboBox.TabIndex = 14;
            // 
            // AccountMovementsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 419);
            this.Controls.Add(this._accountComboBox);
            this.Controls.Add(this._refreshButton);
            this.Controls.Add(this._debitLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._toDateTimePicker);
            this.Controls.Add(this._fromDateTimePicker);
            this.Controls.Add(this._accountMovementsListView);
            this.Controls.Add(this._toolStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "AccountMovementsView";
            this.Text = "Account Movements";
            ((System.ComponentModel.ISupportInitialize)(this._accountMovementsListView)).EndInit();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.FastObjectListView _accountMovementsListView;
        private BrightIdeasSoftware.OLVColumn _dateColumn;
        private BrightIdeasSoftware.OLVColumn _creditColumn;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private BrightIdeasSoftware.OLVColumn _debitColumn;
        private BrightIdeasSoftware.OLVColumn _amountColumn;
        private BrightIdeasSoftware.OLVColumn _descriptionColumn;
        private System.Windows.Forms.DateTimePicker _fromDateTimePicker;
        private System.Windows.Forms.DateTimePicker _toDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _debitLabel;
        private BrightIdeasSoftware.OLVColumn _startBalanceColum;
        private BrightIdeasSoftware.OLVColumn _endBalanceColumn;
        private System.Windows.Forms.ToolStripButton _excelButton;
        private System.Windows.Forms.Button _refreshButton;
        private AutocompletionComboBox _accountComboBox;
    }
}