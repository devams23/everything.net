using EF_CORE.DAY_1.DATA;
using EF_CORE.DAY_1.MODELS;
using EF_CORE.DAY_1.Utils;
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

        public Student? UpdateStudent(Student newstudent)
        {
            try
            {
                var oldstudent = _dbContext?.Students.FirstOrDefault(std => std.Id == newstudent.Id) ?? null;
                if (oldstudent != null)
                {

                    HelperMethods.DetachEntity(oldstudent, _dbContext);
                }

                if (oldstudent == null)
                {
                    Console.WriteLine("no student found with that ID");
                    return null;
                }

                Console.WriteLine(oldstudent.Name); 

                if (string.IsNullOrEmpty(newstudent.Name))
                {
                    oldstudent.Name = newstudent.Name;
                    
                }

                if (string.IsNullOrEmpty(newstudent.Email))
                {
                    
                    oldstudent.Email = newstudent.Email;
                }

                Console.WriteLine("OLD STUDENT DATA:\n " + "EMAIL:" + oldstudent.Email + "\n " + "NAME: " + oldstudent.Name);

                _dbContext.SaveChanges();

                var Updatedstudent = _dbContext?.Students.FirstOrDefault(std => std.Id == newstudent.Id);
                Console.WriteLine("NEW STUDENT DATA:\n " + "EMAIL:" + Updatedstudent.Email + "\n " + "NAME: " + Updatedstudent.Name);

                Console.WriteLine("SUCCESS! STUDENT UPDATED");


                return newstudent;


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public void DisplayStudentWithBatches()
        {
            var students_bathes = _dbContext.Students.Include(std => std.Courses).ThenInclude(course => course.Batches);

            foreach (var students in students_bathes)
            {
                Console.WriteLine("STUDENT --->" + students.Name);
                foreach (var course in students.Courses)
                {
                    Console.WriteLine("COURSE TITLE--->" + course.Title);
                    foreach (var batch in course.Batches)
                    {

                        Console.WriteLine("BATCH START--->"+batch.StartDate);


                    }
                }
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
