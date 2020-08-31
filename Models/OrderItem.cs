using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simulation.Models
{
    public class OrderItem
    {
        [Key]
        [Required]
        public int orderId{get;set;}
        [Required]
        public int count { get; set; }
        [Required]
        [ForeignKey("Product")]
        public int productId{get;set;}
        public Product product{get;set;}
    }
}