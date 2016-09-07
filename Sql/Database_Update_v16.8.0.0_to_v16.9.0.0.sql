update
    dbo.TechnicalParameters
set
    value = 'v16.9.0.0'
where
    name = 'VERSION'
GO