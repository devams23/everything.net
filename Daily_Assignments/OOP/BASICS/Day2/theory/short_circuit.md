# 1. Difference between == and Equals()
1. **`==` Operator**:
   - The `==` operator is used to compare the references of two objects by default. This means it checks whether both operands refer to the same memory location.
   - For value types (like int, float, etc.), `==` compares the actual values.
   - For reference types (like classes), unless overridden, it checks for reference equality.
   - Many built-in types (like strings) override the `==` operator to provide value equality.
2. **`Equals()` Method**:
   -The `Equals()` method is a virtual method defined in the `Object` class, which can be overridden in derived classes to provide custom equality logic.
   - By default, the `Equals()` method also checks for reference equality for reference types, but it can be overridden to compare the actual content of the objects.
   - It is generally used for value comparison when overridden appropriately.

### short summary:
- For Value Types (e.g., int, bool, structs): Both == and Equals() typically perform value comparison and yield the same result. == is slightly faster.
  - For most Reference Types (e.g., custom classes, StringBuilder):
    Use == to check if two variables refer to the exact same instance in memory.
    Use Equals() to check if the objects contain the same data (requires overriding the method in your custom class to provide meaningful comparison logic).
### Eg: 
```csharp
            object value1 = 21;
            object value2 = 21;
            bool areEqualUsingOperator = (value1 == v alue2); // false
            bool areEqualUsingMethod = value1.Equals(value2); // true
            Console.WriteLine($"Using '==': {areEqualUsingOperator}");
            Console.WriteLine($"Using 'Equals': {areEqualUsingMethod}");
```


# 2. Short-circuit behavior in logical operators

1. **Logical AND (&&)**: In an expression A && B, if A evaluates to false, the entire expression must be false, regardless of the value of B or any further expressions. Therefore, B is never evaluated.
2. **Logical OR (||)**: In an expression A || B, if A evaluates to true, the entire expression must be true, regardless of the value of B. Therefore, B is never evaluated. 

