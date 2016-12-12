namespace OpenCBS.GUI.Configuration.EntryFee
{
    partial class EntryFeeAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntryFeeAddEdit));
            this._textBoxId = new System.Windows.Forms.TextBox();
            this._labelId = new System.Windows.Forms.Label();
            this._labelName = new System.Windows.Forms.Label();
            this._textBoxName = new System.Windows.Forms.TextBox();
            this._labelMin = new System.Windows.Forms.Label();
            this._labelMaxSum = new System.Windows.Forms.Label();
            this._labelRate = new System.Windows.Forms.Label();
            this._labelMax = new System.Windows.Forms.Label();
            this._buttonSave = new System.Windows.Forms.Button();
            this._comboBoxRate = new System.Windows.Forms.ComboBox();
            this._numericUpDownMin = new System.Windows.Forms.NumericUpDown();
            this._numericUpDownMax = new System.Windows.Forms.NumericUpDown();
            this._numericUpDownMaxSum = new System.Windows.Forms.NumericUpDown();
            this._timer = new System.Windows.Forms.Timer(this.components);
            this._labelError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownMaxSum)).BeginInit();
            this.SuspendLayout();
            // 
            // _textBoxId
            // 
            resources.ApplyResources(this._textBoxId, "_textBoxId");
            this._textBoxId.Name = "_textBoxId";
            // 
            // _labelId
            // 
            resources.ApplyResources(this._labelId, "_labelId");
            this._labelId.Name = "_labelId";
            // 
            // _labelName
            // 
            resources.ApplyResources(this._labelName, "_labelName");
            this._labelName.Name = "_labelName";
            // 
            // _textBoxName
            // 
            resources.ApplyResources(this._textBoxName, "_textBoxName");
            this._textBoxName.Name = "_textBoxName";
            // 
            // _labelMin
            // 
            resources.ApplyResources(this._labelMin, "_labelMin");
            this._labelMin.Name = "_labelMin";
            // 
            // _labelMaxSum
            // 
            resources.ApplyResources(this._labelMaxSum, "_labelMaxSum");
            this._labelMaxSum.Name = "_labelMaxSum";
            // 
            // _labelRate
            // 
            resources.ApplyResources(this._labelRate, "_labelRate");
            this._labelRate.Name = "_labelRate";
            // 
            // _labelMax
            // 
            resources.ApplyResources(this._labelMax, "_labelMax");
            this._labelMax.Name = "_labelMax";
            // 
            // _buttonSave
            // 
            resources.ApplyResources(this._buttonSave, "_buttonSave");
            this._buttonSave.Name = "_buttonSave";
            this._buttonSave.UseVisualStyleBackColor = true;
            this._buttonSave.Click += new System.EventHandler(this._buttonSave_Click);
            // 
            // _comboBoxRate
            // 
            this._comboBoxRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxRate.FormattingEnabled = true;
            this._comboBoxRate.Items.AddRange(new object[] {
            resources.GetString("_comboBoxRate.Items"),
            resources.GetString("_comboBoxRate.Items1")});
            resources.ApplyResources(this._comboBoxRate, "_comboBoxRate");
            this._comboBoxRate.Name = "_comboBoxRate";
            // 
            // _numericUpDownMin
            // 
            resources.ApplyResources(this._numericUpDownMin, "_numericUpDownMin");
            this._numericUpDownMin.Maximum = new decimal(new int[] {
            -402653185,
            -1613725636,
            54210108,
            0});
            this._numericUpDownMin.Name = "_numericUpDownMin";
            this._numericUpDownMin.ValueChanged += new System.EventHandler(this._numericUpDownMin_ValueChanged);
            // 
            // _numericUpDownMax
            // 
            resources.ApplyResources(this._numericUpDownMax, "_numericUpDownMax");
            this._numericUpDownMax.Maximum = new decimal(new int[] {
            -402653185,
            -1613725636,
            54210108,
            0});
            this._numericUpDownMax.Name = "_numericUpDownMax";
            this._numericUpDownMax.ValueChanged += new System.EventHandler(this._numericUpDownMax_ValueChanged);
            // 
            // _numericUpDownMaxSum
            // 
            resources.ApplyResources(this._numericUpDownMaxSum, "_numericUpDownMaxSum");
            this._numericUpDownMaxSum.Maximum = new decimal(new int[] {
            -402653185,
            -1613725636,
            54210108,
            0});
            this._numericUpDownMaxSum.Name = "_numericUpDownMaxSum";
            // 
            // _labelError
            // 
            resources.ApplyResources(this._labelError, "_labelError");
            this._labelError.ForeColor = System.Drawing.SystemColors.GrayText;
            this._labelError.Name = "_labelError";
            // 
            // EntryFeeAddEdit
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._labelError);
            this.Controls.Add(this._numericUpDownMaxSum);
            this.Controls.Add(this._numericUpDownMax);
            this.Controls.Add(this._numericUpDownMin);
            this.Controls.Add(this._comboBoxRate);
            this.Controls.Add(this._buttonSave);
            this.Controls.Add(this._labelMaxSum);
            this.Controls.Add(this._labelRate);
            this.Controls.Add(this._labelMax);
            this.Controls.Add(this._labelMin);
            this.Controls.Add(this._labelName);
            this.Controls.Add(this._textBoxName);
            this.Controls.Add(this._labelId);
            this.Controls.Add(this._textBoxId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EntryFeeAddEdit";
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownMaxSum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _textBoxId;
        private System.Windows.Forms.Label _labelId;
        private System.Windows.Forms.Label _labelName;
        private System.Windows.Forms.TextBox _textBoxName;
        private System.Windows.Forms.Label _labelMin;
        private System.Windows.Forms.Label _labelMaxSum;
        private System.Windows.Forms.Label _labelRate;
        private System.Windows.Forms.Label _labelMax;
        private System.Windows.Forms.Button _buttonSave;
        private System.Windows.Forms.ComboBox _comboBoxRate;
        private System.Windows.Forms.NumericUpDown _numericUpDownMin;
        private System.Windows.Forms.NumericUpDown _numericUpDownMax;
        private System.Windows.Forms.NumericUpDown _numericUpDownMaxSum;
        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.Label _labelError;
    }
}