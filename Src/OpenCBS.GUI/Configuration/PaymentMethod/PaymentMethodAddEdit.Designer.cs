namespace OpenCBS.GUI.Configuration.PaymentMethod
{
    partial class PaymentMethodAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentMethodAddEdit));
            this._buttonSave = new System.Windows.Forms.Button();
            this._labelDescription = new System.Windows.Forms.Label();
            this._labelName = new System.Windows.Forms.Label();
            this._textBoxName = new System.Windows.Forms.TextBox();
            this._labelId = new System.Windows.Forms.Label();
            this._textBoxId = new System.Windows.Forms.TextBox();
            this._descriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this._labelError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _buttonSave
            // 
            this._buttonSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._buttonSave.Location = new System.Drawing.Point(105, 312);
            this._buttonSave.Name = "_buttonSave";
            this._buttonSave.Size = new System.Drawing.Size(144, 36);
            this._buttonSave.TabIndex = 25;
            this._buttonSave.Text = "Save";
            this._buttonSave.UseVisualStyleBackColor = true;
            this._buttonSave.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // _labelDescription
            // 
            this._labelDescription.AutoSize = true;
            this._labelDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._labelDescription.Location = new System.Drawing.Point(37, 119);
            this._labelDescription.Name = "_labelDescription";
            this._labelDescription.Size = new System.Drawing.Size(60, 13);
            this._labelDescription.TabIndex = 21;
            this._labelDescription.Text = "Description";
            // 
            // _labelName
            // 
            this._labelName.AutoSize = true;
            this._labelName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._labelName.Location = new System.Drawing.Point(37, 82);
            this._labelName.Name = "_labelName";
            this._labelName.Size = new System.Drawing.Size(35, 13);
            this._labelName.TabIndex = 20;
            this._labelName.Text = "Name";
            // 
            // _textBoxName
            // 
            this._textBoxName.Location = new System.Drawing.Point(119, 79);
            this._textBoxName.Name = "_textBoxName";
            this._textBoxName.Size = new System.Drawing.Size(182, 20);
            this._textBoxName.TabIndex = 19;
            this._textBoxName.TextChanged += new System.EventHandler(this.NameChanged);
            // 
            // _labelId
            // 
            this._labelId.AutoSize = true;
            this._labelId.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._labelId.Location = new System.Drawing.Point(37, 42);
            this._labelId.Name = "_labelId";
            this._labelId.Size = new System.Drawing.Size(18, 13);
            this._labelId.TabIndex = 18;
            this._labelId.Text = "ID";
            // 
            // _textBoxId
            // 
            this._textBoxId.Enabled = false;
            this._textBoxId.Location = new System.Drawing.Point(119, 39);
            this._textBoxId.Name = "_textBoxId";
            this._textBoxId.Size = new System.Drawing.Size(182, 20);
            this._textBoxId.TabIndex = 17;
            // 
            // _descriptionRichTextBox
            // 
            this._descriptionRichTextBox.Location = new System.Drawing.Point(40, 149);
            this._descriptionRichTextBox.Name = "_descriptionRichTextBox";
            this._descriptionRichTextBox.Size = new System.Drawing.Size(261, 136);
            this._descriptionRichTextBox.TabIndex = 26;
            this._descriptionRichTextBox.Text = "";
            // 
            // _labelError
            // 
            this._labelError.AutoSize = true;
            this._labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this._labelError.ForeColor = System.Drawing.SystemColors.GrayText;
            this._labelError.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._labelError.Location = new System.Drawing.Point(4, 361);
            this._labelError.Name = "_labelError";
            this._labelError.Size = new System.Drawing.Size(0, 13);
            this._labelError.TabIndex = 27;
            // 
            // PaymentMethodAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 378);
            this.Controls.Add(this._labelError);
            this.Controls.Add(this._descriptionRichTextBox);
            this.Controls.Add(this._buttonSave);
            this.Controls.Add(this._labelDescription);
            this.Controls.Add(this._labelName);
            this.Controls.Add(this._textBoxName);
            this.Controls.Add(this._labelId);
            this.Controls.Add(this._textBoxId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PaymentMethodAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button _buttonSave;
        private System.Windows.Forms.Label _labelDescription;
        private System.Windows.Forms.Label _labelName;
        private System.Windows.Forms.TextBox _textBoxName;
        private System.Windows.Forms.Label _labelId;
        private System.Windows.Forms.TextBox _textBoxId;
        private System.Windows.Forms.RichTextBox _descriptionRichTextBox;
        private System.Windows.Forms.Label _labelError;
    }
}