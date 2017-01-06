namespace OpenCBS.GUI.Configuration.PaymentMethod
{
    partial class PaymentMethodForm
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
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this._buttonClose = new System.Windows.Forms.Button();
            this._TitleLabel = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this._listViewPaymentMethods = new System.Windows.Forms.ListView();
            this.chId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._checkBoxShowDeleted = new System.Windows.Forms.CheckBox();
            this._buttonAdd = new System.Windows.Forms.Button();
            this._buttonDelete = new System.Windows.Forms.Button();
            this._buttonEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.IsSplitterFixed = true;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this._buttonClose);
            this.splitContainerMain.Panel1.Controls.Add(this._TitleLabel);
            this.splitContainerMain.Panel1MinSize = 32;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainerMain.Size = new System.Drawing.Size(1121, 626);
            this.splitContainerMain.SplitterDistance = 47;
            this.splitContainerMain.TabIndex = 2;
            // 
            // _buttonClose
            // 
            this._buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonClose.Font = new System.Drawing.Font("Arial", 9.75F);
            this._buttonClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._buttonClose.Location = new System.Drawing.Point(947, 6);
            this._buttonClose.Name = "_buttonClose";
            this._buttonClose.Size = new System.Drawing.Size(162, 31);
            this._buttonClose.TabIndex = 9;
            this._buttonClose.Text = "Close";
            this._buttonClose.Click += new System.EventHandler(this._buttonClose_Click);
            // 
            // _TitleLabel
            // 
            this._TitleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(81)))), ((int)(((byte)(152)))));
            this._TitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._TitleLabel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this._TitleLabel.ForeColor = System.Drawing.Color.White;
            this._TitleLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._TitleLabel.Location = new System.Drawing.Point(0, 0);
            this._TitleLabel.Name = "_TitleLabel";
            this._TitleLabel.Size = new System.Drawing.Size(1121, 47);
            this._TitleLabel.TabIndex = 10;
            this._TitleLabel.Text = "Payment Methods";
            this._TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer2.Panel1.Controls.Add(this._listViewPaymentMethods);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer2.Panel2.Controls.Add(this._checkBoxShowDeleted);
            this.splitContainer2.Panel2.Controls.Add(this._buttonAdd);
            this.splitContainer2.Panel2.Controls.Add(this._buttonDelete);
            this.splitContainer2.Panel2.Controls.Add(this._buttonEdit);
            this.splitContainer2.Size = new System.Drawing.Size(1121, 575);
            this.splitContainer2.SplitterDistance = 906;
            this.splitContainer2.TabIndex = 0;
            // 
            // _listViewPaymentMethods
            // 
            this._listViewPaymentMethods.BackColor = System.Drawing.SystemColors.Window;
            this._listViewPaymentMethods.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chId,
            this.chName,
            this.chDescription});
            this._listViewPaymentMethods.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listViewPaymentMethods.Font = new System.Drawing.Font("Arial", 9.75F);
            this._listViewPaymentMethods.FullRowSelect = true;
            this._listViewPaymentMethods.GridLines = true;
            this._listViewPaymentMethods.HideSelection = false;
            this._listViewPaymentMethods.Location = new System.Drawing.Point(0, 0);
            this._listViewPaymentMethods.MultiSelect = false;
            this._listViewPaymentMethods.Name = "_listViewPaymentMethods";
            this._listViewPaymentMethods.Size = new System.Drawing.Size(906, 575);
            this._listViewPaymentMethods.TabIndex = 1;
            this._listViewPaymentMethods.UseCompatibleStateImageBehavior = false;
            this._listViewPaymentMethods.View = System.Windows.Forms.View.Details;
            this._listViewPaymentMethods.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._listViewPaymentMethods_MouseDoubleClick);
            // 
            // chId
            // 
            this.chId.Text = "ID";
            this.chId.Width = 57;
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 185;
            // 
            // chDescription
            // 
            this.chDescription.Text = "Description";
            this.chDescription.Width = 641;
            // 
            // _checkBoxShowDeleted
            // 
            this._checkBoxShowDeleted.AutoSize = true;
            this._checkBoxShowDeleted.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._checkBoxShowDeleted.Location = new System.Drawing.Point(20, 164);
            this._checkBoxShowDeleted.Name = "_checkBoxShowDeleted";
            this._checkBoxShowDeleted.Size = new System.Drawing.Size(93, 17);
            this._checkBoxShowDeleted.TabIndex = 12;
            this._checkBoxShowDeleted.Text = "Show Deleted";
            this._checkBoxShowDeleted.UseVisualStyleBackColor = true;
            this._checkBoxShowDeleted.Visible = false;
            // 
            // _buttonAdd
            // 
            this._buttonAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonAdd.Font = new System.Drawing.Font("Arial", 9.75F);
            this._buttonAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._buttonAdd.Location = new System.Drawing.Point(20, 15);
            this._buttonAdd.Name = "_buttonAdd";
            this._buttonAdd.Size = new System.Drawing.Size(150, 31);
            this._buttonAdd.TabIndex = 10;
            this._buttonAdd.Text = "Add";
            this._buttonAdd.Click += new System.EventHandler(this._buttonAdd_Click);
            // 
            // _buttonDelete
            // 
            this._buttonDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonDelete.Font = new System.Drawing.Font("Arial", 9.75F);
            this._buttonDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._buttonDelete.Location = new System.Drawing.Point(20, 115);
            this._buttonDelete.Name = "_buttonDelete";
            this._buttonDelete.Size = new System.Drawing.Size(150, 31);
            this._buttonDelete.TabIndex = 11;
            this._buttonDelete.Text = "Delete";
            this._buttonDelete.Visible = false;
            // 
            // _buttonEdit
            // 
            this._buttonEdit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonEdit.Font = new System.Drawing.Font("Arial", 9.75F);
            this._buttonEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._buttonEdit.Location = new System.Drawing.Point(20, 65);
            this._buttonEdit.Name = "_buttonEdit";
            this._buttonEdit.Size = new System.Drawing.Size(150, 31);
            this._buttonEdit.TabIndex = 11;
            this._buttonEdit.Text = "Edit";
            this._buttonEdit.Click += new System.EventHandler(this._buttonEdit_Click);
            // 
            // PaymentMethodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 626);
            this.Controls.Add(this.splitContainerMain);
            this.Name = "PaymentMethodForm";
            this.Text = "PaymentMethodForm";
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Button _buttonClose;
        private System.Windows.Forms.Label _TitleLabel;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView _listViewPaymentMethods;
        private System.Windows.Forms.ColumnHeader chId;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chDescription;
        private System.Windows.Forms.CheckBox _checkBoxShowDeleted;
        private System.Windows.Forms.Button _buttonAdd;
        private System.Windows.Forms.Button _buttonDelete;
        private System.Windows.Forms.Button _buttonEdit;
    }
}