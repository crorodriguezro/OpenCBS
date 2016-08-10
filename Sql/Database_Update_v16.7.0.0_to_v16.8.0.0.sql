update
    dbo.TechnicalParameters
set
    value = 'v16.8.0.0'
where
    name = 'VERSION'
GO

IF NOT EXISTS ( SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[SavingEvents]') AND name = 'parent_event_id' )
BEGIN
    ALTER TABLE dbo.SavingEvents ADD [parent_event_id] int null
END
GO

INSERT INTO dbo.EventTypes (event_type, description, sort_order, accounting) VALUES ('SFCE', 'Saving Fee Contract Event', 750, 1)
INSERT INTO dbo.EventTypes (event_type, description, sort_order, accounting) VALUES ('STCE', 'Saving Tax Contract Event', 760, 1)