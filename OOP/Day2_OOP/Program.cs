
using System;
// File created on 2025-01-29
namespace Day2_OOP
{
    class A
    {
        virtual public void Show()
        {
            Console.WriteLine("Class A show method called");
        }
    }
    class B : A
    {
        public List<int> list;

        public B(string msg)
        {
            list = [];
            Console.WriteLine("Class B Parameter");
        }
        override public void Show()
        {
            Console.WriteLine("Class B show method called");
        }
    }
    class C : B
    {

        public C() : base("base")
        {
            Console.WriteLine("Class C Parameterless Constructor");
            Console.WriteLine(list);
        }
        override public void Show()
        {
            Console.WriteLine("Class C show method called");
        }
        public void Show1()
        {
            Console.WriteLine("Class C show1 method called");
        }

    }
    class Program
    {
        static void Function1(string message)
        {
            Console.WriteLine(message);
        }

        static void Function1() {
            Console.WriteLine("no message passed");
        }

        static void Function1(int number){
            Console.WriteLine("number passed: " + number);
        }
        static void Function1(int number , int x =32){
            Console.WriteLine("FUNCTION with optional parameter: " + number);
        }
        public static void Main(string[] args)
        
        {
            //Function1("Hello World!");
            Function1(12);
            Function1(12, 23);
            A objA = new A();
            //objA.Show();
            A objB = new B("");
            //objB.Show();
            A objC = new C();

        }


        }
    
}

