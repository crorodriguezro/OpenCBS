namespace OpenCBS.GUI
{
    partial class ScheduleUserControl
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
            this.scheduleObjectListView = new BrightIdeasSoftware.ObjectListView();
            this.numberColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.dateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.interestColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.principalColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.totalColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olbColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.paidInterestColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.paidPrincipalColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.paymentDateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.scheduleObjectListView)).BeginInit();
            this.SuspendLayout();
            // 
            // scheduleObjectListView
            // 
            this.scheduleObjectListView.AllColumns.Add(this.numberColumn);
            this.scheduleObjectListView.AllColumns.Add(this.dateColumn);
            this.scheduleObjectListView.AllColumns.Add(this.interestColumn);
            this.scheduleObjectListView.AllColumns.Add(this.principalColumn);
            this.scheduleObjectListView.AllColumns.Add(this.totalColumn);
            this.scheduleObjectListView.AllColumns.Add(this.olbColumn);
            this.scheduleObjectListView.AllColumns.Add(this.paidInterestColumn);
            this.scheduleObjectListView.AllColumns.Add(this.paidPrincipalColumn);
            this.scheduleObjectListView.AllColumns.Add(this.paymentDateColumn);
            this.scheduleObjectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.numberColumn,
            this.dateColumn,
            this.interestColumn,
            this.principalColumn,
            this.totalColumn,
            this.olbColumn,
            this.paidInterestColumn,
            this.paidPrincipalColumn,
            this.paymentDateColumn});
            this.scheduleObjectListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scheduleObjectListView.Font = new System.Drawing.Font("Arial", 8.25F);
            this.scheduleObjectListView.FullRowSelect = true;
            this.scheduleObjectListView.GridLines = true;
            this.scheduleObjectListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.scheduleObjectListView.HeaderWordWrap = true;
            this.scheduleObjectListView.Location = new System.Drawing.Point(0, 0);
            this.scheduleObjectListView.MultiSelect = false;
            this.scheduleObjectListView.Name = "scheduleObjectListView";
            this.scheduleObjectListView.ShowGroups = false;
            this.scheduleObjectListView.Size = new System.Drawing.Size(1004, 368);
            this.scheduleObjectListView.TabIndex = 0;
            this.scheduleObjectListView.UseCompatibleStateImageBehavior = false;
            this.scheduleObjectListView.View = System.Windows.Forms.View.Details;
            // 
            // numberColumn
            // 
            this.numberColumn.AspectName = "Number";
            this.numberColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numberColumn.Text = "#";
            this.numberColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateColumn
            // 
            this.dateColumn.AspectName = "ExpectedDate";
            this.dateColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateColumn.Text = "Date";
            this.dateColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateColumn.Width = 80;
            // 
            // interestColumn
            // 
            this.interestColumn.AspectName = "InterestsRepayment";
            this.interestColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.interestColumn.Text = "Interest";
            this.interestColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.interestColumn.Width = 100;
            // 
            // principalColumn
            // 
            this.principalColumn.AspectName = "CapitalRepayment";
            this.principalColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.principalColumn.Text = "Principal";
            this.principalColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.principalColumn.Width = 100;
            // 
            // totalColumn
            // 
            this.totalColumn.AspectName = "AmountHasToPayWithInterest";
            this.totalColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.totalColumn.Text = "Total";
            this.totalColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.totalColumn.Width = 100;
            // 
            // olbColumn
            // 
            this.olbColumn.AspectName = "OLB";
            this.olbColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olbColumn.Text = "OLB";
            this.olbColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olbColumn.Width = 100;
            // 
            // paidInterestColumn
            // 
            this.paidInterestColumn.AspectName = "PaidInterests";
            this.paidInterestColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.paidInterestColumn.Text = "Paid interest";
            this.paidInterestColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.paidInterestColumn.Width = 100;
            // 
            // paidPrincipalColumn
            // 
            this.paidPrincipalColumn.AspectName = "PaidCapital";
            this.paidPrincipalColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.paidPrincipalColumn.Text = "Paid principal";
            this.paidPrincipalColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.paidPrincipalColumn.Width = 100;
            // 
            // paymentDateColumn
            // 
            this.paymentDateColumn.AspectName = "PaidDate";
            this.paymentDateColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.paymentDateColumn.Text = "Payment date";
            this.paymentDateColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.paymentDateColumn.Width = 80;
            // 
            // ScheduleUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scheduleObjectListView);
            this.Name = "ScheduleUserControl";
            this.Size = new System.Drawing.Size(1004, 368);
            ((System.ComponentModel.ISupportInitialize)(this.scheduleObjectListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView scheduleObjectListView;
        private BrightIdeasSoftware.OLVColumn numberColumn;
        private BrightIdeasSoftware.OLVColumn dateColumn;
        private BrightIdeasSoftware.OLVColumn interestColumn;
        private BrightIdeasSoftware.OLVColumn principalColumn;
        private BrightIdeasSoftware.OLVColumn totalColumn;
        private BrightIdeasSoftware.OLVColumn olbColumn;
        private BrightIdeasSoftware.OLVColumn paidInterestColumn;
        private BrightIdeasSoftware.OLVColumn paidPrincipalColumn;
        private BrightIdeasSoftware.OLVColumn paymentDateColumn;
    }
}
