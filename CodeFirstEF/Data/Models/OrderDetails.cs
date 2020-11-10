using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public Decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Products> Products { get; set; }

    }
}
