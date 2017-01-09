using System.Windows.Forms;

namespace OpenCBS.ArchitectureV2.Accounting.Interface
{
    public interface IReportItem
    {
        ToolStripMenuItem GetItem();
        int Order { get; }
    }
}
