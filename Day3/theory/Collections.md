#  1. Array vs List:
- An Array is a fixed-size collection of elements of the same type. Once an array is created, its size cannot be changed. Arrays are useful when the number of elements is known in advance and does not change frequently.
- 
	```csharp
	int[] numbersArray = new int[5]; 
	numbersArray[0] = 1;
	numbersArray[1] = 2;
	```
- A List is a dynamic collection of elements that can grow or shrink in size as needed. Lists are more flexible than arrays and are useful when the number of elements is not known in advance or can change frequently.
-	
	```csharp
	using System.Collections.Generic;
	List<int> numbersList = new List<int>();
	numbersList.Add(1);
	numbersList.Add(2);
	numbersList[0]; // returns 1
	```

# 2. How Dictionary works internally:

- the dictionary uses an array of List<KeyValuePair<TKey, TValue>> to store the key-value pairs. 
- Each index in the array corresponds to a "bucket" that can hold multiple key-value pairs in case of hash collisions.
- so when we do dictionary[key], it uses the built in GetHashCode() method of the key to compute a hash code, and than using hashcode% number_of_buckets to find the appropriate bucket index.
- If there are multiple key-value pairs in the same bucket (due to hash collisions), it uses a linked list or another data structure to store them.