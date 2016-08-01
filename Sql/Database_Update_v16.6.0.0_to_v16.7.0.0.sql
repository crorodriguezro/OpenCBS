update
    dbo.TechnicalParameters
set
    value = 'v16.7.0.0'
where
    name = 'VERSION'
GO

IF NOT EXISTS ( SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[SavingProducts]') AND name = 'type' )
BEGIN
    ALTER TABLE dbo.SavingProducts ADD [type] int
END
GO

IF NOT EXISTS ( SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[SavingProducts]') AND name = 'renew_auto' )
BEGIN
    ALTER TABLE dbo.SavingProducts ADD [renew_auto] bit
END
GO

IF NOT EXISTS ( SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[Tiers]') AND name = 'CurrentAccount' )
BEGIN
    ALTER TABLE dbo.Tiers ADD [CurrentAccount] nvarchar(50)
END
GO

IF NOT EXISTS ( SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[SavingEvents]') AND name = 'doc1' )
BEGIN
    ALTER TABLE dbo.SavingEvents ADD [doc1] varchar(max)
END
GO

UPDATE SavingProducts set [renew_auto] = 0 where [renew_auto] is null
GO

UPDATE SavingProducts set [type] = 3 where [type] is null
GO

UPDATE InstallmentTypes set [name] = N'Yearly', [nb_of_days] = 0, [nb_of_months] = 12 where [name] = N'Weekly'
GO

DELETE FROM InstallmentTypes WHERE [name] = N'Daily' or [name] = N'Maturity'
GO

UPDATE SavingBookProducts set [management_fees_freq] = 1 where [management_fees_freq] > 2
GO

UPDATE SavingBookProducts set [agio_fees_freq] = 1 where [agio_fees_freq] > 2
GO