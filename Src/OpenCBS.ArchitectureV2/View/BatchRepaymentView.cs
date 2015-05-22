using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.ArchitectureV2.Interface.View;

namespace OpenCBS.ArchitectureV2.View
{
    public partial class BatchRepaymentView : Form, IBatchRepaymentView
    {
        public BatchRepaymentView()
        {
            InitializeComponent();
        }

        public void Run()
        {
            ShowDialog();
        }

        public void Attach(IBatchRepaymentPresenterCallbacks presenterCallbacks)
        {
        }
    }
}
