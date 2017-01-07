using System.Windows.Forms;

namespace OpenCBS.Extension.Accounting
{
    public interface IAccountingMenu
    {
        ToolStripMenuItem GetItem();
        int Order { get; }
    }
}
