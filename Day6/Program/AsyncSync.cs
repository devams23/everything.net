
using System;
using System.Diagnostics;
using System.Threading.Tasks;

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
        Console.WriteLine("Running tasks synchronously...");
        await Task.Run(FetchData);
        await Task.Run(FetchData);
        Console.WriteLine($"Synchronous total time: {stopwatch.ElapsedMilliseconds} ms");

        // --- Asynchronous/Concurrent Execution ---
        stopwatch.Restart();
        Console.WriteLine("Running tasks asynchronously/concurrently...");
        
        // Start both tasks without awaiting immediately
        Task task1 = Task.Run(FetchData);
        Task task2 = Task.Run(FetchData);

        // Creates a task that will complete when all of the Task objects have completed
        await Task.WhenAll(task1, task2); 

        stopwatch.Stop();
        Console.WriteLine($"Async/Concurrent total time: {stopwatch.ElapsedMilliseconds} ms");
    }
   
}
