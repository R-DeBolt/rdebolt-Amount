using System.ComponentModel.DataAnnotations;
namespace rdebolt_Amount.Models
{
    public class Demographic
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Credit { get; set; }
        public int Defaults { get; set; }
        public float DebtTotal { get; set; }
        public float Risk { get; set; }
        public List<Business> Business { get; set; }
    }
}
