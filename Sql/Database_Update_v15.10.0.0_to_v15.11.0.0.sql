ALTER TABLE dbo.Installments ADD exchanged_amount MONEY null
GO
ALTER TABLE dbo.Installments ADD exchange_rate MONEY null
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v15.11.0.0'
WHERE   [name] = 'VERSION'
GO