declare @query nvarchar(MAX) =
N'
declare @roles nvarchar(MAX)=N''SUPER,CASHI,LOF,VISIT,ADMIN''
declare @from datetime=''2016-06-01 00:00:00''
declare @to datetime=''2016-06-30 00:00:00''
declare @disbursed_in int=0
declare @display_in int=1
declare @branch_id int=0
declare @subordinate_id int=0
declare @user_id int=1


SELECT Reps.event_date AS [date]
	, Cont.contract_code 
	,COALESCE(Gr.name, Corp.name, ISNULL(Pers.first_name, '''')) AS [client_first_name]
    ,ISNULL(Pers.last_name, '''') AS [client_last_name]
    , Us.first_name + SPACE(1) + Us.last_name AS [loan_officer_name]
	, Pack.name AS [loan_product_name]
	, Dts.name AS [district_name]
	, Br.code AS branch_name
	, Reps.commissions AS [early_fee]
	, Reps.penalties AS [late_fee]
	, Reps.principal
	, Reps.interest
	, (Reps.principal + Reps.interest + Reps.commissions + Reps.penalties) AS [total]
	--, Reps.written_off
FROM dbo.Repayments_MC(@from, @to, @disbursed_in, @display_in, @user_id, @subordinate_id, @branch_id) AS Reps
LEFT JOIN dbo.ContractEvents AS ConEv ON ConEv.id = Reps.event_id
LEFT JOIN dbo.Credit AS Cr ON Cr.id = Reps.contract_id
LEFT JOIN dbo.Contracts AS Cont ON Reps.contract_id = Cont.id
LEFT JOIN dbo.Projects AS Pr ON Cont.project_id = Pr.id
LEFT JOIN dbo.Groups AS Gr ON Gr.id = Pr.tiers_id
LEFT JOIN dbo.Persons AS Pers ON Pers.id = Pr.tiers_id
LEFT JOIN dbo.Corporates AS Corp ON Corp.id = Pr.tiers_id
LEFT JOIN dbo.Tiers AS Trs ON Pr.tiers_id = Trs.id
LEFT JOIN dbo.Branches Br ON Br.id = Trs.branch_id
LEFT JOIN dbo.Districts AS Dts ON Dts.id = Trs.district_id
LEFT JOIN dbo.Users AS Us ON Cr.loanofficer_id = Us.id
LEFT JOIN dbo.Packages AS Pack ON Cr.package_id = Pack.id
Where reps.written_off = 0
ORDER BY Reps.event_date  '



declare  @table1 table
(
    date datetime,
    contract_code nvarchar(MAX),
    client_first_name nvarchar(MAX),
    client_last_name nvarchar(MAX),
    loan_officer_name nvarchar(MAX),
    loan_product_name nvarchar(MAX),
    district_name nvarchar(MAX),
    branch_name nvarchar(MAX),
    early_fee decimal(18,2),
    late_fee decimal(18,2),
    principal decimal(18,2),
    interest decimal(18,2),
    total decimal(18,2)
)


declare  @table2 table
(
    date datetime,
    contract_code nvarchar(MAX),
    client_first_name nvarchar(MAX),
    client_last_name nvarchar(MAX),
    loan_officer_name nvarchar(MAX),
    loan_product_name nvarchar(MAX),
    district_name nvarchar(MAX),
    branch_name nvarchar(MAX),
    early_fee decimal(18,2),
    late_fee decimal(18,2),
    principal decimal(18,2),
    interest decimal(18,2),
    total decimal(18,2)
)
use DATABASE_NAME_Source

insert into @table1(date,contract_code,client_first_name,client_last_name,loan_officer_name,loan_product_name,district_name,branch_name,
                    early_fee,late_fee,principal,interest,total)
exec sp_executesql @query 

use DATABASE_NAME_optimize3

insert into @table2(date,contract_code,client_first_name,client_last_name,loan_officer_name,loan_product_name,district_name,branch_name,
                    early_fee,late_fee,principal,interest,total)
exec sp_executesql @query 


select * from @table1 t1
full outer join @table2 t2 on t1.date = t2.date 
                              and t1.contract_code = t2.contract_code 
                              and t1.client_first_name = t2.client_first_name 
                              and t1.client_last_name = t2.client_last_name 
                              and t1.loan_officer_name = t2.loan_officer_name
                              and t1.loan_product_name = t2.loan_product_name
                              and t1.district_name = t2.district_name
                              and t1.branch_name = t2.branch_name
                              and t1.early_fee = t2.early_fee
                              and t1.principal = t2.principal
                              and t1.interest = t2.interest
                              and t1.total = t2.total
where t1.contract_code is null or t2.contract_code is null


	