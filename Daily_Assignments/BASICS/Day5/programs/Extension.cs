using System;
using System.Collections.Generic;

public static class StringExtensions {
	
	/*the method returns the count of each character in the string*/
   public static Dictionary<char,int> FrequencyCount(this string inputString) {
	   Dictionary<char,int> freqcount = new Dictionary<char,int>();
      foreach(char ch in inputString){
		  int count = freqcount.GetValueOrDefault(ch,1);
		  // returns false if the key is already present, adding ! to handle the condition
		  if (!freqcount.TryAdd(ch, count)){
			  freqcount[ch]= count+1; 
		  }
		  
	  }
	   return freqcount;
   }
}

class Program {
   static void Main() {
		string  str = "thisis a sample string";
	   
	    Dictionary<char,int> freqcount= str.FrequencyCount();
	   foreach(var item in freqcount){
		   Console.WriteLine("char:" + item.Key + "value: " + item.Value);
	   }
   }
}