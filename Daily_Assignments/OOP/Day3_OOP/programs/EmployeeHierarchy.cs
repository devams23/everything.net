using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

// File created on 2025-01-29
namespace Day3_OOP.programs
{
    #region employee Hierarchy with Abstract Classes

  
    abstract class Employee
    {
        string? Id { get; set; }
        string? Name { get; set; }

        protected decimal BaseSalary { get; set; } = 0; // base salary for employee

        /// <summary>
        /// Calculates the total salary based on the number of completed projects.
        /// </summary>
        /// <param name="projects">The number of projects completed. Must be zero or greater.</param>
        /// <returns>The total salary as a decimal value, based on the specified number of projects.</returns>
        public abstract decimal CalculateSalary(int projects);

    }

    class FullTimeEmployee : Employee
    {
        private decimal TotalSalary;
        private decimal Bonus = 5500.5m;
        public override decimal CalculateSalary(int projects)
        {
            // a short hand way to tell ---> if (projects<0)
            ArgumentOutOfRangeException.ThrowIfNegative(projects);

            BaseSalary = 40000;
            // Adding full-time employee bonus
            TotalSalary = Bonus*projects + BaseSalary;
            Console.WriteLine("Salary for Full Time Employee: " + TotalSalary);
            return TotalSalary;
        
        }
    }
    class ContractEmployee : Employee
    {

        private decimal TotalSalary;
        private decimal Bonus = 1500.5m;
        public override decimal CalculateSalary(int projects)   
        {
            // a short hand way to tell ---> if (projects<0)
            ArgumentOutOfRangeException.ThrowIfNegative(projects);

            BaseSalary = 10000;
            TotalSalary = Bonus*projects + BaseSalary;
            Console.WriteLine("Salary for Contract Employee: " + TotalSalary);
            return TotalSalary;
        }

    }
    #endregion

    #region Base Keyword Exploration
    /* here we are using a default constructor , so need not to use base() in the child class, */
    class Logger 
    {
        
        public Logger()
        {
            Console.WriteLine("Logger Instance created" );

        }
        public Logger(string name)
        {
            Console.WriteLine("Logger Instance created with string name: "+name);
        }
        public virtual void LogMessage(string message)
        {
            Console.WriteLine("Log: " + message);
        }
    }

    class NetworkLogger : Logger
    {

        public NetworkLogger(string connection) : base (connection)
        {
            Console.WriteLine("using the logger instance to create a network logger");
            Console.WriteLine("Network Logger Instance created with connection: " + connection);
        }

    }

    #endregion
    internal class EmployeeHierarchy
    {

            static void Main(string[] args)
            {

            #region employee implementation

            // using direct reference of derived class
            FullTimeEmployee fullTimeEmployeeObj = new FullTimeEmployee();

            //using base class reference to derived class object
            Employee partTimeEmployeeObj = new ContractEmployee();

            //decimal fullTimeSalary = fullTimeEmployeeObj.CalculateSalary(-2);
            decimal partTimeSalary = partTimeEmployeeObj.CalculateSalary(1);

            
            //Console.WriteLine(fullTimeSalary);
            //Console.WriteLine(partTimeSalary);

            #endregion

            #region base keyword implementation

            Logger logger = new NetworkLogger("http://127.0.0.1");
            #endregion


        }
    }



}
