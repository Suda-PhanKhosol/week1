using System;
using System.Collections.Generic;

namespace week1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int TotalItem { get; set; }
        public double TotalPrice { get; set; }
        public string PayType { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Product> ProductDetail { get; set; }
    }
}