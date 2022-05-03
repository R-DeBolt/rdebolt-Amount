using System.ComponentModel.DataAnnotations;
namespace rdebolt_Amount.Models
{
    public class Business
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public int Loan_Id { get; set; }
    }
}
