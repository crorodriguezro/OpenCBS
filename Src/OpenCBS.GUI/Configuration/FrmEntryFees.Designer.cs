namespace OpenCBS.GUI.Configuration
{
    partial class FrmEntryFees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEntryFees));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this._buttonDelete = new System.Windows.Forms.Button();
            this._buttonEdit = new System.Windows.Forms.Button();
            this._buttonAdd = new System.Windows.Forms.Button();
            this.listViewEntryFee = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMax = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMaxSum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this._buttonClose = new System.Windows.Forms.Button();
            this.lblRoles = new System.Windows.Forms.Label();
            this.chId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            resources.ApplyResources(this.splitContainer2.Panel1, "splitContainer2.Panel1");
            this.splitContainer2.Panel1.Controls.Add(this._buttonDelete);
            this.splitContainer2.Panel1.Controls.Add(this._buttonEdit);
            this.splitContainer2.Panel1.Controls.Add(this._buttonAdd);
            // 
            // splitContainer2.Panel2
            // 
            resources.ApplyResources(this.splitContainer2.Panel2, "splitContainer2.Panel2");
            this.splitContainer2.Panel2.Controls.Add(this.listViewEntryFee);
            // 
            // _buttonDelete
            // 
            this._buttonDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this._buttonDelete, "_buttonDelete");
            this._buttonDelete.Name = "_buttonDelete";
            // 
            // _buttonEdit
            // 
            this._buttonEdit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this._buttonEdit, "_buttonEdit");
            this._buttonEdit.Name = "_buttonEdit";
            // 
            // _buttonAdd
            // 
            this._buttonAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this._buttonAdd, "_buttonAdd");
            this._buttonAdd.Name = "_buttonAdd";
            // 
            // listViewEntryFee
            // 
            this.listViewEntryFee.BackColor = System.Drawing.SystemColors.Window;
            this.listViewEntryFee.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chId,
            this.chName,
            this.chMin,
            this.chMax,
            this.chRate,
            this.chMaxSum});
            resources.ApplyResources(this.listViewEntryFee, "listViewEntryFee");
            this.listViewEntryFee.FullRowSelect = true;
            this.listViewEntryFee.GridLines = true;
            this.listViewEntryFee.HideSelection = false;
            this.listViewEntryFee.MultiSelect = false;
            this.listViewEntryFee.Name = "listViewEntryFee";
            this.listViewEntryFee.UseCompatibleStateImageBehavior = false;
            this.listViewEntryFee.View = System.Windows.Forms.View.Details;
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
            // 
            // lblRoles
            // 
            this.lblRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(81)))), ((int)(((byte)(152)))));
            resources.ApplyResources(this.lblRoles, "lblRoles");
            this.lblRoles.ForeColor = System.Drawing.Color.White;
            this.lblRoles.Name = "lblRoles";
            // 
            // chId
            // 
            resources.ApplyResources(this.chId, "chId");
            // 
            // FrmEntryFees
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Name = "FrmEntryFees";
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblRoles;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button _buttonDelete;
        private System.Windows.Forms.Button _buttonEdit;
        private System.Windows.Forms.Button _buttonAdd;
        private System.Windows.Forms.ListView listViewEntryFee;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chMin;
        private System.Windows.Forms.ColumnHeader chMax;
        private System.Windows.Forms.ColumnHeader chRate;
        private System.Windows.Forms.ColumnHeader chMaxSum;
        private System.Windows.Forms.ColumnHeader chId;
    }
}