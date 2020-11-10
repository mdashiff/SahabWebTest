using System;

namespace Data
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsPaid { get; set; }
    }

}
