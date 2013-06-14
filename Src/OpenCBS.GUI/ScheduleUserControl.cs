using System;
using OpenCBS.CoreDomain.Contracts.Loans;

namespace OpenCBS.GUI
{
    public partial class ScheduleUserControl : System.Windows.Forms.UserControl
    {
        public ScheduleUserControl()
        {
            InitializeComponent();
            Load += (sender, args) => Setup();
        }

        public void SetScheduleFor(Loan loan)
        {
            scheduleObjectListView.SetObjects(loan.InstallmentList);
        }

        private void Setup()
        {
            dateColumn.AspectToStringConverter =
            paymentDateColumn.AspectToStringConverter = value =>
            {
                var date = (DateTime?)value;
                return date.HasValue ? date.Value.ToString("dd.MM.yyyy") : string.Empty;
            };
        }
    }
}
