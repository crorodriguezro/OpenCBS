update
    dbo.TechnicalParameters
set
    value = 'v16.8.0.0'
where
    name = 'VERSION'
GO