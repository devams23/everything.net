The ONLY correct way: CancellationToken



Cancellation in .NET is cooperative, not forceful.

Meaning: “I’m requesting you to stop — please stop when it’s safe”



```csharp
CancellationTokenSource cts = new CancellationTokenSource();

CancellationToken token = cts.Token;

```



//-----passing the token 



static async Task FetchData(CancellationToken token)

{

&nbsp;   Console.WriteLine("Fetching data...");



&nbsp;   await Task.Delay(2000, token); // cancellation-aware



&nbsp;   Console.WriteLine("Data fetched.");

}







CancellationTokenSource cts = new CancellationTokenSource();



Task t1 = FetchData(cts.Token);

Task t2 = FetchData(cts.Token);



cts.Cancel(); // cancels both because the cts is same.





