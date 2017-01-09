using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using OpenCBS.ArchitectureV2.Accounting.Interface.Repository;
using OpenCBS.ArchitectureV2.Accounting.Model;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.Services;

namespace OpenCBS.ArchitectureV2.Accounting.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IConnectionProvider _connectionProvider;

        public BookingRepository(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public void Save(IEnumerable<Booking> entity, IDbTransaction tx = null)
        {
            var connection = tx == null ? _connectionProvider.GetConnection() : tx.Connection;
            try
            {
                var rows = entity.Select(booking => booking.Map()).ToList();
                const string query = @"
                    insert into
                        dbo.Booking 
                    (
                        DebitAccount
                        , CreditAccount
                        , Amount
                        , Date
                        , LoanEventId
                        , UserId
                        , SavingEventId
                        , LoanId
                        , ClientId
                        , BranchId
                        , Description
                        , IsDeleted
                        , AdvanceId
                        , StaffId
                        , IsManualEditable
                        , Doc1
                        , Doc2
                    ) 
                    values 
                    (
                        @DebitAccount
                        , @CreditAccount
                        , @Amount
                        , @Date
                        , @LoanEventId
                        , @UserId
                        , @SavingEventId
                        , @LoanId
                        , @ClientId
                        , @BranchId
                        , @Description
                        , @IsDeleted
                        , @AdvanceId
                        , @StaffId
                        , @IsManualEditable
                        , @Doc1
                        , @Doc2
                    )
                    ";
                connection.Execute(query, rows, tx);
            }
            finally
            {
                if (tx == null)
                {
                    connection.Dispose();
                }
            }
        }

        public int Save(Booking entity, IDbTransaction tx = null)
        {
            var connection = tx == null ? _connectionProvider.GetConnection() : tx.Connection;
            try
            {
                const string query = @"
                    insert into
                        dbo.Booking 
                    (
                        DebitAccount
                        , CreditAccount
                        , Amount
                        , Date
                        , LoanEventId
                        , UserId
                        , SavingEventId
                        , LoanId
                        , ClientId
                        , BranchId
                        , Description
                        , IsDeleted
                        , AdvanceId
                        , StaffId
                        , IsManualEditable
                        , Doc1
                        , Doc2
                    ) 
                    output 
                        inserted.id
                    values 
                    (
                        @DebitAccount
                        , @CreditAccount
                        , @Amount
                        , @Date
                        , @LoanEventId
                        , @UserId
                        , @SavingEventId
                        , @LoanId
                        , @ClientId
                        , @BranchId
                        , @Description
                        , @IsDeleted
                        , @AdvanceId
                        , @StaffId
                        , @IsManualEditable
                        , @Doc1
                        , @Doc2
                    )
                    ";
                return connection.Query<int>(query, entity.Map(), tx).FirstOrDefault();
            }
            finally
            {
                if (tx == null)
                {
                    connection.Dispose();
                }
            }
        }

        public void Update(IEnumerable<Booking> entity, IDbTransaction tx = null)
        {
            var connection = tx == null ? _connectionProvider.GetConnection() : tx.Connection;
            try
            {
                var rows = entity.Select(i => i.Map()).ToList();
                const string query = @"
                    update 
                        dbo.Booking 
                    set 
                        DebitAccount = @DebitAccount
                        , CreditAccount = @CreditAccount
                        , Amount = @Amount
                        , Date = @Date
                        , LoanEventId = @LoanEventId
                        , BranchId = @BranchId
                        , SavingEventId = @SavingEventId
                        , LoanId = @LoanId
                        , UserId = @UserId
                        , ClientId = @ClientId
                        , Description = @Description
                        , IsDeleted = @IsDeleted 
                        , Doc1 = @Doc1
                        , Doc2 = @Doc2
                    where 
                        Id = @Id
                    ";
                connection.Execute(query, rows, tx);
            }
            finally
            {
                if (tx == null)
                {
                    connection.Dispose();
                }
            }
        }

        public void Delete(int bookingId, IDbTransaction tx = null)
        {
            var connection = tx == null ? _connectionProvider.GetConnection() : tx.Connection;
            try
            {
                const string query = @"
                    update 
                        dbo.Booking 
                    set 
                        IsDeleted = 1,
                        CancelDate = getdate()  
                    where 
                        Id = @bookingId
                    ";
                connection.Execute(query, new { bookingId }, tx);
            }
            finally
            {
                if (tx == null)
                {
                    connection.Dispose();
                }
            }
        }

        public void DeleteByLoanEvent(int loanEventId, IDbTransaction tx = null)
        {
            var connection = tx == null ? _connectionProvider.GetConnection() : tx.Connection;
            try
            {
                const string query = @"
                    update 
                        dbo.Booking 
                    set 
                        IsDeleted = 1,
                        CancelDate = getdate()  
                    where 
                        LoanEventId = @loanEventId 
                    ";
                connection.Execute(query, new {loanEventId}, tx);
            }
            finally
            {
                if (tx == null)
                {
                    connection.Dispose();
                }
            }
        }

        public void DeleteBySavingEvent(int savingEventId, IDbTransaction tx = null)
        {
            var connection = tx == null ? _connectionProvider.GetConnection() : tx.Connection;
            try
            {
                const string query = @"
                    update 
                        dbo.Booking 
                    set 
                        IsDeleted = 1,
                        CancelDate = getdate()
                    where 
                        SavingEventId = @savingEventId
                    ";
                connection.Execute(query, new {savingEventId}, tx);
            }
            finally
            {
                if (tx == null)
                {
                    connection.Dispose();
                }
            }
        }

        public Booking Get(int id)
        {
            using (var connection = _connectionProvider.GetConnection())
            {
                const string query = @"
                    select 
                        b.*
                        , coalesce(p.last_name, g.name, c.name, '-') ClientLastName
                        , isnull(p.first_name, '-') ClientFirstName 
                    from 
                        dbo.Booking b 
                    left join 
                        dbo.Tiers t on t.id = b.ClientId
                    left join 
                        dbo.Persons p on p.id = t.id
                    left join 
                        dbo.Corporates c on c.id = t.id
                    left join 
                        dbo.Groups g on g.id = t.id
                    where 
                        b.Id = @id
                    ";
                var row = connection.Query<BookingDto>(query, new { id }).Single();
                var accounts = SelectAllAccounts().ToList();
                var users = ServicesProvider.GetInstance().GetUserServices().FindAll(true);
                var booking = row.Map();
                booking.Credit = accounts.FirstOrDefault(i => i.AccountNumber == row.CreditAccount);
                booking.Debit = accounts.FirstOrDefault(i => i.AccountNumber == row.DebitAccount);
                booking.User = users.FirstOrDefault(i => i.Id == row.UserId);
                return booking;
            }
        }

        public IEnumerable<BookingDto> SelectBookings(DateTime from, DateTime to, Account debit, Account credit)
        {
            using (var connection = _connectionProvider.GetConnection())
            {
                const string query = @"
                    select 
                        b.*
                        , coalesce(p.last_name, g.name, c.name, '-') ClientLastName
                        , isnull(p.first_name, '-') ClientFirstName 
                        , u.first_name + ' ' + u.last_name UserName
                    from 
                        dbo.Booking b 
                    left join 
                        dbo.Tiers t on t.id = b.ClientId
                    left join 
                        dbo.Persons p on p.id = t.id
                    left join 
                        dbo.Corporates c on c.id = t.id
                    left join 
                        dbo.Groups g on g.id = t.id
                    left join
                        dbo.Users u on u.id = b.UserId
                    left join
						dbo.Accounts da on da.account_number = b.DebitAccount
					left join
						dbo.Accounts ca on ca.account_number = b.CreditAccount
                    where 
                        convert(date, b.Date) >= @from 
                        and convert(date, b.Date) <= @to
                        and da.lft >= @debitLeft and da.rgt <= @debitRight
                        and ca.lft >= @creditLeft and ca.rgt <= @creditRight

                    ";
                return connection.Query<BookingDto>(query, new
                {
                    from,
                    to,
                    debitLeft = debit.Lft,
                    debitRight = debit.Rgt,
                    creditLeft = credit.Lft,
                    creditRight = credit.Rgt
                });
            }
        }

        public IEnumerable<BookingDto> SelectBookings(DateTime from, DateTime to)
        {
            using (var connection = _connectionProvider.GetConnection())
            {
                const string query = @"
                    select 
                        b.*
                        , coalesce(p.last_name, g.name, c.name, '-') ClientLastName
                        , isnull(p.first_name, '-') ClientFirstName 
                        , u.first_name + ' ' + u.last_name UserName
                    from 
                        dbo.Booking b 
                    left join 
                        dbo.Tiers t on t.id = b.ClientId
                    left join 
                        dbo.Persons p on p.id = t.id
                    left join 
                        dbo.Corporates c on c.id = t.id
                    left join 
                        dbo.Groups g on g.id = t.id
                    left join
                        dbo.Users u on u.id = b.UserId
                    left join
						dbo.Accounts da on da.account_number = b.DebitAccount
					left join
						dbo.Accounts ca on ca.account_number = b.CreditAccount
                    where 
                        convert(date, b.Date) >= @from 
                        and convert(date, b.Date) <= @to
                    ";
                return connection.Query<BookingDto>(query, new { from, to });
            }
        }

        public decimal GetAccountBalance(DateTime date, Account account)
        {
            using (var connection = _connectionProvider.GetConnection())
            {
                const string query = @"
                    select 
                        case 
                            when a.is_debit = 1
                            then isnull(b.endDebit, 0) - isnull(b.endCredit, 0)
                            else isnull(b.endCredit, 0) - isnull(b.endDebit, 0)
                        end Balance
                    from 
                    (
                        select 
                            t.account_number account
                            , sum(isnull(endDebit.amount, 0)) endDebit
                            , sum(isnull(endCredit.amount, 0)) endCredit
                        from 
                            dbo.Accounts t
                        left join 
                        (
                            select 
                                DebitAccount account
                                , sum(isnull(amount, 0)) amount
                            from 
                                dbo.Booking
                            where 
                                cast(Date as date) <= cast(@date as date) 
                                and IsDeleted = 0
                            group by 
                                DebitAccount 
                        ) endDebit on endDebit.account = t.account_number
                        left join 
                        (
                            select 
                                CreditAccount account
                                , sum(isnull(amount, 0)) amount
                            from 
                                dbo.Booking 
                            where 
                                cast(Date as date) <= cast(@date as date) 
                                and IsDeleted = 0
                            group by 
                                CreditAccount
                        ) endCredit on endCredit.account = t.account_number
                        group by 
                            t.account_number
                    ) b
                    left join 
                        dbo.Accounts a on a.account_number = b.account
                    where 
                        a.account_number = @number
                    ";
                return connection.Query<decimal>(query, new { date, number = account.AccountNumber }).FirstOrDefault();
            }
        }

        public IEnumerable<Account> SelectAllAccounts()
        {
            using (var connection = _connectionProvider.GetConnection())
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
                        , lft Lft
                        , rgt Rgt
                    from 
                        dbo.Accounts";
                return connection.Query<Account>(query);
            }
        }

        public List<AccountMovement> GetAccountMovements(DateTime @from, DateTime to, Account account = null)
        {
            const string query = @"
                select 
                    id Id
                    , DebitAccount Debit
                    , CreditAccount Credit
                    , amount DebitAmount
                    , 0 CreditAmount
                    , date Date
                    , description Description
                from 
                    dbo.Booking b
                left join 
                    dbo.Accounts debit on debit.account_number=b.DebitAccount
                where 
                    convert(date, date) >= @from 
                    and convert(date, date) <= @to 
                    and (debit.lft >= @lft and debit.rgt <= @rgt)
				union all
				select 
                    id Id
                    , DebitAccount Debit
                    , CreditAccount Credit
                    , 0 DebitAmount
                    , amount CreditAmount
                    , date Date
                    , description Description
                from 
                    dbo.Booking b
                left join 
                    dbo.Accounts credit on credit.account_number=b.CreditAccount
                where 
                    convert(date, date) >= @from 
                    and convert(date, date) <= @to 
                    and (credit.lft >= @lft and credit.rgt <= @rgt 
                    and b.IsDeleted = 0)
                ";
            var lft = account == null ? 0 : account.Lft;
            var rgt = account == null ? int.MaxValue : account.Rgt;
            using (var connection = _connectionProvider.GetConnection())
            {
                return connection.Query<AccountMovement>(query, new { from, to, lft, rgt }).ToList();
            }
        }

        public void CloseAccount(DateTime date, Account account, IDbTransaction tx = null)
        {
            var connection = tx == null ? _connectionProvider.GetConnection() : tx.Connection;
            try
            {
                const string query = @"
                    update 
                        dbo.Accounts 
                    set 
                        close_date = @date 
                    where 
                        account_number = @accountNumber
                    ";
                connection.Execute(query, new { date, accountNumber = account.AccountNumber }, tx);
            }
            finally
            {
                if (tx == null)
                {
                    connection.Dispose();
                }
            }
        }

        public void RecoverAccount(Account account, IDbTransaction tx = null)
        {
            var connection = tx == null ? _connectionProvider.GetConnection() : tx.Connection;
            try
            {
                const string query = @"
                    update 
                        dbo.Accounts 
                    set 
                        close_date = null 
                    where 
                        account_number = @accountNumber
                    ";
                connection.Execute(query, new { accountNumber = account.AccountNumber }, tx);
            }
            finally
            {
                if (tx == null)
                {
                    connection.Dispose();
                }
            }
        }

        public int GetLoanId(int savingId)
        {
            using (var connection = _connectionProvider.GetConnection())
            {
                const string query = @"
                    select 
                        loan_id 
                    from 
                        dbo.SavingContracts 
                    where 
                        id = @savingId
                    ";
                return connection.Query<int>(query, new { savingId }).FirstOrDefault();
            }
        }
    }
}
