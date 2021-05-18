
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

DROP TABLE IF EXISTS ClientRole;
DROP TABLE IF EXISTS OrderStatus;
DROP TABLE IF EXISTS OrderAction;

GO

-- enums as tables -> normalized
CREATE TABLE ClientRole (
    Id              INT PRIMARY KEY,
    Role            VARCHAR(20) NOT NULL UNIQUE
);

INSERT INTO ClientRole(Id,Role) VALUES
    (1, 'Admin'),
    (2, 'Moderator'),
    (3, 'User'),
    (4, 'PremiumUser')

CREATE TABLE OrderStatus (
    Id              INT PRIMARY KEY,
    Status          VARCHAR(20) NOT NULL UNIQUE
);

INSERT INTO OrderStatus(Id,Status) VALUES
    (1, 'Inactive'),
    (2, 'WaitingForPayment'),
    (3, 'Paid'),
    (4, 'Sent'),
    (5, 'Delivered'),
    (6, 'Canceled')

CREATE TABLE OrderAction (
    Id              INT PRIMARY KEY,
    Action          VARCHAR(20) NOT NULL UNIQUE
);

INSERT INTO OrderAction(Id,Action) VALUES
    (1, 'Create'),
    (2, 'Pay'),
    (3, 'Cancel'),
    (4, 'Delete'),
    (5, 'Deliver')

GO

-- entities
CREATE TABLE Nations (
    Id              INT IDENTITY(1,1) PRIMARY KEY,
    Name            VARCHAR(100) NOT NULL
);

CREATE TABLE Addresses (
    Id              INT IDENTITY(1,1) PRIMARY KEY,
    NationId        INT NOT NULL DEFAULT 1,
    City            VARCHAR(100) NOT NULL,
    Street          VARCHAR(100),
    Nr              VARCHAR(100) NOT NULL,
    ZipCode         VARCHAR(100) NOT NULL,

    FOREIGN KEY (NationId) REFERENCES Nations(Id),
);



CREATE TABLE Clients (
    Id              INT IDENTITY(1,1) PRIMARY KEY,
    Name            VARCHAR(100) NOT NULL,
    Email           VARCHAR(100) NOT NULL UNIQUE,
    Hash            VARCHAR(50),
    Role            INT,
    AddressId       INT,
    Phone           VARCHAR(100) NOT NULL

    FOREIGN KEY (Role) REFERENCES ClientRole(Id),
    FOREIGN KEY (AddressId) REFERENCES Addresses(Id),
    CONSTRAINT CK_Client_NameNotEmpty CHECK (LEN(Name) >= 5)
);


CREATE TABLE Products (
    Id              INT IDENTITY(1,1) PRIMARY KEY,
    Name            VARCHAR(100) NOT NULL,
    DeliveryCost    MONEY NOT NULL,
    Weight          FLOAT NOT NULL,
    Description     VARCHAR(3000),

    CONSTRAINT CK_Product_NameNotEmpty CHECK (LEN(Name) > 3)
);



CREATE TABLE Orders (
    Id                  INT IDENTITY(1,1) PRIMARY KEY,
    DeliveryAddressId   INT NOT NULL,
    OwnerId             INT NOT NULL,
    Status              INT NOT NULL,
    LatestDate          DATETIME,

    FOREIGN KEY (DeliveryAddressId) REFERENCES Addresses(Id),
    FOREIGN KEY (OwnerId) REFERENCES Clients(Id),
    FOREIGN KEY (Status) REFERENCES OrderStatus(Id)
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
    Action          INT NOT NULL,
    Description     VARCHAR(3000),
    Time            DATETIME NOT NULL DEFAULT GETDATE(),

    FOREIGN KEY (ClientId) REFERENCES Clients(Id),
    FOREIGN KEY (OrderId) REFERENCES Orders(Id),
    FOREIGN KEY (Action) REFERENCES OrderAction(Id)
);

