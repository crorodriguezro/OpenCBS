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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentMethodForm));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this._listViewPaymentMethods = new System.Windows.Forms.ListView();
            this.chId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._checkBoxShowDeleted = new System.Windows.Forms.CheckBox();
            this._buttonAdd = new System.Windows.Forms.Button();
            this._buttonDelete = new System.Windows.Forms.Button();
            this._buttonEdit = new System.Windows.Forms.Button();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this._buttonClose = new System.Windows.Forms.Button();
            this._TitleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            resources.ApplyResources(this.splitContainer2.Panel1, "splitContainer2.Panel1");
            this.splitContainer2.Panel1.Controls.Add(this._listViewPaymentMethods);
            // 
            // splitContainer2.Panel2
            // 
            resources.ApplyResources(this.splitContainer2.Panel2, "splitContainer2.Panel2");
            this.splitContainer2.Panel2.Controls.Add(this._checkBoxShowDeleted);
            this.splitContainer2.Panel2.Controls.Add(this._buttonAdd);
            this.splitContainer2.Panel2.Controls.Add(this._buttonDelete);
            this.splitContainer2.Panel2.Controls.Add(this._buttonEdit);
            // 
            // _listViewPaymentMethods
            // 
            resources.ApplyResources(this._listViewPaymentMethods, "_listViewPaymentMethods");
            this._listViewPaymentMethods.BackColor = System.Drawing.SystemColors.Window;
            this._listViewPaymentMethods.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chId,
            this.chName,
            this.chDescription});
            this._listViewPaymentMethods.FullRowSelect = true;
            this._listViewPaymentMethods.GridLines = true;
            this._listViewPaymentMethods.HideSelection = false;
            this._listViewPaymentMethods.MultiSelect = false;
            this._listViewPaymentMethods.Name = "_listViewPaymentMethods";
            this._listViewPaymentMethods.UseCompatibleStateImageBehavior = false;
            this._listViewPaymentMethods.View = System.Windows.Forms.View.Details;
            this._listViewPaymentMethods.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._listViewPaymentMethods_MouseDoubleClick);
            // 
            // chId
            // 
            resources.ApplyResources(this.chId, "chId");
            // 
            // chName
            // 
            resources.ApplyResources(this.chName, "chName");
            // 
            // chDescription
            // 
            resources.ApplyResources(this.chDescription, "chDescription");
            // 
            // _checkBoxShowDeleted
            // 
            resources.ApplyResources(this._checkBoxShowDeleted, "_checkBoxShowDeleted");
            this._checkBoxShowDeleted.Name = "_checkBoxShowDeleted";
            this._checkBoxShowDeleted.UseVisualStyleBackColor = true;
            // 
            // _buttonAdd
            // 
            resources.ApplyResources(this._buttonAdd, "_buttonAdd");
            this._buttonAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonAdd.Name = "_buttonAdd";
            this._buttonAdd.Click += new System.EventHandler(this._buttonAdd_Click);
            // 
            // _buttonDelete
            // 
            resources.ApplyResources(this._buttonDelete, "_buttonDelete");
            this._buttonDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonDelete.Name = "_buttonDelete";
            // 
            // _buttonEdit
            // 
            resources.ApplyResources(this._buttonEdit, "_buttonEdit");
            this._buttonEdit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonEdit.Name = "_buttonEdit";
            this._buttonEdit.Click += new System.EventHandler(this._buttonEdit_Click);
            // 
            // splitContainerMain
            // 
            resources.ApplyResources(this.splitContainerMain, "splitContainerMain");
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            resources.ApplyResources(this.splitContainerMain.Panel1, "splitContainerMain.Panel1");
            this.splitContainerMain.Panel1.Controls.Add(this._buttonClose);
            this.splitContainerMain.Panel1.Controls.Add(this._TitleLabel);
            // 
            // splitContainerMain.Panel2
            // 
            resources.ApplyResources(this.splitContainerMain.Panel2, "splitContainerMain.Panel2");
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainer2);
            // 
            // _buttonClose
            // 
            resources.ApplyResources(this._buttonClose, "_buttonClose");
            this._buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonClose.Name = "_buttonClose";
            this._buttonClose.Click += new System.EventHandler(this._buttonClose_Click);
            // 
            // _TitleLabel
            // 
            resources.ApplyResources(this._TitleLabel, "_TitleLabel");
            this._TitleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(81)))), ((int)(((byte)(152)))));
            this._TitleLabel.ForeColor = System.Drawing.Color.White;
            this._TitleLabel.Name = "_TitleLabel";
            // 
            // PaymentMethodForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Name = "PaymentMethodForm";
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
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