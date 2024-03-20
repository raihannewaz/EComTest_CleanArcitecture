using EComTest.Domain.OrderEntity;
using EComTest.Domain.ProductEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Domain.CategoryEntity
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll(string a);
        Task<List<Category>> GetByIdForQuery(string a, int id);
        Task<Category> CreateAsync(Category category);
        Task<Category> GetById(int id);
        Task<int> DeleteAsync(int id);
        Task SaveChagnes();

    }
}
