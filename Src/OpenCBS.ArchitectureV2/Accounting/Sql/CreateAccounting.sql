-- Delete old tables
if object_id('dbo.Booking', 'u') is not null drop table dbo.Booking 
if object_id('dbo.Accounts', 'u') is not null drop table dbo.Accounts
if object_id('dbo.Categories', 'u') is not null drop table dbo.Categories

-- Chart of Accounts
create table
    dbo.Accounts
(
    account_number varchar(32) not null
    , label nvarchar(255) not null
    , start_date datetime
    , close_date datetime
    , type tinyint
    , is_debit bit
    , is_manual_editable bit
    , can_be_negative bit
    , parent varchar(32)
    , lft int not null
    , rgt int not null
)
alter table
    dbo.Accounts
add constraint
    PK_Accounts_account_number
primary key
    (account_number)

alter table
    dbo.Accounts
add constraint
    FK_Accounts_parent
foreign key
    (parent)
references
    dbo.Accounts(account_number)
go

-- Bookings
create table
    dbo.Booking
(
    Id int identity(1,1)
    , DebitAccount varchar(32) not null
    , CreditAccount varchar(32) not null
    , Amount money not null
    , Date datetime not null
    , Description varchar(200)
    , IsDeleted bit not null
    , IsExported bit not null
    , IsManualEditable bit
    , LoanEventId int not null
    , SavingEventId int not null
    , LoanId int
    , ClientId int
    , UserId int
    , BranchId int
    , AdvanceId int
    , StaffId int
)
alter table
    dbo.Booking
add constraint
    PK_Booking_Id primary key (Id)

alter table
    dbo.Booking
add constraint
    FK_Booking_DebitAccount foreign key (DebitAccount) references dbo.Accounts(account_number)

alter table
    dbo.Booking
add constraint
    FK_Booking_CreditAccount foreign key (CreditAccount) references dbo.Accounts(account_number)

alter table 
    dbo.Booking
add constraint 
    DF_Booking_IsDeleted default 0 for IsDeleted

alter table 
    dbo.Booking
add constraint 
    DF_Booking_IsExported default 0 for IsExported

alter table 
    dbo.Booking
add constraint 
    DF_Booking_LoanEventId default 0 for LoanEventId

alter table 
    dbo.Booking
add constraint 
    DF_Booking_SavingEventId default 0 for SavingEventId
go

insert into 
    dbo.Accounts (account_number, label, start_date, type, is_debit, parent, lft, rgt) 
values
    ('1000000', 'Assets', '01-01-2015', 1, 1, null, 1, 2)
    , ('2000000', 'Liabilities', '01-01-2015', 1, 2, null, 3, 4)
    , ('3000000', 'Equity', '01-01-2015', 1, 2, null, 5, 6)
    , ('4000000', 'Income', '01-01-2015', 1, 2, null, 7, 8)
    , ('5000000', 'Expenses', '01-01-2015', 1, 1, null, 9, 10)
go