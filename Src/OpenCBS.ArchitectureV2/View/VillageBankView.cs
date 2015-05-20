using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.ArchitectureV2.Interface.View;

namespace OpenCBS.ArchitectureV2.View
{
    public partial class VillageBankView : Form, IVillageBankView
    {
        public VillageBankView()
        {
            InitializeComponent();
        }

        public void Attach(IVillageBankPresenterCallbacks presenterCallbacks)
        {
        }
    }
}
