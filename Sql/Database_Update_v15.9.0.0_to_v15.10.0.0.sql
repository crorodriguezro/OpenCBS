alter table dbo.Contracts add check_number varchar(255) NULL;
alter table dbo.Contracts add receipt_number varchar(255) NULL;
go

UPDATE  [TechnicalParameters]
SET     [value] = 'v15.10.0.0'
WHERE   [name] = 'VERSION'
GO
