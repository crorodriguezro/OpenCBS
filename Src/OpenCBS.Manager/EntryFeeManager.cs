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
                                ,[is_deleted] IsDeleted
                            FROM
                                [dbo].[EntryFees]";

            var result = transaction.Connection.Query<EntryFee>(query, null, transaction).ToList();
            return result;
        }

        public void SaveNewEntryfee(EntryFee entryFee, IDbTransaction transaction)
        {
            const string query = @"INSERT INTO dbo.EntryFees 
                                        (name_of_fee, 
                                        min,
                                        max, 
                                        rate, 
                                        max_sum)
                                   VALUES
                                       (@Name,
                                        @Min,
                                        @Max,
                                        @IsRate,
                                        @MaxSum)";

            transaction.Connection.Execute(query, entryFee, transaction);
        }

        public void UpdateEntryfee(EntryFee entryFee, IDbTransaction transaction)
        {
            const string query = @"UPDATE
                                        dbo.EntryFees
                                   set
                                        name_of_fee = @Name, 
                                        min = @Min,
                                        max = @Max, 
                                        rate = @IsRate, 
                                        max_sum = @MaxSum
                                   where
                                        id = @Id";

            transaction.Connection.Execute(query, entryFee, transaction);
        }

        public void DeleteEntryfee(EntryFee entryFee, IDbTransaction transaction)
        {
            const string query = @"UPDATE
                                        dbo.EntryFees
                                   set
                                        [is_deleted] = 1
                                   where
                                        id = @Id";

            transaction.Connection.Execute(query, entryFee, transaction);
        }
    }
}