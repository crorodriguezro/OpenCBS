using System.Drawing;
using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.ArchitectureV2.Interface.View;

namespace OpenCBS.ArchitectureV2.View
{
    public partial class StartPageView : Form, IStartPageView
    {
        public StartPageView()
        {
            InitializeComponent();
            SizeChanged += (sender, e) => OnResize();
        }

        public void Attach(IStartPagePresenterCallbacks presenterCallbacks)
        {
        }

        private void OnResize()
        {
            SuspendLayout();

            var centerX = Size.Width / 2;
            var centerY = Size.Height / 2;

            var x = centerX - _logoPictureBox.Width / 2;
            var y = centerY - _logoPictureBox.Height - 50;
            _logoPictureBox.Location = new Point(x, y);

            x = centerX - _buttonPanel.Width / 2;
            y = centerY - _buttonPanel.Height / 2;
            _buttonPanel.Location = new Point(x, y);

            x = centerX - _linkPanel.Width / 2;
            y = Size.Height - _linkPanel.Height - 100;
            _linkPanel.Location = new Point(x, y);

            ResumeLayout();
        }
    }
}
