update
    dbo.TechnicalParameters
set
    value = 'v16.8.0.0'
where
    name = 'VERSION'
GO

IF NOT EXISTS ( SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[EventTypes]') AND name = 'parent_event_id' )
BEGIN
    ALTER TABLE dbo.EventTypes ADD [parent_event_id] int
END
GO