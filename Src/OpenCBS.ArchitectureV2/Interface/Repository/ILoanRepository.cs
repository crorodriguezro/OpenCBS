using System;
using System.Collections.Generic;
using OpenCBS.ArchitectureV2.Model;

namespace OpenCBS.ArchitectureV2.Interface.Repository
{
    public interface ILoanRepository
    {
        List<Alert> GetAlerts(DateTime date, int userId);
        List<Loan> GetVillageBankLoans(int villageBankId);
    }
}
