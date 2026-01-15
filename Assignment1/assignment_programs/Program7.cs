using System;
using System.Reflection.Metadata;


namespace Assignment1.assignment_programs
{
    class Program7
    {
        const float TAXRATE = 0.05f;
        readonly string orderId;
          
        public Program7(string id)
        {
            orderId = id;
        }

        static void Main(string[] args)
        {
              //TAXRATE = 0.07f; 
              Program7 program = new Program7("XYZ231145");
              program.DisplayOrderandTax();
        }   

        void DisplayOrderandTax()
        {
            Console.WriteLine("Order ID: " + orderId);
            Console.WriteLine("Tax Rate: " + TAXRATE);
        }

        //void ChangeValues()
        //{
        //    TAXRATE = 0.06f;
        //    orderId = "newId";
        //}
    }
}
