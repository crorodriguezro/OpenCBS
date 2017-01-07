alter table dbo.Accounts drop column is_manual_editable
go

alter table dbo.Accounts add is_direct bit
go

update 
    dbo.Accounts 
set is_direct = 1
go

alter table dbo.Booking add Doc1 varchar(255) null;
alter table dbo.Booking add Doc2 varchar(255) null;
go

