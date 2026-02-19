using EF_CORE.DAY_1.DATA;
using EF_CORE.DAY_1.MODELS;
using Microsoft.EntityFrameworkCore;


namespace EF_CORE.DAY_1.Services
{
    internal class StudentService
    {
        private readonly AppDbContext? _dbContext;
        public StudentService(AppDbContext _appDbContext)
        {
            _dbContext = _appDbContext;
        }


        public Student? AddSingleStudent(Student student)
        {
            try
            {

                _dbContext?.Students.Add(student);
                _dbContext.SaveChanges();

                Console.WriteLine("SUCCESS! NEW STUDENT ADDED");

                return student;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }


        }

        public Student? UpdateStudent(Student student)
        {
            try
            {
                var oldstudent = _dbContext?.Students.FirstOrDefault(std => std.Id == student.Id) ?? null;
    

                if (oldstudent == null)
                {
                    Console.WriteLine("no student found with that ID");
                    return null;
                }
                //Console.WriteLine(oldstudent.Name);

                oldstudent.Name = student.Name;
                oldstudent.Email = student.Email;

                _dbContext.SaveChanges();

                Console.WriteLine("SUCCESS! STUDENT UPDATED");


                return student;


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public string EnrollStudenInMultiplenCourses(string studentId  , string [] courseIds )
        {

            try
            {
                int.TryParse(studentId, out var intStdId);
                var student = _dbContext.Students.Include(std => std.Courses).FirstOrDefault(std => std.Id == intStdId);

                int.TryParse(courseIds[0], out int courseIdint);
                var course = _dbContext.Courses.FirstOrDefault(course => course.Id == courseIdint);


                student.Courses.Add(course);

                _dbContext.SaveChanges();

                return studentId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
        public IEnumerable<Student> GetAllStudents()
        {
            using (var _dbContexttext = new AppDbContext())
            {
                return _dbContexttext.Students.ToList();
            }

        }
    }

}
