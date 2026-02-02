using System;
using System.Collections.Generic;
using System.Text;

// file created on 2025-01-29
namespace Day3_OOP.programs
{
    internal class PaymentProcessor
    {
        // overloading the methods
        public virtual void ProcessPayment(string phonenumber)
        {
            Console.WriteLine("PaymentProcessorCLASS::Processing payment through Phone Number: " + phonenumber);
        }
        public virtual void ProcessPayment(string creditcardnumber, string phonenumber)
        {
            Console.WriteLine("PaymentProcessorCLASS::Processing payment through credit card: " + creditcardnumber + " and Phone Number: " + phonenumber);
        }
    }

    class CreditCardPaymentProcessor : PaymentProcessor
    {
        public override void ProcessPayment(string creditcardnumber, string phonenumber)
        {
            Console.WriteLine("Processing payment through Credit Card: " + creditcardnumber + " and Phone Number: " + phonenumber);
        }

    }

    class UPIPaymentProcessor : PaymentProcessor
    {
        public override void ProcessPayment(string phonenumber)
        {
            Console.WriteLine("Processing payment through UPI with Phone Number: " + phonenumber);
        }
    }



        class ProcessPaymentProgram
        {
            static void Main(string[] args)
            {
            /*using overloading methods in the base class*, compile time polymorphism*/
                PaymentProcessor payment = new PaymentProcessor();
                payment.ProcessPayment("111111119");
                payment.ProcessPayment("4111-1111-1111-1111", "123-456-7890");

            /*using overridden methods in the derived classes , run time polymorphism*/
                PaymentProcessor creditCardPayment = new CreditCardPaymentProcessor();
                creditCardPayment.ProcessPayment("4111-1111-1111-1111", "123-456-7890");

                PaymentProcessor upiPayment = new UPIPaymentProcessor();
                upiPayment.ProcessPayment("111111111");
            }
        }


}
