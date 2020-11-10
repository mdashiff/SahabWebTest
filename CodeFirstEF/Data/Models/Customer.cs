using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<OrderDetails>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        public string PassWord { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<OrderDetails> Orders { get; set; }
    }
}
