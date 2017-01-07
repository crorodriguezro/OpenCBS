delete from dbo.MenuItems where component_name = 'mnuNewBooking'
insert into dbo.MenuItems(component_name, type)
values('mnuNewBooking', 0 )

go

declare @menuUtemId int = (select id from dbo.MenuItems where component_name = 'mnuNewBooking')

delete from dbo.AllowedRoleMenus where menu_item_id = @menuUtemId

declare @adminRoleId int = (select id from dbo.Roles where code = 'ADMIN')
declare @cashiRoleId int = (select id from dbo.Roles where code = 'CASHI')
declare @lofRoleId int = (select id from dbo.Roles where code = 'LOF')
declare @superRoleId int = (select id from dbo.Roles where code = 'SUPER')
declare @visitRoleId int = (select id from dbo.Roles where code = 'VISIT')
declare @itRoleId int = (select id from dbo.Roles where code = 'IT')
declare @accountingRoleId int = (select id from dbo.Roles where code = 'ACCOUNTING')

declare @allowAdmin      bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @adminRoleId      and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowCashi      bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @cashiRoleId      and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowLof        bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @lofRoleId        and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowSuper      bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @superRoleId      and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowVisit      bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @visitRoleId      and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowIt         bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @itRoleId         and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowAccounting bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @accountingRoleId and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)

insert into dbo.AllowedRoleMenus
(menu_item_id, role_id          , allowed         )
values
 (@menuUtemId, @adminRoleId     , @allowAdmin     )
,(@menuUtemId, @cashiRoleId     , @allowCashi     )
,(@menuUtemId, @lofRoleId       , @allowLof       )
,(@menuUtemId, @superRoleId     , @allowSuper     )
,(@menuUtemId, @visitRoleId     , @allowVisit     )
,(@menuUtemId, @itRoleId        , @allowIt        )
,(@menuUtemId, @accountingRoleId, @allowAccounting)

go

-----------------------------------------------------------------------------------------------------------.

delete from dbo.MenuItems where component_name='mnuNewChartOfAccounts'
insert into dbo.MenuItems(component_name, type)
values('mnuNewChartOfAccounts', 0 )

go

declare @menuUtemId int = (select id from dbo.MenuItems where component_name = 'mnuNewChartOfAccounts')

delete from dbo.AllowedRoleMenus where menu_item_id = @menuUtemId

declare @adminRoleId int = (select id from dbo.Roles where code = 'ADMIN')
declare @cashiRoleId int = (select id from dbo.Roles where code = 'CASHI')
declare @lofRoleId int = (select id from dbo.Roles where code = 'LOF')
declare @superRoleId int = (select id from dbo.Roles where code = 'SUPER')
declare @visitRoleId int = (select id from dbo.Roles where code = 'VISIT')
declare @itRoleId int = (select id from dbo.Roles where code = 'IT')
declare @accountingRoleId int = (select id from dbo.Roles where code = 'ACCOUNTING')

declare @allowAdmin      bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @adminRoleId      and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowCashi      bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @cashiRoleId      and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowLof        bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @lofRoleId        and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowSuper      bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @superRoleId      and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowVisit      bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @visitRoleId      and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowIt         bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @itRoleId         and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowAccounting bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @accountingRoleId and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)

insert into dbo.AllowedRoleMenus
(menu_item_id, role_id          , allowed         )
values
 (@menuUtemId, @adminRoleId     , @allowAdmin     )
,(@menuUtemId, @cashiRoleId     , @allowCashi     )
,(@menuUtemId, @lofRoleId       , @allowLof       )
,(@menuUtemId, @superRoleId     , @allowSuper     )
,(@menuUtemId, @visitRoleId     , @allowVisit     )
,(@menuUtemId, @itRoleId        , @allowIt        )
,(@menuUtemId, @accountingRoleId, @allowAccounting)

go

-----------------------------------------------------------------------------------------------------------.

