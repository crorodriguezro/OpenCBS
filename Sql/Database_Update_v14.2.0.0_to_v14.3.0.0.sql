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
UPDATE  [TechnicalParameters]
SET     [value] = 'v14.3.0.0'
WHERE   [name] = 'VERSION'
GO
