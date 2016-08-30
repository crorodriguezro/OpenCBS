
Declare @query nvarchar(MAX) =
 N'DECLARE @date DATETIME
DECLARE @disbursed_in INT
DECLARE @display_in INT
DECLARE @branch_id INT
DECLARE @subordinate_id INT
DECLARE @user_id INT

SET @date = getdate()
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
	, amount MONEY NOT NULL
	, client_type_code CHAR(1) NOT NULL
	, package_id INT NOT NULL
	, activity_id INT NOT NULL
	, district_id INT NOT NULL
	, interest_rate FLOAT NOT NULL
	, installment_type_id INT NOT NULL
	, loan_officer_id INT NOT NULL
	, branch_id INT NOT NULL
	, row INT NOT NULL
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
, ac.amount
, t.client_type_code
, cr.package_id
, c.activity_id
, t.district_id
, cr.interest_rate
, pack.installment_type
, cr.loanofficer_id
, t.branch_id
, ROW_NUMBER() OVER (PARTITION BY ac.contract_id ORDER BY ac.contract_id) row
FROM dbo.ActiveClients_MC(@date, @disbursed_in, @display_in, @branch_id) ac
INNER JOIN dbo.Contracts c on c.id = ac.contract_id
INNER JOIN dbo.Credit cr on cr.id = c.id
INNER JOIN dbo.Projects j on j.id = c.project_id
INNER JOIN dbo.Tiers t on t.id = j.tiers_id
LEFT JOIN dbo.Packages pack ON pack.id = cr.package_id
WHERE 0 = @subordinate_id AND cr.loanofficer_id IN (
					SELECT @user_id
					UNION ALL
					SELECT subordinate_id
					FROM dbo.UsersSubordinates
					WHERE user_id = @user_id
				)
				OR cr.loanofficer_id = @subordinate_id

SELECT pack.name break_down
, COUNT(DISTINCT ac.contract_id) contracts
, SUM(CASE WHEN ''I'' = ac.client_type_code THEN 1 ELSE 0 END) individual
, SUM(CASE WHEN ''G'' = ac.client_type_code AND 1 = ac.row THEN 1 ELSE 0 END) [group]
, SUM(CASE WHEN ''C'' = ac.client_type_code THEN 1 ELSE 0 END) corporate
, COUNT(DISTINCT ac.id) clients
, COUNT(DISTINCT CASE WHEN ac.client_type_code = ''G'' THEN ac.id ELSE null END) in_groups
, SUM(olb) olb    
FROM @active_clients ac
INNER JOIN dbo.Packages pack on pack.id = ac.package_id
GROUP BY ac.package_id, pack.name
ORDER BY pack.name'

declare  @table1 table
(
    break_down nvarchar(MAX),
    contracts int,
    individual int,
    [group] int,
    corporate int,
    clients int,
    in_groups int,
    olb decimal(18,2) 
)

declare @table2 table
(
    break_down nvarchar(MAX),
    contracts int,
    individual int,
    [group] int,
    corporate int,
    clients int,
    in_groups int,
    olb decimal(18,2) 
)

use DATABASE_NAME_Source

insert into @table1(break_down,contracts,individual,[group],corporate,clients,in_groups,olb)
exec sp_executesql @query 

use DATABASE_NAME_optimize3

insert into @table2(break_down,contracts,individual,[group],corporate,clients,in_groups,olb)
exec sp_executesql @query 


select * from @table1 t1
full outer join @table2 t2 on t1.break_down = t2.break_down 
                              and t1.clients = t2.clients 
                              and t1.contracts = t2.contracts 
                              and t1.corporate = t2.corporate 
                              and t1.[group] = t2.[group]
                              and t1.in_groups = t2.in_groups
                              and t1.individual = t2.individual
                              and t1.olb = t2.olb
where t1.break_down is null or t2.break_down is null
