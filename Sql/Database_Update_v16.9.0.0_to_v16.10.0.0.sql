UPDATE  [TechnicalParameters]
SET     [value] = 'v16.10.0.0'
WHERE   [name] = 'VERSION'
GO

alter table EntryFees
add max_sum decimal(18, 4) null
GO

IF NOT EXISTS ( SELECT TOP 1 value FROM dbo.GeneralParameters WHERE [key] = 'ID_NUMBER_IS_MANDATORY' )
BEGIN
    INSERT INTO dbo.GeneralParameters ([key], [value]) VALUES ('ID_NUMBER_IS_MANDATORY', 1)
END
GO

IF NOT EXISTS ( SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[Users]') AND name = 'password_salt' )
BEGIN
    ALTER TABLE dbo.Users ADD [password_salt] nvarchar(4000) null
END
GO

IF NOT EXISTS ( SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[Users]') AND name = 'password_hash' )
BEGIN
    ALTER TABLE dbo.Users ADD [password_hash] nvarchar(4000) null
END
GO

IF EXISTS ( SELECT * FROM sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[Users]') AND name = 'user_pass' )
BEGIN
	declare @passwords table(
		userid int null
		, password_salt nvarchar(250) null
		, password_hash nvarchar(250) null
		, password_hash_bytes varbinary(max) null
		, [password] nvarchar(250) null	
		, [password_binary] varbinary(max) null	
		, [base64] varbinary(max));

	insert into @passwords
	select 
		u.id
		, null
		, null
		, null
		, u.user_pass
		,convert(varbinary(max),u.user_pass)
		, CRYPT_GEN_RANDOM(50)
	 from dbo.users u

	update @passwords
	 set
	  password_salt = cast('' as xml).value('xs:base64Binary(sql:column("base64"))', 'varchar(max)')
	  , password_hash_bytes = hashbytes('sha1',convert(varbinary(max),[password])+[base64])

	update @passwords
	 set
	  password_hash = cast('' as xml).value('xs:base64Binary(sql:column("password_hash_bytes"))', 'varchar(max)')

	update dbo.Users
	set password_hash = (select top 1 password_hash from @passwords p where users.id = userid)
	, password_salt = (select top 1 password_salt from @passwords p where users.id = userid)


	ALTER TABLE dbo.Users DROP CONSTRAINT IX_Users_username_pwd 
    ALTER TABLE dbo.Users DROP COLUMN user_pass	
END
GO

ALTER TABLE Persons ALTER COLUMN identification_data nvarchar(200) NULL