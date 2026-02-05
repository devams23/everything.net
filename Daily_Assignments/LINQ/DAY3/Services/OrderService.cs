using LINQ.DAY3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ.DAY3.Services
{
    internal class OrderService
    {
        List<Order> orders;
        public OrderService()
        {
            orders = new List<Order>() {
                new Order
                {

                    OrderId = "O001",
                    CustomerName = "Devam",
                    Items = new List<OrderItem>
                    {
                        new OrderItem { ProductName = "Laptop", Price = 1200.00 },
                        new OrderItem { ProductName = "Mouse", Price = 25.00 }
                    }
                },
                new Order
                {
                    OrderId = "O002",
                    CustomerName = "Jay",
                    Items = new List<OrderItem>
                    {
                        new OrderItem { ProductName = "Smartphone", Price = 800.00 },
                        new OrderItem { ProductName = "Headphones", Price = 150.00 }
                    }
                },
                new Order
                {
                    OrderId = "O003",
                    CustomerName = "Chirag",
                    Items = new List<OrderItem>
                    {
                        new OrderItem { ProductName = "Smartphone", Price = 800.00 },
                        new OrderItem { ProductName = "Charger", Price = 150.00 }
                    }
                }
            };
        }


        public void Task3()
        {
        /* 
         *   using SelectMany mainly to convert the List<List<OrderItem> ==> List<OrderItem> , which
         *   will flatten the list , (only to the first order),
         *   basically SelectMany is used to project each element of a sequence 
         *   to an IEnumerable<T> and flatten the resulting sequences into one sequence.
         *   
        */
            Console.WriteLine("------------------ print all product names.----------");

            var products = orders.SelectMany(order => order.Items);
            var productCount = products.Count();



            foreach (var item in products)
            {
                Console.WriteLine($"Product Name: {item.ProductName}, Price: {item.Price}");
            }
            Console.WriteLine("------------------TOTAL PRODUCTS SOLD: " + productCount);
        }

        public void Task7()
        {
            /*
             * using Distinct() to get unique product names from the list of all products, and 
             * also using ToList() to store the results in a list to avoid multiple enumerations of the same query result, as we are using it multiple times here.
             */
            Console.WriteLine("------------------ ALL PRODUCTS vs DISTINCE PRODUCT NAMES.----------");
            var allProducts = orders.SelectMany(order => order.Items).Select(product => product.ProductName).ToList();

            Console.WriteLine("Count of all products " + allProducts.Count());         

            var uniqueProducts = allProducts.Distinct();
            Console.WriteLine("Count of unique products " + uniqueProducts.Count());

            //foreach (var item in uniqueProducts)
            //{
            //    Console.WriteLine($"Product Name: {item}");
            //}

        }
    }
}