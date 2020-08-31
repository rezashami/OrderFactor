using System;
using System.Collections.Generic;
using Simulation.Models;

namespace Simulation.Dto
{
    public class FactorGetDto
    {
        public int Id { get; set; }
        public float total { get; set; }
        public DateTime WriteDate { get; set; }
        public PaymentStatus paymentStatus { get; set; }
        public List<OrderItem> orderItems { get; set; }
        public Customer customer { get; set; }
    }
}