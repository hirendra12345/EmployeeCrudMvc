IF DB_ID(N'EmployeeCrudMvcDb') IS NULL
    CREATE DATABASE EmployeeCrudMvcDb;
GO

USE EmployeeCrudMvcDb;
GO

IF OBJECT_ID(N'dbo.Employees', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Employees
    (
        Id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Employees PRIMARY KEY,
        FirstName NVARCHAR(80) NOT NULL,
        LastName NVARCHAR(80) NOT NULL,
        Email NVARCHAR(150) NOT NULL,
        Department NVARCHAR(100) NOT NULL,
        Salary DECIMAL(18,2) NOT NULL,
        JoiningDate DATETIME2 NOT NULL
    );
END;
GO
