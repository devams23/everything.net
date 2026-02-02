##### static constructor in c#



###### The key benefits and characteristics of a static constructor are:

* Guaranteed Execution: The Common Language Runtime (CLR) guarantees that the static constructor will run exactly once, before the class is used for the first time.
* Access Control: It cannot take access modifiers (like public or private) or parameters.
* Automatic Invocation: You cannot call it directly in your code.
* A class have only 1 static contructor
* The static constructor is always called first, before any "default" (instance) constructor in a C# class



* Usercase:

``` charp

public class DataAccessManager

{

\&nbsp;   private static readonly string ConnectionString;



\&nbsp;   // Static constructor is called once

\&nbsp;   static DataAccessManager()

\&nbsp;   {

\&nbsp;       // Initialize the connection string from a configuration source

\&nbsp;       ConnectionString = ConfigurationManager.ConnectionStrings\\\["MyDatabase"].ConnectionString;

\&nbsp;       Console.WriteLine("Static constructor executed. Connection string initialized.");

\&nbsp;   }



\&nbsp;   // Static method that uses the initialized static data

\&nbsp;   public static void ExecuteQuery(string query)

\&nbsp;   {

\&nbsp;       // Use the connection string here

\&nbsp;       Console.WriteLine($"Executing query: {query} with connection: {ConnectionString}");

\&nbsp;   }

}



```

