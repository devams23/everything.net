using System;
using System.Collections.Generic;
using System.Text;

namespace Day4_OOP.PROGRAMS
{
    class MagicalClass
    {
        string message;

        public MagicalClass(string msg)
        {
            message = msg;
            Console.WriteLine("MagicalClass created with message: " + message);
        }
        ~MagicalClass()
        {
            Console.WriteLine("MagicalClass with message '" + message + "' is being finalized.");
        }
    }
    internal class GarbageCollectionProgram
    {

            static void Main(string[] args)
            {
            for (int i = 0; i < 100; i++)
            {
                MagicalClass obj = new MagicalClass("Object " + i);
            }
            GC.Collect();

        }

    
}
}
