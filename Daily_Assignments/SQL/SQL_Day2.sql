/*
Create a view named vw_EmployeeBasicInfo that displays:
EmployeeID
EmployeeName
DepartmentID
*/

CREATE OR ALTER VIEW vw_EmployeeBasicInfo AS 
SELECT EmployeeID,
FirstName ,
Department
FROM Employee
--ORDER BY Department;    can't use ORDER BY in view

SELECT Department , Count(Department) as Countdep FROM vw_EmployeeBasicInfo
GROUP BY Department;
/*
Create a CTE that fetches only Finance department employees
and then select data from that CTE.
*/

WITH FinanceEmp AS 
(
SELECT EmployeeID,
FirstName ,
Department FROM Employee
WHERE Department = 'Finance'

),
SortedFinaceEmp AS (
SELECT * FROM F6inanceEmp
WHERE EmployeeId = 29 
)


SELECT * FROM SortedFinaceEmp;


/*
Create a local temporary table that stores only HR employees and select data from TempTable.
*/

SELECT *  INTO #HREmpTable FROM Employee
WHERE Department = 'HR'

SELECT * FROM  #HREmpTable;

/*
Create an Employee Table with appropriate columns.
Create a Skill Table with  appropriate columns.
Write a query to fetch employees who have more than one entry in EmployeeSkill.
*/

CREATE TABLE EmployeeSkill (
    SkillId INT PRIMARY KEY,
    SkillName VARCHAR(50),
    EmployeeId INT CHECK (EmployeeId BETWEEN 1 AND 50)
);
INSERT INTO EmployeeSkill (SkillId, SkillName, EmployeeId)
VALUES
(1, 'Accounting', 18),
(2, 'Financial Analysis', 7),
(3, 'SQL', 12),
(4, 'Excel', 18),
(5, 'Budgeting', 21),
(6, 'Auditing', 25),
(7, 'Python', 29),
(8, 'Reporting', 34),
(9, 'Risk Management', 41),
(10, 'Data Analysis', 29);

WITH MultipleSkillsEmpId AS (
SELECT EmployeeId FROM EmployeeSkill
GROUP BY EmployeeId 
HAVING Count(EmployeeId) > 1
)

SELECT * FROM Employee
WHERE EmployeeID in (SELECT * FROM MultipleSkillsEmpId)



 

/*
Define primary key, foreign key and unique key for tables.
*/


ALTER TABLE EmployeeSkill
ADD CONSTRAINT FK_EmployeeSkill_Employee
FOREIGN KEY (EmployeeId)
REFERENCES Employee(EmployeeId);


ALTER TABLE EmployeeSkill
ADD CONSTRAINT PK_EmployeeSkill
PRIMARY KEY (EmployeeId, SkillId);

ALTER TABLE EmployeeSkill
ADD CONSTRAINT UQ_SkillName
UNIQUE (SkillName);


