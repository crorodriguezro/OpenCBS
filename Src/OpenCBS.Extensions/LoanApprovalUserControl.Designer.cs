using OpenCBS.Shared.Settings;

namespace OpenCBS.Extensions
{
    partial class LoanApprovalUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCCStatus = new System.Windows.Forms.Label();
            this.pnlCCStatus = new System.Windows.Forms.Panel();
            this._statusComboBox = new System.Windows.Forms.ComboBox();
            this.labelCreditCommiteeDate = new System.Windows.Forms.Label();
            this._dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.labelCreditCommiteeComment = new System.Windows.Forms.Label();
            this.labelCreditCommiteeCode = new System.Windows.Forms.Label();
            this._commentTextBox = new System.Windows.Forms.TextBox();
            this._codeTextBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this._saveButton = new System.Windows.Forms.Button();
            this._printButton = new OpenCBS.Controls.PrintButton();
            this.tableLayoutPanel11.SuspendLayout();
            this.pnlCCStatus.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.AutoSize = true;
            this.tableLayoutPanel11.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel11.ColumnCount = 2;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Controls.Add(this.lblCCStatus, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.pnlCCStatus, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.labelCreditCommiteeDate, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this._dateTimePicker, 1, 1);
            this.tableLayoutPanel11.Controls.Add(this.labelCreditCommiteeComment, 0, 3);
            this.tableLayoutPanel11.Controls.Add(this.labelCreditCommiteeCode, 0, 2);
            this.tableLayoutPanel11.Controls.Add(this._commentTextBox, 1, 3);
            this.tableLayoutPanel11.Controls.Add(this._codeTextBox, 1, 2);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 4;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.Size = new System.Drawing.Size(757, 333);
            this.tableLayoutPanel11.TabIndex = 69;
            // 
            // lblCCStatus
            // 
            this.lblCCStatus.AutoSize = true;
            this.lblCCStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblCCStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCCStatus.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lblCCStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCCStatus.Location = new System.Drawing.Point(3, 0);
            this.lblCCStatus.Name = "lblCCStatus";
            this.lblCCStatus.Size = new System.Drawing.Size(46, 33);
            this.lblCCStatus.TabIndex = 37;
            this.lblCCStatus.Text = "Status";
            this.lblCCStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCCStatus
            // 
            this.pnlCCStatus.AutoSize = true;
            this.pnlCCStatus.Controls.Add(this._statusComboBox);
            this.pnlCCStatus.Location = new System.Drawing.Point(73, 3);
            this.pnlCCStatus.Name = "pnlCCStatus";
            this.pnlCCStatus.Size = new System.Drawing.Size(302, 27);
            this.pnlCCStatus.TabIndex = 69;
            // 
            // _statusComboBox
            // 
            this._statusComboBox.DisplayMember = "Value";
            this._statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._statusComboBox.FormattingEnabled = true;
            this._statusComboBox.Location = new System.Drawing.Point(0, 0);
            this._statusComboBox.Name = "_statusComboBox";
            this._statusComboBox.Size = new System.Drawing.Size(299, 24);
            this._statusComboBox.TabIndex = 4;
            this._statusComboBox.ValueMember = "Key";
            // 
            // labelCreditCommiteeDate
            // 
            this.labelCreditCommiteeDate.AutoSize = true;
            this.labelCreditCommiteeDate.BackColor = System.Drawing.Color.Transparent;
            this.labelCreditCommiteeDate.Font = new System.Drawing.Font("Arial", 9.75F);
            this.labelCreditCommiteeDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCreditCommiteeDate.Location = new System.Drawing.Point(3, 33);
            this.labelCreditCommiteeDate.Name = "labelCreditCommiteeDate";
            this.labelCreditCommiteeDate.Size = new System.Drawing.Size(35, 16);
            this.labelCreditCommiteeDate.TabIndex = 18;
            this.labelCreditCommiteeDate.Text = "Date";
            this.labelCreditCommiteeDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _dateTimePicker
            // 
            this._dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dateTimePicker.CustomFormat = ApplicationSettings.GetInstance("").SHORT_DATE_FORMAT;
            this._dateTimePicker.Location = new System.Drawing.Point(73, 36);
            this._dateTimePicker.Name = "_dateTimePicker";
            this._dateTimePicker.Size = new System.Drawing.Size(125, 22);
            this._dateTimePicker.TabIndex = 0;
            // 
            // labelCreditCommiteeComment
            // 
            this.labelCreditCommiteeComment.AutoSize = true;
            this.labelCreditCommiteeComment.BackColor = System.Drawing.Color.Transparent;
            this.labelCreditCommiteeComment.Font = new System.Drawing.Font("Arial", 9.75F);
            this.labelCreditCommiteeComment.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCreditCommiteeComment.Location = new System.Drawing.Point(3, 89);
            this.labelCreditCommiteeComment.Name = "labelCreditCommiteeComment";
            this.labelCreditCommiteeComment.Size = new System.Drawing.Size(64, 16);
            this.labelCreditCommiteeComment.TabIndex = 20;
            this.labelCreditCommiteeComment.Text = "Comment";
            this.labelCreditCommiteeComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCreditCommiteeCode
            // 
            this.labelCreditCommiteeCode.AutoSize = true;
            this.labelCreditCommiteeCode.BackColor = System.Drawing.Color.Transparent;
            this.labelCreditCommiteeCode.Font = new System.Drawing.Font("Arial", 9.75F);
            this.labelCreditCommiteeCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCreditCommiteeCode.Location = new System.Drawing.Point(3, 61);
            this.labelCreditCommiteeCode.Name = "labelCreditCommiteeCode";
            this.labelCreditCommiteeCode.Size = new System.Drawing.Size(38, 16);
            this.labelCreditCommiteeCode.TabIndex = 35;
            this.labelCreditCommiteeCode.Text = "Code";
            this.labelCreditCommiteeCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _commentTextBox
            // 
            this._commentTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this._commentTextBox.Location = new System.Drawing.Point(73, 92);
            this._commentTextBox.MaxLength = 4000;
            this._commentTextBox.Multiline = true;
            this._commentTextBox.Name = "_commentTextBox";
            this._commentTextBox.Size = new System.Drawing.Size(681, 238);
            this._commentTextBox.TabIndex = 2;
            // 
            // _codeTextBox
            // 
            this._codeTextBox.Location = new System.Drawing.Point(73, 64);
            this._codeTextBox.Name = "_codeTextBox";
            this._codeTextBox.Size = new System.Drawing.Size(237, 22);
            this._codeTextBox.TabIndex = 1;
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.AutoSize = true;
            this.flowLayoutPanel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel7.Controls.Add(this._saveButton);
            this.flowLayoutPanel7.Controls.Add(this._printButton);
            this.flowLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel7.Location = new System.Drawing.Point(0, 333);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Padding = new System.Windows.Forms.Padding(0, 13, 0, 0);
            this.flowLayoutPanel7.Size = new System.Drawing.Size(757, 47);
            this.flowLayoutPanel7.TabIndex = 70;
            // 
            // _saveButton
            // 
            this._saveButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._saveButton.Location = new System.Drawing.Point(3, 16);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(140, 28);
            this._saveButton.TabIndex = 1;
            this._saveButton.Text = "Save";
            // 
            // _printButton
            // 
            this._printButton.Image = global::OpenCBS.Extensions.Properties.Resources.bullet_arrow_down;
            this._printButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._printButton.Location = new System.Drawing.Point(149, 16);
            this._printButton.Name = "_printButton";
            this._printButton.ReportInitializer = null;
            this._printButton.Size = new System.Drawing.Size(140, 28);
            this._printButton.TabIndex = 2;
            this._printButton.Text = "Print";
            this._printButton.UseVisualStyleBackColor = true;
            // 
            // LoanApprovalUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel7);
            this.Controls.Add(this.tableLayoutPanel11);
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Name = "LoanApprovalUserControl";
            this.Size = new System.Drawing.Size(757, 398);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.pnlCCStatus.ResumeLayout(false);
            this.flowLayoutPanel7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.Label lblCCStatus;
        private System.Windows.Forms.Panel pnlCCStatus;
        private System.Windows.Forms.ComboBox _statusComboBox;
        private System.Windows.Forms.Label labelCreditCommiteeDate;
        private System.Windows.Forms.DateTimePicker _dateTimePicker;
        private System.Windows.Forms.Label labelCreditCommiteeComment;
        private System.Windows.Forms.Label labelCreditCommiteeCode;
        private System.Windows.Forms.TextBox _commentTextBox;
        private System.Windows.Forms.TextBox _codeTextBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.Button _saveButton;
        private Controls.PrintButton _printButton;
    }
}
