alter table dbo.Persons
add uuid uniqueidentifier not null default(newid())

UPDATE  [TechnicalParameters]
SET     [value] = 'v14.16.0.0'
WHERE   [name] = 'VERSION'
GO