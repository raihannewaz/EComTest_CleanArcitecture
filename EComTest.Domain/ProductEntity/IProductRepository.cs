using EComTest.Domain.CategoryEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Domain.ProductEntity
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product);
        Task<Product> GetById(int id);
        Task<int> UpdateAsync(int id, Product product);
        Task<int> DeleteAsync(int id);
    }
}
