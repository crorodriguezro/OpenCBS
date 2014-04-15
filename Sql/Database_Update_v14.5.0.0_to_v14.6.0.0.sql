IF  NOT EXISTS(SELECT *  FROM  INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Roles'  AND COLUMN_NAME = 'role_of_loan' AND COLUMN_NAME = 'role_of_saving' AND COLUMN_NAME = 'role_of_teller') 
BEGIN
DECLARE @Str NVARCHAR(100)
SET @Str = ( SELECT   name
               FROM     sysobjects
               WHERE    name LIKE 'DF__Roles__role_of_l%'
             )
EXEC('ALTER TABLE Roles DROP CONSTRAINT '+ @Str)

SET @Str = ( SELECT   name
               FROM     sysobjects
               WHERE    name LIKE 'DF__Roles__role_of_s%'
             )
EXEC('ALTER TABLE Roles DROP CONSTRAINT '+ @Str)

SET @Str = ( SELECT   name
               FROM     sysobjects
               WHERE    name LIKE 'DF__Roles__role_of_t%'
             )
EXEC('ALTER TABLE Roles DROP CONSTRAINT '+ @Str)
 
ALTER TABLE  Roles DROP COLUMN  role_of_loan
ALTER TABLE  Roles DROP COLUMN  role_of_saving
ALTER TABLE  Roles DROP COLUMN  role_of_teller
END
GO
 
UPDATE  [TechnicalParameters]
SET     [value] = 'v14.6.0.0'
WHERE   [name] = 'VERSION'
GO
  