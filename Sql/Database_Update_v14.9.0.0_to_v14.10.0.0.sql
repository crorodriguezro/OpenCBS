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

UPDATE  [TechnicalParameters]
SET     [value] = 'v14.10.0.0'
WHERE   [name] = 'VERSION'
GO