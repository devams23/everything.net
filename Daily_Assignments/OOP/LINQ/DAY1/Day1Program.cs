using LINQ.DAY1.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ.DAY1
{
    internal class Day1Program
    {
        public static void Main(string[] args)
        {

            StudentService studentService = new StudentService();
            EmployeeService employeeService = new EmployeeService();
            OrderService orderService = new OrderService();


            // Employee Services
            var employees = employeeService.GetEmployeesSalaryGreaterThan(25000);
            Console.WriteLine("EMPLOYEES WITH Salary Greater than 25000");
            foreach (var item in employees)
            {
                Console.WriteLine(item.Name + " DEPARTMENT: " + item.Salary);
            }
            var ITemployees = employeeService.GetEmployeesByDepartment("IT");
            foreach (var item in ITemployees)
            {
                Console.WriteLine(item.Name + " DEPARTMENT: " + item.Department);
            }
            employees = employeeService.GetSortedEmployeesSalaryGreater(30000);
            employeeService.GetSortedEmployeesByDepartmentAndName();
            employeeService.GetEmployeeNameDepartmentCity();
            // Employee Names Only
            List<string> employeeNames = employeeService.GetEmployeeNamesOnly();
            List<string> employeeNamesQuery = employeeService.GetEmployeeNamesOnlyQuerySyntax();

            // Student services
            studentService.GetAllStudentsWithResult();

            // Order serivice methods
            orderService.GetProductName();
            orderService.GetCustomerNameWithProducts();


        }
        
    }
}
