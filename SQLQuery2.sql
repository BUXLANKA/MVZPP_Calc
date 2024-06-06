DECLARE @TableName NVARCHAR(128)
DECLARE @SchemaName NVARCHAR(128)
DECLARE @SQL NVARCHAR(MAX)

-- Курсор для перебора всех таблиц с автоинкрементными столбцами
DECLARE TableCursor CURSOR FOR
SELECT s.name AS SchemaName, t.name AS TableName
FROM sys.tables t
JOIN sys.schemas s ON t.schema_id = s.schema_id
JOIN sys.identity_columns ic ON ic.object_id = t.object_id

OPEN TableCursor
FETCH NEXT FROM TableCursor INTO @SchemaName, @TableName

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Формируем SQL-запрос для сброса автоинкремента
    SET @SQL = 'DBCC CHECKIDENT (' + QUOTENAME(@SchemaName + '.' + @TableName) + ', RESEED, 0)'

    -- Выполняем SQL-запрос
    EXEC(@SQL)

    FETCH NEXT FROM TableCursor INTO @SchemaName, @TableName
END

CLOSE TableCursor
DEALLOCATE TableCursor
