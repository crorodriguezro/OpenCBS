ALTER TABLE dbo.Installments ADD extraAmount1 MONEY NULL DEFAULT(0)
GO
ALTER TABLE dbo.Installments ADD extraAmount2 MONEY NULL DEFAULT(0)
GO
ALTER TABLE dbo.InstallmentHistory ADD extraAmount1 MONEY NULL DEFAULT(0)
GO
ALTER TABLE dbo.InstallmentHistory ADD extraAmount2 MONEY NULL DEFAULT(0)
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v15.11.0.0'
WHERE   [name] = 'VERSION'
GO