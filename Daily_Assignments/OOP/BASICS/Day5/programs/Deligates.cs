using System;
namespace DeligatesPractice {

	//creating a custom deligate  
 	 public delegate double CalculatorOperation(double num1, double num2);
   
    public class Calculator
    {
		public static double Multiply(double num1, double num2){
			Console.WriteLine("Performing Multiplication");

            return num1*num2;
        }
		public static double Divide(double num1, double num2){
			Console.WriteLine("Performing Divison");
            return num1/num2;
        }
		public static double Substract(double num1, double num2){
			Console.WriteLine("Performing Substraction");

            return num1-num2;
        }			
        public static double Add(double num1, double num2)
        {
			Console.WriteLine("Performing Divison");
            return num1+num2;
        }
         // a helper method which takes the delegate of type CalculatorOperation.
		public static double PerpormCalculation(double num1 , double num2 , CalculatorOperation CalcOp){
			return CalcOp(num1,num2);
		}
        public static void Main()
        {
			double num1 = 732.43, num2 =432.54;
			CalculatorOperation operation = Add;
			Console.WriteLine(PerpormCalculation(num1,num2,operation));
			operation=Substract;			
			//chaining multiple methods, when the the operation is called, all the method chained to it, will called,
			operation+=Multiply;
			Console.WriteLine(PerpormCalculation(num1,num2,operation));

        }
    }
}