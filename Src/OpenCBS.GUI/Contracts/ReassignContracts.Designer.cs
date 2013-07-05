using OpenCBS.GUI.UserControl;

namespace OpenCBS.GUI.Contracts
{
    partial class ReassignContractsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReassignContractsForm));
            this.filterLabel = new System.Windows.Forms.Label();
            this.filterTextbox = new System.Windows.Forms.TextBox();
            this.onlyActiveCheckbox = new System.Windows.Forms.CheckBox();
            this.selectAllCheckbox = new System.Windows.Forms.CheckBox();
            this.assignButton = new System.Windows.Forms.Button();
            this.toLabel = new System.Windows.Forms.Label();
            this.fromLabel = new System.Windows.Forms.Label();
            this.toCombobox = new System.Windows.Forms.ComboBox();
            this.fromCombobox = new System.Windows.Forms.ComboBox();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.listPanel = new System.Windows.Forms.Panel();
            this.contractsObjectListView = new BrightIdeasSoftware.ObjectListView();
            this.optionsPanel.SuspendLayout();
            this.listPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contractsObjectListView)).BeginInit();
            this.SuspendLayout();
            // 
            // filterLabel
            // 
            resources.ApplyResources(this.filterLabel, "filterLabel");
            this.filterLabel.Name = "filterLabel";
            // 
            // filterTextbox
            // 
            resources.ApplyResources(this.filterTextbox, "filterTextbox");
            this.filterTextbox.Name = "filterTextbox";
            this.filterTextbox.TextChanged += new System.EventHandler(this.textBoxContractFilter_TextChanged);
            // 
            // onlyActiveCheckbox
            // 
            resources.ApplyResources(this.onlyActiveCheckbox, "onlyActiveCheckbox");
            this.onlyActiveCheckbox.Name = "onlyActiveCheckbox";
            this.onlyActiveCheckbox.CheckedChanged += new System.EventHandler(this.chkBox_only_active_CheckedChanged);
            // 
            // selectAllCheckbox
            // 
            resources.ApplyResources(this.selectAllCheckbox, "selectAllCheckbox");
            this.selectAllCheckbox.Name = "selectAllCheckbox";
            this.selectAllCheckbox.CheckedChanged += new System.EventHandler(this.checkBoxAll_CheckedChanged);
            // 
            // assignButton
            // 
            resources.ApplyResources(this.assignButton, "assignButton");
            this.assignButton.Name = "assignButton";
            this.assignButton.Click += new System.EventHandler(this.buttonAssing_Click);
            // 
            // toLabel
            // 
            resources.ApplyResources(this.toLabel, "toLabel");
            this.toLabel.Name = "toLabel";
            // 
            // fromLabel
            // 
            resources.ApplyResources(this.fromLabel, "fromLabel");
            this.fromLabel.Name = "fromLabel";
            // 
            // toCombobox
            // 
            this.toCombobox.BackColor = System.Drawing.SystemColors.Window;
            this.toCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toCombobox.FormattingEnabled = true;
            resources.ApplyResources(this.toCombobox, "toCombobox");
            this.toCombobox.Name = "toCombobox";
            this.toCombobox.SelectedIndexChanged += new System.EventHandler(this.cbLoanOfficerTo_SelectedIndexChanged);
            // 
            // fromCombobox
            // 
            this.fromCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromCombobox.FormattingEnabled = true;
            resources.ApplyResources(this.fromCombobox, "fromCombobox");
            this.fromCombobox.Name = "fromCombobox";
            this.fromCombobox.SelectedIndexChanged += new System.EventHandler(this.cbLoanOfficerFrom_SelectedIndexChanged);
            // 
            // optionsPanel
            // 
            this.optionsPanel.Controls.Add(this.filterTextbox);
            this.optionsPanel.Controls.Add(this.fromCombobox);
            this.optionsPanel.Controls.Add(this.filterLabel);
            this.optionsPanel.Controls.Add(this.fromLabel);
            this.optionsPanel.Controls.Add(this.onlyActiveCheckbox);
            this.optionsPanel.Controls.Add(this.toLabel);
            this.optionsPanel.Controls.Add(this.toCombobox);
            this.optionsPanel.Controls.Add(this.selectAllCheckbox);
            this.optionsPanel.Controls.Add(this.assignButton);
            resources.ApplyResources(this.optionsPanel, "optionsPanel");
            this.optionsPanel.Name = "optionsPanel";
            // 
            // listPanel
            // 
            this.listPanel.Controls.Add(this.contractsObjectListView);
            resources.ApplyResources(this.listPanel, "listPanel");
            this.listPanel.Name = "listPanel";
            // 
            // contractsObjectListView
            // 
            resources.ApplyResources(this.contractsObjectListView, "contractsObjectListView");
            this.contractsObjectListView.Name = "contractsObjectListView";
            this.contractsObjectListView.UseCompatibleStateImageBehavior = false;
            this.contractsObjectListView.View = System.Windows.Forms.View.Details;
            // 
            // ReassignContractsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listPanel);
            this.Controls.Add(this.optionsPanel);
            this.Name = "ReassignContractsForm";
            this.Controls.SetChildIndex(this.optionsPanel, 0);
            this.Controls.SetChildIndex(this.listPanel, 0);
            this.optionsPanel.ResumeLayout(false);
            this.optionsPanel.PerformLayout();
            this.listPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contractsObjectListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button assignButton;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.ComboBox toCombobox;
        private System.Windows.Forms.ComboBox fromCombobox;
        private System.Windows.Forms.CheckBox selectAllCheckbox;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.TextBox filterTextbox;
        private System.Windows.Forms.CheckBox onlyActiveCheckbox;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.Panel listPanel;
        private BrightIdeasSoftware.ObjectListView contractsObjectListView;

    }
}