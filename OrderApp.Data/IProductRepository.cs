using OrderApp.Domain;
using System.Collections.Generic;

namespace OrderApp.Data
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveAll();
    }
}