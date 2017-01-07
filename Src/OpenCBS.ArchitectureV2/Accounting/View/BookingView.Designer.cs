namespace OpenCBS.Extension.Accounting.View
{
    partial class BookingView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookingView));
            this.panel1 = new System.Windows.Forms.Panel();
            this._creditCombobox = new OpenCBS.Extension.Accounting.View.UserControl.AutocompletionComboBox();
            this._debitCombobox = new OpenCBS.Extension.Accounting.View.UserControl.AutocompletionComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this._cancelButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            this._amountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._descriptionTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._branchComboBox = new System.Windows.Forms.ComboBox();
            this._dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._error = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._amountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._error)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._creditCombobox);
            this.panel1.Controls.Add(this._debitCombobox);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this._amountNumericUpDown);
            this.panel1.Controls.Add(this._descriptionTextBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this._branchComboBox);
            this.panel1.Controls.Add(this._dateTimePicker);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // _creditCombobox
            // 
            this._creditCombobox.FormattingEnabled = true;
            resources.ApplyResources(this._creditCombobox, "_creditCombobox");
            this._creditCombobox.Name = "_creditCombobox";
            // 
            // _debitCombobox
            // 
            this._debitCombobox.FormattingEnabled = true;
            resources.ApplyResources(this._debitCombobox, "_debitCombobox");
            this._debitCombobox.Name = "_debitCombobox";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._cancelButton);
            this.panel2.Controls.Add(this._okButton);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // _cancelButton
            // 
            resources.ApplyResources(this._cancelButton, "_cancelButton");
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _okButton
            // 
            resources.ApplyResources(this._okButton, "_okButton");
            this._okButton.Name = "_okButton";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _amountNumericUpDown
            // 
            this._amountNumericUpDown.DecimalPlaces = 2;
            resources.ApplyResources(this._amountNumericUpDown, "_amountNumericUpDown");
            this._amountNumericUpDown.Maximum = new decimal(new int[] {
            -1981284352,
            -1966660860,
            0,
            0});
            this._amountNumericUpDown.Name = "_amountNumericUpDown";
            // 
            // _descriptionTextBox
            // 
            resources.ApplyResources(this._descriptionTextBox, "_descriptionTextBox");
            this._descriptionTextBox.Name = "_descriptionTextBox";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // _branchComboBox
            // 
            this._branchComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._branchComboBox.FormattingEnabled = true;
            resources.ApplyResources(this._branchComboBox, "_branchComboBox");
            this._branchComboBox.Name = "_branchComboBox";
            // 
            // _dateTimePicker
            // 
            this._dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this._dateTimePicker, "_dateTimePicker");
            this._dateTimePicker.Name = "_dateTimePicker";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // _error
            // 
            this._error.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._error.ContainerControl = this;
            // 
            // BookingView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BookingView";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._amountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._error)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker _dateTimePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox _branchComboBox;
        private System.Windows.Forms.TextBox _descriptionTextBox;
        private System.Windows.Forms.NumericUpDown _amountNumericUpDown;
        private System.Windows.Forms.ErrorProvider _error;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _okButton;
        private UserControl.AutocompletionComboBox _creditCombobox;
        private UserControl.AutocompletionComboBox _debitCombobox;
    }
}