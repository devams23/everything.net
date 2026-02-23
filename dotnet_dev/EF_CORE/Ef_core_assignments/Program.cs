using EF_CORE.DAY_1.DATA;
using EF_CORE.DAY_1.MODELS;
using EF_CORE.DAY_1.Services;
using EF_CORE.DAY_1.Utils;

// File created on 2025-01-29
namespace EF_CORE.DAY_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            using (var _dbcontext = new AppDbContext())
            {
                StudentService studentService = new StudentService(_dbcontext);
                CourseService courseService = new CourseService(_dbcontext);
                BatchService batchService = new BatchService(_dbcontext);
                TrainerService trainerService = new TrainerService(_dbcontext);
                AuthorService authorService = new AuthorService(_dbcontext);


                //batchService.getTrainers();

                while (true)
                {
                    Console.WriteLine("----------------CHOOSE A NUMBER FROM THE MENU BELOW-----------");
                    Console.WriteLine("1. Add Student");
                    Console.WriteLine("2. Add Course");
                    Console.WriteLine("3. Show All Students");
                    Console.WriteLine("4. Show All Courses");
                    Console.WriteLine("5. Enroll Student In Multiple Courses");
                    Console.WriteLine("6. Create Batch");
                    Console.WriteLine("7. Show Course with Students");
                    Console.WriteLine("8. Show Trainer with Batches");
                    Console.WriteLine("9. Update Student");
                    Console.WriteLine("10. Delete Trainer");
                    Console.WriteLine("11. Display Student With Batches");
                    Console.WriteLine("12. Get Course WITH Bathces");
                    Console.WriteLine("13. Get Authors With Books");
                    Console.WriteLine("20. Exit");

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

                                    studentService.AddSingleStudent(std1);

                                    break;
                                }



                            case "2":
                                {
                                    Console.WriteLine("Enter Title ");
                                    var title = Console.ReadLine();
                                    Console.WriteLine("Enter Fees ");
                                   
                                    decimal.TryParse(Console.ReadLine(), out decimal feesdec);
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
                            case "3":
                                {
                                    var students = studentService.GetAllStudents();
                                    Console.WriteLine("length:" + students.Count());
                                    break;
                                }
                            case "4":
                                {
                                    var courses = courseService.GetAllCourses();
                                    Console.WriteLine("length:" + courses?.Count());
                                    break;
                                }
                            case "5":
                                {

                                    var students = studentService.GetAllStudents();
                                    Console.WriteLine("---LIST OF STUDENTS----");
                                    foreach (var item in students)
                                    {
                                        Console.WriteLine(item.StudentId + "----" + item.Name);
                                    }
                                    var courses = courseService.GetAllCourses();
                                    Console.WriteLine("---LIST OF Courses----");
                                    foreach (var item in courses)
                                    {
                                        Console.WriteLine(item.Id + "----" + item.Title);
                                    }

                                    Console.WriteLine("Enter the students Id");
                                    string? studentinput = Console.ReadLine();

                                    // Split the string into an array and convert to a List<string>
                                    //var StudentId = stdinput.Split(delimiter).ToArray();

                                    char delimiter = ',';
                                    Console.WriteLine("Enter the Courses Id in order (comma separated)");
                                    string? courseinput = Console.ReadLine();


                                    // Split the string into an array and convert to a List<string>
                                    var CourseList = courseinput.Split(delimiter).ToArray();

                                    studentService.EnrollStudenInMultiplenCourses(studentinput, CourseList);
                                    break;
                                }


                            // Adding batch
                            case "6":
                                {
                                    Console.WriteLine("Enter course Id");
                                    bool Parsed = int.TryParse(Console.ReadLine(), out int courseId);

                                    Console.WriteLine("Enter Trainer Id");

                                    int.TryParse(Console.ReadLine(), out int TrainerId);
                                    Console.WriteLine("Enter Year Date (YYYY)");
                                    int.TryParse(Console.ReadLine(), out int year);
                                    Console.WriteLine("Enter Month (MM)");
                                    int.TryParse(Console.ReadLine(), out int month);
                                    Console.WriteLine("Enter Day (DD)");
                                    int.TryParse(Console.ReadLine(), out int day);
                                    DateTime startDate = new DateTime(year, month, day);
                                    batchService.AddSingleBatch(courseId, TrainerId, startDate);

                                    break;
                                }
                            case "7":
                                {
                                    courseService.ShowCoursewithStudents();
                                    break;
                                }

                            case "8":
                                {
                                    trainerService.ShowTrainerwithBatches();
                                    break;
                                }

                            case "9":
                                {
                                    Console.WriteLine("--STUDENT DATA TO BE UPDATED--");
                                    Console.WriteLine("Enter the Student Id:");

                                    int.TryParse(Console.ReadLine(), out int id);

                                    Console.WriteLine("Enter New Name:");
                                    var name = Console.ReadLine();

                                    Console.WriteLine("Enter New Email");
                                    var email = Console.ReadLine();

                                    Student std1 = new Student()
                                    {
                                        StudentId = id,
                                        Name = name,
                                        Email = email
                                    };

                                    Console.WriteLine(std1.Created);
                                    studentService.UpdateStudent(std1);

                                    break;
                                }

                            case "10":
                                {
                                    Console.WriteLine("Enter Trainer Id");

                                    int.TryParse(Console.ReadLine(), out int TrainerId);

                                    trainerService.DeleteTrainer(TrainerId);

                                    break;
                                }
                            case "11":
                                {
                                    studentService.DisplayStudentWithBatches();
                                    break;
                                }
                            case "12":
                                {
                                    Console.WriteLine("Enter Course Id");

                                    int.TryParse(Console.ReadLine(), out int CourseId);
                                    courseService.GetCourseBathces(CourseId);
                                    break;
                                }
                            case "13":
                                {
                                    //Console.WriteLine("Enter Course Id");

                                    //int.TryParse(Console.ReadLine(), out int CourseId);
                                    authorService.GetAuthorBooks();
                                    break;
                                }
                            default:
                                break;

                        }
                        if (MenuNumber.Equals("20"))
                        {
                            break;
                        }
                    }

                }
            }
        }
    }
}
