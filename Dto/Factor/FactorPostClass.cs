using System;
using System.Collections.Generic;
using Simulation.Models;

namespace Simulation.Dto
{
    public class FactorPostClass
    {
        public float total { get; set; }
        public DateTime WriteDate { get; set; }
        public List<orderSimple> orderItems { get; set; }
        public int customerId { get; set; }
    }
    public class orderSimple{
        public int count { get; set; }
        public int productId{get;set;}
    }
}