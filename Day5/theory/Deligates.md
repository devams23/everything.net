1. ### Deligates vs interface

||deligates|interface|
|-|-|-|
|Purpose|it makes a contract , on how a function should behave , (input parameter, return type)|it makes a contract, on how a class should behave, when implemented, (the members in the interface should be implemented by the class )<br />|
|Chaining|can chain multiple deligates using += or -=|does not support method chaining inherently.|
|Functionality|it is mainly used to pass functions as a parameter to other function<br />(callback)|used to decouple the members from the implementing class,|
|Use cases|LINQ operations, asynchronous callbacks, and event systems where simple function passing is needed.|dependency injection, mocking for unit testing, and defining core, multi-method capabilities of a class (e.g., IEnumerable, IComparable|



