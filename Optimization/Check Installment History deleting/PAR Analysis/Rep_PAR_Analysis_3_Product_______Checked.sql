 
declare @query nvarchar(MAX) =


N'DECLARE @disbursed_in INT
DECLARE @display_in INT
DECLARE @branch_id INT
DECLARE @subordinate_id INT
DECLARE @user_id INT
DECLARE @date datetime

SET @date = GETDATE()
SET @disbursed_in = 0
SET @display_in = 1
SET @branch_id = 0
SET @user_id = 1
SET @subordinate_id = 0 
 
DECLARE @active_clients TABLE
(
	id INT NOT NULL
	, contract_id INT NOT NULL
	, olb MONEY NOT NULL
	, late_days INT NOT NULL
	, district_id INT NOT NULL
	, loan_officer_id INT NOT NULL
	, product_id INT NOT NULL
	, client_type_code CHAR(1) NOT NULL
	, activity_id INT NOT NULL
	, branch_id INT NOT NULL
	, num INT NOT NULL
			
)

DECLARE @active_loans TABLE
(
	id INT NOT NULL
	, olb MONEY NOT NULL
	, late_days INT NOT NULL
	, district_id INT NOT NULL
)

DECLARE @users TABLE
(
	id INT NOT NULL
)
		
INSERT INTO @users
SELECT @user_id
INSERT INTO @users
SELECT subordinate_id
FROM dbo.UsersSubordinates
WHERE user_id = @user_id
		
	INSERT INTO @active_clients
SELECT ac.id
	, ac.contract_id
	, ac.olb
	, ac.late_days
	, t.district_id
	, cr.loanofficer_id
	, cr.package_id
	, t2.client_type_code
	, ISNULL(p.activity_id, cp.activity_id) activity_id
	, t.branch_id
	, ROW_NUMBER() OVER (PARTITION BY ac.contract_id ORDER BY ac.contract_id) row
FROM dbo.ActiveClients_MC(@date, @disbursed_in, @display_in, @branch_id) ac
INNER JOIN dbo.Contracts c ON c.id = ac.contract_id
INNER JOIN dbo.Credit cr ON cr.id = c.id
INNER JOIN dbo.Projects j ON j.id = c.project_id
LEFT JOIN dbo.Tiers t2 ON t2.id = j.tiers_id
LEFT JOIN dbo.Tiers t ON t.id = ac.id
LEFT JOIN dbo.persons p ON p.id = t.id
LEFT JOIN dbo.Corporates cp ON cp.id = t.id
WHERE (0 = @branch_id OR t.branch_id = @branch_id)
	AND (0 = @subordinate_id AND cr.loanofficer_id IN (SELECT id FROM @users) OR cr.loanofficer_id = @subordinate_id)

INSERT INTO @active_loans
SELECT ac.contract_id, SUM(ac.olb), ac.late_days, t.district_id
FROM @active_clients ac
INNER JOIN dbo.Contracts c ON c.id = ac.contract_id
INNER JOIN dbo.Projects j ON j.id = c.project_id
LEFT JOIN dbo.Tiers t ON t.id = j.tiers_id
GROUP BY ac.contract_id, ac.late_days, t.district_id
 
 
DECLARE @common TABLE 
(
id INT ,
    break_down NVARCHAR(150)
	,  olb MONEY
	,  par MONEY
	,  clients INT 
	, all_clients INT
	, contracts INT
	, all_contracts INT
	,  par_30 MONEY
	, clients_30 INT 
	,  contracts_30 INT 
	,  par_1_30 MONEY
	,  clients_1_30 INT 
	,  contracts_1_30 INT 
	,  par_31_60 MONEY
	,  clients_31_60 INT
	,  contracts_31_60 INT
	,  par_61_90 MONEY
	,  clients_61_90 INT
	,  contracts_61_90 INT
	,  par_91_180 MONEY
	,  clients_91_180 INT
	,  contracts_91_180 INT
	,  par_181_365 MONEY
	,  clients_181_365 INT
	,  contracts_181_365 INT
	,  par_365 MONEY
	,  clients_365 INT
	, contracts_365 INT
)
		 
		 
	INSERT INTO @common
		    
