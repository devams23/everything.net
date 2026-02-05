using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ.DAY3
{
    internal class BestPractices
    {
        /*
         * LINQ BEST PRACTICES:
         
            1.USING .ToList(), 
                    in caseof multiple iterations over the same query result to avoid re-evaluation.
                    eg. here it is better to use .ToList() to store the products in a list if we plan to iterate over them multiple times.
            var products = orders.SelectMany(order => order.Items).ToList();
            var productCount = products.Count;
            
            2. Avoid multiple enumerations of the same query.
                If you need to iterate over the same query result multiple times,
                consider storing the result in a collection like List<T> or Array to avoid re-evaluation.

            3. Use Any() and All() for existence checks:
                Instead of using Count() > 0 to check for the existence of elements,
        
                use Any() for better readability and performance.
                Example:
                bool hasThreeLetterNames = names.Any(name => name.Length == 3);
                
                To check if all names have three letters, use All():
                bool allThreeLetterNames = names.All(name => name.Length == 3);
         
            4. Avoid loops inside LINQ queries:
                Avoid using loops or complex logic inside LINQ queries, as it can lead to performance issues and reduced readability.
                Instead, try to express your logic using LINQ operators.

            5. N+1 query problem : 
                time complexity - O(m*n), instead of O(m+n)
                use joins or SelectMany to fetch related data in a single query instead of multiple queries.
                
            6. using PARALLEL LINQ (PLINQ) for CPU-bound operations to improve performance by utilizing multiple processors.
               call the AsParallel() method 
            */
        public static void Main(string[] args)
        {
            List<string> names = new List<string> { "Alice", "Bob", "Charlie", "David", "Eve" };

            var isnamenot = names.Where(name => name.Length == 3).Count() >0;
            var isnames = names.All(name => name.Length == 3);
            Console.WriteLine(isnames);
            
        }
    }
}
