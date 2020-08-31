using System;
using System.Collections.Generic;
using System.Linq;
using Simulation.Models;

namespace Simulation.Data
{
    public class SqlCustomerRepo : ICustomerRepo
    {
        private readonly SimulationContext _context;

        public SqlCustomerRepo(SimulationContext context)
        {
            _context = context;
        }

        public void CreateCustomer(Customer cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.customers.Add(cmd);
        }

        public void DeleteCustomer(Customer cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.customers.Remove(cmd);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.customers.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCustomer(Customer cmd)
        {
            //Nothing
        }
    }
}