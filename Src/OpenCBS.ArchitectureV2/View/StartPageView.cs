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
        }

        public void Attach(IStartPagePresenterCallbacks presenterCallbacks)
        {
        }
    }
}
