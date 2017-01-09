namespace OpenCBS.ArchitectureV2.Accounting.View
{
    partial class AccountsView
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
            this._accountsListView = new BrightIdeasSoftware.TreeListView();
            this._accountNumberColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this._accountNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._addButton = new System.Windows.Forms.ToolStripButton();
            this._editButton = new System.Windows.Forms.ToolStripButton();
            this._deleteButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this._accountsListView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _accountsListView
            // 
            this._accountsListView.AllColumns.Add(this._accountNumberColumn);
            this._accountsListView.AllColumns.Add(this._accountNameColumn);
            this._accountsListView.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._accountsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._accountNumberColumn,
            this._accountNameColumn});
            this._accountsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._accountsListView.FullRowSelect = true;
            this._accountsListView.HideSelection = false;
            this._accountsListView.Location = new System.Drawing.Point(0, 25);
            this._accountsListView.MultiSelect = false;
            this._accountsListView.Name = "_accountsListView";
            this._accountsListView.OwnerDraw = true;
            this._accountsListView.ShowGroups = false;
            this._accountsListView.Size = new System.Drawing.Size(1121, 673);
            this._accountsListView.TabIndex = 34;
            this._accountsListView.UseAlternatingBackColors = true;
            this._accountsListView.UseCompatibleStateImageBehavior = false;
            this._accountsListView.View = System.Windows.Forms.View.Details;
            this._accountsListView.VirtualMode = true;
            // 
            // _accountNumberColumn
            // 
            this._accountNumberColumn.AspectName = "AccountNumber";
            this._accountNumberColumn.IsEditable = false;
            this._accountNumberColumn.Text = "Account Number";
            this._accountNumberColumn.Width = 300;
            // 
            // _accountNameColumn
            // 
            this._accountNameColumn.AspectName = "Label";
            this._accountNameColumn.Text = "Account Name";
            this._accountNameColumn.Width = 700;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._addButton,
            this._editButton,
            this._deleteButton});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1121, 25);
            this.toolStrip1.TabIndex = 35;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _addButton
            // 
            this._addButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._addButton.Image = global::OpenCBS.ArchitectureV2.Properties.Resources.add;
            this._addButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(23, 22);
            this._addButton.Text = "Add";
            // 
            // _editButton
            // 
            this._editButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._editButton.Image = global::OpenCBS.ArchitectureV2.Properties.Resources.pencil;
            this._editButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._editButton.Name = "_editButton";
            this._editButton.Size = new System.Drawing.Size(23, 22);
            this._editButton.Text = "Edit";
            // 
            // _deleteButton
            // 
            this._deleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._deleteButton.Image = global::OpenCBS.ArchitectureV2.Properties.Resources.delete;
            this._deleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.Size = new System.Drawing.Size(23, 22);
            this._deleteButton.Text = "Delete";
            // 
            // AccountsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 698);
            this.Controls.Add(this._accountsListView);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "AccountsView";
            this.Text = "Chart of Accounts";
            ((System.ComponentModel.ISupportInitialize)(this._accountsListView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.TreeListView _accountsListView;
        private BrightIdeasSoftware.OLVColumn _accountNumberColumn;
        private BrightIdeasSoftware.OLVColumn _accountNameColumn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton _addButton;
        private System.Windows.Forms.ToolStripButton _editButton;
        private System.Windows.Forms.ToolStripButton _deleteButton;
    }
}