# 1.Parameter passing mechanisms 
- In C#, there are three primary parameter passing mechanisms: by value, by reference using the `ref` keyword, and by reference using the `out` keyword.
	1. **By Value**: When a parameter is passed by value, a copy of the argument's value is made and passed to the method. Changes made to the parameter inside the method do not affect the original argument.
	2. **By Reference using `ref`**: When a parameter is passed by reference using the `ref` keyword, a reference to the original argument is passed to the method. This means that changes made to the parameter inside the method will affect the original argument.
	3. **By Reference using `out`**: The `out` keyword is used to pass parameters by reference, similar to `ref`, but it is specifically intended for output parameters. The called method must assign a value to an `out` parameter before the method returns. This is useful for returning multiple values from a method.

	

# 2.Difference between returning values and void
- In C#, methods can either return a value or be declared as void, which means they do not return any value. The choice between returning a value and using void depends on the purpose of the method and how it is intended to be used.