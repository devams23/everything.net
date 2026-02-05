using LINQ.DAY3.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ.DAY3
{
    internal class Day3Program
    {

        public static void Main()
        {

        EmployeeService employeeService = new EmployeeService();
         StudentService studentService = new StudentService();
            OrderService orderService = new OrderService();
            employeeService.TASK1();
            studentService.Task2();
            orderService.Task3();
            employeeService.Task4();
            employeeService.Task5();
            employeeService.Task6();
            orderService.Task7();
            employeeService.Task8();
            employeeService.Task9();
        }


        
    }
}
