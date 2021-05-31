
CREATE OR ALTER PROCEDURE DeleteForeignKeys(@tablename varchar(MAX)) AS
BEGIN

    DECLARE @constraint nvarchar(MAX) = CONCAT('FK__',@tablename,'__%');

    -- cursor
	DECLARE c_FKeys CURSOR FOR		
		SELECT name FROM sys.foreign_keys WHERE name LIKE @constraint
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

-- entities
CREATE TABLE Nations (
    -- 4 + 60 = 64
    Id              INT IDENTITY(1,1) PRIMARY KEY,
    Name            VARCHAR(60) NOT NULL
);

CREATE TABLE Addresses (
    Id              INT IDENTITY(1,1) PRIMARY KEY,
    NationId        INT NOT NULL DEFAULT 1,
    City            VARCHAR(128) NOT NULL,
    Street          VARCHAR(128),
    Nr              VARCHAR(64) NOT NULL,
    ZipCode         VARCHAR(16) NOT NULL,

    FOREIGN KEY (NationId) REFERENCES Nations(Id),
);

CREATE TABLE Clients (
    Id              INT IDENTITY(1,1) PRIMARY KEY,
    Name            VARCHAR(128) NOT NULL,
    Email           VARCHAR(128) NOT NULL UNIQUE,
    Hash            VARCHAR(64),
    Role            VARCHAR(64),
    AddressId       INT,
    Phone           VARCHAR(64) NOT NULL,

    FOREIGN KEY (AddressId) REFERENCES Addresses(Id),
    CONSTRAINT CK_Client_NameNotEmpty CHECK (LEN(Name) >= 5)
);

CREATE TABLE Products (
    Id              INT IDENTITY(1,1) PRIMARY KEY,
    Name            VARCHAR(64) NOT NULL,
    DeliveryCost    MONEY NOT NULL,
    Weight          FLOAT NOT NULL,
    Description     VARCHAR(4096),

    CONSTRAINT CK_Product_NameNotEmpty CHECK (LEN(Name) > 3)
);

CREATE TABLE Orders (
    Id                  INT IDENTITY(1,1) PRIMARY KEY,
    DeliveryAddressId   INT NOT NULL,
    OwnerId             INT NOT NULL,
    Status              VARCHAR(64) NOT NULL,
    LatestDate          DATETIME,

    FOREIGN KEY (DeliveryAddressId) REFERENCES Addresses(Id),
    FOREIGN KEY (OwnerId) REFERENCES Clients(Id)
);

CREATE TABLE OrderLines (
    Id                  INT IDENTITY(1,1) PRIMARY KEY,
    ProductId           INT NOT NULL,
    Quantity            INT NOT NULL DEFAULT 1,
    Bonus               MONEY NOT NULL DEFAULT 0,

    FOREIGN KEY (ProductId) REFERENCES Products(Id)
);

CREATE TABLE OrderDetails (
    Id                  INT IDENTITY(1,1) PRIMARY KEY,
    OrderId             INT NOT NULL,
    OrderLineId         INT NOT NULL,

    FOREIGN KEY (OrderId) REFERENCES Orders(Id),
    FOREIGN KEY (OrderLineId) REFERENCES OrderLines(Id)
)


CREATE TABLE History (
    Id              INT IDENTITY(1,1) PRIMARY KEY,
    ClientId        INT NOT NULL,
    OrderId         INT NOT NULL,
    Action          VARCHAR(64),
    Description     VARCHAR(3000),
    Time            DATETIME NOT NULL DEFAULT GETDATE(),

    FOREIGN KEY (ClientId) REFERENCES Clients(Id),
    FOREIGN KEY (OrderId) REFERENCES Orders(Id)
);

