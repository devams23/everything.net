# 1. Exception handling vs suppression
- Exception handling is the process of catching and managing exceptions that occur during program execution.
- It allows developers to gracefully handle errors, log them, and provide feedback to users without crashing the application. Exception handling is typically done using try-catch blocks in C#
 ```csharp
	try
	{
		if (balance < amount)
		{
			throw new InvalidOperationException("Insufficient funds.");
		}
	}
	catch (Exception ex)
	{
		// handling the exception
		Console.WriteLine(ex.Message);
	}
 ```
- `expression supression` refers to the practice of ignoring or silencing exceptions without proper handling.
-  the practice of catching an exception and performing no action, which is a universally discouraged anti-pattern
 ```csharp
	try
	{
		if (balance < amount)
		{
			throw new InvalidOperationException("Insufficient funds.");
		}
	}
	catch (Exception)
	{
		// suppressing the exception - not recommended
	}
 ```


 # 2. Risks of empty catch blocks:
- Silent failures: When exceptions are suppressed, it can lead to silent failures where the program continues to run without any indication that something went wrong. This can make it difficult to identify and fix issues.
- Lack of feedback: Developers may not receive any feedback about the issue, making it harder to diagnose problems and improve the code.