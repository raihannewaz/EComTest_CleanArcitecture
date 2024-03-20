using EComTest.Domain.CategoryEntity;
using EComTest.Domain.OrderEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Domain.ProductEntity
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll(string a);
        Task<List<Product>> GetByIdForQuery(string a, int id);
        Task<Product> CreateAsync(Product product);
        Task<Product> GetById(int id);
        Task<int> DeleteAsync(int id);
        Task SaveChagnes();
    }
}
