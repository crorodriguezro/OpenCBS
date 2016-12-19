using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using OpenCBS.CoreDomain;
using OpenCBS.CoreDomain.Contracts.Loans;

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
                                ,[max_sum] MaxSum
                                ,[is_deleted] IsDeleted
                            FROM
                                [dbo].[EntryFees]";

            var result = transaction.Connection.Query<EntryFee>(query, null, transaction).ToList();
            return result;
        }

        public List<EntryFee> GetAllEntryFeeFromLoanProduct(int loanProductId, IDbTransaction transaction)
        {
            const string query = @"SELECT
                                         ef.[id] Id
                                        ,ef.[name_of_fee] Name
                                        ,ef.[min] Min
                                        ,ef.[max] Max
                                        ,ef.[rate] IsRate
                                        ,ef.[max_sum] MaxSum
                                        ,ef.[is_deleted] IsDeleted
	                                    ,lpef.[cycle_id] CycleId
                                        ,lpef.[fee_index] [Index]
                                    FROM
                                        [dbo].[EntryFees] ef
                                    LEFT JOIN
	                                    [dbo].[LoanProductsEntryFees] lpef on lpef.id_entry_fee = ef.id
                                    WHERE
	                                    lpef.id_product = @loanProductId
	                                    and ef.is_deleted = 0
                                    ";

            var result = transaction.Connection.Query<EntryFee>(query, new { loanProductId }, transaction).ToList();
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

        public void SaveNewEntryFeeListToLoanProduct(List<EntryFee> entryFeeList, int creditProductId, IDbTransaction transaction)
        {
            var query = @"delete from dbo.LoanProductsEntryFees where id_product = @creditProductId";
            transaction.Connection.Execute(query, new { creditProductId }, transaction);
            
            query = @"INSERT INTO dbo.LoanProductsEntryFees 
                            (id_entry_fee
				            , id_product
				            , cycle_id
				            , fee_index)
                        VALUES
                            (@Id
				            , @creditProductId
				            , @CycleId
				            , @Index)";

            foreach (var entryFee in entryFeeList)
            {
                transaction.Connection.Execute(query, new
                {
                    creditProductId = creditProductId
                    , Id = entryFee.Id
                    , CycleId = entryFee.CycleId
                    , Index = entryFee.Index
                }, transaction);
            }
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

        public EntryFee SelectEntryFeeById(int entryFeeId, IDbTransaction transaction)
        {
            const string query = @"SELECT
                                 [id] Id
                                ,[name_of_fee] Name
                                ,[min] Min
                                ,[max] Max
                                ,[rate] IsRate
                                ,[max_sum] MaxSum
                                ,[is_deleted] IsDeleted
                            FROM
                                [dbo].[EntryFees]
                            WHERE
                                id = @entryFeeId";

            var result = transaction.Connection.Query<EntryFee>(query, new { entryFeeId }, transaction).FirstOrDefault();
            return result;
        }

        public List<LoanEntryFee> SelectAllLoanEntryFeeFromLoanProduct(int productId, IDbTransaction transaction)
        {
            const string query = @"SELECT
                                         ef.[id] ProductEntryFeeId
                                    FROM
                                        [dbo].[EntryFees] ef
                                    LEFT JOIN
	                                    [dbo].[LoanProductsEntryFees] lpef on lpef.id_entry_fee = ef.id
                                    WHERE
	                                    lpef.id_product = @productId
	                                    and ef.is_deleted = 0
                                    ";

            var result = transaction.Connection.Query<LoanEntryFee>(query, new { productId }, transaction).ToList();
            return result;
        }

        public List<LoanEntryFee> SelectAllLoanEntryFeeFromCredit(int loanId, IDbTransaction transaction)
        {
            const string query = @"SELECT
                                    id ID
                                    , [entry_fee_id] ProductEntryFeeId
                                    , [fee_value] FeeValue
                                  FROM [dbo].[CreditEntryFees] 
                                  WHERE [credit_id] = @loanId
                                    ";

            var result = transaction.Connection.Query<LoanEntryFee>(query, new { loanId }, transaction).ToList();
            return result;
        }
    }
}