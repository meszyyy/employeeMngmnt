IF DB_ID(N'EmployeeManagement') IS NULL
    CREATE DATABASE EmployeeManagement;
GO

USE EmployeeManagement;
GO

DROP TABLE IF EXISTS dbo.Employee;
DROP TABLE IF EXISTS dbo.Department;
GO

CREATE TABLE dbo.Department
(
    Id    INT           IDENTITY(1,1) NOT NULL,
    Name  NVARCHAR(100)               NOT NULL,
    CONSTRAINT PK_Department PRIMARY KEY (Id),
    CONSTRAINT UQ_Department_Name UNIQUE (Name)
);
GO

CREATE TABLE dbo.Employee
(
    Id            INT           IDENTITY(1,1) NOT NULL,
    DepartmentId  INT                         NOT NULL,
    FirstName     NVARCHAR(100)               NOT NULL,
    LastName      NVARCHAR(100)               NOT NULL,
    Email         NVARCHAR(320)               NOT NULL,
    EntryDate     DATE                        NOT NULL,
    CONSTRAINT PK_Employee PRIMARY KEY (Id),
    CONSTRAINT UQ_Employee_Email UNIQUE (Email),
    CONSTRAINT FK_Employee_Department FOREIGN KEY (DepartmentId)
        REFERENCES dbo.Department (Id)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION
);
GO

INSERT INTO dbo.Department (Name)
VALUES (N'IT'),
       (N'HR'),
       (N'Marketing'),
       (N'Sales'),
       (N'Finance');
GO

INSERT INTO dbo.Employee (DepartmentId, FirstName, LastName, Email, EntryDate)
SELECT d.Id, v.FirstName, v.LastName, v.Email, v.EntryDate
FROM (VALUES
        (N'IT',        N'John',     N'Doe',        N'john.doe@example.com',        '2019-03-01'),
        (N'IT',        N'Lukas',    N'Gruber',     N'lukas.gruber@example.com',    '2022-01-10'),
        (N'HR',        N'Jane',     N'Smith',      N'jane.smith@example.com',      '2018-11-05'),
        (N'HR',        N'Jürgen',   N'Müller',     N'juergen.mueller@example.com', '2021-04-19'),
        (N'Marketing', N'Alice',    N'Johnson',    N'alice.johnson@example.com',   '2020-07-01'),
        (N'Marketing', N'Lena',     N'Hofer',      N'lena.hofer@example.com',      '2024-10-21'),
        (N'Sales',     N'Bob',      N'Brown',      N'bob.brown@example.com',       '2017-05-22'),
        (N'Sales',     N'Sophie',   N'Weiß',       N'sophie.weiss@example.com',    '2026-01-12')
     ) AS v (DepartmentName, FirstName, LastName, Email, EntryDate)
JOIN dbo.Department d ON d.Name = v.DepartmentName;
GO