using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace OpenCBS.ArchitectureV2.Accounting.View.UserControl
{
    public class ToolStripCheckBox : ToolStripButton
    {
        private bool _oldState;
        private Color _checkedColor1 = Color.FromArgb(71, 113, 179);
        private Color _checkedColor2 = Color.FromArgb(98, 139, 205);

        public ToolStripCheckBox()
        {
            CheckOnClick = true;
        }

        [Category("Appearance")]
        public Color CheckedColor1
        {
            get { return _checkedColor1; }
            set { _checkedColor1 = value; }
        }

        [Category("Appearance")]
        public Color CheckedColor2
        {
            get { return _checkedColor2; }
            set { _checkedColor2 = value; }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Checked = !_oldState;
            _oldState = Checked;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Checked)
            {
                var checkedBackgroundBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, Height),
                                                                     CheckedColor1, CheckedColor2);
                e.Graphics.FillRectangle(checkedBackgroundBrush, new Rectangle(new Point(0, 0), Size));
            }

            base.OnPaint(e);
        }
    }
}