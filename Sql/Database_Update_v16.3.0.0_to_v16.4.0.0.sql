-- Clean up dbo.Persons
if col_length('dbo.Persons', 'povertylevel_economiceducation') is not null
alter table dbo.Persons drop constraint DF_Persons_povertylevel_economiceducation, column povertylevel_economiceducation
GO

if col_length('dbo.Persons', 'first_appointment') is not null
alter table dbo.Persons drop column first_appointment
GO

if col_length('dbo.Persons', 'professional_situation') is not null
alter table dbo.Persons drop column professional_situation
GO

if col_length('dbo.Persons', 'first_contact') is not null
alter table dbo.Persons drop column first_contact
GO

-- Drop dbo.Person.uuid default contstraint
declare @object_name nvarchar(100)
select
    @object_name = object_name(default_object_id)
from
    sys.columns
where
    [object_id] = object_id('dbo.Persons')
    and name = 'uuid'
if not @object_name is null
exec('alter table dbo.Persons drop constraint ' + @object_name)
GO

if col_length('dbo.Persons', 'uuid') is not null
alter table dbo.Persons drop column uuid
GO

-- Clean up dbo.Tiers
if col_length('dbo.Tiers', 'other_org_name') is not null
alter table dbo.Tiers drop column other_org_name
GO

if col_length('dbo.Tiers', 'other_org_amount') is not null
alter table dbo.Tiers drop column other_org_amount
GO

if col_length('dbo.Tiers', 'other_org_debts') is not null
alter table dbo.Tiers drop column other_org_debts
GO

if col_length('dbo.Tiers', 'other_org_comment') is not null
alter table dbo.Tiers drop column other_org_comment
GO

if col_length('dbo.Tiers', 'sponsor1') is not null
alter table dbo.Tiers drop column sponsor1
GO

if col_length('dbo.Tiers', 'sponsor1_comment') is not null
alter table dbo.Tiers drop column sponsor1_comment
GO

if col_length('dbo.Tiers', 'sponsor2') is not null
alter table dbo.Tiers drop column sponsor2
GO

if col_length('dbo.Tiers', 'sponsor2_comment') is not null
alter table dbo.Tiers drop column sponsor2_comment
GO

if col_length('dbo.Tiers', 'follow_up_comment') is not null
alter table dbo.Tiers drop column follow_up_comment
GO

if col_length('dbo.Tiers', 'cash_input_voucher_number') is not null
alter table dbo.Tiers drop column cash_input_voucher_number
GO

if col_length('dbo.Tiers', 'cash_output_voucher_number') is not null
alter table dbo.Tiers drop column cash_output_voucher_number
GO

if col_length('dbo.Tiers', 'home_type') is not null
alter table dbo.Tiers drop column home_type
GO

if col_length('dbo.Tiers', 'secondary_homeType') is not null
alter table dbo.Tiers drop column secondary_homeType
GO

update
    dbo.TechnicalParameters
set
    value = 'v16.4.0.0'
where
    name = 'VERSION'
GO
