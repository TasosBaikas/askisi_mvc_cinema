USE CINEMA_DB; -- Replace 'YourDatabaseName' with the actual name of your database

-- Create a new table
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Age INT,
    Department NVARCHAR(50)
);