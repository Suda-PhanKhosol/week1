using System.ComponentModel.DataAnnotations;

namespace week1.Models
{
    public class StockMarket
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(1)]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Value is required")]
        [Range(100,1000000)]
        public double Value { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.1,200)]
        public double Price { get; set; }
    }
}