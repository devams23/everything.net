# 1. Advantages of enums:
- Enums provide a way to define a set of named constants, making code more readable and maintainable.
- They can be easily used in switch statements, improving code clarity.
- The underlying type of an enum in C# must be an integral numeric type, such as byte, sbyte, short, ushort, int, uint, long, or ulong

# 2. Limitations of structs
- Structs are value types, and they are stored in the stack, which makes them inefficient for large data structures.
- Structs do not support inheritance, which limits their flexibility compared to classes.
- Structs cannot have a default constructor (a constructor without parameters) or a destructor.
- Structs are copied on assignment, which can lead to performance issues if the struct is large.