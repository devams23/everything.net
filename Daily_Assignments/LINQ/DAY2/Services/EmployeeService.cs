using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LINQ.DAY2.Models;
namespace LINQ.DAY2.Services
{
    internal class EmployeeService
    {
        List<Employee> employees;
        List<Department> departments;
        public EmployeeService()
        {
            employees = new List<Employee>()
            {
                new Employee(){ EmployeeID=101, Name="Manohar", DepartmentId ="1", Salary=25000 , City = "Hyderabad" },
                new Employee(){ EmployeeID=102, Name="Baldev", DepartmentId ="2", Salary=55000 , City = "Bangalore" },
                new Employee(){ EmployeeID=103, Name="Chaitanya", DepartmentId ="3", Salary=70000 , City = "Ahmedabad" },
                new Employee(){ EmployeeID=104, Name="Devanshi", DepartmentId ="2", Salary=30000 , City = "Ahmedabad" },
                new Employee(){ EmployeeID=105, Name="Devam", DepartmentId ="3", Salary=5000 , City = "Chennai" },
                new Employee(){ EmployeeID=106, Name="Eshwar", DepartmentId ="1", Salary=65000 , City = "Mumbai" },
                new Employee(){ EmployeeID=107, Name="Farhan", DepartmentId ="4", Salary=45000 , City = "Pune" },

            };
            departments = new List<Department>()
            {
                new Department(){ DepartmentId="1", DepartmentName="IT" },
                new Department(){ DepartmentId="2", DepartmentName="HR" },
                new Department(){ DepartmentId="3", DepartmentName="Finance" },
                new Department(){ DepartmentId="4", DepartmentName="Marketing" },
            };
        }


        public void TASK1()
        {
            /*  LINQ Functions : Average(), Max(), Min(), Sum()
             * 
             * Average() will calculate the average of a numeric sequence, based on a the selector function provided.
             * Max() will return the maximum value from a numeric sequence, based on a the selector function provided.
             * Min() will return the minimum value from a numeric sequence, based on a the selector function provided.
             * 
             * Sum() will calculate the sum of a numeric sequence, based on a the selector function provided.
             */

            double MaxSalary = employees.Max(employee => employee.Salary);
            double MinSalary = employees.Min(employee => employee.Salary);
            double AvgSalary = employees.Average(employee => employee.Salary);
            double TotalSalary = employees.Sum(employee => employee.Salary);

            Console.WriteLine("---------------Salary Statistics:---------------------");
            Console.WriteLine($"Maximum Salary: {MaxSalary}");
            Console.WriteLine($"Minimum Salary: {MinSalary}");
            Console.WriteLine($"Average Salary: {AvgSalary}");
            Console.WriteLine($"Total Salary: {TotalSalary}");

            /*without using JOINS
             GROUP BY- this will group the employees by their department ID ,
            and store it in the form of key-value pairs , here key is the department ID , 
            and value is the collection of employees, but we are customizing the result to have key and count as
            new value */
            var DepartmentGroup = employees.GroupBy(
                        employee => employee.DepartmentId, // this is the key by which grouping is done
                                /*
                                 * here i will get the custom new result of key,value
                                 *  instead of the built in IEnumerable<IGrouping<TKey,TSource>>*/
                                (key, group) => new
                                { key, Count = group.Count() });

            /* 
             * using method chaining, to first join the table, and then use GroupBy, which 
             * will group the data by departmentName
            */
            var DepartmentNamesGroup = employees
                                        .Join(departments,   // table to join with
                                        employee => employee.DepartmentId,  // key from first table
                                        department => department.DepartmentId, // key from second table
                                        (employee, department) => new   
                                        {
                                            employeeName = employee.Name,
                                            departmentName = department.DepartmentName, // the new data passed to other method
                                        })
                                        .GroupBy(department => department.departmentName,
                                                    (key, group) => new
                                                    { DepartmentName = key, Count = group.Count() });


            Console.WriteLine("---------------DEPARTMENT COUNTS :---------------------");

            foreach (var item in DepartmentNamesGroup)
            {
                Console.WriteLine("Department : " + item.DepartmentName);
                Console.WriteLine("Count: " + item.Count);




            }
        }
        public void TASK2()
        {
            /*
             * the equals keyword is used in LINQ query syntax to specify the join condition between two sequences.
             * and the select keyword is used to project the result of a LINQ query into a new form.
             */

            var DepartmentNamesGroup = from emp in employees
                                       join dep in departments on emp.DepartmentId equals dep.DepartmentId

                                       select new
                                       {
                                           EmployeeName = emp.Name,
                                           Department = dep.DepartmentName,

                                       };

            var DepartmentEmployees = employees
                            .Join(departments,
                            employee => employee.DepartmentId,
                            department => department.DepartmentId,
                            (employee, department) => new
                            {
                                employeeName = employee.Name,
                                departmentName = department.DepartmentName,

                                // the new data passed to other method
                            })
                            .GroupBy(emp => emp.departmentName);

            Console.WriteLine("---------------  employee with their department name -----------------");
            foreach (var item in DepartmentNamesGroup)
            {
                Console.WriteLine(item.EmployeeName + " --> " + item.Department);
                //Console.WriteLine(item.Department);


                Console.WriteLine("------------------------");
            }
            Console.WriteLine("--------------- DEPARTMENT WITH ALL EMPLOYEES -----------------");
            foreach (var item in DepartmentEmployees)
            {
                Console.WriteLine("DEPARTMENT: " + item.Key);
                foreach (var item1 in item)
                {

                    Console.WriteLine("--" + item1.employeeName);
                }
            }
        }

