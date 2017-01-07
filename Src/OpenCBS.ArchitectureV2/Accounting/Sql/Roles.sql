	delete from dbo.ActionItems where class_name = 'Accounting'
	insert into dbo.ActionItems (class_name,method_name)
	values
	('Accounting','EntryTransaction')
	,('Accounting','EditTransaction')
	,('Accounting','DeleteTransaction')
	,('Accounting','PrintTransaction')
	,('Accounting','EntryAccount')
	,('Accounting','EditAccount')
	,('Accounting','DeleteAccount')
	go
	------------------------------------------------------------------
	delete from dbo.MenuItems where component_name='mnuCoreAccounting'
	insert into dbo.MenuItems(component_name,type)
	values('mnuCoreAccounting',0 )
	go

	delete from dbo.MenuItems where component_name='mnuNewChartOfAccounts'
	insert into dbo.MenuItems(component_name,type)
	values ('mnuNewChartOfAccounts',0 )
	go

	delete from dbo.MenuItems where component_name='mnuNewBooking'
	insert into dbo.MenuItems(component_name,type)
	values ('mnuNewBooking',0 )
	go

	delete from dbo.MenuItems where component_name='mnuNewTurnoverBalances'
	insert into dbo.MenuItems(component_name,type)
	values ('mnuNewTurnoverBalances',0 )
	go

	delete from dbo.MenuItems where component_name='mnuNewBalances'
	insert into dbo.MenuItems(component_name,type)
	values ('mnuNewBalances',0 )
	go

	delete from dbo.MenuItems where component_name='mnuNewAccountMovements'
	insert into dbo.MenuItems(component_name,type)
	values ('mnuNewAccountMovements',0 )