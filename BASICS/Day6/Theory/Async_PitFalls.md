##### async void Methods (Outside Event Handlers)

* *Pitfall* : async void methods are "fire-and-forget" and cannot be awaited or have their exceptions caught by the caller in a try-catch block, which means unhandled exceptions can crash the application.
* *Solution* : Always return a Task or Task<T> from async methods to allow for proper exception propagation and awaiting. The only exception is for event handlers, where the signature is required to be void



#####  using Task.Run() for I/O-Bound Operations

* *Pitfall* : Task.Run() is used to move CPU-intensive work to a different thread pool thread. Using it for I/O-bound operations (like database calls, network requests) is inefficient because the original thread still blocks, consuming unnecessary threads from the thread pool and reducing scalability.
* *Solution* : For I/O-bound work, use the built-in asynchronous methods provided by the .NET libraries (e.g., HttpClient.GetStringAsync(), File.ReadAllTextAsync(), Entity Framework Core's ToListAsync() methods). These methods leverage OS-level asynchronous operations that don't block managed threads.



##### Ignoring Exception Handling in "Fire-and-Forget" Tasks



* *Pitfall* : If an async task is started without being awaited and without proper exception handling within the task itself, any exceptions it throws can go unobserved and potentially crash the application.
* *Solution* : Always await tasks, or if you truly need a fire-and-forget operation, ensure you have robust try-catch blocks within the async method, or attach a continuation to handle exceptions
