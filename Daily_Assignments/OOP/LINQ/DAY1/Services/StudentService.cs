using LINQ.DAY1.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace LINQ.DAY1.Services
{
    internal class StudentService
    {
        List<Student> students;
        public StudentService()
        {
            students = new List<Student>()
            {
                new Student(){ RollNo=1, Name="John", Marks=90 },
                new Student(){ RollNo=2, Name="Jane", Marks=89 },
                new Student(){ RollNo=3, Name="Sam", Marks=32 },
                new Student(){ RollNo=4, Name="Sara", Marks=45 },
                new Student(){ RollNo=5, Name="Tom",  Marks=65 },
            };
        }

        // helper method to determine result type based on marks
        private string GetResultType(int marks)
        {
            return marks switch
            {
                > 40 => "PASS",
                < 40 => "FAIL",
                _ => "",

            };
        }
        // using anonymous type -- object --to return student details along with result status(pass/fail)
        /* 
         * can use ternary operator,or a helper method to check the marks and 
         * then do PASS OR FAIL
         * 
         */
        public void GetAllStudentsWithResult()
        {
            var results = students.Select((student) => new {

                 student.RollNo,
                 student.Name,
                 student.Marks,

                //Result = student.Marks > 40 ? "PASS" : "FAIL"
                Result = GetResultType(student.Marks)
                }

            );
            foreach (var student in results)
            {
                Console.WriteLine($"RollNo: {student.RollNo}, Name: {student.Name}, Marks: {student.Marks}, Result: {student.Result}");
            }
        }


    }
}
