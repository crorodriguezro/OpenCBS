update
    dbo.TechnicalParameters
set
    value = 'v16.6.0.0'
where
    name = 'VERSION'
GO

insert into 
	dbo.ActionItems (class_name,method_name)
values
	 ('ClientServices', 'ModifyNonSolidarityGroup')
GO

if(select [key] from dbo.GeneralParameters where [key] = 'CHECK_CREDIT_COMMITTEE_DATE') is null
	begin
		insert into 
		    dbo.GeneralParameters([key], value)
		values
		    ('CHECK_CREDIT_COMMITTEE_DATE', 0)
	end
GO
