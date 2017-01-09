namespace OpenCBS.ArchitectureV2.Accounting.View
{
    partial class LoadingProgressForm
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
            this.loaderControl = new OpenCBS.Controls.LoaderControl();
            this.elapsedTimeLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // loaderControl
            // 
            this.loaderControl.Location = new System.Drawing.Point(12, 12);
            this.loaderControl.Name = "loaderControl";
            this.loaderControl.Size = new System.Drawing.Size(220, 18);
            this.loaderControl.TabIndex = 4;
            // 
            // elapsedTimeLabel
            // 
            this.elapsedTimeLabel.AutoSize = true;
            this.elapsedTimeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.elapsedTimeLabel.Location = new System.Drawing.Point(97, 42);
            this.elapsedTimeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.elapsedTimeLabel.Name = "elapsedTimeLabel";
            this.elapsedTimeLabel.Size = new System.Drawing.Size(49, 13);
            this.elapsedTimeLabel.TabIndex = 3;
            this.elapsedTimeLabel.Text = "00:00:00";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            // 
            // ReportLoadingProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 64);
            this.Controls.Add(this.loaderControl);
            this.Controls.Add(this.elapsedTimeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportLoadingProgressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.LoaderControl loaderControl;
        private System.Windows.Forms.Label elapsedTimeLabel;
        private System.Windows.Forms.Timer timer;
    }
}