if not exists (select name from sysindexes where name = 'IX_ContractEvents_event_date')
	create nonclustered index [IX_ContractEvents_event_date] on [dbo].[ContractEvents] ([event_date] ASC)
GO

update
    dbo.TechnicalParameters
set
    value = 'v16.5.0.0'
where
    name = 'VERSION'
GO
