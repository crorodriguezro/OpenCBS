namespace OpenCBS.Extension.Accounting.View
{
    partial class AccountView
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
            this._isDebitCheckBox = new System.Windows.Forms.CheckBox();
            this._labelTextBox = new System.Windows.Forms.TextBox();
            this._nameLabel = new System.Windows.Forms.Label();
            this._cancelButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            this._accountNumberTextBox = new System.Windows.Forms.TextBox();
            this._codeLabel = new System.Windows.Forms.Label();
            this._parentLabel = new System.Windows.Forms.Label();
            this._accountTypeComboBox = new System.Windows.Forms.ComboBox();
            this._accountTypeLabel = new System.Windows.Forms.Label();
            this._parentComboBox = new OpenCBS.Extension.Accounting.View.UserControl.AutocompletionComboBox();
            this._directCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // _isDebitCheckBox
            // 
            this._isDebitCheckBox.AutoSize = true;
            this._isDebitCheckBox.Location = new System.Drawing.Point(30, 263);
            this._isDebitCheckBox.Name = "_isDebitCheckBox";
            this._isDebitCheckBox.Size = new System.Drawing.Size(100, 19);
            this._isDebitCheckBox.TabIndex = 89;
            this._isDebitCheckBox.Text = "Debit account";
            this._isDebitCheckBox.UseVisualStyleBackColor = true;
            // 
            // _labelTextBox
            // 
            this._labelTextBox.Location = new System.Drawing.Point(30, 158);
            this._labelTextBox.Name = "_labelTextBox";
            this._labelTextBox.Size = new System.Drawing.Size(339, 23);
            this._labelTextBox.TabIndex = 84;
            // 
            // _nameLabel
            // 
            this._nameLabel.AutoSize = true;
            this._nameLabel.Location = new System.Drawing.Point(27, 140);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(85, 15);
            this._nameLabel.TabIndex = 92;
            this._nameLabel.Text = "Account name";
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(202, 338);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 91;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _okButton
            // 
            this._okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._okButton.Location = new System.Drawing.Point(121, 338);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 90;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _accountNumberTextBox
            // 
            this._accountNumberTextBox.Location = new System.Drawing.Point(30, 100);
            this._accountNumberTextBox.Name = "_accountNumberTextBox";
            this._accountNumberTextBox.Size = new System.Drawing.Size(149, 23);
            this._accountNumberTextBox.TabIndex = 83;
            // 
            // _codeLabel
            // 
            this._codeLabel.AutoSize = true;
            this._codeLabel.Location = new System.Drawing.Point(27, 82);
            this._codeLabel.Name = "_codeLabel";
            this._codeLabel.Size = new System.Drawing.Size(97, 15);
            this._codeLabel.TabIndex = 88;
            this._codeLabel.Text = "Account number";
            // 
            // _parentLabel
            // 
            this._parentLabel.AutoSize = true;
            this._parentLabel.Location = new System.Drawing.Point(27, 22);
            this._parentLabel.Name = "_parentLabel";
            this._parentLabel.Size = new System.Drawing.Size(87, 15);
            this._parentLabel.TabIndex = 85;
            this._parentLabel.Text = "Parent account";
            // 
            // _accountTypeComboBox
            // 
            this._accountTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._accountTypeComboBox.FormattingEnabled = true;
            this._accountTypeComboBox.Location = new System.Drawing.Point(30, 218);
            this._accountTypeComboBox.Name = "_accountTypeComboBox";
            this._accountTypeComboBox.Size = new System.Drawing.Size(339, 23);
            this._accountTypeComboBox.TabIndex = 94;
            // 
            // _accountTypeLabel
            // 
            this._accountTypeLabel.AutoSize = true;
            this._accountTypeLabel.Location = new System.Drawing.Point(27, 197);
            this._accountTypeLabel.Name = "_accountTypeLabel";
            this._accountTypeLabel.Size = new System.Drawing.Size(78, 15);
            this._accountTypeLabel.TabIndex = 95;
            this._accountTypeLabel.Text = "Account type";
            // 
            // _parentComboBox
            // 
            this._parentComboBox.FormattingEnabled = true;
            this._parentComboBox.Location = new System.Drawing.Point(30, 51);
            this._parentComboBox.Name = "_parentComboBox";
            this._parentComboBox.Size = new System.Drawing.Size(339, 23);
            this._parentComboBox.TabIndex = 96;
            // 
            // _directCheckBox
            // 
            this._directCheckBox.AutoSize = true;
            this._directCheckBox.Location = new System.Drawing.Point(30, 288);
            this._directCheckBox.Name = "_directCheckBox";
            this._directCheckBox.Size = new System.Drawing.Size(103, 19);
            this._directCheckBox.TabIndex = 89;
            this._directCheckBox.Text = "Direct account";
            this._directCheckBox.UseVisualStyleBackColor = true;
            // 
            // AccountView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(397, 379);
            this.Controls.Add(this._parentComboBox);
            this.Controls.Add(this._accountTypeLabel);
            this.Controls.Add(this._accountTypeComboBox);
            this.Controls.Add(this._directCheckBox);
            this.Controls.Add(this._isDebitCheckBox);
            this.Controls.Add(this._labelTextBox);
            this.Controls.Add(this._nameLabel);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._accountNumberTextBox);
            this.Controls.Add(this._codeLabel);
            this.Controls.Add(this._parentLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Account";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox _isDebitCheckBox;
        private System.Windows.Forms.TextBox _labelTextBox;
        private System.Windows.Forms.Label _nameLabel;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.TextBox _accountNumberTextBox;
        private System.Windows.Forms.Label _codeLabel;
        private System.Windows.Forms.Label _parentLabel;
        private System.Windows.Forms.ComboBox _accountTypeComboBox;
        private System.Windows.Forms.Label _accountTypeLabel;
        private UserControl.AutocompletionComboBox _parentComboBox;
        private System.Windows.Forms.CheckBox _directCheckBox;
    }
}