
using System.Windows.Forms;
using OpenCBS.GUI.UserControl;

namespace OpenCBS.GUI.Login
{
    public partial class LoginForm
    {
        private System.Windows.Forms.Button startButton;
        private TextBox usernameTextbox;
        private TextBox passwordTextbox;
        private Label usernameLabel;
        private Label passwordLabel;
        private PictureBox logoPicturebox;
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form
        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.startButton = new System.Windows.Forms.Button();
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.logoPicturebox = new System.Windows.Forms.PictureBox();
            this.databaseCombobox = new System.Windows.Forms.ComboBox();
            this.databaseLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            resources.ApplyResources(this.startButton, "startButton");
            this.startButton.BackColor = System.Drawing.SystemColors.Control;
            this.startButton.Name = "startButton";
            this.startButton.UseVisualStyleBackColor = false;
            // 
            // usernameTextbox
            // 
            resources.ApplyResources(this.usernameTextbox, "usernameTextbox");
            this.usernameTextbox.Name = "usernameTextbox";
            // 
            // passwordTextbox
            // 
            resources.ApplyResources(this.passwordTextbox, "passwordTextbox");
            this.passwordTextbox.Name = "passwordTextbox";
            // 
            // usernameLabel
            // 
            resources.ApplyResources(this.usernameLabel, "usernameLabel");
            this.usernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.usernameLabel.Name = "usernameLabel";
            // 
            // passwordLabel
            // 
            resources.ApplyResources(this.passwordLabel, "passwordLabel");
            this.passwordLabel.BackColor = System.Drawing.Color.Transparent;
            this.passwordLabel.Name = "passwordLabel";
            // 
            // logoPicturebox
            // 
            resources.ApplyResources(this.logoPicturebox, "logoPicturebox");
            this.logoPicturebox.BackColor = System.Drawing.Color.Transparent;
            this.logoPicturebox.BackgroundImage = global::OpenCBS.GUI.Properties.Resources.LOGO;
            this.logoPicturebox.Name = "logoPicturebox";
            this.logoPicturebox.TabStop = false;
            // 
            // databaseCombobox
            // 
            resources.ApplyResources(this.databaseCombobox, "databaseCombobox");
            this.databaseCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.databaseCombobox.FormattingEnabled = true;
            this.databaseCombobox.Name = "databaseCombobox";
            // 
            // databaseLabel
            // 
            resources.ApplyResources(this.databaseLabel, "databaseLabel");
            this.databaseLabel.BackColor = System.Drawing.Color.Transparent;
            this.databaseLabel.Name = "databaseLabel";
            // 
            // LoginForm
            // 
            this.AcceptButton = this.startButton;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.databaseLabel);
            this.Controls.Add(this.databaseCombobox);
            this.Controls.Add(this.logoPicturebox);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.passwordTextbox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.logoPicturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private ComboBox databaseCombobox;
        private Label databaseLabel;

    }
}
