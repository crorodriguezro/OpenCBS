ALTER TABLE dbo.ContractEvents ADD check_number VARCHAR(255) NULL;
ALTER TABLE dbo.ContractEvents ADD receipt_number VARCHAR(255) NULL;
go

UPDATE  [TechnicalParameters]
SET     [value] = 'v15.10.0.0'
WHERE   [name] = 'VERSION'
GO
