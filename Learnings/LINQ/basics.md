##### BASICS

* LINQ (Language Integrated Query) is fundamentally a unified syntax for querying data built directly into C# and VB.NET. At its core, it's a set of extension methods and language features that let you write SQL-like queries against any data source using the same consistent syntax.
* LINQ is popular because it's declarative (you describe what you want, not how to get it), type-safe (compile-time checking catches errors), and readable (reads almost like natural language). It also enables powerful features like deferred execution and composable queries.
* -------------VERY IMP THING ----------------------
* **The query is not executed during this translation process; the resulting method chain merely defines the query. Execution is deferred until you iterate over the query variable (e.g., with a foreach loop) or call a method that forces immediate execution (e.g., ToList(), Count(), or ToArray())**



##### LINQ providers

The .NET framework includes several built-in LINQ providers: 

* LINQ to Objects Used for querying in-memory collections of objects that implement the IEnumerable or generic IEnumerable<T> interface, such as arrays, lists, or dictionaries.
* LINQ to XML (XLINQ) Provides capabilities for working with XML documents. It translates LINQ queries into operations for creating, reading, and manipulating XML structures using classes like XDocument and XElement.
* LINQ to SQL (DLINQ) An object-relational mapper (ORM) designed specifically for querying Microsoft SQL Server databases. It converts LINQ queries into T-SQL commands which are then executed on the database.
* LINQ to Entities The more modern and general ORM, part of the Entity Framework (EF). It allows developers to query various relational databases (not just SQL Server) against a conceptual model defined by C# classes (entities). The provider translates the queries into a database-specific query language (like SQL).
* LINQ to DataSet  Enables querying data cached in a DataSet object, which is useful for working with data in a disconnected environment in ADO.NET applications.
* Parallel LINQ (PLINQ) An execution engine that allows for the parallel execution of LINQ to Objects queries, leveraging multiple processors to potentially improve performance on large datasets. 
