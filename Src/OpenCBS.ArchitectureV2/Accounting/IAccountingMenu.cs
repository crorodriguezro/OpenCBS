using System.Windows.Forms;

namespace OpenCBS.ArchitectureV2.Accounting
{
    public interface IAccountingMenu
    {
        ToolStripMenuItem GetItem();
        int Order { get; }
    }
}
