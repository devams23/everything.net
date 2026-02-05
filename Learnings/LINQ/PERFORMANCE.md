**IEnumerable vs IQueryable**

##### IQueryable -> why compile Time?

- Expression Trees, not Delegates: Unlike IEnumerable (which uses Func<> delegates executed directly), IQueryable uses Expression<Func<>>. The compiler converts LINQ operators (.Where(), .Select()) into expression trees, which are data structures representing the logic, not runnable code.
- Provider Translation: At runtime, the IQueryProvider takes this pre-built expression tree and translates it into SQL or another target language.
- Because the query structure is parsed during compilation, it provides strong typing for expressions
