using System;
using System.Collections.Generic;

namespace SSS.DataAccess.Models
{
    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Product> products { get; set; }
    }

    public class customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Order> orders { get; set; }
    }
}
