 
 UPDATE dbo.ProvisioningRules
SET dbo.ProvisioningRules.provisioning_value =  2  
 

UPDATE  [TechnicalParameters]
SET     [value] = 'v13.13.0.0'
WHERE   [name] = 'VERSION'
GO
