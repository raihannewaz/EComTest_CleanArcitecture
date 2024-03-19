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
        Task<Category> CreateAsync(Category category);
        Task<Category> GetById(int id);
        Task<int> UpdateAsync(int id,Category category);
        Task<int> DeleteAsync(int id);

    }
}
