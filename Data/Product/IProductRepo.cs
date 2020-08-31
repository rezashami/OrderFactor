using System.Collections.Generic;
using Simulation.Models;

namespace Simulation.Data
{
    public interface IProductRepo
    {
        bool SaveChanges();

        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        void CreateProduct(Product cmd);
        void UpdateProduct(Product cmd);
        void DeleteProduct(Product cmd);
    }
}