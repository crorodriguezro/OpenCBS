INSERT INTO [GeneralParameters]([key], [value]) VALUES('NUMBER_GROUP_SEPARATOR', ' ')
INSERT INTO [GeneralParameters]([key], [value]) VALUES('NUMBER_DECIMAL_SEPARATOR', ',')
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v14.5.0.0'
WHERE   [name] = 'VERSION'
GO
