There are several situations when splitting a class definition is desirable:



* Declaring a class over separate files enables multiple programmers to work on it at the same time.
* You can add code to the class without having to recreate the source file that includes automatically generated source. Visual Studio uses this approach when it creates Windows Forms, Web service wrapper code, and so on. You can create code that uses these classes without having to modify the file created by Visual Studio.
* Source generators can generate extra functionality in a class.



