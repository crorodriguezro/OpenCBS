	declare @query nvarchar(MAX)=
    
    N'DECLARE @_beginDate DATETIME
	DECLARE @_endDate DATETIME
	DECLARE @_disbursed_in INT
	DECLARE @_display_in INT
	DECLARE @_user_id INT
	DECLARE @_subordinate_id INT
	DECLARE @_branch_id INT
	
	SET @_beginDate = ''2016-06-29 00:00:00''
	SET @_endDate = ''2016-06-29 00:00:00''
	SET @_disbursed_in = 0
	SET @_display_in = 1
	SET @_user_id = 1
	SET @_subordinate_id = 0
	SET @_branch_id = 0

	SELECT 
		--  i.contract_id
		--, dbo.GetXR(p.currency_id, @_display_in, @_beginDate) AS exchange_rate
		 i.expected_date
		 ,substring(cl.name,0,CHARINDEX('' '',cl.name)) as client_first_name
		 ,substring(cl.name,CHARINDEX('' '',cl.name),LEN(cl.name)) as client_last_name
		 , COALESCE(t.personal_phone, t.home_phone, secondary_personal_phone, secondary_home_phone) AS phone_number
		 , d.name AS district_name
		 , t.city
		 , c.contract_code
	     , u.first_name + '' '' + u.last_name AS loan_officer_name
	     , ea.name AS activity_name
	     , cr.amount
		 , i.olb
		 , i.interest_repayment - i.paid_interest AS interest
	   	 , i.capital_repayment - i.paid_capital AS principal
		 , i.capital_repayment + i.interest_repayment - i.paid_capital - i.paid_interest total
	FROM dbo.Installments AS i
	LEFT JOIN dbo.Contracts AS c ON c.id = i.contract_id
	LEFT JOIN dbo.Credit AS cr ON cr.id = c.id
	LEFT JOIN dbo.Projects AS j ON j.id = c.project_id
	LEFT JOIN dbo.Tiers AS t ON t.id = j.tiers_id
	LEFT JOIN dbo.Clients AS cl ON cl.id = t.id
	LEFT JOIN dbo.Districts AS d ON d.id = t.district_id
	LEFT JOIN dbo.Users AS u ON u.id = cr.loanofficer_id
	LEFT JOIN dbo.Packages AS p ON p.id = cr.package_id
	LEFT JOIN dbo.EconomicActivities AS ea ON ea.id = c.activity_id
        LEFT JOIN dbo.Branches b ON b.id = t.branch_id
	WHERE expected_date BETWEEN @_beginDate AND @_endDate
	    AND (capital_repayment > paid_capital OR interest_repayment > paid_interest)
	    AND (c.status = 5 OR c.status = 10)
	    AND (t.branch_id = @_branch_id OR @_branch_id = 0)
	    AND (@_subordinate_id = 0 and cr.loanofficer_id in
		(		SELECT @_user_id
				UNION ALL
				SELECT subordinate_id
				FROM dbo.UsersSubordinates
				WHERE user_id = @_user_id OR 0=@_user_id) OR cr.loanofficer_id = @_subordinate_id
		)
	ORDER BY i.expected_date, u.first_name, u.last_name'




    
declare  @table1 table
(
    expected_date datetime,
    client_first_name nvarchar(MAX),
    client_last_name nvarchar(MAX),
    phone_number nvarchar(MAX),
    district_name nvarchar(MAX),
    city nvarchar(MAX),
    contract_code nvarchar(MAX),
    loan_officer_name nvarchar(MAX),
    activity_name nvarchar(MAX),
    amount decimal(18,2),
    olb decimal(18,2),
    interest decimal(18,2),
    principal decimal(18,2),
    total decimal(18,2)
)

declare  @table2 table
(
    expected_date datetime,
    client_first_name nvarchar(MAX),
    client_last_name nvarchar(MAX),
    phone_number nvarchar(MAX),
    district_name nvarchar(MAX),
    city nvarchar(MAX),
    contract_code nvarchar(MAX),
    loan_officer_name nvarchar(MAX),
    activity_name nvarchar(MAX),
    amount decimal(18,2),
    olb decimal(18,2),
    interest decimal(18,2),
    principal decimal(18,2),
    total decimal(18,2)
)

use DATABASE_NAME_Source

insert into @table1(expected_date,client_first_name,client_last_name,phone_number,district_name,city,contract_code,loan_officer_name,activity_name,
                    amount,olb,interest,principal,total)
exec sp_executesql @query 

use DATABASE_NAME_optimize3

insert into @table2(expected_date,client_first_name,client_last_name,phone_number,district_name,city,contract_code,loan_officer_name,activity_name,
                    amount,olb,interest,principal,total)
exec sp_executesql @query 


select * from @table1 t1
full outer join @table2 t2 on t1.expected_date = t2.expected_date 
                              and t1.client_first_name = t2.client_first_name 
                              and t1.client_last_name = t2.client_last_name 
                              and t1.phone_number = t2.phone_number 
                              and t1.district_name = t2.district_name
                              and t1.city = t2.city
                              and t1.contract_code = t2.contract_code
                              and t1.loan_officer_name = t2.loan_officer_name
                              and t1.activity_name = t2.activity_name
                              and t1.amount = t2.amount
                              and t1.olb = t2.olb
                              and t1.interest = t2.interest
                              and t1.principal = t2.principal
                              and t1.total = t2.total
where t1.client_first_name is null or t2.client_first_name is null
