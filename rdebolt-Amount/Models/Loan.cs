using System.ComponentModel.DataAnnotations;
namespace rdebolt_Amount.Models
{
    public class Loan
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double amount { get; set; }
        [Required]
        public double apr { get; set; }
        [Required]
        public int duration { get; set; }

        //public int BusinessId { get; set; }
    }
}
