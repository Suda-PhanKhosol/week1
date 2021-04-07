using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace week1.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
    
        public int ProductId { get; set; }

        public int TotalItem { get; set; }
        public double TotalPrice { get; set; }
        [Required]
        [StringLength(10)]
        public string PayType { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Product> ProductDetail { get; set; }
    }
}