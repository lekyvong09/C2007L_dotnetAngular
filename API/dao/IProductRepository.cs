using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.dao
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<List<Product>> GetProductsAsync();
    }
}