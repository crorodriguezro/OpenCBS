CREATE NONCLUSTERED INDEX [IX_Contract_id_Event_id] ON [dbo].[InstallmentHistory] 
(
	[contract_id] ASC,
	[event_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v13.10.0.0'
WHERE   [name] = 'VERSION'
GO
