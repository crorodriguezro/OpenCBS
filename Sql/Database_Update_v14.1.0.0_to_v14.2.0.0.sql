ALTER TABLE Packages
ADD year_type INT NOT NULL DEFAULT(1)
GO

UPDATE  [TechnicalParameters]
SET     [value] = 'v14.2.0.0'
WHERE   [name] = 'VERSION'
GO
