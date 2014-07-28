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


IF not exists (SELECT * FROM sys.tables WHERE name = 'Booking')
BEGIN
CREATE TABLE [dbo].[Booking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DebitAccountId] [int] NULL,
	[CreditAccountId] [int] NULL,
	[Amount] [decimal](25, 15) NULL,
	[Date] [datetime] NULL,
	[LoanEventId] [int] NOT NULL DEFAULT(0),
	[SavingEventId] [int] NOT NULL DEFAULT(0),
	[LoanId] [int] NULL,
	[ClientId] [int] NULL,
	[UserId] [int] NULL,
	[BranchId] [int] NULL,
	[Description] [nvarchar](200) NULL,
	[IsExported] [bit] NOT NULL DEFAULT(0),
	[IsDeleted] [bit] NOT NULL DEFAULT(0)
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

GO

IF not exists (SELECT * FROM sys.tables WHERE name = 'Accounts')
                                                BEGIN 
                                                CREATE TABLE Accounts
                                                (id int identity(1,1),
                                                 account_number varchar(64),
                                                 label nvarchar(256) not null,
                                                 is_debit bit,
                                                 id_category int,
                                                 parent_id int
                                                ) 
END  
GO

IF not exists (SELECT * FROM sys.tables WHERE name = 'Categories')
                                                BEGIN 
                                                CREATE TABLE Categories
												(
												  Id int  identity(1,1),
												  ParentId int,
												  Name nvarchar(128),
												  lft int ,
												  rgt int
												)
END  
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v14.10.0.0'
WHERE   [name] = 'VERSION'
GO