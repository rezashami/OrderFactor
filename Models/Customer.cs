using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Simulation.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string name { get; set; }

        [Required] 
        public string address { get; set; }
        public ICollection<Factor> myFactors { get; set; }
    }
}