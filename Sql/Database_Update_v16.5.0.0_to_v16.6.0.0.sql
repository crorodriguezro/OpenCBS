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