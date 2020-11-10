using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public String Description { get; set; }
        public int ItemCount { get; set; }
        public int ItemPrice { get; set; }
        public bool AvailabilityStatus { get; set; }
        public virtual OrderDetails OrderDetails { get; set; }

    }
}
