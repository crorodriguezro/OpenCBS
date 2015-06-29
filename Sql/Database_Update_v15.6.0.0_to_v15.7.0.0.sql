if not exists(select * from sys.columns 
            where Name = N'default_start_view' and Object_ID = Object_ID(N'Roles'))
begin
    alter table dbo.Roles
	add default_start_view varchar(20) not null default('START_PAGE')
	
	alter table dbo.Tiers add created_at date, created_by int
end
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v15.7.0.0'
WHERE   [name] = 'VERSION'
GO
