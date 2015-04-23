if exists(select * from sys.columns 
            where Name = N'type_id' and Object_ID = Object_ID(N'city'))
begin
    alter table city 
	add default '1' for type_id
end
GO

insert into MenuItems (component_name, type)
values ('_viewItem', 0)
, ('_startPageItem', 0)
, ('_alertsItem' , 0)
, ('_dashboardItem', 0)
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v15.5.0.0'
WHERE   [name] = 'VERSION'
GO