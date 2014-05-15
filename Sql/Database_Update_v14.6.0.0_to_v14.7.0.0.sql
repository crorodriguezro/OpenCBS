DELETE GeneralParameters
WHERE [key] = 'USE_TELLER_MANAGEMENT'
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v14.7.0.0'
WHERE   [name] = 'VERSION'
GO
  