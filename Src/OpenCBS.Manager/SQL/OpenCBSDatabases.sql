DECLARE @userName NVARCHAR(MAX) = N'{0}'
DECLARE @databases TABLE
(
    Name NVARCHAR(MAX),
    Version NVARCHAR(MAX),
    BranchCode NVARCHAR(MAX)
)
DECLARE @name NVARCHAR(MAX)
DECLARE @version NVARCHAR(MAX)
DECLARE @branch NVARCHAR(MAX)
DECLARE @query NVARCHAR(MAX)
DECLARE @total INT
DECLARE @count INT
DECLARE @hasDatabaseAccess BIT
DECLARE databaseCursor CURSOR FOR
SELECT name FROM sys.databases
OPEN databaseCursor

FETCH databaseCursor INTO @name
WHILE @@FETCH_STATUS = 0
BEGIN
    IF NOT OBJECT_ID(@name + '..TechnicalParameters') IS NULL
    BEGIN
        SET @query = N'SELECT @versionOut = value FROM ' + @name + N'.dbo.TechnicalParameters WHERE name = ''version'''
        EXEC sp_executesql @query, N'@versionOut NVARCHAR(MAX) OUTPUT', @versionOut = @version OUTPUT
        SET @query = N'SELECT TOP 1 @branchOut = code FROM ' + @name + N'.dbo.Branches'
        EXEC sp_executesql @query, N'@branchOut NVARCHAR(MAX) OUTPUT', @branchOut = @branch OUTPUT
        IF OBJECT_ID(N'dbo.OpenCBSDatabasePermissions', N'U') IS NOT NULL
        BEGIN
            SELECT @total = COUNT(*) FROM dbo.OpenCBSDatabasePermissions WHERE UserName = @userName
            SELECT @count = COUNT(*) FROM dbo.OpenCBSDatabasePermissions WHERE UserName = @userName AND DatabaseName = @name
            IF @total = 0 OR @count = 1
            BEGIN
                INSERT INTO @databases VALUES (@name, @version, @branch)
            END
        END
        ELSE
        BEGIN
            INSERT INTO @databases VALUES (@name, @version, @branch)
        END
    END
    FETCH databaseCursor INTO @name
END

CLOSE databaseCursor
DEALLOCATE databaseCursor

;

WITH fs
AS
(
    SELECT database_id, type, size * 8192 size
    FROM sys.master_files
)

SELECT db.Name, db.Version, db.BranchCode, dbs.DataFileSize, dbs.LogFileSize
FROM @databases db
INNER JOIN 
(
    SELECT
    name,
    (SELECT SUM(size) FROM fs WHERE type = 0 AND fs.database_id = db.database_id) DataFileSize,
    (SELECT SUM(size) FROM fs WHERE type = 1 AND fs.database_id = db.database_id) LogFileSize
    FROM sys.databases db
) dbs ON db.Name = dbs.name

