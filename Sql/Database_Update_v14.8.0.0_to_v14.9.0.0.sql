alter table RepaymentEvents
add bounce_fee money not null default(0)
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v14.9.0.0'
WHERE   [name] = 'VERSION'
GO