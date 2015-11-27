ALTER TABLE dbo.Installments ADD extraAmount1 MONEY NULL DEFAULT(0)
GO
ALTER TABLE dbo.Installments ADD extraAmount2 MONEY NULL DEFAULT(0)
GO
ALTER TABLE dbo.InstallmentHistory ADD extraAmount1 MONEY NULL DEFAULT(0)
GO
ALTER TABLE dbo.InstallmentHistory ADD extraAmount2 MONEY NULL DEFAULT(0)
GO

alter table dbo.Installments add last_interest_accrual_date date NULL
GO

alter table dbo.InstallmentHistory add last_interest_accrual_date date NULL
GO

update dbo.Installments set last_interest_accrual_date = expected_date
GO

update dbo.InstallmentHistory set last_interest_accrual_date = expected_date
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v15.11.0.0'
WHERE   [name] = 'VERSION'
GO
