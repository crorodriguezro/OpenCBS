alter table dbo.ContractEvents add doc1 varchar(255) null
GO
alter table dbo.ContractEvents add doc2 varchar(255) null
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v15.10.0.0'
WHERE   [name] = 'VERSION'
GO
