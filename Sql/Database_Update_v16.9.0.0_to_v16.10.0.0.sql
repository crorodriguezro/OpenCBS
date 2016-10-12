UPDATE  [TechnicalParameters]
SET     [value] = 'v16.10.0.0'
WHERE   [name] = 'VERSION'
GO

alter table EntryFees
add max_sum decimal(18, 4) null
GO