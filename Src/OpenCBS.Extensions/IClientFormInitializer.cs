using System.Windows.Forms;
using OpenCBS.CoreDomain.Contracts.Loans;

namespace OpenCBS.Extensions
{
    public interface IClientFormInitializer
    {
        void Initialize(Form form);
        void Refresh(Form form, Loan loan = null);
    }
}
