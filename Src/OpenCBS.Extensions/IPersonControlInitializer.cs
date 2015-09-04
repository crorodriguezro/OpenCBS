using System.Windows.Forms;

namespace OpenCBS.Extensions
{
    public interface IPersonControlInitializer
    {
        void Initialize(Control control);
    }
}
