alter table dbo.Persons
add uuid uniqueidentifier not null default(newid())

<<<<<<< HEAD
=======
alter table dbo.Branches
add is_default bit not null default(0)


>>>>>>> Adding the possibility to set default date format
INSERT INTO dbo.GeneralParameters ([key], value)
values ('SHORT_DATE_FORMAT', 'dd-MM-yyyy')

UPDATE  [TechnicalParameters]
SET     [value] = 'v14.16.0.0'
WHERE   [name] = 'VERSION'
GO