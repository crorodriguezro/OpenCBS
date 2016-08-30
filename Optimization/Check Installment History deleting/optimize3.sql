declare @currentDate datetime = getdate()
declare @NotActive_LoansIds table(NotActiveLoanId int)
declare @NonActive_Projects table(id int)
-------------------Set Non Active Loans Ids-------------------------
insert into @NotActive_LoansIds
select
    cr.id
from dbo.Credit cr 
where cr.id NOT IN (select id from ActiveLoans(@currentDate , 0));

insert into @NonActive_Projects
select
    distinct pr.id
from @NotActive_LoansIds nali
left join dbo.Contracts c on c.id = nali.NotActiveLoanId
left join dbo.Projects pr on pr.id = c.project_id

--select nap.id,count(c.id) from @NonActive_Projects nap
--left join dbo.Contracts c on c.project_id = nap.id
--group by nap.id
--------------------------------------------------------------------


--------------------------Delete Non Active Loans-------------------------
DECLARE @Counter INT = 1
WHILE @Counter > 0
BEGIN
 
    delete top(100000)
    from dbo.InstallmentHistory
    where contract_id in (select NotActiveLoanId from @NotActive_LoansIds)
    SET @Counter = @@ROWCOUNT 
END
--------------------------------------------------------------------------

----------------------Delete Loan Additional Information-----------------
delete 
from dbo.Installments
where contract_id in (select * from @NotActive_LoansIds)


delete
from dbo.CreditEntryFees
where credit_id in (select * from @NotActive_LoansIds)


if(object_id(N'[dbo].[CustomTable_Collaterals]', 'U') is not null)
begin
    delete
    from dbo.CustomTable_Collaterals
    where owner_id in (select * from @NotActive_LoansIds)
end

if(object_id(N'[dbo].[CustomTable_Guarantor]', 'U') is not null)
begin
    delete
    from dbo.CustomTable_Guarantor
    where owner_id in (select * from @NotActive_LoansIds)
end


delete
from dbo.Credit
where id in (select * from @NotActive_LoansIds)






-----------------Delete Credits and Events--------------------------
declare @NotActive_ContractEventsIds table (NotActiveContractEventsId int)

insert into @NotActive_ContractEventsIds
    select ce.id 
    from dbo.ContractEvents ce 
    where ce.contract_id in (select NotActiveLoanId from @NotActive_LoansIds)

delete
from dbo.AccrualInterestLoanEvents
where id in (select * from @NotActive_ContractEventsIds)

delete
from dbo.CreditInsuranceEvents
where id in (select * from @NotActive_ContractEventsIds)

delete 
from dbo.InterestWriteOffEvents    
where id in (select * from @NotActive_ContractEventsIds)

delete
from dbo.InterestWriteOffEvents
where id in (select * from @NotActive_ContractEventsIds)

delete
from dbo.LoanDisbursmentEvents    
where id in (select * from @NotActive_ContractEventsIds)

delete
from dbo.LoanEntryFeeEvents    
where id in (select * from @NotActive_ContractEventsIds)

delete
from dbo.LoanPenaltyAccrualEvents    
where id in (select * from @NotActive_ContractEventsIds)

delete
from dbo.LoanTransitionEvents    
where id in (select * from @NotActive_ContractEventsIds)

delete
from dbo.OverdueEvents    
where id in (select * from @NotActive_ContractEventsIds)

delete
from dbo.PenaltyWriteOffEvents    
where id in (select * from @NotActive_ContractEventsIds)

delete
from dbo.ProvisionEvents    
where id in (select * from @NotActive_ContractEventsIds)

delete
from dbo.RepaymentEvents    
where id in (select * from @NotActive_ContractEventsIds)

delete
from dbo.ReschedulingOfALoanEvents    
where id in (select * from @NotActive_ContractEventsIds)

delete
from dbo.TrancheEvents    
where id in (select * from @NotActive_ContractEventsIds)

