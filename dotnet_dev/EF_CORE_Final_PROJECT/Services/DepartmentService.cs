using EF_CORE_Final_PROJECT.Data;
using EF_CORE_Final_PROJECT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CORE_Final_PROJECT.Services
{
    internal class DepartmentService
    {
        private readonly AppDbContext _context;

        public DepartmentService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public List<Department> GetAllDepartments()
        {
            try
            {
                var departments = _context.Departments.ToList();
                if (departments!=null)
                {
                    return departments;
                    
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                
            }

            return new List<Department>();
        }
        public void ShowDepartmentReport(int departmentId) { 

            var departmentReport = _context.Departments.Include(dep => dep.Employees).ThenInclude(emp => emp.TrainingEnrolledEmployees).First(dep => dep.Id == departmentId);

            var departmentreport = _context.Departments
                                            .Select(dep => new {
                                                Department = dep.Name,
                                                TotalEmployees = dep.Employees.Count(),

                                                EnrolledEmployees = dep.Employees.Select(emp => new
                                                {
                                                    EmployeeName = emp.Name,
                                                    TrainingCount = emp.TrainingEnrolledEmployees.Count()

                                                }).ToList()

                                            });


            Console.WriteLine("DEPARTMENT: " + departmentReport.Name);
            Console.WriteLine("Total Employees: " + departmentReport.Employees.Count());


            // Only count employees that are enrolled in at least one training
            Console.WriteLine("Employees Enrolled in Training: " + departmentReport.Employees.Count(emp => emp.TrainingEnrolledEmployees.Count != 0));


            Console.WriteLine("DEPARTMENT: " + .departmentreport.Department);
            Console.WriteLine("Total Employees: " + departmentReport.Employees.Count());


            // Only count employees that are enrolled in at least one training
            Console.WriteLine("Employees Enrolled in Training: " + departmentReport.Employees.Count(emp => emp.TrainingEnrolledEmployees.Count != 0));

        }
    }
}
