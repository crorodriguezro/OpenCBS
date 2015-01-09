INSERT INTO dbo.GeneralParameters ([key], value)
values ('SHORT_DATE_FORMAT', 'dd-MM-yyyy')

UPDATE  [TechnicalParameters]
SET     [value] = 'v15.1.0.0'
WHERE   [name] = 'VERSION'
GO