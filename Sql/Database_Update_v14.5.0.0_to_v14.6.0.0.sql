IF  NOT EXISTS(SELECT *  FROM  INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Roles'  AND COLUMN_NAME = 'role_of_loan' AND COLUMN_NAME = 'role_of_saving' AND COLUMN_NAME = 'role_of_teller') 
BEGIN
ALTER TABLE [dbo].[Roles] DROP CONSTRAINT [DF__Roles__role_of_l__014935CB]
ALTER TABLE [dbo].[Roles] DROP CONSTRAINT [DF__Roles__role_of_s__023D5A04]
ALTER TABLE [dbo].[Roles] DROP CONSTRAINT [DF__Roles__role_of_t__03317E3D]

ALTER TABLE  Roles DROP COLUMN  role_of_loan
ALTER TABLE  Roles DROP COLUMN  role_of_saving
ALTER TABLE  Roles DROP COLUMN  role_of_teller
END
GO
 
UPDATE  [TechnicalParameters]
SET     [value] = 'v14.6.0.0'
WHERE   [name] = 'VERSION'
GO
  