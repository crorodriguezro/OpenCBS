alter table dbo.Credit
add schedule_type int, script_name nvarchar(255) null
GO

update
	t1
set
	t1.schedule_type = t2.interest_scheme,
	t1.script_name = t2.script_name
from
	dbo.Credit t1
left join
	dbo.Packages t2 on t2.id = t1.package_id
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v15.3.0.0'
WHERE   [name] = 'VERSION'
GO