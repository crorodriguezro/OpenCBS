update
    dbo.TechnicalParameters
set
    value = 'v16.9.0.0'
where
    name = 'VERSION'
GO

declare @actionUtemId int = (select id from dbo.ActionItems where method_name = 'CancelLastSavingEvent')
delete from dbo.AllowedRoleActions where action_item_id = @actionUtemId
delete from dbo.ActionItems where method_name = 'CancelLastSavingEvent'

insert into dbo.ActionItems(class_name, method_name)
values('SavingServices', 'CancelLastSavingEvent')

go

declare @actionUtemId int = (select id from dbo.ActionItems where method_name = 'CancelLastSavingEvent')

delete from dbo.AllowedRoleActions where action_item_id = @actionUtemId

declare @adminRoleId int = (select id from dbo.Roles where code = 'ADMIN')
declare @cashiRoleId int = (select id from dbo.Roles where code = 'CASHI')
declare @lofRoleId int = (select id from dbo.Roles where code = 'LOF')
declare @superRoleId int = (select id from dbo.Roles where code = 'SUPER')
declare @visitRoleId int = (select id from dbo.Roles where code = 'VISIT')
declare @itRoleId int = (select id from dbo.Roles where code = 'IT')
declare @accountingRoleId int = (select id from dbo.Roles where code = 'ACCOUNTING')

declare @allowAdmin      bit = 1
declare @allowCashi      bit = 0
declare @allowLof        bit = 0
declare @allowSuper      bit = 1
declare @allowVisit      bit = 0
declare @allowIt         bit = 1
declare @allowAccounting bit = 1

insert into dbo.AllowedRoleActions
(action_item_Id, role_id          , allowed         )
values
 (@actionUtemId, @adminRoleId     , @allowAdmin     )
,(@actionUtemId, @cashiRoleId     , @allowCashi     )
,(@actionUtemId, @lofRoleId       , @allowLof       )
,(@actionUtemId, @superRoleId     , @allowSuper     )
,(@actionUtemId, @visitRoleId     , @allowVisit     )
,(@actionUtemId, @itRoleId        , @allowIt        )
,(@actionUtemId, @accountingRoleId, @allowAccounting)

go