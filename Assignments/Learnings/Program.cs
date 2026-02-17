// See https://aka.ms/new-console-template for more information
namespace Learnings
{
    internal class Program
    {
        internal string name = "Devam";
        
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Sample sample = new Sample();
            sample.Age = 25;
            sample.Age = -2;
            Console.WriteLine(sample.Age);
            
        }
    }

    class Sample
    {
        private int age;
        
        public int Age {
            get { return age; }
            set {
            
            if (value < 0)
                {
                    Console.WriteLine("Age cannot be negative.");
                }
                else
                {
                    age = value;
                }
            }
        }
        public static void Display()
        {

            Program program = new Program();
            Console.WriteLine(program.name);
        }
    }

}