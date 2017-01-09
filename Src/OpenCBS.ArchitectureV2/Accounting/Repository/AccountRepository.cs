using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using OpenCBS.ArchitectureV2.Accounting.Interface.Repository;
using OpenCBS.ArchitectureV2.Accounting.Model;
using OpenCBS.CoreDomain;
using OpenCBS.Shared;

namespace OpenCBS.ArchitectureV2.Accounting.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SqlConnection _connection;

        public AccountRepository()
        {
            _connection = DatabaseConnection.GetConnection();
        }

        public List<Balance> GetBalances(DateTime @from, DateTime to, int branchId)
        {
            const string query = @"
                declare @_from date = @from
                declare @_to date = @to
                declare @_branch_id int = @branchId
                ;
                with
                start_debit as
                (
                    -- Debit at the beginning of period
                    select
                        a.account_number
                        , a.lft
                        , a.rgt
                        , sum(b.amount) amount
                    from
                        dbo.Booking b
                    left join
                        dbo.Accounts a on b.DebitAccount = a.account_number
                    where
                        b.IsDeleted = 0
                        and (b.BranchId = @_branch_id or @_branch_id = 0)
                        and cast(b.Date as date) < @_from
                    group by
                        a.account_number, a.lft, a.rgt
                )
                , start_credit as
                (
                    -- Credit at the beginning of period
                    select
                        a.account_number
                        , a.lft
                        , a.rgt
                        , sum(b.amount) amount
                    from
                        dbo.Booking b
                    left join
                        dbo.Accounts a on b.CreditAccount = a.account_number
                    where
                        b.IsDeleted = 0
                        and (b.BranchId = @_branch_id or @_branch_id = 0)
                        and cast(b.Date as date) < @_from
                    group by
                        a.account_number, a.lft, a.rgt
                )
                , debit as
                (
                    -- Debit during the period
                    select
                        a.account_number
                        , a.lft
                        , a.rgt
                        , sum(b.amount) amount
                    from
                        dbo.Booking b
                    left join
                        dbo.Accounts a on b.DebitAccount = a.account_number
                    where
                        b.IsDeleted = 0
                        and (b.BranchId = @_branch_id or @_branch_id = 0)
                        and cast(b.Date as date) between @_from and @_to
                        and b.CreditAccount != '00'
                    group by
                        a.account_number, a.lft, a.rgt
                )
                , credit as
                (
                    -- Credit during the period
                    select
                        a.account_number
                        , a.lft
                        , a.rgt
                        , sum(b.amount) amount
                    from
                        dbo.Booking b
                    left join
                        dbo.Accounts a on b.CreditAccount = a.account_number
                    where
                        b.IsDeleted = 0
                        and (b.BranchId = @_branch_id or @_branch_id = 0)
                        and cast(b.Date as date) between @_from and @_to
                        and b.DebitAccount != '00'
                    group by
                        a.account_number, a.lft, a.rgt
                )
                , end_debit as
                (
                    -- Debit at the end of the period
                    select
                        a.account_number
                        , a.lft
                        , a.rgt
                        , sum(b.amount) amount
                    from
                        dbo.Booking b
                    left join
                        dbo.Accounts a on b.DebitAccount = a.account_number
                    where
                        b.IsDeleted = 0
                        and (b.BranchId = @_branch_id or @_branch_id = 0)
                        and cast(b.Date as date) <= @_to
                    group by
                        a.account_number, a.lft, a.rgt
                )
                , end_credit as
                (
                    -- Credit at the end of the period
                    select
                        a.account_number
                        , a.lft
                        , a.rgt
                        , sum(b.amount) amount
                    from
                        dbo.Booking b
                    left join
                        dbo.Accounts a on b.CreditAccount = a.account_number
                    where
                        b.IsDeleted = 0
                        and (b.BranchId = @_branch_id or @_branch_id = 0)
                        and cast(b.Date as date) <= @_to
                    group by
                        a.account_number, a.lft, a.rgt
                )
                select
                    account_number Code
                    , label Name
                    , parent Parent
                    , case
                        when is_debit = 1 then start_debit - start_credit
                        else 0
                    end StartDebit
                    , case
                        when is_debit = 1 then 0
                        else start_credit - start_debit
                    end StartCredit

                    , debit Debit
                    , credit Credit

                    , case
                        when is_debit = 1 then end_debit - end_credit
                        else 0
                    end EndDebit
                    , case
                        when is_debit = 1 then 0
                        else end_credit - end_debit
                    end EndCredit
                from
                (
                    select
                        a.account_number
                        , a.label
                        , a.parent
                        , a.is_debit
                        -- Amounts at beginning
                        , isnull((
                            select
                                sum(sd.amount)
                            from
                                start_debit sd
                            where
                                a.lft <= sd.lft and sd.rgt <= a.rgt
                        ), 0) start_debit
                        , isnull((
                            select
                                sum(sc.amount)
                            from
                                start_credit sc
                            where
                                a.lft <= sc.lft and sc.rgt <= a.rgt
                        ), 0) start_credit

                        -- Amounts during period
                        , isnull((
                            select
                                sum(d.amount)
                            from
                                debit d
                            where
                                a.lft <= d.lft and d.rgt <= a.rgt
                        ), 0) debit
                        , isnull((
                            select
                                sum(c.amount)
                            from
                                credit c
                            where
                                a.lft <= c.lft and c.rgt <= a.rgt
                        ), 0) credit

                        -- Amounts at end
                        , isnull((
                            select
                                sum(ed.amount)
                            from
                                end_debit ed
                            where
                                a.lft <= ed.lft and ed.rgt <= a.rgt
                        ), 0) end_debit
                        , isnull((
                            select
                                sum(ec.amount)
                            from
                                end_credit ec
                            where
                                a.lft <= ec.lft and ec.rgt <= a.rgt
                        ), 0) end_credit    from
                        dbo.Accounts a
                ) t
                ";
            return _connection.Query<Balance>(query, new {from, to, branchId}, commandTimeout:300).ToList();
        }

        public List<Balance> GetAnalyticBalances(string parentCode, DateTime from, DateTime to, int branchId)
        {
            const string query = @"
                    select 
                    a.account_number Code 
                    , a.label Name
                    , a.parent Parent
                    , case 
                        when a.is_debit = 1
                        then start_debit.amount - start_credit.amount
                        else 0
                    end StartDebit
                    , case 
                        when a.is_debit = 1
                        then 0
                        else start_credit.amount - start_debit.amount
                    end StartCredit
                    , debit.amount Debit
                    , credit.amount Credit
                    , case 
                        when a.is_debit = 1
                        then end_debit.amount - end_credit.amount
                        else 0
                    end EndDebit
                    , case 
                        when a.is_debit = 1
                        then 0
                        else end_credit.amount - end_debit.amount
                    end EndCredit
                from 
                    dbo.Accounts a
                left join
                (
                    select 
                        a.account_number 
                        , sum(t.amount) amount
                    from 
                        dbo.Accounts a
                    left join
                    (
                        select 
                            isnull(b.amount, 0) amount
                            , a.lft
                            , a.rgt 
                        from 
                            dbo.Accounts a
                        left join 
                            dbo.Booking b on b.DebitAccount = a.account_number 
                                and convert(date, b.date) < convert(date, @from)
                                and (b.BranchId = @branchId or @branchId = 0) and b.IsDeleted = 0
                    ) t on a.lft < = t.lft and t.rgt <= a.rgt
                    group by 
                        a.account_number
                ) start_debit on start_debit.account_number = a.account_number
                left join
                (
                    select 
                        a.account_number
                        , sum(t.amount) amount
                    from 
                        dbo.Accounts a
                    left join
                    (
                        select 
                            isnull(b.amount, 0) amount
                            , a.lft
                            , a.rgt 
                        from 
                            dbo.Accounts a
                        left join 
                            dbo.Booking b on b.CreditAccount = a.account_number 
                                and convert(date, b.date) < convert(date, @from)
                                and (b.BranchId = @branchId or @branchId = 0) and b.IsDeleted = 0
                    ) t on a.lft < = t.lft and t.rgt <= a.rgt
                    group by 
                        a.account_number
                ) start_credit on start_credit.account_number = a.account_number
                left join
                (
                    select 
                        a.account_number
                        , sum(t.amount) amount
                    from 
                        dbo.Accounts a
                    left join
                    (
                        select 
                            isnull(b.amount, 0) amount 
                            , a.lft
                            , a.rgt 
                        from 
                            dbo.Accounts a
                        left join 
                            dbo.Booking b on b.DebitAccount = a.account_number 
                                and convert(date, b.date) >= convert(date, @from)
                                and convert(date, b.date) <= convert(date, @to)
                                and (b.BranchId = @branchId or @branchId = 0) and b.IsDeleted = 0 and b.CreditAccount != '00'
                    ) t on a.lft < = t.lft and t.rgt <= a.rgt
                    group by 
                        a.account_number
                ) debit on debit.account_number = a.account_number
                left join
                (
                    select 
                        a.account_number
                        , sum(t.amount) amount
                    from 
                        dbo.Accounts a
                    left join
                    (
                        select 
                            isnull(b.amount, 0) amount
                            , a.lft
                            , a.rgt 
                        from 
                            dbo.Accounts a
                        left join 
                            dbo.Booking b on b.CreditAccount = a.account_number 
                                and convert(date, b.date) >= convert(date, @from)
                                and convert(date, b.date) <= convert(date, @to)
                                and (b.BranchId = @branchId or @branchId = 0) and b.IsDeleted = 0 and b.DebitAccount != '00'
                    ) t on a.lft < = t.lft and t.rgt <= a.rgt
                    group by 
                        a.account_number
                ) credit on credit.account_number = a.account_number
                left join
                (
                    select 
                        a.account_number
                        , sum(t.amount) amount
                    from 
                        dbo.Accounts a
                    left join
                    (
                        select 
                            isnull(b.amount, 0) amount
                            , a.lft
                            , a.rgt 
                        from 
                            dbo.Accounts a
                        left join 
                            dbo.Booking b on b.DebitAccount = a.account_number 
                                and convert(date, b.date) <= convert(date, @to)
                                and (b.BranchId = @branchId or @branchId = 0) and b.IsDeleted = 0
                    ) t on a.lft < = t.lft and t.rgt <= a.rgt
                    group by 
                        a.account_number
                ) end_debit on end_debit.account_number = a.account_number
                left join
                (
                    select 
                        a.account_number
                        , sum(t.amount) amount
                    from 
                        dbo.Accounts a
                    left join
                    (
                        select 
                            isnull(b.amount, 0) amount
                            , a.lft
                            , a.rgt 
                        from 
                            dbo.Accounts a
                        left join 
                            dbo.Booking b on b.CreditAccount = a.account_number 
                                and convert(date, b.date) <= convert(date, @to)
                                and (b.BranchId = @branchId or @branchId = 0) and b.IsDeleted = 0
                    ) t on a.lft < = t.lft and t.rgt <= a.rgt
                    group by 
                        a.account_number
                ) end_credit on end_credit.account_number = a.account_number
                left join
                    Accounts p on p.account_number = @parentCode
                where 
                    a.type = 5
                    and p.lft < a.lft
                    and p.rgt > a.rgt
                ";
            return _connection.Query<Balance>(query, new {parentCode, from, to, branchId}).ToList();
        }


        public void Save(Account entity, IDbTransaction tx = null)
        {
            var connection = tx == null ? DatabaseConnection.GetConnection() : tx.Connection;
            try
            {
                var query = @"
                    select
                        case 
                            when isnull(@parent,'') = '' 
                            then 
                            (
                                select 
                                    case 
                                        when max(rgt) is null 
                                        then 1 
                                        else max(rgt) + 1 
                                    end
                                from 
                                    dbo.Accounts
                            )
                            else 
                            (
                                select 
                                    rgt
                                from
                                    dbo.Accounts
                                where
                                    account_number = @parent
                            )
                        end
                    ";
                var rightMostSibling = connection.Query<int>(query, entity, tx).FirstOrDefault();

                entity.Lft = rightMostSibling;
                entity.Rgt = rightMostSibling + 1;
                query = @"
                    update
                        dbo.Accounts
                    set
                        lft = case 
                            when lft > @rightMostSibling 
                            then lft + 2 
                            else lft 
                        end
                        , rgt = case 
                            when rgt >= @rightMostSibling 
                            then rgt + 2 
                            else rgt 
                        end
                    where 
                        rgt >= @rightMostSibling
                    ";
                connection.Execute(query, new {rightMostSibling}, tx);
                query = @"
                    insert into
                        dbo.Accounts 
                        (
                        account_number
                        , label
                        , start_date
                        , close_date
                        , type
                        , is_debit
                        , parent
                        , is_direct
                        , lft
                        , rgt
                        )
                    values
                        (
                        @AccountNumber
                        , @Label
                        , @StartDate
                        , @CloseDate
                        , @Type
                        , @IsDebit
                        , @Parent
                        , @IsDirect
                        , @Lft
                        , @Rgt
                        )
                    ";
                if (entity.StartDate == new DateTime())
                {
                    entity.StartDate = TimeProvider.Today;
                }
                if (entity.CloseDate == new DateTime())
                {
                    entity.CloseDate = DateTime.MaxValue;
                }
                connection.Execute(query, entity, tx);
            }
            finally
            {
                if (tx == null)
                {
                    connection.Dispose();
                }
            }
        }


        public bool Exists(Account entity, IDbTransaction tx = null)
        {
            var connection = tx == null ? DatabaseConnection.GetConnection() : tx.Connection;
            try
            {
                const string query = @"
                        SELECT COUNT(*) FROM dbo.Accounts WHERE account_number=@account_number
                    ";
                var result = connection.Query<int>(query,new { account_number = entity.AccountNumber}, tx);
                return result.FirstOrDefault()>0;
            }
            finally
            {
                if (tx == null)
                {
                    connection.Dispose();
                }
            }
        }

        public void Update(Account entity, IDbTransaction tx = null)
        {
            var connection = tx == null ? DatabaseConnection.GetConnection() : tx.Connection;
            try
            {
                const string query = @"
                    update 
                        dbo.Accounts 
                    set 
                        label = @Label
                        , type = @Type
                        , is_debit = @IsDebit
                        , is_direct = @IsDirect
                    where 
                        account_number = @AccountNumber
                    ";
                connection.Execute(query, entity, tx);
            }
            finally
            {
                if (tx == null)
                {
                    connection.Dispose();
                }
            }
        }

        public void Delete(Account entity, IDbTransaction tx = null)
        {
            var connection = tx == null ? DatabaseConnection.GetConnection() : tx.Connection;
            try
            {
                var query = @"
                    delete from 
                        dbo.Accounts
                    where 
                        lft >= @Lft 
                        and rgt <= @Rgt
                    ";
                connection.Execute(query, entity, tx);
                query = @"
                    update 
                        dbo.Accounts
                    set 
                        lft = lft - @diff
                        , rgt = rgt - @diff
                    where 
                        lft > @lft
                    ";
                connection.Execute(query, new {lft = entity.Lft, @diff = entity.Rgt - entity.Lft + 1}, tx);
                query = @"
                    update 
                        dbo.Accounts
                    set 
                        rgt = rgt - @diff
                    where 
                        lft < @lft 
                        and rgt > @rgt
                    ";
                connection.Execute(query, new {lft = entity.Lft, rgt = entity.Rgt, @diff = entity.Rgt - entity.Lft + 1},
                    tx);
            }
            finally
            {
                if (tx == null)
                {
                    connection.Dispose();
                }
            }
        }

        public List<Account> SelectAllAccounts()
        {
            const string query = @"
                select 
                    account_number AccountNumber
                    , label Label
                    , start_date StartDate
                    , close_date CloseDate
                    , type Type
                    , is_debit IsDebit
                    , is_direct IsDirect
                    , can_be_negative CanBeNegative
                    , parent Parent
                    , is_direct IsDirect
                    , lft Lft
                    , rgt Rgt
                from 
                    dbo.Accounts
                ";
            return _connection.Query<Account>(query).ToList();
        }

        public void AddAccountsForLoan(
            string portfolioAccount,
            string interestAccount,
            string transitAccount,
            int loanId, IDbTransaction tx)
        {
            const string query = @"
                update 
                    dbo.Credit 
                set 
                    portfolio_account = @portfolioAccount
                    , interest_account = @interestAccount
                    , transit_account = @transitAccount
                where 
                    id = @loanId
                ";
            tx.Connection.Execute(query, new {portfolioAccount, interestAccount, transitAccount, loanId}, tx);
        }

        public void DeleteAccounts(int loanId, IDbTransaction tx)
        {
            var query = @"
                select 
                    portfolio_account 
                from 
                    dbo.Credit 
                where 
                    id = @loanId";
            var portfolioAccount = tx.Connection.Query<string>(query, new {loanId}, tx).FirstOrDefault();
            query = @"
                select 
                    interest_account 
                from 
                    dbo.Credit 
                where 
                    id = @loanId";
            var interestAccount = tx.Connection.Query<string>(query, new {loanId}, tx).FirstOrDefault();
            query = @"
                select 
                    transit_account 
                from 
                    dbo.Credit 
                where 
                    id = @loanId";
            var transitAccount = tx.Connection.Query<string>(query, new {loanId}, tx).FirstOrDefault();
            query = @"
                update 
                    dbo.Credit 
                set
                    portfolio_account = null
                    , interest_account = null
                    , transit_account = null
                where 
                    id = @loanId
                ";
            tx.Connection.Execute(query, new {loanId}, tx);
            DeleteAccount(portfolioAccount, tx);
            DeleteAccount(interestAccount, tx);
            DeleteAccount(transitAccount, tx);
        }

        public void DeleteAccount(string accountNumber, IDbTransaction transaction)
        {
            var query = @"
                select 
                    lft  
                from 
                    dbo.Accounts 
                where 
                    account_number = @accountNumber
                ";
            var lft = transaction.Connection.Query<int>(query, new {accountNumber}, transaction).FirstOrDefault();
            query = @"
                select 
                    rgt
                from 
                    dbo.Accounts 
                where 
                    account_number = @accountNumber
                ";
            var rgt = transaction.Connection.Query<int>(query, new {accountNumber}, transaction).FirstOrDefault();
            query = @"
                delete from 
                    dbo.Booking 
                where 
                    CreditAccount = @accountNumber
                delete  from 
                    dbo.Booking 
                where 
                    DebitAccount = @accountNumber
                ";
            transaction.Connection.Execute(query, new {accountNumber}, transaction);
            query = @"
                delete from 
                    dbo.Accounts
                where
                    lft >= @lft and rgt <= @rgt
                ";
            transaction.Connection.Execute(query, new {lft, rgt}, transaction);
            query = @"
                update  
                    dbo.Accounts
                set 
                    lft = lft - @diff, rgt = rgt - @diff
                where   
                    lft > @lft
                ";
            transaction.Connection.Execute(query, new {lft, @diff = rgt - lft + 1}, transaction);
            query = @"
                update 
                    dbo.Accounts
                set 
                    rgt = rgt - @diff
                where 
                    lft < @lft and rgt > @rgt
                ";
            transaction.Connection.Execute(query, new {lft, rgt, @diff = rgt - lft + 1}, transaction);
        }

        public void CreateSavingForLaon(int loanId, string code, int userId, DateTime creationDate, IDbTransaction tx)
        {
            var clientId = tx.Connection.Query<int>(
                @"SELECT DISTINCT Tiers.id 
                FROM Contracts 
                INNER JOIN Projects ON Projects.id = Contracts.project_id
                INNER JOIN Tiers ON Tiers.id = Projects.tiers_id
                WHERE Contracts.id = @loanId", new {loanId}, tx).FirstOrDefault();

            tx.Connection.Execute(
                @"insert into SavingContracts (product_id, user_id, code, tiers_id, creation_date, interest_rate, status, loan_id)
                values (1, @userId, @code, @clientId, @creationDate, 0, 1, @loanId)
                declare @id int;
                select @id = SCOPE_IDENTITY()

                insert into SavingBookContracts values(@id, 0,	NULL,	0,	NULL,	0,	0,	0,	0,	0,	0,	0,	0,	0,	NULL,	0,	0,	NULL,	NULL,	NULL,	0,	NULL)

                insert into SavingEvents (user_id, contract_id, code, amount, description, deleted, creation_date, cancelable, is_fired, fees, savings_method)
                values (@userId, @id, 'SVIE', 0, 'First deposit', 0, @creationDate, 0, 1, 0, 1)",
                new {loanId, code, userId, clientId, creationDate},
                tx);
        }

        public Balance GetBalance(DateTime date, string accountNumber)
        {
            const string query = @"
                select 
                    a.account_number Code 
                    , a.label Name
                    , a.parent Parent
                    , case 
                        when a.is_debit = 1
                        then start_debit.amount - start_credit.amount
                        else 0
                    end StartDebit
                    , case 
                        when a.is_debit = 1
                        then 0
                        else start_credit.amount - start_debit.amount
                    end StartCredit
                from 
                    dbo.Accounts a
                left join
                (
                    select 
                        a.account_number 
                        , sum(t.amount) amount
                    from 
                        dbo.Accounts a
                    left join
                    (
                        select 
                            b.amount
                            , a.lft
                            , a.rgt 
                        from 
                            dbo.Accounts a
                        left join 
                            dbo.Booking b on b.DebitAccount = a.account_number 
                                and convert(date, b.date) < convert(date, @date)
                                and b.IsDeleted = 0
                    ) t on a.lft < = t.lft and t.rgt <= a.rgt
                    group by 
                        a.account_number
                ) start_debit on start_debit.account_number = a.account_number
                left join
                (
                    select 
                        a.account_number
                        , sum(t.amount) amount
                    from 
                        dbo.Accounts a
                    left join
                    (
                        select 
                            isnull(b.amount, 0) amount
                            , a.lft
                            , a.rgt 
                        from 
                            dbo.Accounts a
                        left join 
                            dbo.Booking b on b.CreditAccount = a.account_number 
                                and convert(date, b.date) < convert(date, @date)
                                and b.IsDeleted = 0
                    ) t on a.lft < = t.lft and t.rgt <= a.rgt
                    group by 
                        a.account_number
                ) start_credit on start_credit.account_number = a.account_number
                where
                    a.account_number = @accountNumber
            ";
            return _connection.Query<Balance>(query, new { date, accountNumber }).FirstOrDefault();
        }
    }
}
