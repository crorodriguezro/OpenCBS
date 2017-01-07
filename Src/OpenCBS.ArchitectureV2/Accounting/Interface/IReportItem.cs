using System.Windows.Forms;

namespace OpenCBS.Extension.Accounting.Interface
{
    public interface IReportItem
    {
        ToolStripMenuItem GetItem();
        int Order { get; }
    }
}