SELECT  
pack.id 
	, pack.name break_down
	, SUM(olb) olb
	, SUM(CASE WHEN late_days > 0 THEN olb ELSE 0 END) par
	, SUM(CASE WHEN late_days > 0 THEN 1 ELSE 0 END) clients
	, COUNT(DISTINCT ac.id) all_clients
	, SUM(CASE WHEN late_days > 0 AND 1 = num THEN 1 ELSE 0 END) contracts
	, SUM(CASE WHEN 1 = num THEN 1 ELSE 0 END) all_contracts
	, SUM(CASE WHEN late_days > 30 THEN olb ELSE 0 END) par_30
	, SUM(CASE WHEN late_days > 30 THEN 1 ELSE 0 END) clients_30
	, SUM(CASE WHEN late_days > 30 AND 1 = num THEN 1 ELSE 0 END) contracts_30
	, SUM(CASE WHEN late_days BETWEEN 1 AND 30 THEN olb ELSE 0 END) par_1_30
	, SUM(CASE WHEN late_days BETWEEN 1 AND 30 THEN 1 ELSE 0 END) clients_1_30
	, SUM(CASE WHEN late_days BETWEEN 1 AND 30 AND 1 = num THEN 1 ELSE 0 END) contracts_1_30
	, SUM(CASE WHEN late_days BETWEEN 31 AND 60 THEN olb ELSE 0 END) par_31_60
	, SUM(CASE WHEN late_days BETWEEN 31 AND 60 THEN 1 ELSE 0 END) clients_31_60
	, SUM(CASE WHEN late_days BETWEEN 31 AND 60 AND 1 = num THEN 1 ELSE 0 END) contracts_31_60
	, SUM(CASE WHEN late_days BETWEEN 61 AND 90 THEN olb ELSE 0 END) par_61_90
	, SUM(CASE WHEN late_days BETWEEN 61 AND 90 THEN 1 ELSE 0 END) clients_61_90
	, SUM(CASE WHEN late_days BETWEEN 61 AND 90 AND 1 = num THEN 1 ELSE 0 END) contracts_61_90
	, SUM(CASE WHEN late_days BETWEEN 91 AND 180 THEN olb ELSE 0 END) par_91_180
	, SUM(CASE WHEN late_days BETWEEN 91 AND 180 THEN 1 ELSE 0 END) clients_91_180
	, SUM(CASE WHEN late_days BETWEEN 91 AND 180 AND 1 = num THEN 1 ELSE 0 END) contracts_91_180
	, SUM(CASE WHEN late_days BETWEEN 181 AND 365 THEN olb ELSE 0 END) par_181_365
	, SUM(CASE WHEN late_days BETWEEN 181 AND 365 THEN 1 ELSE 0 END) clients_181_365
	, SUM(CASE WHEN late_days BETWEEN 181 AND 365 AND 1 = num THEN 1 ELSE 0 END) contracts_181_365
	, SUM(CASE WHEN late_days > 365 THEN olb ELSE 0 END) par_365
	, SUM(CASE WHEN late_days > 365 THEN 1 ELSE 0 END) clients_365
	, SUM(CASE WHEN late_days > 365 AND 1 = num THEN 1 ELSE 0 END) contracts_365
