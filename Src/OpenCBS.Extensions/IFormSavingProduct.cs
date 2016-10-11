using System.Windows.Forms;

namespace OpenCBS.Extensions
{
    public interface IFormSavingProduct
    {
        void Initialize(Form form);
        void Refresh(Form form);
    }
}