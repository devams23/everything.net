using System;

namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //String username = Environment.UserName;
            String username = "devam";
            String machineName = Environment.MachineName;
            DateTime currentTime = DateTime.Now;

            // printing the output
            Console.WriteLine("Hello, I'm " + username + "!");
            Console.WriteLine("I am running on machine: " + machineName);
            Console.WriteLine("Current Time is:" + currentTime);

            //Reading the input from the commmandline
            Console.Write("Say something and i will echo it 10 times:");
            String textline = Console.ReadLine();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(textline);
            }

        }
    }
}
