# 1. Benefits of lambda expressions
- Lambda expressions provide a more concise and readable way to write anonymous methods compared to traditional delegate or anonymous method syntax.
- They can be used to create inline functions that can be passed as arguments to higher-order functions, making code more flexible and expressive.
- Lambda expressions can capture variables from their surrounding context (closure), allowing for more powerful and dynamic behavior.
- Their most common applications include LINQ queries, event handling, and working with delegates
# 2. Lambda vs traditional methods:
| Feature                     | Lambda Expressions                          | Traditional Methods                     |
|-----------------------------|---------------------------------------------|-----------------------------------------|
| Syntax                      | Concise and expressive                      | More verbose and less readable          |
| Declaration                 | Inline, often without a name                | Requires a separate method declaration  |
| Context Capture             | Can capture surrounding variables {x,y => (x>y)} | Cannot capture context (we have to use additional variables to store them)                 |
| Use Cases                   | Ideal for short, single-use functions       | Better for complex, multi-line logic    |
