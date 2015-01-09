alter table dbo.Persons
add uuid uniqueidentifier not null default(newid())

alter table dbo.Branches
add is_default bit not null default(0)

INSERT INTO dbo.GeneralParameters ([key], value)
values ('SHORT_DATE_FORMAT', 'dd-MM-yyyy')

UPDATE  [TechnicalParameters]
SET     [value] = 'v14.16.0.0'
WHERE   [name] = 'VERSION'
GO