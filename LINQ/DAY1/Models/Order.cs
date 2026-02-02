using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ.DAY1.Models
{
    // the Order Data model,that represents the structure of Order,

    internal class Order
    {
        public string OrderId { get; set; } = String.Empty;
        public string CustomerName { get; set; } = String.Empty;
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

    }

    // orderItem class to represent individual items in an order 
    internal class OrderItem
    {
        public string ProductName { get; set; } = String.Empty;

        public double Price { get; set; }

    }
}
