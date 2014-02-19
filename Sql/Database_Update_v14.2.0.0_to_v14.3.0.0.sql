CREATE NONCLUSTERED INDEX [IX_ContractEvents_type_contract_id] ON [dbo].[ContractEvents] 
(
	[event_type] ASC,
	[contract_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

UPDATE ce SET ce.event_type = 'RGLE'
FROM ContractEvents ce
INNER JOIN RepaymentEvents re ON re.id = ce.id
WHERE ce.event_type = 'RRLE'
    AND re.past_due_days = 0
GO
    
UPDATE ce SET ce.event_type = 'RBLE'
FROM ContractEvents ce
INNER JOIN RepaymentEvents re ON re.id = ce.id
WHERE ce.event_type = 'RRLE'
    AND re.past_due_days <> 0
GO

DELETE lam FROM LoanAccountingMovements lam
INNER JOIN AccountingRules ar ON ar.id = lam.rule_id
WHERE ar.event_attribute_id IN
    (SELECT id FROM EventAttributes WHERE event_type = 'RRLE')
GO
    
DELETE car FROM ContractAccountingRules car
INNER JOIN AccountingRules ar ON ar.id = car.id
WHERE ar.event_attribute_id IN
    (SELECT id FROM EventAttributes WHERE event_type = 'RRLE')
GO

DELETE FROM AccountingRules WHERE event_attribute_id in 
    (SELECT id FROM EventAttributes where event_type = 'RRLE')
GO

DELETE FROM EventAttributes WHERE event_type = 'RRLE'
GO

DELETE FROM EventTypes WHERE event_type = 'RRLE'
GO
 IF (not exists(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE  TABLE_NAME = 'LateDaysRange'))
		BEGIN 
			CREATE TABLE LateDaysRange
			(
			 [Min] INT not  null, [Max] INT not  null, [Label] NVARCHAR(15) null, [Color] NVARCHAR(30) null
			)
		END
GO

INSERT INTO dbo.LateDaysRange ([Min], [Max], [Label] ) VALUES (0, 0, 'Performing') 
INSERT INTO dbo.LateDaysRange ([Min], [Max], [Label], [Color]) VALUES (1, 30, 'PAR 1-30','#EAC81C') 
INSERT INTO dbo.LateDaysRange ([Min], [Max], [Label], [Color])  VALUES (31, 60, 'PAR 31-60','#EAA01C')
INSERT INTO dbo.LateDaysRange ([Min], [Max], [Label], [Color])  VALUES (61, 90, 'PAR 61-90','#EA781C')
INSERT INTO dbo.LateDaysRange ([Min], [Max], [Label], [Color])  VALUES (91, 180, 'PAR 91-180','#EA501C')
INSERT INTO dbo.LateDaysRange ([Min], [Max], [Label], [Color]) VALUES (181, 365, 'PAR 181-365','#EA281C')
INSERT INTO dbo.LateDaysRange ([Min], [Max], [Label], [Color]) VALUES (365, 1000000, 'PAR >365','#EA001C')
INSERT INTO dbo.LateDaysRange ([Min], [Max], [Label]) VALUES (0, 1000000, 'Total')
GO

ALTER TABLE TrancheEvents
ADD payment_method_id INT
GO

UPDATE TrancheEvents SET payment_method_id = 1
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v14.3.0.0'
WHERE   [name] = 'VERSION'
GO
