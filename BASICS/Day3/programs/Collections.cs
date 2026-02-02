using System;

namespace Day3.programs;


internal class ArraysAndCollection
{
    static void Main(string[] args)
    {
        // using array to store students data
        int numberOfStudents = 1;
        Student[] students = new Student[numberOfStudents];

        // allocating memory for each student object
        for (int i = 0; i < numberOfStudents; i++)
        {
            students[i] = new Student();
        }
        students[0].Id = "abc124";
        students[0].Name = "Devam";
        students[0].Age = 21;
        //Student.DisplayStudentDetails(students[0]);


        //-------using List to store students data-------//
        List<Student> studentsList = new List<Student>();
        studentsList.Add(students[0]);
        Student.DisplayStudentDetails(studentsList[0]);

        // searching for a student by id
        Student? searchedStudent = Student.SearchStudentById(studentsList, "abc124");
        if (searchedStudent != null)
        {
            Console.WriteLine("Student Found in the List/Array:");
            Student.DisplayStudentDetails(searchedStudent);
        }
        else
        {
            Console.WriteLine("Student Not Found");
        }

        //-- using Dictionary to store student data with id as key --//
        Dictionary<string, Student> studentsDict = new Dictionary<string, Student>();
        studentsDict["abc124"] = students[0];
        studentsDict["abc124"].Age = 22; // updating age
        studentsDict["abc124"].Id = "hellochanged";


        // searching for a student by id
        if (studentsDict.TryGetValue("abc124", out Student? dictStudent))
        {
            Console.WriteLine("Student Found in Dictionary:");
            Student.DisplayStudentDetails(dictStudent);
        }
        else
        {
            Console.WriteLine("Student Not Found in Dictionary");
        }
    }
}
internal class Student
{
    public string? Id;
    public string? Name { get; set; }

    private int age;

    // adding custom getters and setters
    public int Age{
        get
        {
            return age;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age can't be less than 0");
                    
            }
            age = value;
        }
    }

    // method to display student details
    static internal void DisplayStudentDetails(Student student)
    {   
        Console.WriteLine($"Id:{student.Id}, Name:{student.Name}, Age:{student.Age}");
    }


    // method to search for a student by id , returns null if not found using INumerable (works with list and arrays)
    static internal Student? SearchStudentById(IEnumerable<Student> students, string id)
    {
        
        foreach (Student student in students)
        {
            if (student.Id == id)
            {
                return student;
            }
        }
        return null;
    }

    //


}