namespace OpenCBS.GUI.Configuration.EntryFee
{
    partial class EntryFeesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntryFeesForm));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this._listViewEntryFee = new System.Windows.Forms.ListView();
            this.chId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMax = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMaxSum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._checkBoxShowDeleted = new System.Windows.Forms.CheckBox();
            this._buttonAdd = new System.Windows.Forms.Button();
            this._buttonDelete = new System.Windows.Forms.Button();
            this._buttonEdit = new System.Windows.Forms.Button();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this._buttonClose = new System.Windows.Forms.Button();
            this.lblRoles = new System.Windows.Forms.Label();
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
            this.splitContainer2.Panel1.Controls.Add(this._listViewEntryFee);
            // 
            // splitContainer2.Panel2
            // 
            resources.ApplyResources(this.splitContainer2.Panel2, "splitContainer2.Panel2");
            this.splitContainer2.Panel2.Controls.Add(this._checkBoxShowDeleted);
            this.splitContainer2.Panel2.Controls.Add(this._buttonAdd);
            this.splitContainer2.Panel2.Controls.Add(this._buttonDelete);
            this.splitContainer2.Panel2.Controls.Add(this._buttonEdit);
            // 
            // _listViewEntryFee
            // 
            this._listViewEntryFee.BackColor = System.Drawing.SystemColors.Window;
            this._listViewEntryFee.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chId,
            this.chName,
            this.chMin,
            this.chMax,
            this.chRate,
            this.chMaxSum});
            resources.ApplyResources(this._listViewEntryFee, "_listViewEntryFee");
            this._listViewEntryFee.FullRowSelect = true;
            this._listViewEntryFee.GridLines = true;
            this._listViewEntryFee.HideSelection = false;
            this._listViewEntryFee.MultiSelect = false;
            this._listViewEntryFee.Name = "_listViewEntryFee";
            this._listViewEntryFee.UseCompatibleStateImageBehavior = false;
            this._listViewEntryFee.View = System.Windows.Forms.View.Details;
            this._listViewEntryFee.DoubleClick += new System.EventHandler(this._listViewEntryFee_DoubleClick);
            // 
            // chId
            // 
            resources.ApplyResources(this.chId, "chId");
            // 
            // chName
            // 
            resources.ApplyResources(this.chName, "chName");
            // 
            // chMin
            // 
            resources.ApplyResources(this.chMin, "chMin");
            // 
            // chMax
            // 
            resources.ApplyResources(this.chMax, "chMax");
            // 
            // chRate
            // 
            resources.ApplyResources(this.chRate, "chRate");
            // 
            // chMaxSum
            // 
            resources.ApplyResources(this.chMaxSum, "chMaxSum");
            // 
            // _checkBoxShowDeleted
            // 
            resources.ApplyResources(this._checkBoxShowDeleted, "_checkBoxShowDeleted");
            this._checkBoxShowDeleted.Name = "_checkBoxShowDeleted";
            this._checkBoxShowDeleted.UseVisualStyleBackColor = true;
            this._checkBoxShowDeleted.CheckedChanged += new System.EventHandler(this._checkBoxShowDeleted_CheckedChanged);
            // 
            // _buttonAdd
            // 
            this._buttonAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this._buttonAdd, "_buttonAdd");
            this._buttonAdd.Name = "_buttonAdd";
            this._buttonAdd.Click += new System.EventHandler(this._buttonAdd_Click);
            // 
            // _buttonDelete
            // 
            this._buttonDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this._buttonDelete, "_buttonDelete");
            this._buttonDelete.Name = "_buttonDelete";
            this._buttonDelete.Click += new System.EventHandler(this._buttonDelete_Click);
            // 
            // _buttonEdit
            // 
            this._buttonEdit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this._buttonEdit, "_buttonEdit");
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
            this.splitContainerMain.Panel1.Controls.Add(this._buttonClose);
            this.splitContainerMain.Panel1.Controls.Add(this.lblRoles);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainer2);
            // 
            // _buttonClose
            // 
            resources.ApplyResources(this._buttonClose, "_buttonClose");
            this._buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonClose.Name = "_buttonClose";
            this._buttonClose.Click += new System.EventHandler(this._buttonClose_Click);
            // 
            // lblRoles
            // 
            this.lblRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(81)))), ((int)(((byte)(152)))));
            resources.ApplyResources(this.lblRoles, "lblRoles");
            this.lblRoles.ForeColor = System.Drawing.Color.White;
            this.lblRoles.Name = "lblRoles";
            // 
            // EntryFeesForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Name = "EntryFeesForm";
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
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button _buttonDelete;
        private System.Windows.Forms.Button _buttonEdit;
        private System.Windows.Forms.Button _buttonAdd;
        private System.Windows.Forms.ListView _listViewEntryFee;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chMin;
        private System.Windows.Forms.ColumnHeader chMax;
        private System.Windows.Forms.ColumnHeader chRate;
        private System.Windows.Forms.ColumnHeader chMaxSum;
        private System.Windows.Forms.ColumnHeader chId;
        private System.Windows.Forms.CheckBox _checkBoxShowDeleted;
        private System.Windows.Forms.Button _buttonClose;
        private System.Windows.Forms.Label lblRoles;
    }
}