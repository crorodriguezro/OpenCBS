UPDATE  [TechnicalParameters]
SET     [value] = 'v16.10.0.0'
WHERE   [name] = 'VERSION'
GO

ALTER TABLE EntryFees
ADD max_sum decimal(18, 4) null
GO