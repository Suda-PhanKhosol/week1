using System;
using System.Collections.Generic;
using week1.Models;

namespace week1.DTOs
{
    public class OrderDTO_ToReturn
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int TotalItem { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public List<ProductDTO_ToReturn> ProductDetail { get; set; }
    }
}