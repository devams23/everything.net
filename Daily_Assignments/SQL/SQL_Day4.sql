-- 1. Departments Table
CREATE TABLE Departments (
    DepartmentId INT IDENTITY(1,1) PRIMARY KEY,
    DepartmentName VARCHAR(100) NOT NULL UNIQUE
);

-- 2. Employees Table
CREATE TABLE Employees (
    EmployeeId INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Salary DECIMAL(10,2) CHECK (Salary > 15000),
    HireDate DATE,
    DepartmentId INT,
    CONSTRAINT FK_Employees_Departments
        FOREIGN KEY (DepartmentId)
        REFERENCES Departments(DepartmentId)
);


-- Alter Table & Comstraint

ALTER TABLE   Employees
ADD Email VARCHAR(50) NOT NULL UNIQUE;


ALTER TABLE Employees
ADD CONSTRAINT CHK_Employees_Status CHECK (IsActive IN (1,0))

ALTER TABLE Employees
ADD CONSTRAINT CHK_Employees_HireDate CHECK (HireDate <= GETDATE())
GO

ALTER TABLE Employees
ALTER COLUMN Salary DECIMAL(10,2) NOT NULL;


---DML 
-- Insert Departments
INSERT INTO Departments (DepartmentName) VALUES
('Human Resources'),
('IT'),
('Finance'),
('Marketing');

-- Insert Employees


INSERT INTO Employees (Name, Salary, HireDate, DepartmentId) VALUES
('John Smith', 25000, '2022-03-15', 1),
('Alice Johnson', 32000, '2021-07-10', 2),
('Robert Brown', 28000, '2023-01-20', 3),
('Emily Davis', 35000, '2020-11-05', 2),
('Michael Wilson', 22000, '2022-09-18', 4),
('Jay Smith', 25000, '2022-03-15', 1),
('Alok Johnson', 32000, '2021-07-10', 2),
('Rabdi Brown', 28000, '2023-01-20', 3),
('Enish Davis', 35000, '2020-11-05', 2),
('Mann Wilson', 22000, '2022-09-18', 4),
('Jasprit Patel', 25000, '2022-03-15', 1),
('Ajay Johnson', 32000, '2021-07-10', 2),
('Rudra Brown', 28000, '2023-01-20', 3),
('Estva Davis', 35000, '2020-11-05', 2),
('Vatsal Wilson', 22000, '2022-09-18', 4);




--Increase the salary of employees in one department by 5%.

DECLARE @DEPID INT = 2;
UPDATE Employees
SET Salary = Salary + 0.05*Salary
WHERE DepartmentId = @DEPID;

--Deactivate employees hired before a specific date.

DECLARE @EXP_DATE DATE = '2022-01-01';
UPDATE Employees
SET IsActive = 0
WHERE HireDate < @EXP_DATE;

------ Delete employees who are marked inactive
DELETE FROM Employees
WHERE IsActive = 0;

----Transfer 2 employees from one department to another


UPDATE Employees
SET DepartmentId = 3
WHERE EmployeeId in (1,5);


select * from employees;


-----JOINS---

---Show employees with department names
SELECT emp.Name , dep.DepartmentName FROM Employees emp
JOIN Departments dep ON emp.DepartmentId = dep.DepartmentId

select * from Departments

---Show departments with no employees
SELECT  dep.DepartmentName FROM Employees emp
RIGHT JOIN Departments dep ON emp.DepartmentId = dep.DepartmentId
GROUP BY dep.DepartmentName 
HAVING Count(Name) = 0

----Show highest salary in each department
SELECT MAX(emp.Salary) MaxSalary ,dep.DepartmentName FROM Employees emp
RIGHT JOIN Departments dep ON emp.DepartmentId = dep.DepartmentId
GROUP BY dep.DepartmentName
ORDER BY MAX(emp.Salary);
