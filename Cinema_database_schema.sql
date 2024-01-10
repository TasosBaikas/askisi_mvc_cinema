
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Cinema_database')
CREATE DATABASE Cinema_database;
GO

USE Cinema_database;
GO

IF SCHEMA_ID('cinema_schema') IS NULL
	EXEC('CREATE SCHEMA cinema_schema');
GO


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('cinema_schema.[USER]') AND type in (N'U'))
CREATE TABLE cinema_schema.[USER] (
    USERNAME VARCHAR(32) PRIMARY KEY,
    EMAIL VARCHAR(32),
    PASSWORD VARCHAR(45),
    CREATE_TIME DATETIME,
    SALT VARCHAR(45),
    ROLE VARCHAR(45)
);
GO


-- Create the MOVIES table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('cinema_schema.MOVIES') AND type in (N'U'))
CREATE TABLE cinema_schema.MOVIES (
    ID INT PRIMARY KEY,
    NAME VARCHAR(45),
    CONTENT VARCHAR(45),
    LENGTH INT,
    TYPE VARCHAR(45),
    SUMMARY VARCHAR(45),
    DIRECTOR VARCHAR(45),
    USER_USERNAME VARCHAR(32), 

	FOREIGN KEY (USER_USERNAME) REFERENCES cinema_schema.[USER](USERNAME)
);
GO

-- Create the CINEMAS table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('cinema_schema.CINEMAS') AND type in (N'U'))
CREATE TABLE cinema_schema.CINEMAS (
    ID INT PRIMARY KEY,
    NAME VARCHAR(45),
    SEATS VARCHAR(45),
    _3D VARCHAR(45) -- Assuming '_3D' is a VARCHAR, it needs to start with an underscore because names cannot start with a number
);
GO

-- Create the PROVOLES table (junction table between MOVIES and CINEMAS)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('cinema_schema.PROVOLES') AND type in (N'U'))
CREATE TABLE cinema_schema.PROVOLES (
    MOVIES_ID INT,
    MOVIES_NAME VARCHAR(45),
    CINEMAS_ID INT,
	USER_USERNAME VARCHAR(32), 

    PRIMARY KEY (MOVIES_ID, CINEMAS_ID),
	FOREIGN KEY (USER_USERNAME) REFERENCES cinema_schema.[USER](USERNAME),
    FOREIGN KEY (MOVIES_ID) REFERENCES cinema_schema.MOVIES(ID),
    FOREIGN KEY (CINEMAS_ID) REFERENCES cinema_schema.CINEMAS(ID)
);
GO

-- Create the RESERVATIONS table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('cinema_schema.RESERVATIONS') AND type in (N'U'))
CREATE TABLE cinema_schema.RESERVATIONS (
    PROVOLES_MOVIES_ID INT,
    PROVOLES_MOVIES_NAME VARCHAR(45),
    PROVOLES_CINEMAS_ID INT,
    CUSTOMERS_ID INT,
    NUMBER_OF_SEATS INT,
    USER_USERNAME VARCHAR(32), 

	FOREIGN KEY (USER_USERNAME) REFERENCES cinema_schema.[USER](USERNAME),
    FOREIGN KEY (PROVOLES_MOVIES_ID, PROVOLES_CINEMAS_ID) REFERENCES cinema_schema.PROVOLES(MOVIES_ID, CINEMAS_ID)
    -- Assuming there's a CUSTOMERS table to link CUSTOMERS_ID
);
GO