FROM @active_clients ac
LEFT JOIN dbo.Packages pack ON pack.id = ac.product_id
GROUP BY pack.id, pack.name
		
		
		
		
SELECT 
break_down,
par,
par_30,
olb,
CASE WHEN break_down <> ''_clients'' AND break_down <> ''_contracts'' THEN   par/olb 
ELSE ''''
END AS ''par/olb''  ,
CASE WHEN break_down <> ''_clients'' AND break_down <> ''_contracts'' THEN   par_30/olb 
ELSE ''''
END AS ''par_30/olb''  ,
par_1_30,
par_31_60,
par_61_90,
par_91_180,
par_181_365,
par_365
FROM 
(				
SELECT  
	break_down,
	olb,
	par,
	par_30,
	par_1_30,
	par_31_60,
	par_61_90,
	par_91_180,
	par_181_365,
	par_365,
	id 
FROM 
@common 
	  
UNION ALL
	  
SELECT 
	  
''_clients'',
CAST(all_clients AS MONEY), 
CAST(clients AS MONEY),
CAST(clients_30 AS MONEY),
CAST(clients_1_30 AS MONEY),
CAST(clients_31_60 AS MONEY),
CAST(clients_61_90  AS MONEY),
CAST(clients_91_180  AS MONEY),
CAST(clients_181_365 AS MONEY),
CAST(clients_365 AS MONEY), 
id 
FROM @common
	   
UNION ALL 
	   
SELECT 
	  
''_contracts'',
CAST(all_contracts AS MONEY), 
CAST(contracts AS MONEY),
CAST(contracts_30 AS MONEY),
CAST(contracts_1_30 AS MONEY),
CAST(contracts_31_60 AS MONEY),
CAST(contracts_61_90  AS MONEY),
CAST(contracts_91_180  AS MONEY),
CAST(contracts_181_365 AS MONEY),
CAST(contracts_365 AS MONEY)
, id  
FROM @common
	   
UNION All
	   
	   
SELECT  
	''Total'',
	SUM(olb),
	SUM(par),
	SUM(par_30),
	SUM(par_1_30),
	SUM(par_31_60),
	SUM(par_61_90),
	SUM(par_91_180),
	SUM(par_181_365),
	SUM(par_365),
	    SUM(id) +1
FROM 
@common 
	  
UNION ALL
	  
SELECT 
	  
''_clients'',
SUM(CAST(all_clients AS MONEY)), 
SUM(CAST(clients AS MONEY)),
SUM(CAST(clients_30 AS MONEY)),
SUM(CAST(clients_1_30 AS MONEY)),
SUM(CAST(clients_31_60 AS MONEY)),
SUM(CAST(clients_61_90  AS MONEY)),
SUM(CAST(clients_91_180  AS MONEY)),
SUM(CAST(clients_181_365 AS MONEY)),
SUM(CAST(clients_365 AS MONEY)), 
	SUM(id) +1
FROM @common
	   
UNION ALL 
	   
SELECT 
	  
''_contracts'',
SUM(CAST(all_contracts AS MONEY)), 
SUM(CAST(contracts AS MONEY)),
SUM(CAST(contracts_30 AS MONEY)),
SUM(CAST(contracts_1_30 AS MONEY)),
SUM(CAST(contracts_31_60 AS MONEY)),
SUM(CAST(contracts_61_90  AS MONEY)),
SUM(CAST(contracts_91_180  AS MONEY)),
SUM(CAST(contracts_181_365 AS MONEY)),
SUM(CAST(contracts_365 AS MONEY))
, SUM(id) +1
FROM @common
		
) AS temp     ORDER BY  id,  break_down  DESC '



declare  @table1 table
(
    break_down nvarchar(MAX),
    par decimal(18,2),
    par_30 decimal(18,2),
    olb decimal(18,2),
    par_olb decimal(18,2),
    par_30_olb decimal(18,2),
    par_1_30 decimal(18,2),
    par_31_60 decimal(18,2),
    par_61_90 decimal(18,2),
    par_91_180 decimal(18,2),
    par_181_365 decimal(18,2),
    par_365 decimal(18,2)
)

declare  @table2 table
(
    break_down nvarchar(MAX),
    par decimal(18,2),
    par_30 decimal(18,2),
    olb decimal(18,2),
    par_olb decimal(18,2),
    par_30_olb decimal(18,2),
    par_1_30 decimal(18,2),
    par_31_60 decimal(18,2),
    par_61_90 decimal(18,2),
    par_91_180 decimal(18,2),
    par_181_365 decimal(18,2),
    par_365 decimal(18,2)
)


use DATABASE_NAME_Source

insert into @table1(break_down,par,par_30,olb,par_olb,par_30_olb,par_1_30,par_31_60,par_61_90,
                    par_91_180,par_181_365,par_365)
exec sp_executesql @query 

use DATABASE_NAME_optimize3

insert into @table2(break_down,par,par_30,olb,par_olb,par_30_olb,par_1_30,par_31_60,par_61_90,
                    par_91_180,par_181_365,par_365)
exec sp_executesql @query 


select * from @table1 t1
full outer join @table2 t2 on t1.break_down = t2.break_down 
                              and t1.par = t2.par 
                              and t1.par_30 = t2.par_30 
                              and t1.olb = t2.olb 
                              and t1.par_olb = t2.par_olb
                              and t1.par_30_olb = t2.par_30_olb
                              and t1.par_31_60 = t2.par_31_60
                              and t1.par_61_90 = t2.par_61_90
                              and t1.par_91_180 = t2.par_91_180
                              and t1.par_181_365 = t2.par_181_365
                              and t1.par_365 = t2.par_365
where t1.break_down is null or t2.break_down is null