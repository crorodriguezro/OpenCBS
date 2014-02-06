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

UPDATE  [TechnicalParameters]
SET     [value] = 'v14.3.0.0'
WHERE   [name] = 'VERSION'
GO
