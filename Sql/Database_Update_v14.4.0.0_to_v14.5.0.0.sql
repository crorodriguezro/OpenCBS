INSERT INTO [GeneralParameters]([key], [value]) VALUES('NUMBER_GROUP_SEPARATOR', ' ')
INSERT INTO [GeneralParameters]([key], [value]) VALUES('NUMBER_DECIMAL_SEPARATOR', ',')
GO

ALTER TABLE Packages
ADD script_name NVARCHAR(255) NULL
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v14.5.0.0'
WHERE   [name] = 'VERSION'
GO