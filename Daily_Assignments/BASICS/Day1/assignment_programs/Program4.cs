using System;


namespace Assignment1
{
    internal class Program4
    {
        static void Main(string[] args)
        {

            int? age = null;
            int? gender = null;
            //putting the default age as 18
            //Console.Write("Enter you age:");
            //age = Console.ReadLine();
            CheckAligibility(age, gender);
            //age = 21;
            age ??= 18;

            CheckAligibility(age, gender);
        }

        static void CheckAligibility(int? age, int? gender)
        {
            if (!age.HasValue)
            {
                Console.WriteLine("Age is required");
                return;
            }

            else if (age.HasValue && age > 18)
            {
                Console.WriteLine("Good Job! Your age is " + age);
            }
            else
            {
                Console.WriteLine("Sorry! You are not eligible");
            }

        }

    }
}
