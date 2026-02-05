using LINQ.DAY1.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;


namespace LINQ.DAY3.Services
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
                new Student(){ RollNo=3, Name="Sam", Marks=35 },
                new Student(){ RollNo=4, Name="Sara", Marks=45 },
                new Student(){ RollNo=5, Name="Tom",  Marks=65 },
            };
        }


        // DEFERRED EXECUTION && IMMEDIATE EXECUTION
        /* 
         *  1. DEFERRED EXECUTION : The query is not executed until the results are actually needed, here the results
         *   variable is assigned a LINQ query that filters the students based on their marks,but it does not execute the query immediately.
         *                          As we add the change the value or add somthing to the list, the results will reflect those changes when we iterate over it.
         *                          
         * 2. IMMEDIATE EXECUTION : The query is executed immediately and the results are stored in a collection, here the resultList variable
         *      resultList stores the immediate results of the query when ToList() is called.
         * 
         */
        public void Task2()
        {
            var results = students.Where(std => std.Marks > 40);
            var resultList = results.ToList();


            foreach (var result in students) { 
                result.Marks = result.Marks ==35 ? 80 : result.Marks;
            }
            //var studentwithMarks35 = students.Where(std => std.Marks == 35).Select(std => std.Marks = 80).ToList();
            
            Console.WriteLine("STORED RESULT LIST:");
            foreach (var item in resultList)
            {
                Console.WriteLine($"RollNo: {item.RollNo}, Name: {item.Name}, Marks: {item.Marks}");

            }
            Console.WriteLine("FRESH QUERY RESULT: after updating 35--> 80");
            foreach (var student in results)
            {
                Console.WriteLine($"RollNo: {student.RollNo}, Name: {student.Name}, Marks: {student.Marks}");
            }
        }


    }
}
