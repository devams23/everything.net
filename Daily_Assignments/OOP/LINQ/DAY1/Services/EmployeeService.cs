using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LINQ.DAY1.Models;
namespace LINQ.DAY1.Services
{
    internal class EmployeeService
    {
         List<Employee> employees;
        public EmployeeService()
        {
            employees = new List<Employee>()
            {
                new Employee(){ EmployeeID=101, Name="Manohar", Department="IT", Salary=25000 , City = "Hyderabad" },
                new Employee(){ EmployeeID=102, Name="Baldev", Department="HR", Salary=55000 , City = "Bangalore" },
                new Employee(){ EmployeeID=103, Name="Chaitanya", Department="IT", Salary=70000 , City = "Ahmedabad" },
                new Employee(){ EmployeeID=104, Name="Devam", Department="Finance", Salary=5000 , City = "Chennai" },
                new Employee(){ EmployeeID=105, Name="Eshwar", Department="IT", Salary=65000 , City = "Mumbai" },
            };
        }

        /// <summary>
        /// Returns a list of employees whose salary is greater than the specified value.
        /// </summary>
        /// <param name="salary">The salary threshold. Only employees with a salary greater than this value are included in the result.</param>
        /// <returns>A list of employees with a salary greater than the specified value, or null if the employee collection is
        /// not initialized. Returns an empty list if no employees meet the criteria.</returns>
        
        public IEnumerable<Employee>? GetEmployeesSalaryGreaterThan(double salary)
        {
            
            return employees?.Where(emp => emp.Salary > salary).ToList();
            
        }
        /* Returns a list of employees belonging to the specified department.
         * Each employee in the result is represented by an EmployeeTask2DTO object containing only the Name and Salary properties.
         */
        public IEnumerable<Employee>? GetEmployeesByDepartment( string department)
        {
            return employees?
                    .Where(emp => emp.Department == department)               
                    .ToList();

        }

        // Sort the employees whose salary is greater than the specified value in ascending order of their salary.
        public IEnumerable<Employee>? GetSortedEmployeesSalaryGreater(double salary)
        {

            return employees?.Where(emp => emp.Salary > salary).OrderBy(emp => emp.Salary).ToList();

        }

        /* Sort the employees whose salary is greater than the specified value
         * first by their department in ascending order,
         * and then by their salary in ascending order within each department.
         */
        public IEnumerable<Employee>? GetSortedEmployeesByDepartmentAndName()
        {

            return employees?
                            .OrderBy(emp => emp.Department)
                            .OrderBy(emp => emp.Salary).ToList();


        }

        public void GetEmployeeNameDepartmentCity()
        {

            var employeeData =  employees.Select(emp => new 
            {
                emp.Name,
                emp.Department,
                emp.City
            }).ToList();  
            
            foreach (var item in employeeData)
            {
                Console.WriteLine($"Name: {item.Name}, Department: {item.Department}, City: {item.City}");
            }
        }

        public List<string> GetEmployeeNamesOnly()
        {
            // here we are using simple LINQ method syntax to select only the names of employees from the employees list 
            return employees.Select(emp => emp.Name).ToList();
        }

        public List<string> GetEmployeeNamesOnlyQuerySyntax()
        {
            return (
                from emp in employees
                select emp.Name
            ).ToList();

            
        }

    }
}
