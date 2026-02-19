using EF_CORE.DAY_1.DATA;
using EF_CORE.DAY_1.MODELS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CORE.DAY_1.Services
{
    internal class CourseService
    {

        private readonly AppDbContext? _dbContext;

        
        public CourseService(AppDbContext _appDbContext)
        {
            _dbContext = _appDbContext;
        }

        
        public Course? AddSingleCourse(Course course)
        {

            try
            {
                
                _dbContext?.Courses.Add(course);

                _dbContext.SaveChanges();
                return course;
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            
        }
        public IEnumerable<Course>? GetAllCourses()
        {

            return _dbContext?.Courses.ToList();
            
            
        }

        public void ShowCoursewithStudents()
        {
            var course_students = _dbContext.Courses.Include(course => course.Students);

            foreach (var course in course_students)
            {
                Console.WriteLine("Course : " + course.Title);
                foreach (var student in course.Students)
                {
                    Console.WriteLine(student.Name);
                }
            }
        }
    }
}
