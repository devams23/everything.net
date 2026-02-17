# 1. Generics Type safety
- using generics the errors can be caught at compile time rather than at runtime. This means that if you try to add an incompatible type to a generic collection, the compiler will generate an error, preventing potential runtime exceptions. This leads to more robust and reliable code. 	
- reducing the risk of `ClassCastException` errors at runtime.
- Clearer intent and less boilerplate code (like casting) make code easier to understand and maintain.
# 2. Performance benefits
- Using generics can lead to better performance compared to non-generic collections. Since generics eliminate the need for boxing and unboxing when working with value types, they reduce overhead and improve execution speed. This is particularly beneficial in scenarios where performance is critical, such as in high-frequency trading systems or real-time applications.