delete from dbo.MenuItems where component_name='mnuNewBalances'
insert into dbo.MenuItems(component_name, type)
values('mnuNewBalances', 0 )

go

declare @menuUtemId int = (select id from dbo.MenuItems where component_name = 'mnuNewBalances')

delete from dbo.AllowedRoleMenus where menu_item_id = @menuUtemId

declare @adminRoleId int = (select id from dbo.Roles where code = 'ADMIN')
declare @cashiRoleId int = (select id from dbo.Roles where code = 'CASHI')
declare @lofRoleId int = (select id from dbo.Roles where code = 'LOF')
declare @superRoleId int = (select id from dbo.Roles where code = 'SUPER')
declare @visitRoleId int = (select id from dbo.Roles where code = 'VISIT')
declare @itRoleId int = (select id from dbo.Roles where code = 'IT')
declare @accountingRoleId int = (select id from dbo.Roles where code = 'ACCOUNTING')

declare @allowAdmin      bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @adminRoleId      and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowCashi      bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @cashiRoleId      and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowLof        bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @lofRoleId        and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowSuper      bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @superRoleId      and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowVisit      bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @visitRoleId      and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowIt         bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @itRoleId         and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowAccounting bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @accountingRoleId and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)

insert into dbo.AllowedRoleMenus
(menu_item_id, role_id          , allowed         )
values
 (@menuUtemId, @adminRoleId     , @allowAdmin     )
,(@menuUtemId, @cashiRoleId     , @allowCashi     )
,(@menuUtemId, @lofRoleId       , @allowLof       )
,(@menuUtemId, @superRoleId     , @allowSuper     )
,(@menuUtemId, @visitRoleId     , @allowVisit     )
,(@menuUtemId, @itRoleId        , @allowIt        )
,(@menuUtemId, @accountingRoleId, @allowAccounting)

go


-----------------------------------------------------------------------------------------------------------.

delete from dbo.MenuItems where component_name='mnuNewTurnoverBalances'
insert into dbo.MenuItems(component_name, type)
values('mnuNewTurnoverBalances', 0 )

go

declare @menuUtemId int = (select id from dbo.MenuItems where component_name = 'mnuNewTurnoverBalances')

delete from dbo.AllowedRoleMenus where menu_item_id = @menuUtemId

declare @adminRoleId int = (select id from dbo.Roles where code = 'ADMIN')
declare @cashiRoleId int = (select id from dbo.Roles where code = 'CASHI')
declare @lofRoleId int = (select id from dbo.Roles where code = 'LOF')
declare @superRoleId int = (select id from dbo.Roles where code = 'SUPER')
declare @visitRoleId int = (select id from dbo.Roles where code = 'VISIT')
declare @itRoleId int = (select id from dbo.Roles where code = 'IT')
declare @accountingRoleId int = (select id from dbo.Roles where code = 'ACCOUNTING')

declare @allowAdmin      bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @adminRoleId      and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowCashi      bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @cashiRoleId      and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowLof        bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @lofRoleId        and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowSuper      bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @superRoleId      and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowVisit      bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @visitRoleId      and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowIt         bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @itRoleId         and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowAccounting bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @accountingRoleId and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)

insert into dbo.AllowedRoleMenus
(menu_item_id, role_id          , allowed         )
values
 (@menuUtemId, @adminRoleId     , @allowAdmin     )
,(@menuUtemId, @cashiRoleId     , @allowCashi     )
,(@menuUtemId, @lofRoleId       , @allowLof       )
,(@menuUtemId, @superRoleId     , @allowSuper     )
,(@menuUtemId, @visitRoleId     , @allowVisit     )
,(@menuUtemId, @itRoleId        , @allowIt        )
,(@menuUtemId, @accountingRoleId, @allowAccounting)

go

-----------------------------------------------------------------------------------------------------------.

