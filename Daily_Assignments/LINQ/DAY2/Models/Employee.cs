using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ.DAY2.Models
{
    // the Employee Data model , that represents the structure of Employee
    internal class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        public string DepartmentId { get; set; } = String.Empty;
        public double Salary { get; set; }

    }

    internal class  Department
    {
        public string DepartmentId { get; set; } = String.Empty;
        public string DepartmentName { get; set; } = String.Empty;
    }


    /*creating a (Data Transfer Object) to avoid an error of converting anonymous type to a known type, also
     * useful when sending only useful data with type safety
     *
     */
    internal class EmployeeTask2DTO {

        public double Salary { get; set; } 
        public string Name { get; set; } = String.Empty;
    }
    
}
