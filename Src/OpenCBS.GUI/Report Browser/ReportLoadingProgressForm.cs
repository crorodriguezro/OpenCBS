using System;
using System.Windows.Forms;

namespace OpenCBS.GUI.Report_Browser
{
    public partial class ReportLoadingProgressForm : Form
    {
        private DateTime _startDate;

        public ReportLoadingProgressForm()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            Load += (sender, args) => LoadForm();
            timer.Tick += (sender, args) => Tick();
        }

        private void LoadForm()
        {
            _startDate = DateTime.Now;
            timer.Enabled = true;
            loaderControl.Start();
        }

        private void Tick()
        {
            elapsedTimeLabel.Text = (DateTime.Now - _startDate).Seconds + " s.";
        }
    }
}
