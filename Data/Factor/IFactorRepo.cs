using System.Collections.Generic;
using Simulation.Models;

namespace Simulation.Data
{
    public interface IFactorRepo
    {
        bool SaveChanges();

        IEnumerable<Factor> GetAllFactors();
        Factor GetFactorById(int id);
        void CreateFactor(Factor cmd);
        void UpdateFactor(Factor cmd);
        void DeleteFactor(Factor cmd);
    }
}