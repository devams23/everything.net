---------------------------------------------------------------------------------
CREATE OR ALTER FUNCTION empFnGetTotalExpinYears (@DateofJoining DATE)
RETURNS DECIMAL (4,1)
AS
BEGIN
    
    DECLARE @YOEinYears DECIMAL(4,1);
    SET @YOEinYears = DATEDIFF(MONTH,@DateofJoining, GETDATE()) / 12.0 ;
    RETURN @YOEinYears ;
END;

DECLARE @JoiningDate DATE = '1890-03-11'
select  dbo.empFnGetTotalExpinYears(@JoiningDate);

---------------------------------------------------------------------------------
CREATE OR ALTER FUNCTION GetEmpinDepartment (@DepartmentId VARCHAR(50))
RETURNS TABLE
AS
RETURN
(
    SELECT 
        *,
        
        CASE
            WHEN dbo.empFnGetTotalExpinYears(DateOfJoining) > 5 
                THEN 'YES'
            ELSE 'NO'
        END AS IsSeniorEmployee
    FROM Employee 
    WHERE Department = @DepartmentId
);

select * from GetEmpinDepartment('Engineering');

---------------------------------------------------------------------------------

/*we can use EXISTS, here and do manual checking to know if the email exists or not,but its not a 
good uproach, 
instead a better uproaach is add a UNIQUE constraint, and using try catch to insert the values.
*/

ALTER TABLE Employee
ADD CONSTRAINT UQ_Employee_Email UNIQUE (Email);



CREATE OR ALTER PROCEDURE sp_InsertNewEmployee
    @EmployeeID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Email VARCHAR(100),
    @Department VARCHAR(50),
    @Salary DECIMAL(10,2),
    @DateOfJoining DATE
AS
BEGIN
    BEGIN TRY
        INSERT INTO Employee
        VALUES
        (
            @EmployeeID,
            @FirstName,
            @LastName,
            @Email,
            @Department,
            @Salary,
            @DateOfJoining
        )

        RETURN 'ADDED EMPLOYEE DATA' ;
    END TRY
    BEGIN CATCH
        RETURN ERROR_MESSAGE();
    END CATCH
END



DECLARE @Result VARCHAR(50);
EXECUTE @Result =  sp_InsertNewEmployee 52, 'Devam', 'Satasiya', 'devam.satasiyaa' , 'Engineering', 320000, '2026-02-11' 

SELECT @Result as Result;


---------------------------------------------------------------------------------
CREATE FUNCTION fn_EmployeeMonths
(
    @StartDate DATE,
    @EndDate DATE
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        EmployeeId,
        Department,
        Salary,
        CASE
            WHEN DateOfJoining > @EndDate THEN 0
            WHEN DateOfJoining < @StartDate 
                THEN DATEDIFF(MONTH, @StartDate, @EndDate)
            ELSE 
                DATEDIFF(MONTH, DateOfJoining, @EndDate)
        END AS TotalMonths
    FROM Employee
);

CREATE OR ALTER PROCEDURE sp_TotalSalaryPerDepartment
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT 
        Department,
        SUM(Salary * TotalMonths) AS TotalSalary
    FROM dbo.fn_EmployeeMonths(@StartDate, @EndDate)
    GROUP BY Department
    ORDER BY TotalSalary DESC;
END



EXEC dbo.sp_TotalSalaryPerDepartment '2022-11-20' , '2025-11-20'

---------------------------------------------------------------------------------   

CREATE TRIGGER TR_Orders_Insert
ON Orders
AFTER INSERT
AS
BEGIN
    INSERT INTO OrderAudit (OrderId, InsertedDate, InsertedBy)
    SELECT 
        i.OrderId,
        SYSDATETIME(),
        SUSER_SNAME()
    FROM INSERTED i;
END;


INSERT INTO Orders  VALUES ('fdss234', SYSDATETIME() , 'devam')

select * from OrderAudit


---------------------------------------------------------------------------------