        public void Task3()
        {
            /* GROUP BY with JOIN
             * 
             * here we are joining two tables employees and departments
             * based on departmentId, then we are grouping the result based on departmentName
             * and then calculating average salary and count of employees in each department
             */
            var DepartmentStats = employees
                                    .Join(departments,
                                    employee => employee.DepartmentId,
                                    depatment => depatment.DepartmentId,
                                    (emp, dep) => new { empSalary = emp.Salary, empDep = dep.DepartmentName })
                                    .GroupBy(
                                    employee => employee.empDep,
                                    (key, empList) => new
                                    {
                                        DepartmentName = key,
                                        AverageSalary = empList.Average(emp => emp.empSalary),
                                        Count = empList.Count()
                                    });


            Console.WriteLine("--------------- DEPARTMENT AVG.SALARY & COUNT -----------------");
            foreach (var item in DepartmentStats)
            {
                Console.WriteLine("DEPARTMENT: " + item.DepartmentName);
                Console.WriteLine("AVERAGE SALARY: " + item.AverageSalary);
                Console.WriteLine("Count: " + item.Count);
                Console.WriteLine("----------------------------");

            }


        }

        public void Task4()
        {
            /* FILTERING BASED ON AGGREGATE FUNCTIONS
             * 
             * here we are filtering employees whose salary is greater than average salary of all employees
             * and also filtering employees whose salary is greater than maximum salary of HR department
             * 
             */

            Console.WriteLine("--------------- EMPLOYEES With Salary > Avg. Salary -----------------");


            //var AverageSalary = employees.Average(emp => emp.Salary);
            var EmployeesGreaterThanAverage = employees.Where(emp => emp.Salary > employees.Average(emp => emp.Salary));
            var EmpoyeesHavingSalaryGreaterHR = employees.Where(emp => emp.Salary > employees
                                                                .Where(emp => emp.DepartmentId == "2").Max(emp => emp.Salary));
            
            
            
            //var EmployeesGreaterThanAverageQuery = from emp in employees
            //                              where emp.Salary >
            //                              (
            //                              from empnew in employees
            //                              select emp.Salary)
            //                              .Average()
            //                              select emp;

            foreach (var item in EmployeesGreaterThanAverage)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("--------------- EMPLOYEES With Salary > MAX. HR-DEPartment. SALARY -----------------");


            foreach (var item in EmpoyeesHavingSalaryGreaterHR)
            {
                Console.WriteLine(item.Name);
            }

        }

        public void Task5()
        {
            /* SET OPERATIONS: UNION, INTERSECT, EXCEPT
             * 
             * UNION: combines two sequences and returns distinct elements from both sequences.
             * INTERSECT: returns only the elements that are present in both sequences.
             * EXCEPT: returns the elements that are present in the first sequence but not in the second sequence.
             * INTERSECTBY: compares two sequences based on a specified key selector function and returns the elements from the first sequence that have matching keys in the second sequence.
             * 
             */

            Console.WriteLine("--------------- SET  OPERATIONS-----------------");
            List<int> numbers1 = new List<int>() { 1, 2, 3, 4, 5,6 ,6};
            List<int> numbers2 = new List<int>() { 4, 5, 6, 7, 8 };
            // here 
            var intersectNumbers = numbers1.Intersect(numbers2);
            var exceptNumbers = numbers1.Except(numbers2);
            // this will compare numbers1 with numbers2 after adding 1 to each element of numbers2, 
            // and return
            var intersectByNumbers = numbers1.IntersectBy(numbers2, num => num + 1);


            
            var unionDistinctNumbers = numbers1.Union(numbers2);
            Console.WriteLine("--------------- UNION -----------------");
            foreach (var item in unionDistinctNumbers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------- EXCEPT -----------------");
            foreach (var item in exceptNumbers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------- INTERSECT -----------------");
            foreach (var item in intersectNumbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
