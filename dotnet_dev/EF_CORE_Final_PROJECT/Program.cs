
// File created on 2026/02/23
using EF_CORE_Final_PROJECT.Data;
using EF_CORE_Final_PROJECT.Models;
using EF_CORE_Final_PROJECT.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF_CORE_Final_PROJECT
{
    class Program
    {
        public static void Main(string[] args)
        {

            //var configuration = new ConfigurationBuilder()
            //.SetBasePath(Directory.GetCurrentDirectory())
            //.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //.Build();

            //string? connectionString = configuration.GetConnectionString("DefaultConnection");

            //if (connectionString== null)
            //{
            //    Console.WriteLine("Connection string not found.");

            //}
            if (true)

            {
                //var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                //optionsBuilder.UseSqlServer(connectionString);


                using (var context = new AppDbContext())
                {
                    Console.WriteLine("Database connection established and operational.");

                    var trainingService = new TrainingProgramService(context);
                    var employeeService = new EmployeeService(context);
                    var enrollmentService = new TrainingEnrolledEmployeeService(context);
                    var departmentService = new DepartmentService(context);
                    var trainerService = new TrainerService(context);

                    bool exit = false;

                    while (!exit)
                    {
                        Console.WriteLine("\n========= TRAINING MANAGEMENT SYSTEM =========");
                        Console.WriteLine("1. Create Training Program");
                        Console.WriteLine("2. Register Employee");
                        Console.WriteLine("3. Enroll Employee in Training");
                        Console.WriteLine("4. Show Training Details (With Employees)");
                        Console.WriteLine("5. Show Department Report");
                        Console.WriteLine("6. Update Employee Performance");
                        Console.WriteLine("7. Delete Training Program");
                        Console.WriteLine("8. Exit");
                        Console.Write("Select an option: ");

                        string? choice = Console.ReadLine();

                        try
                        {
                            switch (choice)
                            {
                                case "1":
                                    Console.Write("Enter Training Title: ");
                                    string? title = Console.ReadLine();

                                    Console.Write("Enter Duration (Days): ");
                                    int duration = int.Parse(Console.ReadLine()!);

                                    Console.Write("Enter Start Date (yyyy-mm-dd): ");
                                    DateTime startDate = DateTime.Parse(Console.ReadLine()!);

                                    Console.WriteLine("\nAvailable Trainers:");
                                    var trainers = trainerService.GetAllTrainers();
                                    foreach (var t in trainers)
                                        Console.WriteLine($"Id: {t.Id} | Name: {t.Name} | Exp: {t.YearsOfExperience}");

                                    Console.Write("Select Trainer Id: ");
                                    int trainerId = int.Parse(Console.ReadLine()!);

                                    TrainingProgram newtrainingProgram = new TrainingProgram()
                                    {
                                    
                                        Title = title,
                                        DurationinDays = duration,
                                        StartDate = startDate,
                                        TrainerId = trainerId
                                    };
                                    trainingService.AddTrainingProgram(newtrainingProgram);

                                    Console.WriteLine("Training Program Created Successfully.");
                                    break;

                                case "2":
                                    Console.Write("Enter Employee Name: ");
                                    string? empName = Console.ReadLine();

                                    Console.Write("Enter Salary: ");
                                    decimal salary = decimal.Parse(Console.ReadLine()!);

                                    Console.WriteLine("\nAvailable Departments:");
                                    var departments = departmentService.GetAllDepartments();
                                    foreach (var d in departments)
                                        Console.WriteLine($"Id: {d.Id} | Name: {d.Name} | Location: {d.Location}");

                                    Console.Write("Select Department Id: ");
                                    int deptId = int.Parse(Console.ReadLine()!);

                                    Employee newEmployee = new Employee()
                                    {
                                        Name = empName,
                                        Salary = salary,
                                        DepartmentId = deptId
                                    };
                                    employeeService.AddEmployee(newEmployee);

                                    Console.WriteLine("Employee Registered Successfully.");
                                    break;

                                case "3":
                                    Console.WriteLine("\nAvailable Employees:");
                                    var employees = employeeService.GetAllEmployees();
                                    foreach (var e in employees)
                                        Console.WriteLine($"Id: {e.Id} | Name: {e.Name}");

                                    Console.Write("Enter Employee Id: ");
                                    int empId = int.Parse(Console.ReadLine()!);

                                    Console.WriteLine("\nAvailable Training Programs:");
                                    var trainings = trainingService.GetAllTrainings();
                                    foreach (var tr in trainings)
                                        Console.WriteLine($"Id: {tr.Id} | Title: {tr.Title}");

                                    Console.Write("Enter Training Id: ");
                                    int trainingId = int.Parse(Console.ReadLine()!);

                                    enrollmentService.EnrollEmployeeInTrainingProgram(empId, trainingId);

                                    Console.WriteLine("Employee Enrolled Successfully.");
                                    break;

                                case "4":
                                    //Console.WriteLine("\nAvailable Training Programs:");
                                    //var allTrainings = trainingService.GetAllTrainings();
                                    //foreach (var tr in allTrainings)
                                    //    Console.WriteLine($"Id: {tr.Id} | Title: {tr.Title}");

                                    //Console.Write("Enter Training Id: ");
                                    //int trainingDetailsId = int.Parse(Console.ReadLine()!);

                                    enrollmentService.ShowAllTrainingDetails();
                                    break;

                                case "5":
                                    Console.WriteLine("\nAvailable Departments:");
                                    var _departments = departmentService.GetAllDepartments();
                                    foreach (var d in _departments)
                                        Console.WriteLine($"Id: {d.Id} | Name: {d.Name} | Location: {d.Location}");

                                    Console.Write("Select Department Id: ");
                                    int deptIdRpo = int.Parse(Console.ReadLine()!);
                                    departmentService.ShowDepartmentReport(deptIdRpo);


                                    break;

                                case "6":
                                    Console.WriteLine("\nAvailable Employees:");
                                    var _employees = employeeService.GetAllEmployees();
                                    foreach (var e in _employees)
                                        Console.WriteLine($"Id: {e.Id} | Name: {e.Name}");

                                    Console.Write("Enter Employee Id: ");
                                    int updateEmpId = int.Parse(Console.ReadLine()!);

                                    Console.WriteLine("\nAvailable Training Programs:");
                                    var _trainings = trainingService.GetAllTrainings();
                                    foreach (var tr in _trainings)
                                        Console.WriteLine($"Id: {tr.Id} | Title: {tr.Title}");


                                    Console.Write("Enter Training Id: ");
                                    int updateTrainingId = int.Parse(Console.ReadLine()!);

                                    Console.Write("Enter New Performance Score: ");
                                    int score = int.Parse(Console.ReadLine()!);


                                    enrollmentService.UpdateEmployeePerformance(updateEmpId, updateTrainingId, score);
                                    Console.WriteLine("Performance Updated Successfully.");
                                    break;

                                case "7":

                                    Console.Write("Enter Training Id to Delete: ");
                                    int deleteTrainingId = int.Parse(Console.ReadLine()!);

                                    trainingService.RemoveTrainingProgram(deleteTrainingId);

                                    Console.WriteLine("Training Deleted Successfully.");
                                    break;

                                case "8":
                                    exit = true;
                                    Console.WriteLine("Exiting Application...");
                                    break;

                                default:
                                    Console.WriteLine("Invalid option.");
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                }

            }



        }
    }
}
