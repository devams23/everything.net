using EF_CORE_Final_PROJECT.Data;
using EF_CORE_Final_PROJECT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CORE_Final_PROJECT.Services
{

    internal class TrainingEnrolledEmployeeService
    {
        private readonly AppDbContext _context;
        public  TrainingEnrolledEmployeeService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void EnrollEmployeeInTrainingProgram(int employeeId, int trainingProgramId)
        {
            try
            {
                var enrollment = new TrainingEnrolledEmployee
                {
                    EmployeeId = employeeId,
                    TrainingProgramId = trainingProgramId,
                    
                };
                _context.TrainingEnrolledEmployees.Add(enrollment);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ShowAllTrainingDetails()
        {
            try
            {
                var enrollments = _context.TrainingEnrolledEmployees
                    .Include(enrolled => enrolled.Employee)
                    .ThenInclude(emp => emp.Department)
                    .Include(enrolled => enrolled.TrainingProgram)
                    .ThenInclude(tp=> tp.Trainer)
                    .GroupBy(enrolled => enrolled.TrainingProgram.Title)
                    .ToList();
                foreach (var enrollment in enrollments)
                {
                    Console.WriteLine($"Title: {enrollment.Key}");
                    Console.WriteLine($"Trainer: {enrollment.First().TrainingProgram.Trainer.Name}");
                    Console.WriteLine($"Duration: {enrollment.First().TrainingProgram.DurationinDays}");
                    Console.WriteLine("--------Enrolled Employees-----");
                    Console.WriteLine("--------Name-----Department-----Performance Score");
                    foreach (var employee in enrollment)
                    {
                        Console.WriteLine($"{employee.Employee.Name} --- {employee.Employee.Department.Name}--- {employee.PerformanceScore}");
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UpdateEmployeePerformance(int employeeId, int trainingId, int score)
        {
            if (score > 100 || score < 0)
            {
                Console.WriteLine("SCORE IS OUT OF RANGE");
            }
            else
            {

                try
                {
                    var employee = _context.TrainingEnrolledEmployees.FirstOrDefault(e => e.EmployeeId == employeeId && e.TrainingProgramId == trainingId);
                    if (employee != null)
                    {

                        employee.PerformanceScore = score;
                        _context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}
