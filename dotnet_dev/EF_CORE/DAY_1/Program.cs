using EF_CORE.DAY_1.DATA;
using EF_CORE.DAY_1.MODELS;
using EF_CORE.DAY_1.Services;

// File created on 2025-01-29
namespace EF_CORE.DAY_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            using (var _dbcontext = new AppDbContext())
            {
                StudentService stdservice = new StudentService(_dbcontext);
                CourseService courseService = new CourseService(_dbcontext);
                BatchService batchService = new BatchService(_dbcontext);

                batchService.getTrainers();
                
                while (true)
                {
                    Console.WriteLine("----------------CHOOSE A NUMBER FROM THE MENU BELOW-----------");
                    Console.WriteLine("1. Add Student");
                    //Console.WriteLine("2. Update Student");
                    //Console.WriteLine("3. Delete Student");
                    Console.WriteLine("4. Add Course");
                    //Console.WriteLine("5. Update Course");
                    //Console.WriteLine("6. Delete Course");
                    Console.WriteLine("7. Show All Students");
                    Console.WriteLine("8. Show All Courses");
                    Console.WriteLine("9. Exit");

                    string? MenuNumber = Console.ReadLine();

                    if (MenuNumber != null)
                    {
                        
                    switch (MenuNumber)
                    {
                        case "1":
                            {
                                Console.WriteLine("Enter Student Name");
                                var name = Console.ReadLine();
                                Console.WriteLine("Enter Student Email");
                                var email = Console.ReadLine();

                                Student std1 = new Student()
                                {
                                    Name = name,
                                    Email = email
                                };

                                stdservice.AddSingleStudent(std1);

                                break;
                            }

                            case "2":
                                {
                                    Console.WriteLine("--STUDENT DATA TO BE UPDATED--");
                                    Console.WriteLine("Enter the Student Id:");

                                    int.TryParse(Console.ReadLine() , out int id);

                                    Console.WriteLine("Enter New Name:");
                                    var name = Console.ReadLine();
                                    Console.WriteLine("Enter New Email");
                                    var email = Console.ReadLine();

                                    Student std1 = new Student()
                                    {
                                        Id = id,
                                        Name = name,
                                        Email = email
                                    };

                                    Console.WriteLine(std1.Created);
                                    stdservice.UpdateStudent(std1);

                                    break;
                                }

                            case "4":
                            {
                                Console.WriteLine("Enter Title ");
                                var title = Console.ReadLine();
                                Console.WriteLine("Enter Fees ");
                                var fees = Console.ReadLine();
                                decimal.TryParse(fees, out decimal feesdec);
                                Console.WriteLine("Enter DurationInMonths ");

                                bool Parsed = int.TryParse(Console.ReadLine(), out int durationInMonths);
                                if (Parsed)
                                {
                                    Course course1 = new Course()
                                    {
                                        Title = title,
                                        Fees = feesdec,
                                        DurationInMonths = durationInMonths

                                    };
                                    courseService.AddSingleCourse(course1);
                                }



                                break;

                            }
                            case "6":
                                {

                                    var students = stdservice.GetAllStudents();
                                    Console.WriteLine("---LIST OF STUDENTS----");
                                    foreach (var item in students)
                                    {
                                        Console.WriteLine(item.Id + "----" + item.Name);
                                    }
                                    var courses = courseService.GetAllCourses();
                                    Console.WriteLine("---LIST OF Courses----");
                                    foreach (var item in courses)
                                    {
                                        Console.WriteLine(item.Id + "----" + item.Title);
                                    }

                                    Console.WriteLine("Enter the students Id in order (comma separated)");
                                    string? studentinput = Console.ReadLine();
                                    char delimiter = ',';

                                    // Split the string into an array and convert to a List<string>
                                    //var StudentId = stdinput.Split(delimiter).ToArray();
                                    
                                    Console.WriteLine("Enter the Courses Id in order (comma separated)");
                                    string? courseinput = Console.ReadLine();
                                    

                                    // Split the string into an array and convert to a List<string>
                                    var CourseList = courseinput.Split(delimiter).ToArray();

                                    stdservice.EnrollStudenInMultiplenCourses(studentinput, CourseList);


                                    break;
                                }
                            case "7":
                            {
                                var students = stdservice.GetAllStudents();
                                Console.WriteLine("length:" + students.Count());
                                break;
                            }
                        case "8":
                            {
                                var courses = courseService.GetAllCourses();
                                Console.WriteLine("length:" + courses?.Count());
                                break;
                            }

                        default:
                            break;

                    }
                    if (MenuNumber.Equals("9"))
                    {
                        break;
                    }
                    }

                }
            }
        }
    }
}
