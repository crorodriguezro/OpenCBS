using System.Data.SqlClient;
using OpenCBS.CoreDomain.Contracts.Loans;
using OpenCBS.Extension.Tasks;

namespace OpenCBS.Extensions
{
    public interface ILoanExtension
    {
        void Save(Loan loan, SqlTransaction transaction);
    }
}
