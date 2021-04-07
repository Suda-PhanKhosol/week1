using System.ComponentModel.DataAnnotations;

namespace week1.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string NameItem { get; set; }
        [Required]
        [StringLength(100)]
        public string Descr { get; set; }
        [Required]
        [StringLength(10)]
        public string CodeType { get; set; }
        public int Price { get; set; }
    }
}