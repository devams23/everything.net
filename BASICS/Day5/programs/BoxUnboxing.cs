using System;
using System.Collections;

class Program {
   static void Main() {
	   
	   // boxing done implicitly
		ArrayList sampleList = new ArrayList(){"devam", 2311, 70.23};
	    
		//arraylist is a non-generic collection 
	   foreach(var item in sampleList){
		   Console.WriteLine(item.GetType());
	   }
	   
	   // we have to unbox it manually, for better type safety
	   
	   int x = 23;
	   int sum = x + (int)sampleList[1];
	   Console.WriteLine(sum);
   }
}