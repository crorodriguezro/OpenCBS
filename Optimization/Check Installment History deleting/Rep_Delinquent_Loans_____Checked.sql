declare @query nvarchar(MAX) =

'declare @roles nvarchar(MAX) = N''SUPER,CASHI,LOF,VISIT,ADMIN''
declare @date datetime = ''2016-06-29 00:00:00''
declare @disbursed_in int = 0
declare @branch_id int = 0
declare @subordinate_id int = 0
declare @user_id int =0    
declare @display_in int =1 


    
    if (object_id(''tempdb..#RepaymentEvents'') is null)
    begin
        create table #RepaymentEvents
        (
            contract_id int
		    , num INT
		    , installment_number INT
		    , interest MONEY
		    , principal MONEY
		    , penalty MONEY
		    , event_date DATETIME
		    , total MONEY
		    , rt_interest MONEY
		    , rt_principal MONEY
		    , rt_total MONEY
        )
        CREATE INDEX IX_Contract_id ON #RepaymentEvents (contract_id) -- speed things up
    end

    truncate table #RepaymentEvents
    INSERT INTO #RepaymentEvents
    SELECT re1.contract_id, re1.num, re1.installment_number, re1.interests, re1.principal, re1.penalties, re1.event_date, re1.total 
    , SUM(re2.interests) AS rt_interest
    , SUM(re2.principal) AS rt_principal
    , SUM(re2.total) AS rt_total
    FROM
    (
	    SELECT ce.contract_id, re.interests, re.principal, re.penalties, ce.event_date
	    , ROW_NUMBER() OVER (partition by contract_id ORDER BY event_date, re.id) AS num
	    , re.interests + re.principal AS total
	    , re.installment_number
	    FROM dbo.RepaymentEvents AS re
	    LEFT JOIN dbo.ContractEvents AS ce ON re.id = ce.id
	    WHERE is_deleted = 0 AND event_date <= @date
    ) AS re1
    LEFT JOIN
    (
	    SELECT ce.contract_id, re.interests, re.principal, re.penalties, ce.event_date
	    , ROW_NUMBER() OVER (partition by contract_id ORDER BY event_date, re.id) AS num
	    , re.interests + re.principal AS total
	    FROM dbo.RepaymentEvents AS re
	    LEFT JOIN dbo.ContractEvents AS ce ON re.id = ce.id
	    WHERE is_deleted = 0 AND event_date <= @date
    ) AS re2 ON re1.contract_id = re2.contract_id and  re2.num <= re1.num
    GROUP BY re1.contract_id, re1.num, re1.installment_number, re1.event_date, re1.principal,re1.penalties, re1.interests, re1.total

	-- Create temporary table for storing installment data
	IF OBJECT_ID(''tempdb..#installments'') IS NULL
	BEGIN
		CREATE TABLE #installments
		(
			contract_id INT
			, number INT
			, expected_date DATETIME
			, principal MONEY
			, interest MONEY
			, paid_principal MONEY
			, paid_interest MONEY
			, paid_date DATETIME
		)
		CREATE INDEX IX_Contract_id ON #installments (contract_id) -- speed things up
	END
	TRUNCATE TABLE #installments
	INSERT INTO #installments 
	SELECT contract_id, number, expected_date, principal, interest, paid_principal, paid_interest, paid_date 
	FROM dbo.InstallmentSnapshot(@date)

	-- Create temporary table for storing penalties
	IF OBJECT_ID(''tempdb..#penalties'') IS NULL
	BEGIN
		CREATE TABLE #penalties
		(
			contract_id INT
			, penalty MONEY
		)
	END
	TRUNCATE TABLE #penalties

	DECLARE @active_loans TABLE
	(
		id INT NOT NULL
		, late_days INT NOT NULL
		, olb MONEY NOT NULL
	)
	INSERT INTO @active_loans
	SELECT id, late_days, olb
	FROM dbo.ActiveLoans(@date, @branch_id)

	-- Calculate penalties
	DECLARE @contract_id INT
	DECLARE cur CURSOR FOR 
	SELECT al.id FROM @active_loans al
	--SELECT al.id FROM dbo.ActiveLoans(@date, @branch_id) AS al

	LEFT JOIN dbo.Credit AS cr ON cr.id = al.id
	LEFT JOIN dbo.Packages AS pkg ON pkg.id = cr.package_id
	WHERE pkg.currency_id = @disbursed_in OR 0 = @disbursed_in
	OPEN cur
	FETCH NEXT FROM	cur
	INTO @contract_id
	WHILE 0 = @@FETCH_STATUS
	BEGIN
		EXEC dbo.CalculateLatePenalty @contract_id, @date
		FETCH NEXT FROM cur
		INTO @contract_id
	END
	CLOSE cur
	DEALLOCATE cur

	-- Fetch data
	SELECT 
	    [temp].[contract_code],
	    [temp].[client_first_name],  
	    [temp].[client_last_name],  
	    [temp].[district_name], 
	    [temp].[loan_officer_name],
	    [temp].[start_date],  
	    [temp].[end_date], 
	    [temp].[amount], 
	    [temp].[paid_principal], 
	    [temp].[olb],	     
	    CASE WHEN paid_principal > due_principal THEN 0 ELSE due_principal - paid_principal END AS late_principal
	    ,CASE WHEN paid_interest > due_interest THEN 0 ELSE due_interest - paid_interest END AS late_interest
	    ,[temp].[penalty]
	    ,[temp].[late_days]
	    
	    
	FROM
	(
		SELECT 
		--al.id
		 c.contract_code
		 , u.first_name + '' '' + u.last_name AS loan_officer_name
		,ISNULL(corp.name,ISNULL(g.name, prsn.first_name)) as client_first_name
        , ISNULL(corp.name,ISNULL(g.name,prsn.last_name)) AS client_last_name
		, d.name AS district_name
		--, pkg.code AS product_code
        --, pkg.name AS product_name		
		, dbo.GetDisbursementDate(al.id) AS [start_date]
        , (SELECT MAX(expected_date) FROM #installments WHERE contract_id = c.id) end_date
        , CAST(cr.amount * dbo.GetXR(pkg.currency_id, @display_in, @date) AS MONEY) AS amount
        , CAST(ISNULL(i.paid_principal, 0) * dbo.GetXR(pkg.currency_id, @display_in, @date) AS MONEY) AS paid_principal
        , CAST(al.olb * dbo.GetXR(pkg.currency_id, @display_in, @date) AS MONEY) AS olb
        
        
        , CAST(p.penalty * dbo.GetXR(pkg.currency_id, @display_in, @date) AS MONEY) AS penalty
		, al.late_days
		, CAST(ISNULL(i.paid_interest, 0) * dbo.GetXR(pkg.currency_id, @display_in, @date) AS MONEY) AS paid_interest
		, CAST(ISNULL(i.due_principal, 0) * dbo.GetXR(pkg.currency_id, @display_in, @date) AS MONEY) AS due_principal
		, CAST(ISNULL(i.due_interest, 0) * dbo.GetXR(pkg.currency_id, @display_in, @date) AS MONEY) AS due_interest
		FROM @active_loans al
		LEFT JOIN #penalties AS p ON al.id = p.contract_id
		LEFT JOIN dbo.Contracts AS c ON c.id = al.id
		LEFT JOIN dbo.Credit AS cr ON cr.id = c.id
		LEFT JOIN dbo.Projects AS j ON j.id = c.project_id
		LEFT JOIN dbo.Tiers AS t ON t.id = j.tiers_id
		LEFT JOIN dbo.Persons AS prsn ON prsn.id = t.id
		LEFT JOIN dbo.Corporates AS corp ON corp.id = t.id
		LEFT JOIN dbo.Groups AS g ON g.id = t.id
		LEFT JOIN dbo.Districts AS d ON d.id = t.district_id
		LEFT JOIN dbo.Packages AS pkg ON pkg.id = cr.package_id
		LEFT JOIN dbo.Users AS u ON u.id = cr.loanofficer_id
		LEFT JOIN
		(
			SELECT i.contract_id
                , SUM(CASE WHEN i.expected_date = @date THEN 0 ELSE  i.principal END) AS due_principal
                , SUM(CASE WHEN i.expected_date = @date THEN 0 ELSE  i.interest END) AS due_interest
				, SUM(i.paid_principal) paid_principal
				, SUM(i.paid_interest) paid_interest
			FROM #installments AS i
			WHERE i.expected_date <= @date
			GROUP BY i.contract_id
		) AS i ON i.contract_id = al.id
		WHERE p.penalty >= 0 AND al.late_days > 0 	  
		AND ((0 = @branch_id AND t.branch_id IN (SELECT branch_id FROM dbo.UsersBranches WHERE user_id = @user_id))
		OR t.branch_id = @branch_id)
		AND (@subordinate_id = 0 and cr.loanofficer_id in
		(	SELECT @user_id
			UNION ALL
			SELECT subordinate_id
			FROM dbo.UsersSubordinates
			WHERE user_id = @user_id) OR cr.loanofficer_id = @subordinate_id)
		  AND (pkg.currency_id = @disbursed_in OR 0 = @disbursed_in)
		  AND NOT(paid_principal >= due_principal AND paid_interest >= due_interest)
	) AS temp
	ORDER BY loan_officer_name DESC'




declare  @table1 table
(
    contract_code nvarchar(MAX),
    client_first_name nvarchar(MAX),
    client_last_name nvarchar(MAX),
    district_name nvarchar(MAX),
    loan_officer_name nvarchar(MAX),
    start_date datetime,
    end_date datetime,
    amount decimal(18,2),
    paid_principal decimal(18,2),
    olb decimal(18,2),
    late_principal decimal(18,2),
    late_interest decimal(18,2),
    penalty decimal(18,2),
    late_days int
)

declare  @table2 table
(
    contract_code nvarchar(MAX),
    client_first_name nvarchar(MAX),
    client_last_name nvarchar(MAX),
    district_name nvarchar(MAX),
    loan_officer_name nvarchar(MAX),
    start_date datetime,
    end_date datetime,
    amount decimal(18,2),
    paid_principal decimal(18,2),
    late_interest decimal(18,2),
    olb decimal(18,2),
    late_principal decimal(18,2),
    penalty decimal(18,2),
    late_days int
)

use DATABASE_NAME_Source

insert into @table1(contract_code,client_first_name,client_last_name,district_name,loan_officer_name,start_date,end_date,amount,
                    paid_principal,olb,late_principal,late_interest,penalty,late_days)
exec sp_executesql @query 

use DATABASE_NAME_optimize3

insert into @table2(contract_code,client_first_name,client_last_name,district_name,loan_officer_name,start_date,end_date,amount,
                    paid_principal,olb,late_principal,late_interest,penalty,late_days)
exec sp_executesql @query 


select * from @table1 t1
full outer join @table2 t2 on t1.contract_code = t2.contract_code 
                              and t1.client_first_name = t2.client_first_name 
                              and t1.client_last_name = t2.client_last_name 
                              and t1.district_name = t2.district_name 
                              and t1.loan_officer_name = t2.loan_officer_name
                              and t1.start_date = t2.start_date
                              and t1.end_date = t2.end_date
                              and t1.amount = t2.amount
                              and t1.paid_principal = t2.paid_principal
                              and t1.olb = t2.olb
                              and t1.late_principal = t2.late_principal
                              and t1.late_interest = t2.late_interest
                              and t1.penalty = t2.penalty
                              and t1.late_days = t2.late_days
where t1.contract_code is null or t2.contract_code is null
