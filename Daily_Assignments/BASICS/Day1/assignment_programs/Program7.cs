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
              Program7Test test = new Program7Test();
              test.orderId = "NEWID12345";
                test.DisplayOrderId();
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
    class Program7Test
    {
        String orderId {get; set; }
        public Program7Test()
        {
            orderId = "ABC123456";
        }
        public void DisplayOrderId()
        {
            Console.WriteLine("Order ID from Test class: " + orderId);
        }
    }
}
