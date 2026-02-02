using System;
using System.Collections.Generic;
using System.Text;

namespace Day1_OOP.Program.PartialClasses
{
    //
    internal partial class Student
    {
        public string? Name { get; set;}
        public int Age { get; set;} 
        


        public void SetStudentInfo(string name, int age, string rollNumber, string course)
        {
            Name = name;
            Age = age;
            RollNumber = rollNumber;
            Course = course;
        }   
        public void DisplayCompleteStudentInfo()
        {
            Console.WriteLine("----- Student Information -----");
            Console.WriteLine("Name:" + Name);
            Console.WriteLine("Age:" + Age);

            Console.WriteLine("----- Academic Information -----");
            Console.WriteLine("Roll Number:" + RollNumber);
            Console.WriteLine("Course: " + Course);
        }

        public static void Main(string[] args)
        {
            Student student = new Student();
            student.SetStudentInfo("Devam Satasiya", 20, "AABCS21321", "Computer Science");
            student.DisplayCompleteStudentInfo();
        }
    }
}
