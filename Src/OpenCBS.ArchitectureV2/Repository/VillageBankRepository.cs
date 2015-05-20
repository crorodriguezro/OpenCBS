using System.Linq;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.ArchitectureV2.Interface.Repository;
using OpenCBS.ArchitectureV2.Model;
using Dapper;

namespace OpenCBS.ArchitectureV2.Repository
{
    public class VillageBankRepository : IVillageBankRepository
    {
        private readonly IConnectionProvider _connectionProvider;

        public VillageBankRepository(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public VillageBank Get(int id)
        {
            const string query = @"
                select id, name from dbo.Villages where id = @id

                select
	                p.id
	                , p.first_name FirstName
	                , p.last_name LastName
	                , p.identification_data Passport
                    , t.loan_cycle LoanCycle
                    , t.active
                from
	                dbo.Persons p
                left join
                    dbo.Tiers t on t.id = p.id
                left join
	                dbo.VillagesPersons vp on vp.person_id = p.id
                where
	                vp.left_date is null
	                and vp.village_id = @id
                order by
                    p.id
            ";
            using (var connection = _connectionProvider.GetConnection())
            using (var multi = connection.QueryMultiple(query, new {id}))
            {
                var result = multi.Read<VillageBank>().Single();
                result.Members = multi.Read<VillageBankMember>().ToList();
                return result;
            }
        }
    }
}
