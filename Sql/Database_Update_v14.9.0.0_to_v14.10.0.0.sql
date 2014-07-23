CREATE FUNCTION [dbo].[GetSubordinates](@id_user INT)
RETURNS TABLE
AS RETURN
(
 SELECT  *, 
    (SELECT COUNT(*)
	FROM dbo.Credit 
	WHERE loanofficer_id = u.id) AS num_contracts
 FROM  dbo.users u LEFT JOIN dbo.UsersSubordinates us  ON u.id = us.subordinate_id
 WHERE us.user_id  = @id_user AND u.deleted =0 
)
GO

DElETE FROM GeneralParameters WHERE [key] ='USE_EXTERNAL_ACCOUNTING'
GO

CREATE TABLE [dbo].[Booking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DebitAccountId] [int] NULL,
	[CreditAccountId] [int] NULL,
	[Amount] [decimal](25, 15) NULL,
	[Date] [datetime] NULL,
	[LoanEventId] [int] NULL,
	[SavingEventId] [int] NULL,
	[LoanId] [int] NULL,
	[ClientId] [int] NULL,
	[UserId] [int] NULL,
	[BranchId] [int] NULL,
	[Description] [nvarchar](200) NULL,
	[IsExported] [bit] NULL,
	[IsDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Booking] ADD  DEFAULT ((0)) FOR [LoanEventId]
GO

ALTER TABLE [dbo].[Booking] ADD  DEFAULT ((0)) FOR [SavingEventId]
GO

ALTER TABLE [dbo].[Booking] ADD  DEFAULT ((0)) FOR [IsExported]
GO

ALTER TABLE [dbo].[Booking] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO


UPDATE  [TechnicalParameters]
SET     [value] = 'v14.10.0.0'
WHERE   [name] = 'VERSION'
GO