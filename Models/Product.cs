using System.ComponentModel.DataAnnotations;

namespace Simulation.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public float price { get; set; }
        public string name { get; set; }
    }
}