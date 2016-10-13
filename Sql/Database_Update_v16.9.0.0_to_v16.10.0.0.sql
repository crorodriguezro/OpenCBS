UPDATE  [TechnicalParameters]
SET     [value] = 'v16.10.0.0'
WHERE   [name] = 'VERSION'
GO

alter table EntryFees
add max_sum decimal(18, 4) null
GO

IF NOT EXISTS ( SELECT TOP 1 value FROM dbo.GeneralParameters WHERE [key] = 'ID_NUMBER_IS_MANDATORY' )
BEGIN
    INSERT INTO dbo.GeneralParameters ([key], [value]) VALUES ('ID_NUMBER_IS_MANDATORY', 1)
END
GO

ALTER TABLE Persons ALTER COLUMN identification_data nvarchar(200) NULL