using System;
using System.Windows.Forms;

namespace OpenCBS.Controls
{
    public partial class LoadingProgressForm : Form
    {
        private DateTime _startDate;

        public LoadingProgressForm()
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
            elapsedTimeLabel.Text = String.Concat((((DateTime.Now - _startDate).Hours) < 10 ? "0" : ""),(DateTime.Now - _startDate).Hours, ":",
                                                  (((DateTime.Now - _startDate).Minutes)< 10 ? "0" : ""),(DateTime.Now - _startDate).Minutes, ":",
                                                  (((DateTime.Now - _startDate).Seconds)< 10 ? "0" : ""),(DateTime.Now - _startDate).Seconds);
        }


    }
}
