using System;
using System.Drawing;
using System.Windows.Forms;

namespace OpenCBS.GUI.Report_Browser
{
    public partial class ReportLoadingProgressForm : Form
    {
        private DateTime _dt;
        private int gx, gy;
        private bool move; 

        public ReportLoadingProgressForm()
        {
            InitializeComponent();
        }

        private void LoadingReport_Load(object sender, EventArgs e)
        {
            _dt = DateTime.Now;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = (DateTime.Now - _dt).Seconds.ToString() + " s.";
        }

        private void LoadingReport_MouseDown(object sender, MouseEventArgs e)
        {
            gx = MousePosition.X - this.Location.X;
            gy = MousePosition.Y - this.Location.Y;
            move = true;
        }

        private void LoadingReport_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.Location = new Point(MousePosition.X - gx, MousePosition.Y - gy);
            }
        }

        private void LoadingReport_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }
    }
}
