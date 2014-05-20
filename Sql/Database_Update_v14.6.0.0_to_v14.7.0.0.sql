DELETE GeneralParameters
WHERE [key] = 'USE_TELLER_MANAGEMENT'
GO

alter table Installments 
add commission money not null default(0),
paid_commission money not null default(0)
GO

alter table InstallmentHistory
add commission money not null default(0),
paid_commission money not null default(0)
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v14.7.0.0'
WHERE   [name] = 'VERSION'
GO