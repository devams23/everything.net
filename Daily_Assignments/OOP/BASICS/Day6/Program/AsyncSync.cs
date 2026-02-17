
using System;
using System.Diagnostics;
using System.Threading.Tasks;

/*Internally TAsk is:

It has a state machine

	It tracks:
	Is it running?
	Is it completed?
	Did it fail?
	Who is waiting for me?
*/
class Program
{

// simulating an API , 
static async Task  FetchData( )
        {
            Console.WriteLine("fetching data from API...");
            await Task.Delay(2000); 
            Console.WriteLine("Data Fetched.");
        }

    static async Task Main(string[] args)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        // --- Synchronous Execution  ---
	/*
FetchData #1 : start → await ────────── resume → end
FetchData #2 :  ----waits for the task----------start → await ────────── resume → end
*/

        Console.WriteLine("Running tasks synchronously...");
        await Task.Run(FetchData);
        await Task.Run(FetchData);
        Console.WriteLine($"Synchronous total time: {stopwatch.ElapsedMilliseconds} ms");

        // --- Asynchronous/Concurrent Execution ---
/*Timeline →
------------------------------------------------
FetchData #1 : start → await ────────── resume → end
FetchData #2 : start → await ────────── resume → end
------------------------------------------------*/
        stopwatch.Restart();
        Console.WriteLine("Running tasks asynchronously/concurrently...");
        
     // this will start synchronously, but as we have await, in the fetchdata , it will become asynchronous
	Task task1 =  FetchData();   
        Task task2 = FetchData();


        // Creates a task that will complete when all of the Task objects have completed, so basically the timeline will pause, here , (await keyword)
        //await Task.WhenAll(task1, task2); 

	
        stopwatch.Stop();
        Console.WriteLine($"Async/Concurrent total time: {stopwatch.ElapsedMilliseconds} ms");
    }
   
}
