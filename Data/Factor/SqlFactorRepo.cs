using System;
using System.Collections.Generic;
using System.Linq;
using Simulation.Models;

namespace Simulation.Data
{
    public class SqlFactorRepo : IFactorRepo
    {
        private readonly SimulationContext _context;

        public SqlFactorRepo(SimulationContext context)
        {
            _context = context;
        }

        public void CreateFactor(Factor cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.factors.Add(cmd);
        }

        public void DeleteFactor(Factor cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.factors.Remove(cmd);
        }

        public IEnumerable<Factor> GetAllFactors()
        {
            return _context.factors.ToList();
        }

        public Factor GetFactorById(int id)
        {
            return _context.factors.FirstOrDefault(p => p.factorId == id);
        }

        // public IEnumerable<Product> GetProducts()
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateFactor(Factor cmd)
        {
            //Nothing
        }
    }
}