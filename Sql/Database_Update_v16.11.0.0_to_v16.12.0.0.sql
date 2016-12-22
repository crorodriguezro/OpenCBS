UPDATE  [TechnicalParameters]
SET     [value] = 'v16.12.0.0'
WHERE   [name] = 'VERSION'
GO

if col_length('dbo.LoanPenaltyAccrualEvents','installment_number') IS NULL
    begin
        alter table dbo.LoanPenaltyAccrualEvents add installment_number int not null
    end
GO
