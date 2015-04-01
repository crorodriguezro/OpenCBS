namespace OpenCBS.ArchitectureV2.View
{
    partial class StartPageView
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
            this._logoPictureBox = new System.Windows.Forms.PictureBox();
            this._searchClientButton = new System.Windows.Forms.Button();
            this._newClientButton = new OpenCBS.Controls.SplitButton();
            this.button1 = new System.Windows.Forms.Button();
            this._newClientMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._newPersonItem = new System.Windows.Forms.ToolStripMenuItem();
            this._newGroupItem = new System.Windows.Forms.ToolStripMenuItem();
            this._newVillageBankItem = new System.Windows.Forms.ToolStripMenuItem();
            this._newCompanyItem = new System.Windows.Forms.ToolStripMenuItem();
            this._buttonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._linkPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._siteLink = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this._userGuideLink = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this._logoPictureBox)).BeginInit();
            this._newClientMenu.SuspendLayout();
            this._buttonPanel.SuspendLayout();
            this._linkPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _logoPictureBox
            // 
            this._logoPictureBox.Image = global::OpenCBS.ArchitectureV2.Properties.Resources.logo_with_tagline;
            this._logoPictureBox.Location = new System.Drawing.Point(244, 59);
            this._logoPictureBox.Name = "_logoPictureBox";
            this._logoPictureBox.Size = new System.Drawing.Size(285, 88);
            this._logoPictureBox.TabIndex = 0;
            this._logoPictureBox.TabStop = false;
            // 
            // _searchClientButton
            // 
            this._searchClientButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this._searchClientButton.Location = new System.Drawing.Point(189, 3);
            this._searchClientButton.Name = "_searchClientButton";
            this._searchClientButton.Size = new System.Drawing.Size(180, 35);
            this._searchClientButton.TabIndex = 20;
            this._searchClientButton.Text = "Search Client";
            this._searchClientButton.UseVisualStyleBackColor = true;
            // 
            // _newClientButton
            // 
            this._newClientButton.ContextMenuStrip = this._newClientMenu;
            this._newClientButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this._newClientButton.Location = new System.Drawing.Point(3, 3);
            this._newClientButton.Name = "_newClientButton";
            this._newClientButton.Size = new System.Drawing.Size(180, 35);
            this._newClientButton.SplitMenuStrip = this._newClientMenu;
            this._newClientButton.TabIndex = 10;
            this._newClientButton.Text = "New Client";
            this._newClientButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button1.Location = new System.Drawing.Point(375, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 35);
            this.button1.TabIndex = 30;
            this.button1.Text = "Search Loan";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // _newClientMenu
            // 
            this._newClientMenu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this._newClientMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._newPersonItem,
            this._newGroupItem,
            this._newVillageBankItem,
            this._newCompanyItem});
            this._newClientMenu.Name = "_newClientMenu";
            this._newClientMenu.Size = new System.Drawing.Size(166, 108);
            // 
            // _newPersonItem
            // 
            this._newPersonItem.Name = "_newPersonItem";
            this._newPersonItem.Size = new System.Drawing.Size(165, 26);
            this._newPersonItem.Text = "Person";
            // 
            // _newGroupItem
            // 
            this._newGroupItem.Name = "_newGroupItem";
            this._newGroupItem.Size = new System.Drawing.Size(165, 26);
            this._newGroupItem.Text = "Group";
            // 
            // _newVillageBankItem
            // 
            this._newVillageBankItem.Name = "_newVillageBankItem";
            this._newVillageBankItem.Size = new System.Drawing.Size(165, 26);
            this._newVillageBankItem.Text = "Village Bank";
            // 
            // _newCompanyItem
            // 
            this._newCompanyItem.Name = "_newCompanyItem";
            this._newCompanyItem.Size = new System.Drawing.Size(165, 26);
            this._newCompanyItem.Text = "Company";
            // 
            // _buttonPanel
            // 
            this._buttonPanel.AutoSize = true;
            this._buttonPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._buttonPanel.Controls.Add(this._newClientButton);
            this._buttonPanel.Controls.Add(this._searchClientButton);
            this._buttonPanel.Controls.Add(this.button1);
            this._buttonPanel.Location = new System.Drawing.Point(107, 178);
            this._buttonPanel.Name = "_buttonPanel";
            this._buttonPanel.Size = new System.Drawing.Size(558, 41);
            this._buttonPanel.TabIndex = 31;
            // 
            // _linkPanel
            // 
            this._linkPanel.AutoSize = true;
            this._linkPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._linkPanel.Controls.Add(this._siteLink);
            this._linkPanel.Controls.Add(this.label1);
            this._linkPanel.Controls.Add(this._userGuideLink);
            this._linkPanel.Controls.Add(this.label2);
            this._linkPanel.Controls.Add(this.linkLabel1);
            this._linkPanel.Controls.Add(this.label3);
            this._linkPanel.Controls.Add(this.linkLabel2);
            this._linkPanel.Location = new System.Drawing.Point(219, 340);
            this._linkPanel.Name = "_linkPanel";
            this._linkPanel.Size = new System.Drawing.Size(334, 15);
            this._linkPanel.TabIndex = 32;
            // 
            // _siteLink
            // 
            this._siteLink.AutoSize = true;
            this._siteLink.Location = new System.Drawing.Point(3, 0);
            this._siteLink.Name = "_siteLink";
            this._siteLink.Size = new System.Drawing.Size(79, 15);
            this._siteLink.TabIndex = 0;
            this._siteLink.TabStop = true;
            this._siteLink.Text = "opencbs.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(88, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "●";
            // 
            // _userGuideLink
            // 
            this._userGuideLink.AutoSize = true;
            this._userGuideLink.Location = new System.Drawing.Point(108, 0);
            this._userGuideLink.Name = "_userGuideLink";
            this._userGuideLink.Size = new System.Drawing.Size(64, 15);
            this._userGuideLink.TabIndex = 2;
            this._userGuideLink.TabStop = true;
            this._userGuideLink.Text = "User Guide";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(178, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "●";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(198, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(42, 15);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Forum";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(246, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "●";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(266, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(65, 15);
            this.linkLabel2.TabIndex = 6;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Contact Us";
            // 
            // StartPageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(772, 379);
            this.Controls.Add(this._linkPanel);
            this.Controls.Add(this._buttonPanel);
            this.Controls.Add(this._logoPictureBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "StartPageView";
            this.ShowIcon = false;
            this.Text = "Start Page";
            ((System.ComponentModel.ISupportInitialize)(this._logoPictureBox)).EndInit();
            this._newClientMenu.ResumeLayout(false);
            this._buttonPanel.ResumeLayout(false);
            this._linkPanel.ResumeLayout(false);
            this._linkPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _logoPictureBox;
        private System.Windows.Forms.Button _searchClientButton;
        private Controls.SplitButton _newClientButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip _newClientMenu;
        private System.Windows.Forms.ToolStripMenuItem _newPersonItem;
        private System.Windows.Forms.ToolStripMenuItem _newGroupItem;
        private System.Windows.Forms.ToolStripMenuItem _newVillageBankItem;
        private System.Windows.Forms.ToolStripMenuItem _newCompanyItem;
        private System.Windows.Forms.FlowLayoutPanel _buttonPanel;
        private System.Windows.Forms.FlowLayoutPanel _linkPanel;
        private System.Windows.Forms.LinkLabel _siteLink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel _userGuideLink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}