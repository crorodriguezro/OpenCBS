declare @query nvarchar(MAX)=

N'DECLARE @beginDate     DATETIME = CAST(DATEADD(M, -1, GETDATE()) AS DATE),
	    @endDate       DATETIME = CAST(GETDATE() AS DATE),
	    @disbursed_in  INT = 0,
	    @display_in    INT = 1,
	    @branch_id     INT = 1
	
SELECT cc.close_date
	    ,co.contract_code
	    ,substring(cc.client_name,0,CHARINDEX('' '',cc.client_name)) as client_first_name
        ,substring(cc.client_name,CHARINDEX('' '',cc.client_name),LEN(cc.client_name)) as client_last_name
        ,pa.name
	    ,cc.loan_officer
	    ,ce.event_date AS disb_date
	    ,cc.amount * dbo.GetXR(cc.currency_id, @display_in, cc.close_date) AS amount
	    ,cc.currency
FROM   ClosedContracts(@beginDate, @endDate, @branch_id) cc
	    INNER JOIN Contracts co
	        ON  co.id = cc.contract_id
	    INNER JOIN Credit cr
	        ON  cr.id = cc.contract_id
	    INNER JOIN Packages pa
	        ON  pa.id = cr.package_id
	    INNER JOIN ContractEvents ce
	        ON  co.id = ce.contract_id
	        AND ce.event_type = ''LODE''
	        AND ce.is_deleted = 0
WHERE  (cc.currency_id = @disbursed_in OR 0 = @disbursed_in)
ORDER BY
	    close_date,
	    loan_officer'


declare  @table1 table
(
    close_date datetime,
    contract_code nvarchar(MAX),
    client_first_name nvarchar(MAX),
    client_last_name nvarchar(MAX),
    name nvarchar(MAX),
    loan_officer int,
    disb_date datetime,
    amount decimal(18,2),
    currency nvarchar(MAX)
)

declare  @table2 table
(
    close_date datetime,
    contract_code nvarchar(MAX),
    client_first_name nvarchar(MAX),
    client_last_name nvarchar(MAX),
    name nvarchar(MAX),
    loan_officer int,
    disb_date datetime,
    amount decimal(18,2),
    currency nvarchar(MAX)
)

use DATABASE_NAME_Source

insert into @table1(close_date,contract_code,client_first_name,client_last_name,name,loan_officer,disb_date,amount,currency)
exec sp_executesql @query 

use DATABASE_NAME_optimize3

insert into @table2(close_date,contract_code,client_first_name,client_last_name,name,loan_officer,disb_date,amount,currency)
exec sp_executesql @query 


select * from @table1 t1
full outer join @table2 t2 on t1.close_date = t2.close_date 
                              and t1.contract_code = t2.contract_code 
                              and t1.client_first_name = t2.client_first_name 
                              and t1.client_last_name = t2.client_last_name 
                              and t1.name = t2.name
                              and t1.loan_officer = t2.loan_officer
                              and t1.disb_date = t2.disb_date
                              and t1.amount = t2.amount
                              and t1.currency = t2.currency
where t1.close_date is null or t2.close_date is null
