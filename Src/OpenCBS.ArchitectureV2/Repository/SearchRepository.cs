using System.Collections.Generic;
using System.Linq;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.ArchitectureV2.Interface.Repository;
using OpenCBS.ArchitectureV2.Model;
using Dapper;
using OpenCBS.CoreDomain;
using OpenCBS.Services;

namespace OpenCBS.ArchitectureV2.Repository
{
    public class SearchRepository : ISearchRepository
    {
        private readonly IConnectionProvider _connectionProvider;

        public SearchRepository(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public List<SearchResult> Search(string keywords)
        {
            const string query = @"
                select
	                v.id
	                , 'Village Bank' [Type]
                    , t.active Active
	                , v.name
	                , d.name District
	                , t.city City
                from 
	                dbo.Villages v
                left join
	                dbo.Tiers t on v.id = t.id
                left join
	                dbo.Districts d on d.id = t.district_id
                where
                    v.loan_officer in
                    (
                        -- Fetch only the village banks that belong to the user
                        -- or any subordinate of the user
                        select @userId
                        union all
                        select subordinate_id from dbo.UsersSubordinates where user_id = @userId
                    )
                    and t.branch_id in
                    (
                        -- Fetch only the villages banks that belong to the branches
                        -- that the user has access to
                        select branch_id from dbo.UsersBranches where user_id = @userId
                    )
	                and v.name like @keywords
                order by
                    v.name
            ";
            using (var connection = _connectionProvider.GetConnection())
            {
                keywords = "%" + keywords + "%";
                return connection.Query<SearchResult>(query, new { keywords, userId = User.CurrentUser.Id }).ToList();
            }
        }
    }
}
