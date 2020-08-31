using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Simulation.Models
{
    public class Factor
    {
        [Key]
        [Required]
        public int factorId { get; set; }
        [Required]
        public float total { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime WriteDate { get; set; }
        public PaymentStatus paymentStatus { get; set; }
        public List<OrderItem> orderItems { get; set; }
        [ForeignKey("Customer")]
        public int customerId { get; set; }
        public Customer customer { get; set; }
    }
    public enum PaymentStatus
    {
        Cache = 1, // pay with money
        Debt = 0, // no payment 
        Credit = 2 // pay with credit card
    }

}