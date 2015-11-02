ALTER TABLE dbo.ContractEvents ADD doc1 VARCHAR(255) NULL;
ALTER TABLE dbo.ContractEvents ADD doc2 VARCHAR(255) NULL;
Go

UPDATE  [TechnicalParameters]
SET     [value] = 'v15.10.0.0'
WHERE   [name] = 'VERSION'
GO
