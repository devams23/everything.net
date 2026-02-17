

||Asynchronous|Multithreading|
|-|-|-|
|aim|It is used to handle the task efficiently (which require waiting for a while), and then moves to the other one without waiting for a response.|It is a process of using multiple threads to perform a particular task, so to divide the task and do it parallelly.|
|Focus|Efficiently managing many tasks (I/O operations) using fewer threads.|Explicity used multiple threads, which can sometime increase the overhead,|
|when to use|For applications that spend most of their time waiting for external resources (network, disk) to respond, maximizing responsiveness with minimal threads|For applications that need to perform heavy computations or tasks that can be broken down and run truly in parallel across multiple CPU cores. |



