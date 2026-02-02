using System;

namespace Assignment1.assignment_programs
{
    public class Program2
    {
        int somedata = 3;
        static void Main(string[] args)
        {
            Program2 program2 = new Program2();
            int age = 21;
            changeValues(age, program2);
            Console.WriteLine("Values after changing\nAge: " + age + "Program.somedata: " +
    program2.somedata);

        }
        static void changeValues(int age, Program2 program)
        {
            Console.WriteLine("Values beore changing\nAge: " + age + "Program.somedata: " +
    program.somedata);

            age = 25;
            program.somedata = 5;



        }

    }
}
