if object_id('dbo.InterestWriteOffEvents') is null
begin
	create table dbo.InterestWriteOffEvents
	(
		id int not null,
		amount money not null
	)
	alter table dbo.InterestWriteOffEvents
	add constraint FK_InterestWriteOffEvents foreign key (id) references dbo.ContractEvents(id)
end
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v15.4.0.0'
WHERE   [name] = 'VERSION'
GO