delete
from dbo.WriteOffEvents    
where id in (select * from @NotActive_ContractEventsIds)

delete
from dbo.LoanDisbursmentEvents    
where id in (select * from @NotActive_ContractEventsIds)

delete 
from dbo.ContractEvents  
where id in (select * from @NotActive_ContractEventsIds)
-------------------------------------------------------------


-----------------Delete Contracts and Projects--------------
delete 
from dbo.ContractAssignHistory  
where contract_id in (select * from @NotActive_LoansIds)

delete 
from dbo.LoansLinkSavingsBook  
where loan_id in (select * from @NotActive_LoansIds)

delete 
from dbo.CollateralPropertyValues  
where contract_collateral_id in 
(select id
from dbo.CollateralsLinkContracts  
where contract_id in (select * from @NotActive_LoansIds))

delete 
from dbo.CollateralsLinkContracts  
where contract_id in (select * from @NotActive_LoansIds)

delete 
from dbo.LinkGuarantorCredit  
where contract_id in (select * from @NotActive_LoansIds)

delete
from dbo.Contracts
where id in (select * from @NotActive_LoansIds)
------------------------------------------------------


----------------------Delete Booking-------------------

insert into dbo.Booking
select 
	    sum(Amount) as Amount
	   , max(Date) as [Date] 
	   , 0 as LoanEventId
	   , 0 as SavingEventId
	   , 0 as LoanId
	   , 0 as ClientId
	   , 1 as UserId
	   , BranchId as BranchId
	   , N'Balanced Transaction' as [Description]
	   , 0 as IsDeleted
	   , 0 as IsExported
	   , DebitAccount
	   , CreditAccount
	   , 0 as AdvanceId
	   , 0 as StaffId
	   , 0 as IsManualEditable
	   , null as Doc1
	   , null as Doc2
from dbo.Booking 
where LoanId in (select * from @NotActive_LoansIds)
group by DebitAccount, CreditAccount, BranchId
GO

delete from dbo.Booking where LoanId in (select * from @NotActive_LoansIds) and [Description] != 'Balanced Transaction'
GO
------------------------------------------------------------

select account_number, dbo.GetBalance(account_number,getdate()) from dbo.Accounts

select * from dbo.Booking where  [Description] = 'Balanced Transaction' and (DebitAccount is null or CreditAccount is null)

select * from dbo.Booking where DebitAccount is null
-----------------------------------------------------------------------------------------------------------------------------------


INSERT [dbo].[Accounts] ([account_number], [label], [is_debit], [parent], [lft], [rgt], [type], [start_date], [close_date], [can_be_negative], [is_direct]) VALUES (N'0', N'Off-balance account', 1, NULL, 0, 0, 1, CAST(N'2015-12-31 00:00:00.000' AS DateTime), NULL, NULL, 0)
GO



declare @balances table(account_number nvarchar(50),balance decimal)

insert into @balances
select account_number, dbo.GetBalance(account_number,getdate()) from dbo.Accounts

insert into dbo.Booking 
select 
	    dbo.GetBalance(account_number,getdate())
	   , getdate() as [Date] 
	   , 0 as LoanEventId
	   , 0 as SavingEventId
	   , 0 as LoanId
	   , 0 as ClientId
	   , 1 as UserId
	   , 0 as BranchId
	   , N'Balanced Transaction' as [Description]
	   , 0 as IsDeleted
	   , 0 as IsExported
	   , case 
			when is_debit=1 then account_number else '0'	
	   end DebitAccount
	   	, case 
			when is_debit=1 then '0' else account_number	
	   end DebitAccount
	   , 0 as AdvanceId
	   , 0 as StaffId
	   , 0 as IsManualEditable
	   , null as Doc1
	   , null as Doc2
from dbo.Accounts

delete from dbo.Booking where [Description] !='Balanced Transaction'

select ac.account_number, dbo.GetBalance(ac.account_number,getdate()) from dbo.Accounts ac

----------------------------------------------------------







