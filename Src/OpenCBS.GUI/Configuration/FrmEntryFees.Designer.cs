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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEntryFees));
            this.groupBoxEntryFees = new System.Windows.Forms.GroupBox();
            this.swbtnEntryFeesRemoveCycle = new System.Windows.Forms.Button();
            this.swbtnEntryFeesAddCycle = new System.Windows.Forms.Button();
            this.cbRate = new System.Windows.Forms.ComboBox();
            this.cbxRate = new System.Windows.Forms.CheckBox();
            this.tbEntryFeesValues = new System.Windows.Forms.TextBox();
            this.lvEntryFees = new OpenCBS.GUI.UserControl.ListViewEx();
            this.chEntryFeeId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEntryFeeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEntryFeeMin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEntryFeeMax = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEntryFeeValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEntryFeeRate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEntryFeeIsAdded = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEntryFeeCycleId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEntryFeeNewId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEntryFeeIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEntryFeeMaxSum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nudEntryFeescycleFrom = new System.Windows.Forms.NumericUpDown();
            this.lblEntryFeesFromCycle = new System.Windows.Forms.Label();
            this.cbEnableEntryFeesCycle = new System.Windows.Forms.CheckBox();
            this.lblEntryFeesCycle = new System.Windows.Forms.Label();
            this.cmbEntryFeesCycles = new System.Windows.Forms.ComboBox();
            this.groupBoxEntryFees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEntryFeescycleFrom)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxEntryFees
            // 
            this.groupBoxEntryFees.Controls.Add(this.swbtnEntryFeesRemoveCycle);
            this.groupBoxEntryFees.Controls.Add(this.swbtnEntryFeesAddCycle);
            this.groupBoxEntryFees.Controls.Add(this.cbRate);
            this.groupBoxEntryFees.Controls.Add(this.cbxRate);
            this.groupBoxEntryFees.Controls.Add(this.tbEntryFeesValues);
            this.groupBoxEntryFees.Controls.Add(this.lvEntryFees);
            this.groupBoxEntryFees.Controls.Add(this.nudEntryFeescycleFrom);
            this.groupBoxEntryFees.Controls.Add(this.lblEntryFeesFromCycle);
            this.groupBoxEntryFees.Controls.Add(this.cbEnableEntryFeesCycle);
            this.groupBoxEntryFees.Controls.Add(this.lblEntryFeesCycle);
            this.groupBoxEntryFees.Controls.Add(this.cmbEntryFeesCycles);
            resources.ApplyResources(this.groupBoxEntryFees, "groupBoxEntryFees");
            this.groupBoxEntryFees.Name = "groupBoxEntryFees";
            this.groupBoxEntryFees.TabStop = false;
            // 
            // swbtnEntryFeesRemoveCycle
            // 
            resources.ApplyResources(this.swbtnEntryFeesRemoveCycle, "swbtnEntryFeesRemoveCycle");
            this.swbtnEntryFeesRemoveCycle.Name = "swbtnEntryFeesRemoveCycle";
            // 
            // swbtnEntryFeesAddCycle
            // 
            resources.ApplyResources(this.swbtnEntryFeesAddCycle, "swbtnEntryFeesAddCycle");
            this.swbtnEntryFeesAddCycle.Name = "swbtnEntryFeesAddCycle";
            // 
            // cbRate
            // 
            this.cbRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRate.FormattingEnabled = true;
            this.cbRate.Items.AddRange(new object[] {
            resources.GetString("cbRate.Items"),
            resources.GetString("cbRate.Items1")});
            resources.ApplyResources(this.cbRate, "cbRate");
            this.cbRate.Name = "cbRate";
            // 
            // cbxRate
            // 
            resources.ApplyResources(this.cbxRate, "cbxRate");
            this.cbxRate.Name = "cbxRate";
            // 
            // tbEntryFeesValues
            // 
            resources.ApplyResources(this.tbEntryFeesValues, "tbEntryFeesValues");
            this.tbEntryFeesValues.Name = "tbEntryFeesValues";
            // 
            // lvEntryFees
            // 
            this.lvEntryFees.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chEntryFeeId,
            this.chEntryFeeName,
            this.chEntryFeeMin,
            this.chEntryFeeMax,
            this.chEntryFeeValue,
            this.chEntryFeeRate,
            this.chEntryFeeIsAdded,
            this.chEntryFeeCycleId,
            this.chEntryFeeNewId,
            this.chEntryFeeIndex,
            this.chEntryFeeMaxSum});
            resources.ApplyResources(this.lvEntryFees, "lvEntryFees");
            this.lvEntryFees.DoubleClickActivation = false;
            this.lvEntryFees.FullRowSelect = true;
            this.lvEntryFees.GridLines = true;
            this.lvEntryFees.Name = "lvEntryFees";
            this.lvEntryFees.UseCompatibleStateImageBehavior = false;
            this.lvEntryFees.View = System.Windows.Forms.View.Details;
            // 
            // chEntryFeeId
            // 
            resources.ApplyResources(this.chEntryFeeId, "chEntryFeeId");
            // 
            // chEntryFeeName
            // 
            resources.ApplyResources(this.chEntryFeeName, "chEntryFeeName");
            // 
            // chEntryFeeMin
            // 
            resources.ApplyResources(this.chEntryFeeMin, "chEntryFeeMin");
            // 
            // chEntryFeeMax
            // 
            resources.ApplyResources(this.chEntryFeeMax, "chEntryFeeMax");
            // 
            // chEntryFeeValue
            // 
            resources.ApplyResources(this.chEntryFeeValue, "chEntryFeeValue");
            // 
            // chEntryFeeRate
            // 
            resources.ApplyResources(this.chEntryFeeRate, "chEntryFeeRate");
            // 
            // chEntryFeeIsAdded
            // 
            resources.ApplyResources(this.chEntryFeeIsAdded, "chEntryFeeIsAdded");
            // 
            // chEntryFeeCycleId
            // 
            resources.ApplyResources(this.chEntryFeeCycleId, "chEntryFeeCycleId");
            // 
            // chEntryFeeNewId
            // 
            resources.ApplyResources(this.chEntryFeeNewId, "chEntryFeeNewId");
            // 
            // chEntryFeeIndex
            // 
            resources.ApplyResources(this.chEntryFeeIndex, "chEntryFeeIndex");
            // 
            // chEntryFeeMaxSum
            // 
            resources.ApplyResources(this.chEntryFeeMaxSum, "chEntryFeeMaxSum");
            // 
            // nudEntryFeescycleFrom
            // 
            resources.ApplyResources(this.nudEntryFeescycleFrom, "nudEntryFeescycleFrom");
            this.nudEntryFeescycleFrom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEntryFeescycleFrom.Name = "nudEntryFeescycleFrom";
            this.nudEntryFeescycleFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblEntryFeesFromCycle
            // 
            resources.ApplyResources(this.lblEntryFeesFromCycle, "lblEntryFeesFromCycle");
            this.lblEntryFeesFromCycle.Name = "lblEntryFeesFromCycle";
            // 
            // cbEnableEntryFeesCycle
            // 
            resources.ApplyResources(this.cbEnableEntryFeesCycle, "cbEnableEntryFeesCycle");
            this.cbEnableEntryFeesCycle.Name = "cbEnableEntryFeesCycle";
            // 
            // lblEntryFeesCycle
            // 
            resources.ApplyResources(this.lblEntryFeesCycle, "lblEntryFeesCycle");
            this.lblEntryFeesCycle.Name = "lblEntryFeesCycle";
            // 
            // cmbEntryFeesCycles
            // 
            this.cmbEntryFeesCycles.DisplayMember = "Name";
            this.cmbEntryFeesCycles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEntryFeesCycles.FormattingEnabled = true;
            resources.ApplyResources(this.cmbEntryFeesCycles, "cmbEntryFeesCycles");
            this.cmbEntryFeesCycles.Name = "cmbEntryFeesCycles";
            this.cmbEntryFeesCycles.ValueMember = "Id";
            // 
            // FrmEntryFees
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxEntryFees);
            this.Name = "FrmEntryFees";
            this.groupBoxEntryFees.ResumeLayout(false);
            this.groupBoxEntryFees.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEntryFeescycleFrom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxEntryFees;
        private System.Windows.Forms.Button swbtnEntryFeesRemoveCycle;
        private System.Windows.Forms.Button swbtnEntryFeesAddCycle;
        private System.Windows.Forms.ComboBox cbRate;
        private System.Windows.Forms.CheckBox cbxRate;
        private System.Windows.Forms.TextBox tbEntryFeesValues;
        private UserControl.ListViewEx lvEntryFees;
        private System.Windows.Forms.ColumnHeader chEntryFeeId;
        private System.Windows.Forms.ColumnHeader chEntryFeeName;
        private System.Windows.Forms.ColumnHeader chEntryFeeMin;
        private System.Windows.Forms.ColumnHeader chEntryFeeMax;
        private System.Windows.Forms.ColumnHeader chEntryFeeValue;
        private System.Windows.Forms.ColumnHeader chEntryFeeRate;
        private System.Windows.Forms.ColumnHeader chEntryFeeIsAdded;
        private System.Windows.Forms.ColumnHeader chEntryFeeCycleId;
        private System.Windows.Forms.ColumnHeader chEntryFeeNewId;
        private System.Windows.Forms.ColumnHeader chEntryFeeIndex;
        private System.Windows.Forms.ColumnHeader chEntryFeeMaxSum;
        private System.Windows.Forms.NumericUpDown nudEntryFeescycleFrom;
        private System.Windows.Forms.Label lblEntryFeesFromCycle;
        private System.Windows.Forms.CheckBox cbEnableEntryFeesCycle;
        private System.Windows.Forms.Label lblEntryFeesCycle;
        private System.Windows.Forms.ComboBox cmbEntryFeesCycles;
    }
}