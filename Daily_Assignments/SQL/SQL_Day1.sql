
--1. Write a SQL query to retrieve the TOP 5 highest-paid employees. Ensure the result is correct by applying proper ordering.

/*SELECT * FROM Employee
ORDER BY Salary DESC
OFFSET 0 ROWS
FETCH FIRST 5 ROWS ONLY;
*/


SELECT TOP 5 * FROM Employee
ORDER BY Salary Desc;

--2. Write a query to fetch DISTINCT department names from the Employee table where the department name starts with the letter 'S'.

SELECT DISTINCT(Department) From Employee
WHERE Department Like 'S_%';


--3. Write a query to retrieve employees whose Department is IN ('HR', 'Finance', 'IT') AND whose Salary is greater than 50,000.

SELECT * FROM Employee
WHERE Department IN ('HR', 'Finance', 'IT') AND (Salary > 50000);

--4. Write a query to retrieve employees who belong to the 'Sales' department OR have a Salary greater than 75,000. Explain your filtering logic using SQL comments.
	/* Logic - Using Logical Operator -- OR , we are checking if any of the condition matches 
	then take that row, also we can use IN or = to check for department.
	*/
SELECT * FROM Employee
WHERE Department IN ('SALES') OR Salary > 75000;

--5 Write a query to find all employees whose Email contains their FirstName anywhere in the email using the LIKE operator.

SELECT * From Employee
WHERE Email Like '%' + FirstName+ '%';

--6. Write a query to display employees ordered by DateOfJoining (oldest first) and return rows 6 to 10 using OFFSET FETCH.
SELECT * FROM Employee 
ORDER BY DateOfJoining ASC
OFFSET 5 ROWS
FETCH NEXT 5 ROWS ONLY;  -- we can also use NEXT

/*
7. Write a query to retrieve employees where:
 - Department is 'IT' AND Salary is greater than 60,000
 OR
 - Department is 'HR' AND DateOfJoining is before '2020-01-01'

 Use parentheses correctly to control logical precedence.
 
 */

 SELECT * FROM Employee
 WHERE (Department = 'IT' AND Salary > 60000 ) OR ( Department = 'IT' AND DateOfJoining < '2020-01-01'); 

