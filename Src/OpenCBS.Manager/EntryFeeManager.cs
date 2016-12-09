using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using OpenCBS.CoreDomain;

namespace OpenCBS.Manager
{
    public class EntryFeeManager : Manager
    {
        public EntryFeeManager(string pDatabaseConnectionString) : base(pDatabaseConnectionString)
        {

        }

        public EntryFeeManager(User pUser) : base(pUser)
        {

        }

        public List<EntryFee> GetAllEntryFee(IDbTransaction transaction)
        {
            const string query = @"SELECT
                                 [id] Id
                                ,[name_of_fee] Name
                                ,[min] Min
                                ,[max] Max
                                ,[rate] IsRate
                                ,[cycle_id] CycleId
                                ,[max_sum] MaxSum
                            FROM
                                [dbo].[EntryFees]";

            var result = transaction.Connection.Query<EntryFee>(query, null, transaction).ToList();
            return result;
        }
    }
}