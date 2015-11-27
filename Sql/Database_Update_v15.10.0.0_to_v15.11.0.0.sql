if col_length('dbo.Installments','extraAmount1') is null
ALTER TABLE dbo.Installments ADD extraAmount1 MONEY NULL DEFAULT(0)
GO

if col_length('dbo.Installments','extraAmount2') is null
ALTER TABLE dbo.Installments ADD extraAmount2 MONEY NULL DEFAULT(0)
GO

if col_length('dbo.InstallmentHistory','extraAmount1') is null
ALTER TABLE dbo.Installments ADD extraAmount1 MONEY NULL DEFAULT(0)
GO

if col_length('dbo.InstallmentHistory','extraAmount2') is null
ALTER TABLE dbo.Installments ADD extraAmount2 MONEY NULL DEFAULT(0)
GO

if col_length('dbo.Installments','last_interest_accrual_date') is null
ALTER TABLE dbo.Installments ADD extraAmount1 MONEY NULL DEFAULT(0)
GO

if col_length('dbo.InstallmentHistory','last_interest_accrual_date') is null
ALTER TABLE dbo.Installments ADD extraAmount2 MONEY NULL DEFAULT(0)
GO

update dbo.Installments set last_interest_accrual_date = expected_date
GO

update dbo.InstallmentHistory set last_interest_accrual_date = expected_date
GO

if col_length('dbo.Installments','last_interest_accrual_date') is null
alter table dbo.Installments alter column last_interest_accrual_date date not null
GO

if col_length('dbo.InstallmentHistory','last_interest_accrual_date') is null
alter table dbo.InstallmentHistory alter column last_interest_accrual_date date not null
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v15.11.0.0'
WHERE   [name] = 'VERSION'
GO
