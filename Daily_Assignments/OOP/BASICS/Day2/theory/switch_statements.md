
# 1.When switch is preferable
- A switch statement is preferable in scenarios where we have multiple discrete values to compare against a single variable. It makes code more readable and maintainable by using different cases in a structured manner. Switch statements are particularly useful when dealing with enumerations or a fixed set of known values, as they can be more efficient than multiple if-else statements.


# 2.Research and briefly explain modern switch enhancements
- Modern switch enhancements in C# include several features that improve the expressiveness and functionality of switch statements:
	1. **Pattern Matching**: C# has introduced pattern matching capabilities that allow you to match types and properties directly within switch cases. This enables more complex conditions and reduces the need for additional type checks.
	2. **Switch Expressions**:  switch expressions provide a more concise syntax for switch statements. They allow you to return values directly from the switch, making the code cleaner and more functional in style.
	3. **Property Patterns**: This feature allows to match against properties of an object directly in the switch case, enabling more granular control over the matching logic.
	4. **Tuple Patterns**: use tuples in switch cases to match multiple values simultaneously, which is useful for scenarios where you need to consider combinations of values.
	5. **When Clauses**: You can add additional conditions to switch cases using the `when` keyword, allowing for more complex logic within a single case.
	6. **Discard Patterns**: The discard pattern (`_`) allows you to ignore certain values in switch cases, making it easier to handle cases where you don't care about specific values.

```
		
		var result = (x, y) switch
		{
			(0, 0) => "Origin",
			(0, _) => "On Y-axis",
			(_, 0) => "On X-axis",
			_ => "Somewhere else"
		};
```

