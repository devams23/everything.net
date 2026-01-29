using System;
using System.Collections.Generic;
using System.Text;

    // File created on 2025-01-29
namespace Day3_OOP.programs
{

        class A
        {
            public void ShowMessage(string message)
            {
                Console.WriteLine("Message in class A: " + message);
            }

        }
        class B : A
        {

        /*the main use of new keyword is to hide the member of base class, and avoid compiler warning.
         * so here even if we do A obj = new B(); it will call the Display method of class A
        */

        public new void ShowMessage(string message)
        {
            Console.WriteLine("Message in class B: " + message);
        }

        }



    
        class MethodHidingProgram
        {
            static void Main(string[] args)
            {

                A objA = new B();
                objA.ShowMessage("have a great day ahead.");  
                
            }
        }
    

}
