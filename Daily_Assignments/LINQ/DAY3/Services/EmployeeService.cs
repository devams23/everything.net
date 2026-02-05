using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;
using LINQ.DAY3.Models;
namespace LINQ.DAY3.Services
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
                new Department(){ DepartmentId="5", DepartmentName="Networking" },
            };
        }


        public void TASK1()
        {
            /*  OBSERVATIONS -DEFERRED EXECUTION :
             * 
                Here the filteremployees variable is assigned a LINQ query that filters the employees based on their salary, 
            but the query is not executed immediately, instead it is deferred until we iterate over the filteremployees variable using a foreach loop, or 
            we use any other method that forces the execution of the query, such as ToList(), ToArray(), Count(), etc.
  
             */

            var filteremployees = employees.Where(emp => emp.Salary > 30000);

            // ADDING A NEW EMPLOYEE WITH SALARY 50000
            employees.Add(new Employee() { EmployeeID = 108, Name = "Gautam", DepartmentId = "1", Salary = 50000, City = "Delhi" });



            Console.WriteLine("---------------TASK-1 DEFERRED EXECUTION :---------------------");

            foreach (var item in filteremployees)
            {
                Console.WriteLine("Department : " + item.DepartmentId);
                Console.WriteLine("Count: " + item.Salary);




            }
        }
        public void TASK2()
        {
            /*
             * LINQ FUNCTIONS USED: JOIN, GROUPBY
             * using JOIN to combine two sequences based on a common key, 
             * AND GROUPBY to group the result based on a specified key.
             * the equals keyword is used in LINQ query syntax to specify the join condition between two sequences.
             * and the select keyword is used to project the result of a LINQ query into a new form.
             */


            Console.WriteLine("---------------  TASK 2 -----------------");
            //foreach (var item in DepartmentNamesGroup)
            //{
            //    Console.WriteLine(item.EmployeeName + " --> " + item.Department);
            //    //Console.WriteLine(item.Department);


            //    Console.WriteLine("------------------------");
            //}

        }


        public void Task4()
        {
            Console.WriteLine("--------------- EMPLOYEES COUNT IN EACH DEPARTMENT -----------------");

            /*
             * WHY GROUPJOIN -- >
                    here the execution type is DEFERRED execution, because we are not executing the query immediately, instead we are just 
                    defining the query, and it will execute when we iterate over the result.
                <===>CORRECT FLOW -----> Immediate execution per group

             */
            var EmployeesGreaterThanAverageQuery = departments.GroupJoin(employees,

                dep => dep.DepartmentId,
                emp => emp.DepartmentId,
                (department, empGroup) => new
                {
                    department.DepartmentName,
                    Count = empGroup.Count()
                });
            //.SelectMany(emp => emp.empGroup.DefaultIfEmpty() , (department,emp)=> new {department.DepartmentName , emp = emp}




            //foreach (var item in EmployeesGreaterThanAverageQuery)
            //{
            //    Console.WriteLine(item.emp?.Name);
            //    Console.WriteLine(item.DepartmentName);

            //}
            foreach (var item in EmployeesGreaterThanAverageQuery)
            {

                Console.WriteLine(item.DepartmentName + "--->" + item.Count);
            }

        }

        public void Task5()
        {
            /* IEnumerable and IQueryable
             * The major difference between IEnumerable and IQueryable is that IEnumerable is used for in-memory collections,
             * while IQueryable is used for querying data from out-of-memory sources, such as databases or remote services.
             * we can Use Include method with IQueryable to perform eager loading of related entities from the database.
             * So, If I write a body in IQueryable, it will not execute until I enumerate it, and when I enumerate it, it will execute the query against the data source,
             */

            var GreaterThan30K = employees.Where(emp => emp.Salary > 30000);

            IQueryable<Employee> queryableNumbers = employees.AsQueryable();
                    
            var GreaterThan30KQuery = queryableNumbers.Where(emp =>

                 emp.Salary > 30000);


            Console.WriteLine("---------------------USING ENUMERABLE (Salary > 30000)---------------------");

            foreach (var item in GreaterThan30K)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("---------------------USING QUERYABLE (Salary > 30000)------------------------");
            foreach (var item in GreaterThan30KQuery)
            {
                Console.WriteLine(item.Name);

            }
        }

        public void Task6()
        {
            /* THE N+1 PRPBLEM:
                this problem occurs when an application needs to retrieve related data from a database, and it does so by executing one query to fetch the main data (the "1" query) and then executes additional queries (the "N" queries) for each related item,
                resulting in poor performance and increased load on the database.
                

            here we are fetching the employees and departments separately, and then we are using nested loops to match the department names with the employees, which results in N+1 queries, where N is the number of employees, and 1 is the initial query to fetch the employees.
        

            SOLUTION:
                instead we can use JOINS, that offer better performance by fetching related data in a single query, reducing the number of database round-trips and improving overall efficiency.
            */

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine("--------------- EMPLOYEES WITH DEPARTMENT NAMES (USING n+1 queries) -----------------");
            foreach (var emp in employees)
            {
                string currentempDeptId = emp.DepartmentId;
                foreach (var dep in departments)
                {
                    if (dep.DepartmentId == currentempDeptId)
                    {
                        Console.WriteLine($"Employee: {emp.Name}, Department: {dep.DepartmentName}");
                    }
                }
            }

            stopwatch.Stop();
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine($"Time taken using N+1 queries: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine("-------------------------------------------------------------------");

            stopwatch.Reset();
            stopwatch.Start();


            Console.WriteLine("--------------- EMPLOYEES WITH DEPARTMENT NAMES (USING SINGLE QUERY ) -----------------");
            var EmployeeWithDepartment = from dep in departments
                                         join emp in employees
                                         on dep.DepartmentId equals emp.DepartmentId
                                         select new
                                         {
                                             emp.Name,
                                             dep.DepartmentName
                                         };

            stopwatch.Stop();
            Console.WriteLine("-------------------------------------------------------------------");

            Console.WriteLine($"Time taken using Single Query: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine("-------------------------------------------------------------------");

            foreach (var item in EmployeeWithDepartment)
            {
                Console.WriteLine($"Employee: {item.Name}, Department: {item.DepartmentName}");
            }
        }

        public void Task8()
        {
            /*  ToDictionary is a LINQ extension method that creates a Dictionary<TKey, TValue> from an IEnumerable<T> 
             *  by using specified key selector and element selector functions,
             *  it is an immediate because it has a specified key selector and element selector functions,
             *  so it will execute immediately and create a dictionary based on the provided selectors.
             */
            var employeeDict = employees.ToDictionary(employee => employee.EmployeeID, employee => employee.Name);

            foreach (var emp in employeeDict)
            {
                Console.WriteLine($"Employee ID: {emp.Key}");
                Console.WriteLine($"Employee Name: {emp.Value}");
            }
        }

        public void Task9()
        {
            /* WHAT HAPPENS UNDER THE HOOD?
                so, here we are just saving the query, we are not executing it, (deferred execution),
                so, when we update or modify the original collection, the query will reflect those changes when we iterate over it, 
                and we will get the updated results.
            */
            Console.WriteLine("--------------- EMPLOYEES IN IT,  -----------------");
            var ITEmployees = employees.Where(emp => emp.DepartmentId == "1")
                                   .Select(emp => new { emp.Name, emp.Salary });

            foreach (var emp in ITEmployees)
            {
                Console.WriteLine($"Employee Name: {emp.Name}, Salary: {emp.Salary}");
            }

            // employ

            employees[0].DepartmentId = "2";
            Console.WriteLine("----After modifying the original collection:----");
            Console.WriteLine("--------------- EMPLOYEES IN IT,  -----------------");
            foreach (var emp in ITEmployees)
            {
                Console.WriteLine($"Employee Name: {emp.Name}, Salary: {emp.Salary}");
            }
        }

        
    }
}
