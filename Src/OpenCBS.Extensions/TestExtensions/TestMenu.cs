using System.ComponentModel.Composition;
using System.Windows.Forms;

namespace OpenCBS.Extensions.TestExtensions
{
    [PartCreationPolicy(CreationPolicy.Shared)]
    [Export(typeof(IMenu))]
    public class TestMenu : IMenu
    {
        public string InsertAfter
        {
            get { return "mnuClients"; }
        }

        public string Text
        {
            get { return "TEST"; }
        }

        public void Execute()
        {
            MessageBox.Show("Hello, this is a test message.");
        }
    }
}
