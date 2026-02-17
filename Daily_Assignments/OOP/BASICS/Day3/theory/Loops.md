# 1. Infinite loops:
- An infinite loop is a loop that continues to execute indefinitely because the terminating condition is never met. This happens due to a logical error in the loop's condition or because the loop's control variable is not updated correctly.
- Example c#:
	```csharp
	while (true)
	{
		Console.WriteLine("This will print forever!");
	}
	```
# 2. break vs continue:
- The `break` statement is used to exit a loop or switch statement prematurely. When `break` is encountered, the control is transferred to the statement immediately following the loop or switch.
- Example c#:
	```csharp
	for (int i = 0; i < 10; i++)
	{
		if (i == 5)
		{
			break; // Exit the loop when i is 5
		}
		Console.WriteLine(i);
	}
	```
- The `continue` statement is used to skip the current iteration of a loop and proceed to the next iteration. When `continue` is encountered, the control jumps to the next iteration of the loop.
- Example c#:
	```csharp
	for (int i = 0; i < 10; i++)
	{
		if (i % 2 == 0)
		{
			continue; // Skip even numbers
		}
		Console.WriteLine(i); // This will print only odd numbers
	}
	```
