create table dbo.InterestWriteOffEvents
(
	id int not null,
	amount money not null
)
GO

alter table dbo.InterestWriteOffEvents
add constraint FK_InterestWriteOffEvents foreign key (id) references dbo.ContractEvents(id)
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v15.4.0.0'
WHERE   [name] = 'VERSION'
GO