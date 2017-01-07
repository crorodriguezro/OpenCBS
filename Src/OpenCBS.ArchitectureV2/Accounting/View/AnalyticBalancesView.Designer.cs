namespace OpenCBS.Extension.Accounting.View
{
    partial class AnalyticBalancesView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalyticBalancesView));
            this._analyticBalancesListView = new BrightIdeasSoftware.FastObjectListView();
            this._codeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._nameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._startDebitColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._startCreditColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._debitColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._creditColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._endDebitColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._endCreditColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._saldoColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._excelButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this._analyticBalancesListView)).BeginInit();
            this._toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _analyticBalancesListView
            // 
            this._analyticBalancesListView.AllColumns.Add(this._codeColumn);
            this._analyticBalancesListView.AllColumns.Add(this._nameColumn);
            this._analyticBalancesListView.AllColumns.Add(this._startDebitColumn);
            this._analyticBalancesListView.AllColumns.Add(this._startCreditColumn);
            this._analyticBalancesListView.AllColumns.Add(this._debitColumn);
            this._analyticBalancesListView.AllColumns.Add(this._creditColumn);
            this._analyticBalancesListView.AllColumns.Add(this._endDebitColumn);
            this._analyticBalancesListView.AllColumns.Add(this._endCreditColumn);
            this._analyticBalancesListView.AllColumns.Add(this._saldoColumn);
            this._analyticBalancesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._codeColumn,
            this._nameColumn,
            this._startDebitColumn,
            this._startCreditColumn,
            this._debitColumn,
            this._creditColumn,
            this._endDebitColumn,
            this._saldoColumn});
            this._analyticBalancesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._analyticBalancesListView.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._analyticBalancesListView.FullRowSelect = true;
            this._analyticBalancesListView.GridLines = true;
            this._analyticBalancesListView.Location = new System.Drawing.Point(0, 25);
            this._analyticBalancesListView.MultiSelect = false;
            this._analyticBalancesListView.Name = "_analyticBalancesListView";
            this._analyticBalancesListView.ShowGroups = false;
            this._analyticBalancesListView.Size = new System.Drawing.Size(770, 332);
            this._analyticBalancesListView.TabIndex = 0;
            this._analyticBalancesListView.UseCompatibleStateImageBehavior = false;
            this._analyticBalancesListView.View = System.Windows.Forms.View.Details;
            this._analyticBalancesListView.VirtualMode = true;
            // 
            // _codeColumn
            // 
            this._codeColumn.AspectName = "Code";
            this._codeColumn.Text = "Account Number";
            this._codeColumn.Width = 110;
            // 
            // _nameColumn
            // 
            this._nameColumn.AspectName = "Name";
            this._nameColumn.Text = "Account Name";
            this._nameColumn.Width = 400;
            // 
            // _startDebitColumn
            // 
            this._startDebitColumn.AspectName = "StartDebit";
            this._startDebitColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._startDebitColumn.Text = "Start Debit";
            this._startDebitColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._startDebitColumn.Width = 110;
            // 
            // _startCreditColumn
            // 
            this._startCreditColumn.AspectName = "StartCredit";
            this._startCreditColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._startCreditColumn.Text = "Start Credit";
            this._startCreditColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._startCreditColumn.Width = 110;
            // 
            // _debitColumn
            // 
            this._debitColumn.AspectName = "Debit";
            this._debitColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._debitColumn.Text = "Debit";
            this._debitColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._debitColumn.Width = 110;
            // 
            // _creditColumn
            // 
            this._creditColumn.AspectName = "Credit";
            this._creditColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._creditColumn.Text = "Credit";
            this._creditColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._creditColumn.Width = 110;
            // 
            // _endDebitColumn
            // 
            this._endDebitColumn.AspectName = "EndDebit";
            this._endDebitColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._endDebitColumn.Text = "End Debit";
            this._endDebitColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._endDebitColumn.Width = 110;
            // 
            // _endCreditColumn
            // 
            this._endCreditColumn.AspectName = "EndCredit";
            this._endCreditColumn.DisplayIndex = 7;
            this._endCreditColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._endCreditColumn.IsVisible = false;
            this._endCreditColumn.Text = "End Credit";
            this._endCreditColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._endCreditColumn.Width = 110;
            // 
            // _saldoColumn
            // 
            this._saldoColumn.AspectName = "Saldo";
            this._saldoColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._saldoColumn.Text = "Balance";
            this._saldoColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._saldoColumn.Width = 110;
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._excelButton,
            this.toolStripSeparator1});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(770, 25);
            this._toolStrip.TabIndex = 2;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // AnalyticBalancesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 357);
            this.Controls.Add(this._analyticBalancesListView);
            this.Controls.Add(this._toolStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnalyticBalancesView";
            this.Text = "Balances of Analytic Accounts";
            ((System.ComponentModel.ISupportInitialize)(this._analyticBalancesListView)).EndInit();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.FastObjectListView _analyticBalancesListView;
        private BrightIdeasSoftware.OLVColumn _codeColumn;
        private BrightIdeasSoftware.OLVColumn _nameColumn;
        private BrightIdeasSoftware.OLVColumn _startDebitColumn;
        private BrightIdeasSoftware.OLVColumn _startCreditColumn;
        private BrightIdeasSoftware.OLVColumn _debitColumn;
        private BrightIdeasSoftware.OLVColumn _creditColumn;
        private BrightIdeasSoftware.OLVColumn _endDebitColumn;
        private BrightIdeasSoftware.OLVColumn _endCreditColumn;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _excelButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private BrightIdeasSoftware.OLVColumn _saldoColumn;
    }
}