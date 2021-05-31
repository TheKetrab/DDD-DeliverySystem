
CREATE OR ALTER PROCEDURE DeleteForeignKeys(@tablename varchar(MAX)) AS
BEGIN

    -- cursor
	DECLARE c_FKeys CURSOR FOR	
        SELECT fk.name FKName FROM sys.tables t
            JOIN sys.foreign_keys fk ON fk.parent_object_id = t.object_id
            WHERE t.name = @tablename
	OPEN c_FKeys
	
	DECLARE @c_FKey nvarchar(100);
	FETCH NEXT FROM c_Fkeys INTO @c_FKey
	WHILE ( @@FETCH_STATUS = 0 )
	BEGIN

        DECLARE @SQL VARCHAR(MAX) =
            'ALTER TABLE ' + @tablename
            + '  DROP CONSTRAINT ' + @c_FKey;

        PRINT @SQL;
        EXEC(@SQL);

		FETCH NEXT FROM c_FKeys INTO @c_FKey
	END

    CLOSE c_FKeys;
	DEALLOCATE c_FKeys;

END

GO

-- drop foreign keys
exec DeleteForeignKeys @tablename = 'Addresses'
exec DeleteForeignKeys @tablename = 'Clients'
exec DeleteForeignKeys @tablename = 'Products'
exec DeleteForeignKeys @tablename = 'Orders'
exec DeleteForeignKeys @tablename = 'OrderLines'
exec DeleteForeignKeys @tablename = 'OrderDetails'
exec DeleteForeignKeys @tablename = 'History'

-- drop tables
DROP TABLE IF EXISTS Nations;
DROP TABLE IF EXISTS Addresses;
DROP TABLE IF EXISTS Clients;
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS OrderLines;
DROP TABLE IF EXISTS OrderDetails;
DROP TABLE IF EXISTS History;

GO