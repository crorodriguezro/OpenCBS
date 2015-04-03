using System;
using System.Collections.Generic;
using System.Linq;
using OpenCBS.ArchitectureV2.Interface.Repository;
using OpenCBS.ArchitectureV2.Model;
using Dapper;
using OpenCBS.ArchitectureV2.Interface;

namespace OpenCBS.ArchitectureV2.Repository
{
    public class LoanRepository : ILoanRepository
    {
        private readonly IConnectionProvider _connectionProvider;

        public LoanRepository(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public List<Alert> GetAlerts(DateTime date, int userId)
        {
            const string query = @"
                select
                    id,
                    kind,
                    status,
                    date,
                    late_days LateDays,
                    amount,
                    contract_code ContractCode,
                    client_name ClientName,
                    loan_officer LoanOfficer,
                    city,
                    address,
                    phone,
                    branch_name BranchName
                from
                    dbo.Alerts(@date, @userId)
            ";
            using (var connection = _connectionProvider.GetConnection())
            {
                return connection.Query<Alert>(query, new { date, userId }).ToList();
            }
        }
    }
}
