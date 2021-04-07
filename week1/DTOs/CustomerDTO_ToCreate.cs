using System.ComponentModel.DataAnnotations;

namespace week1.DTOs
{
    public class CustomerDTO_ToCreate
    {
     
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
          [Required]
        [StringLength(15)]
        public string BankAccount { get; set; }
          [Required]
        [StringLength(6)]
        public string ATMCode { get; set; }
          [Required]
        public double Balance { get; set; }
    }
}