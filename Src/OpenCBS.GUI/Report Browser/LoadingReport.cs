using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenCBS.GUI.Report_Browser
{
    public partial class LoadingReport : Form
    {
        private DateTime _dt;
        private int gx, gy;
        private bool move = false; 

        public LoadingReport()
        {
            InitializeComponent();
        }

        private void LoadingReport_Load(object sender, EventArgs e)
        {
            _dt = DateTime.Now;
            timer1.Enabled = true;
            Color cl = this.BackColor;
            pictureBox1.BackColor = cl;
            label1.BackColor = cl;
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
