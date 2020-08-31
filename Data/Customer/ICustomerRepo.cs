using System.Collections.Generic;
using Simulation.Models;

namespace Simulation.Data
{
    public interface ICustomerRepo
    {
        bool SaveChanges();

        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void CreateCustomer(Customer cmd);
        void UpdateCustomer(Customer cmd);
        void DeleteCustomer(Customer cmd);
    }
}