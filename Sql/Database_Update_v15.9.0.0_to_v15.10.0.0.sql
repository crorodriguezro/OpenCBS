ALTER TABLE dbo.ContractEvents ADD check_number VARCHAR(255) NULL;
ALTER TABLE dbo.ContractEvents ADD receipt_number VARCHAR(255) NULL;
go
ALTER TABLE dbo.Booking ADD CheckNumber VARCHAR(255) NULL;
ALTER TABLE dbo.Booking ADD ReceiptNumber VARCHAR(255) NULL;
go

UPDATE  [TechnicalParameters]
SET     [value] = 'v15.10.0.0'
WHERE   [name] = 'VERSION'
GO
