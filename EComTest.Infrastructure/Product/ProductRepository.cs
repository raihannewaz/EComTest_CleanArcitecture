using EComTest.Domain.CategoryEntity;
using EComTest.Domain.ProductEntity;
using EComTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Infrastructure.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Domain.ProductEntity.Product> CreateAsync(Domain.ProductEntity.Product product)
        {

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var p = await _context.Products.FindAsync(id);
            if (p != null)
            {
                _context.Products.Remove(p);
                _context.SaveChanges();
            }

            return id;
        }

        public async Task<List<Domain.ProductEntity.Product>> GetAll(string a)
        {
            var data = await _context.Products.FromSqlRaw(a).ToListAsync();
            return data;
        }

        public async Task<Domain.ProductEntity.Product> GetById(int id)
        {
            return await _context.Products.Include(c => c.Category).FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<List<Domain.ProductEntity.Product>> GetByIdForQuery(string a, int id)
        {
            var data = await _context.Products.FromSqlRaw(a +" "+ id).ToListAsync();

            return data;
        }

        public async Task SaveChagnes()
        {
            await _context.SaveChangesAsync();
        }
    }
}
