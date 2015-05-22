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

        public List<Loan> GetVillageBankLoans(int villageBankId)
        {
            const string query = @"
                select
	                c.id
	                , p.first_name FirstName
	                , p.last_name LastName
	                , c.contract_code ContractCode
                from
	                dbo.Persons p
                left join
	                dbo.Projects j on j.tiers_id = p.id
                left join
	                dbo.Contracts c on c.project_id = j.id
                left join
	                dbo.VillagesPersons vp on vp.person_id = p.id
                where
	                vp.village_id = @villageBankId
	                and c.status = 5
                order by
                    p.id

                select
	                number
                    , contract_id ContractId
	                , expected_date ExpectedDate
	                , capital_repayment Principal
	                , paid_capital PaidPrincipal
	                , interest_repayment Interest
	                , paid_interest PaidInterest
                from
	                dbo.Installments
                where
	                contract_id in
	                (
		                select
			                c.id
		                from
			                dbo.Persons p
		                left join
			                dbo.Projects j on j.tiers_id = p.id
		                left join
			                dbo.Contracts c on c.project_id = j.id
		                left join
			                dbo.VillagesPersons vp on vp.person_id = p.id
		                where
			                vp.village_id = @villageBankId
			                and c.status = 5
	                )
            ";
            using (var connection = _connectionProvider.GetConnection())
            using (var multi = connection.QueryMultiple(query, new { villageBankId }))
            {
                var loans = multi.Read<Loan>().ToList();
                var installments = multi.Read<Installment>().ToList();
                foreach (var loan in loans)
                {
                    loan.Schedule = installments
                        .Where(x => x.ContractId == loan.Id)
                        .OrderBy(x => x.Number)
                        .ToList();
                }
                return loans;
            }
        }
    }
}
