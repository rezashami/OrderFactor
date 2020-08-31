using System;
using System.Collections.Generic;
using System.Linq;
using Simulation.Models;

namespace Simulation.Data
{
    public class SqlProductRepo : IProductRepo
    {
        private readonly SimulationContext _context;

        public SqlProductRepo(SimulationContext context)
        {
            _context = context;
        }

        public void CreateProduct(Product cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.products.Add(cmd);
        }

        public void DeleteProduct(Product cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.products.Remove(cmd);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.products.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateProduct(Product cmd)
        {
            //Nothing
        }
    }
}