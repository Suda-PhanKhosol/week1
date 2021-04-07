using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace week1.Models
{
    [Table("Book")]
    public class Book
    {
        [Range(1,int.MaxValue)]
        public int Id { get; set; }
        [Required]
        [MinLength(10)]
        public string Name { get; set; }
        [Range(0,50000)]
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}