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
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownMaxSum)).BeginInit();
            this.SuspendLayout();
            // 
            // _textBoxId
            // 
            this._textBoxId.Enabled = false;
            this._textBoxId.Location = new System.Drawing.Point(117, 35);
            this._textBoxId.Name = "_textBoxId";
            this._textBoxId.Size = new System.Drawing.Size(182, 20);
            this._textBoxId.TabIndex = 0;
            // 
            // _labelId
            // 
            this._labelId.AutoSize = true;
            this._labelId.Location = new System.Drawing.Point(35, 38);
            this._labelId.Name = "_labelId";
            this._labelId.Size = new System.Drawing.Size(16, 13);
            this._labelId.TabIndex = 1;
            this._labelId.Text = "Id";
            // 
            // _labelName
            // 
            this._labelName.AutoSize = true;
            this._labelName.Location = new System.Drawing.Point(35, 78);
            this._labelName.Name = "_labelName";
            this._labelName.Size = new System.Drawing.Size(35, 13);
            this._labelName.TabIndex = 3;
            this._labelName.Text = "Name";
            // 
            // _textBoxName
            // 
            this._textBoxName.Location = new System.Drawing.Point(117, 75);
            this._textBoxName.Name = "_textBoxName";
            this._textBoxName.Size = new System.Drawing.Size(182, 20);
            this._textBoxName.TabIndex = 2;
            // 
            // _labelMin
            // 
            this._labelMin.AutoSize = true;
            this._labelMin.Location = new System.Drawing.Point(35, 115);
            this._labelMin.Name = "_labelMin";
            this._labelMin.Size = new System.Drawing.Size(24, 13);
            this._labelMin.TabIndex = 5;
            this._labelMin.Text = "Min";
            // 
            // _labelMaxSum
            // 
            this._labelMaxSum.AutoSize = true;
            this._labelMaxSum.Location = new System.Drawing.Point(35, 230);
            this._labelMaxSum.Name = "_labelMaxSum";
            this._labelMaxSum.Size = new System.Drawing.Size(51, 13);
            this._labelMaxSum.TabIndex = 11;
            this._labelMaxSum.Text = "Max Sum";
            // 
            // _labelRate
            // 
            this._labelRate.AutoSize = true;
            this._labelRate.Location = new System.Drawing.Point(35, 193);
            this._labelRate.Name = "_labelRate";
            this._labelRate.Size = new System.Drawing.Size(30, 13);
            this._labelRate.TabIndex = 9;
            this._labelRate.Text = "Rate";
            // 
            // _labelMax
            // 
            this._labelMax.AutoSize = true;
            this._labelMax.Location = new System.Drawing.Point(35, 153);
            this._labelMax.Name = "_labelMax";
            this._labelMax.Size = new System.Drawing.Size(27, 13);
            this._labelMax.TabIndex = 7;
            this._labelMax.Text = "Max";
            // 
            // _buttonSave
            // 
            this._buttonSave.Location = new System.Drawing.Point(101, 284);
            this._buttonSave.Name = "_buttonSave";
            this._buttonSave.Size = new System.Drawing.Size(144, 36);
            this._buttonSave.TabIndex = 12;
            this._buttonSave.Text = "Save";
            this._buttonSave.UseVisualStyleBackColor = true;
            this._buttonSave.Click += new System.EventHandler(this._buttonSave_Click);
            // 
            // _comboBoxRate
            // 
            this._comboBoxRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxRate.FormattingEnabled = true;
            this._comboBoxRate.Items.AddRange(new object[] {
            "True",
            "False"});
            this._comboBoxRate.Location = new System.Drawing.Point(117, 185);
            this._comboBoxRate.Name = "_comboBoxRate";
            this._comboBoxRate.Size = new System.Drawing.Size(182, 21);
            this._comboBoxRate.TabIndex = 13;
            // 
            // _numericUpDownMin
            // 
            this._numericUpDownMin.Location = new System.Drawing.Point(117, 107);
            this._numericUpDownMin.Maximum = new decimal(new int[] {
            -402653185,
            -1613725636,
            54210108,
            0});
            this._numericUpDownMin.Name = "_numericUpDownMin";
            this._numericUpDownMin.Size = new System.Drawing.Size(182, 20);
            this._numericUpDownMin.TabIndex = 14;
            this._numericUpDownMin.ValueChanged += new System.EventHandler(this._numericUpDownMin_ValueChanged);
            // 
            // _numericUpDownMax
            // 
            this._numericUpDownMax.Location = new System.Drawing.Point(117, 146);
            this._numericUpDownMax.Maximum = new decimal(new int[] {
            -402653185,
            -1613725636,
            54210108,
            0});
            this._numericUpDownMax.Name = "_numericUpDownMax";
            this._numericUpDownMax.Size = new System.Drawing.Size(182, 20);
            this._numericUpDownMax.TabIndex = 15;
            this._numericUpDownMax.ValueChanged += new System.EventHandler(this._numericUpDownMax_ValueChanged);
            // 
            // _numericUpDownMaxSum
            // 
            this._numericUpDownMaxSum.Location = new System.Drawing.Point(117, 223);
            this._numericUpDownMaxSum.Maximum = new decimal(new int[] {
            -402653185,
            -1613725636,
            54210108,
            0});
            this._numericUpDownMaxSum.Name = "_numericUpDownMaxSum";
            this._numericUpDownMaxSum.Size = new System.Drawing.Size(182, 20);
            this._numericUpDownMaxSum.TabIndex = 16;
            // 
            // EntryFeeAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 348);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EntryFeeAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
    }
}