delete from dbo.MenuItems where component_name='mnuNewAccountMovements'
insert into dbo.MenuItems(component_name, type)
values('mnuNewAccountMovements', 0 )

go

declare @menuUtemId int = (select id from dbo.MenuItems where component_name = 'mnuNewAccountMovements')

delete from dbo.AllowedRoleMenus where menu_item_id = @menuUtemId

declare @adminRoleId int = (select id from dbo.Roles where code = 'ADMIN')
declare @cashiRoleId int = (select id from dbo.Roles where code = 'CASHI')
declare @lofRoleId int = (select id from dbo.Roles where code = 'LOF')
declare @superRoleId int = (select id from dbo.Roles where code = 'SUPER')
declare @visitRoleId int = (select id from dbo.Roles where code = 'VISIT')
declare @itRoleId int = (select id from dbo.Roles where code = 'IT')
declare @accountingRoleId int = (select id from dbo.Roles where code = 'ACCOUNTING')

declare @allowAdmin      bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @adminRoleId      and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowCashi      bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @cashiRoleId      and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowLof        bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @lofRoleId        and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowSuper      bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @superRoleId      and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowVisit      bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @visitRoleId      and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowIt         bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @itRoleId         and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowAccounting bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @accountingRoleId and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)

insert into dbo.AllowedRoleMenus
(menu_item_id, role_id          , allowed         )
values
 (@menuUtemId, @adminRoleId     , @allowAdmin     )
,(@menuUtemId, @cashiRoleId     , @allowCashi     )
,(@menuUtemId, @lofRoleId       , @allowLof       )
,(@menuUtemId, @superRoleId     , @allowSuper     )
,(@menuUtemId, @visitRoleId     , @allowVisit     )
,(@menuUtemId, @itRoleId        , @allowIt        )
,(@menuUtemId, @accountingRoleId, @allowAccounting)

go

-----------------------------------------------------------------------------------------------------------.

delete from dbo.MenuItems where component_name='mnuAccountingReports'
insert into dbo.MenuItems(component_name, type)
values('mnuAccountingReports', 0 )

go

declare @menuUtemId int = (select id from dbo.MenuItems where component_name = 'mnuAccountingReports')

delete from dbo.AllowedRoleMenus where menu_item_id = @menuUtemId

declare @adminRoleId int = (select id from dbo.Roles where code = 'ADMIN')
declare @cashiRoleId int = (select id from dbo.Roles where code = 'CASHI')
declare @lofRoleId int = (select id from dbo.Roles where code = 'LOF')
declare @superRoleId int = (select id from dbo.Roles where code = 'SUPER')
declare @visitRoleId int = (select id from dbo.Roles where code = 'VISIT')
declare @itRoleId int = (select id from dbo.Roles where code = 'IT')
declare @accountingRoleId int = (select id from dbo.Roles where code = 'ACCOUNTING')

declare @allowAdmin      bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @adminRoleId      and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowCashi      bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @cashiRoleId      and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowLof        bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @lofRoleId        and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowSuper      bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @superRoleId      and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowVisit      bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @visitRoleId      and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowIt         bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @itRoleId         and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)
declare @allowAccounting bit = isnull((select allowed from dbo.AllowedRoleMenus where role_id = @accountingRoleId and menu_item_id = (select id from dbo.MenuItems where component_name = 'mnuAccounting')), 0)

insert into dbo.AllowedRoleMenus
(menu_item_id, role_id          , allowed         )
values
 (@menuUtemId, @adminRoleId     , @allowAdmin     )
,(@menuUtemId, @cashiRoleId     , @allowCashi     )
,(@menuUtemId, @lofRoleId       , @allowLof       )
,(@menuUtemId, @superRoleId     , @allowSuper     )
,(@menuUtemId, @visitRoleId     , @allowVisit     )
,(@menuUtemId, @itRoleId        , @allowIt        )
,(@menuUtemId, @accountingRoleId, @allowAccounting)

go
