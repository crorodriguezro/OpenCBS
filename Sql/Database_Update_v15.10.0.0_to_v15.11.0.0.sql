ALTER TABLE dbo.Installments ADD exchanged_amount MONEY NULL DEFAULT(0)
GO
ALTER TABLE dbo.Installments ADD exchange_rate MONEY NULL DEFAULT(0)
GO
ALTER TABLE dbo.InstallmentHistory ADD exchanged_amount MONEY NULL DEFAULT(0)
GO
ALTER TABLE dbo.InstallmentHistory ADD exchange_rate MONEY NULL DEFAULT(0)
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v15.11.0.0'
WHERE   [name] = 'VERSION'
GO