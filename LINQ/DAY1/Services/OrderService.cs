using LINQ.DAY1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ.DAY1.Services
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
                        new OrderItem { ProductName = "Tablet", Price = 300.00 },
                        new OrderItem { ProductName = "Stylus", Price = 50.00 }
                    }
                }
            };
        }

        public void GetProductName()
        {
            var products = orders.SelectMany(order => order.Items).ToList();

            foreach (var item in products)
            {
                Console.WriteLine($"Product Name: {item.ProductName}, Price: {item.Price}");
            }
        }

        // 
        public void GetCustomerNameWithProducts() {

            var neworders = orders.Select(order => new
            {
                order.CustomerName,
                ProductsPurchased = order.Items.Select(item => item.ProductName)

            });

            foreach (var item in neworders)
            {
                Console.WriteLine(item.CustomerName + " PURCHAsedD:");
                foreach (var item1 in item.ProductsPurchased)
                {
                    Console.WriteLine(item1 + ",");
                }
                Console.WriteLine("-----------------------------");

            }
        }
    }
}
