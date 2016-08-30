declare @query nvarchar(MAX) =


N'declare @subordinate_id int = 0
declare @user_id int = 1
declare @date datetime = getdate()
declare @disbursed_in int = 0
declare @display_in int = 1
declare @branch_id int = 0

DECLARE @users TABLE
(
	id INT
)
IF EXISTS (SELECT * FROM dbo.IntListToTable(@subordinate_id) WHERE number = 0)
BEGIN
	INSERT INTO @users
	SELECT @user_id
	INSERT INTO @users
	SELECT subordinate_id
	FROM dbo.UsersSubordinates
	WHERE user_id = @user_id
END
ELSE
BEGIN
	INSERT INTO @users
	SELECT number
	FROM dbo.IntListToTable(@subordinate_id)
END

DECLARE @active_loans TABLE (
	id INT NOT NULL
	, olb MONEY NOT NULL
	, interest MONEY NOT NULL
	, late_days INT NOT NULL
	, rescheduled BIT NOT NULL
)

DECLARE @re_llp_rate FLOAT
SELECT @re_llp_rate = provisioning_value
FROM dbo.ProvisioningRules
WHERE number_of_days_min = -1 AND number_of_days_max = -1

INSERT INTO @active_loans
SELECT id, olb, interest, late_days, CASE WHEN re.contract_id IS NULL THEN 0 ELSE 1 END
FROM dbo.ActiveLoans_MC(@date, @disbursed_in, @display_in, @branch_id) al
LEFT JOIN (
	SELECT contract_id
	FROM dbo.ContractEvents
	WHERE event_type = ''ROLE'' AND convert(date, event_date) <= @date AND is_deleted = 0
	GROUP BY contract_id
) re ON re.contract_id = al.id

DECLARE @installments TABLE
(
    contract_id INT NOT NULL
    , last_expected_date DATETIME NOT NULL
)
INSERT INTO @installments
SELECT contract_id, MAX(expected_date)
FROM dbo.InstallmentSnapshot(@date)
GROUP BY contract_id

SELECT
c.contract_code
, c.start_date
, i.last_expected_date close_date
, case
	when cl.code != ''C'' then (select substring(cl.name,0,CHARINDEX('' '',cl.name)))
	when cl.code = ''C'' then (select cl.name)
end as client_first_name
, case
	when cl.code != ''C'' then (select substring(cl.name,CHARINDEX('' '',cl.name),LEN(cl.name)) as client_last_name)
	when cl.code = ''C'' then (select co.sigle)
end as client_last_name
, u.first_name + '' '' + u.last_name loan_officer_name
, b.code AS branch_name
, al.interest
, al.olb
, al.late_days
, CASE
	WHEN 1 = al.rescheduled AND pr.provisioning_value < @re_llp_rate THEN @re_llp_rate * 100
	ELSE pr.provisioning_value * 100
END llp_rate
, CASE
	WHEN 1 = al.rescheduled AND pr.provisioning_value < @re_llp_rate THEN CAST(ROUND(al.olb * @re_llp_rate, 0) AS MONEY)
	ELSE CAST(ROUND(al.olb * pr.provisioning_value, 0) AS MONEY)
END llp
, d.name district_name
, fl.name FundingLine
--, pack.name product_name
--, cur.name currency_name
--, pr.number_of_days_min range_from
--, pr.number_of_days_max range_to
--, CASE WHEN 1 = al.rescheduled THEN ''Rescheduled loans'' ELSE '''' END rescheduled
FROM @active_loans al
INNER JOIN dbo.Contracts c ON c.id = al.id
INNER JOIN dbo.Projects j ON j.id = c.project_id
INNER JOIN dbo.Credit cr ON cr.id = c.id
INNER JOIN dbo.Packages pack ON pack.id = cr.package_id
INNER JOIN dbo.Tiers t ON t.id = j.tiers_id
LEFT JOIN dbo.Branches b ON b.id = t.branch_id
INNER JOIN dbo.Districts d ON d.id = t.district_id
INNER JOIN dbo.Clients cl ON cl.id = t.id
INNER JOIN dbo.Users u ON u.id = cr.loanofficer_id
INNER JOIN dbo.Currencies cur ON cur.id = pack.currency_id
INNER JOIN dbo.FundingLines fl ON fl.id = pack.fundingLine_id
left join dbo.Corporates as co on co.id = cl.id
--INNER JOIN dbo.ProvisioningRules pr ON al.late_days BETWEEN pr.number_of_days_min AND pr.number_of_days_max
INNER JOIN (
	SELECT number_of_days_min, number_of_days_max, provisioning_value
	FROM dbo.ProvisioningRules
	GROUP BY number_of_days_min, number_of_days_max, provisioning_value
		    ) pr ON al.late_days BETWEEN pr.number_of_days_min AND pr.number_of_days_max
    INNER JOIN @installments i ON i.contract_id = c.id
--WHERE (cr.loanofficer_id IN (SELECT id FROM @users) or SELECT * FROM dbo.IntListToTable(@subordinate_id) where number!=0))
WHERE cr.loanofficer_id IN (SELECT id FROM @users)
ORDER BY al.rescheduled, al.late_days, cur.name'


declare  @table1 table
(
    contract_code nvarchar(MAX),
    start_date datetime,
    close_date datetime,
    client_first_name nvarchar(MAX),
    client_last_name nvarchar(MAX),
    loan_officer_name nvarchar(MAX),
    branch_name nvarchar(MAX),
    interest decimal(18,2),
    olb decimal(18,2),
    late_days int,
    llp_rate int,
    llp decimal(18,2),
    district_name nvarchar(MAX),
    FundingLine nvarchar(MAX)
)

declare  @table2 table
(
    contract_code nvarchar(MAX),
    start_date datetime,
    close_date datetime,
    client_first_name nvarchar(MAX),
    client_last_name nvarchar(MAX),
    loan_officer_name nvarchar(MAX),
    branch_name nvarchar(MAX),
    interest decimal(18,2),
    olb decimal(18,2),
    late_days int,
    llp_rate int,
    llp decimal(18,2),
    district_name nvarchar(MAX),
    FundingLine nvarchar(MAX)
)
use DATABASE_NAME_optimize3

insert into @table1(contract_code,start_date,close_date,client_first_name,client_last_name,loan_officer_name,branch_name,interest,
                    olb,late_days,llp_rate,llp,district_name,FundingLine)
exec sp_executesql @query 

use DATABASE_NAME_Source

insert into @table2(contract_code,start_date,close_date,client_first_name,client_last_name,loan_officer_name,branch_name,interest,
                    olb,late_days,llp_rate,llp,district_name,FundingLine)
exec sp_executesql @query 


select * from @table1 t1
full outer join @table2 t2 on t1.contract_code = t2.contract_code 
                              and t1.start_date = t2.start_date 
                              and t1.close_date = t2.close_date 
                              and t1.client_first_name = t2.client_first_name 
                              and t1.client_last_name = t2.client_last_name
                              and t1.loan_officer_name = t2.loan_officer_name
                              and t1.branch_name = t2.branch_name
                              and t1.interest = t2.interest
                              and t1.olb = t2.olb
                              and t1.late_days = t2.late_days
                              and t1.llp_rate = t2.llp_rate
                              and t1.llp = t2.llp
                              and t1.district_name = t2.district_name
                              and t1.FundingLine = t2.FundingLine
where t1.contract_code is null or t2.contract_code is null