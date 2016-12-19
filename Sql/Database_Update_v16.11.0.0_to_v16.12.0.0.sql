UPDATE  [TechnicalParameters]
SET     [value] = 'v16.12.0.0'
WHERE   [name] = 'VERSION'
GO

--------------------------------------------------------------------------------- ENTRY FEE START -----------------------------------------------------------------------------------------

-- First step - create new
--_________________________________________________________________________________________________________________________________________________________________________________________
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoanProductsEntryFees]') AND type in (N'U'))
	BEGIN
		CREATE TABLE [dbo].[LoanProductsEntryFees](
            [id]           [int] IDENTITY(1,1) NOT NULL,
			[id_entry_fee] [int] NOT NULL,
			[id_product]   [int] NOT NULL,
			[cycle_id]     [int] NULL,
			[fee_index]    [int] NOT NULL)
	END
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LoanProductsEntryFees_EntryFees]') AND parent_object_id = OBJECT_ID(N'[dbo].[LoanProductsEntryFees]'))
	ALTER TABLE [dbo].[LoanProductsEntryFees]  WITH CHECK ADD CONSTRAINT [FK_LoanProductsEntryFees_EntryFees] FOREIGN KEY([id_entry_fee])
	REFERENCES [dbo].[EntryFees] ([id])
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LoanProductsEntryFees_Packages]') AND parent_object_id = OBJECT_ID(N'[dbo].[LoanProductsEntryFees]'))
	ALTER TABLE [dbo].[LoanProductsEntryFees]  WITH CHECK ADD CONSTRAINT [FK_LoanProductsEntryFees_Packages] FOREIGN KEY([id_product])
	REFERENCES [dbo].[Packages] ([id])
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LoanProductsEntryFees_Cycles]') AND parent_object_id = OBJECT_ID(N'[dbo].[LoanProductsEntryFees]'))
	ALTER TABLE [dbo].[LoanProductsEntryFees]  WITH CHECK ADD CONSTRAINT [FK_LoanProductsEntryFees_Cycles] FOREIGN KEY([cycle_id])
	REFERENCES [dbo].[Cycles] ([id])
GO

-- Second step - migration old entry fees to new table
--_________________________________________________________________________________________________________________________________________________________________________________________
update
	[dbo].[EntryFees]
set
	[min] = case
				when [value] is not null then [value]
				else [min]
			end,
	[max] = case
				when [value] is not null then [value]
				else [max]
			end
GO

if not exists(select * from [dbo].[LoanProductsEntryFees])
begin
	insert into [dbo].[LoanProductsEntryFees]
		(id_entry_fee
		, id_product
		, cycle_id
		, fee_index)
	select
		ef.id
		, ef.id_product
		, ef.cycle_id
		, ef.fee_index
	from
		[dbo].[EntryFees] ef
	where
		ef.is_deleted = 0
		and ef.id_product IS NOT NULL
end
GO

-- Third step - clean up old data
--_________________________________________________________________________________________________________________________________________________________________________________________
-- Drop column id_product from EntryFees
IF EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EntryFees_Packages]') AND parent_object_id = OBJECT_ID(N'[dbo].[EntryFees]'))
	alter table [dbo].[EntryFees] drop constraint FK_EntryFees_Packages
GO

IF EXISTS(SELECT * FROM sys.columns WHERE Name = N'id_product' AND Object_ID = Object_ID(N'EntryFees'))
BEGIN
    ALTER TABLE [dbo].[EntryFees]
	DROP COLUMN id_product
END

-- Drop column cycle_id from EntryFees
IF EXISTS(SELECT * FROM sys.columns WHERE Name = N'cycle_id' AND Object_ID = Object_ID(N'EntryFees'))
BEGIN
    ALTER TABLE [dbo].[EntryFees]
	DROP COLUMN cycle_id
END

-- Drop column fee_index from EntryFees
DECLARE @sql NVARCHAR(MAX)
WHILE 1=1
BEGIN
    SELECT TOP 1 @sql = N'alter table [dbo].[EntryFees] drop constraint ['+dc.NAME+N']'
    from sys.default_constraints dc
    JOIN sys.columns c
        ON c.default_object_id = dc.object_id
    WHERE 
        dc.parent_object_id = OBJECT_ID('[dbo].[EntryFees]')
    AND c.name = N'fee_index'
    IF @@ROWCOUNT = 0 BREAK
    EXEC (@sql)
END
GO

IF EXISTS(SELECT * FROM sys.columns WHERE Name = N'fee_index' AND Object_ID = Object_ID(N'EntryFees'))
BEGIN
    ALTER TABLE [dbo].[EntryFees]
	DROP COLUMN fee_index
END

-- Drop column value from EntryFees
IF EXISTS(SELECT * FROM sys.columns WHERE Name = N'value' AND Object_ID = Object_ID(N'EntryFees'))
BEGIN
    ALTER TABLE [dbo].[EntryFees]
	DROP COLUMN [value]
END

--------------------------------------------------------------------------------- ENTRY FEE END -----------------------------------------------------------------------------------------