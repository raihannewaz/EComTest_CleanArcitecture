﻿using EComTest.Domain.CategoryEntity;
using EComTest.Domain.ProductEntity;
using EComTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Infrastructure.CategoryProduct
{
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Domain.CategoryEntity.Category> CreateAsync(Domain.CategoryEntity.Category category)
        {

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var c = await _context.Categories.FindAsync(id);
            if (c != null)
            {
                _context.Categories.Remove(c);
                _context.SaveChanges();
            }

            return id;
        }

        public async Task<List<Domain.CategoryEntity.Category>> GetAll(string a)
        {
            var data = await _context.Categories.FromSqlRaw(a).ToListAsync();
            return data;
        }

        public async Task<Domain.CategoryEntity.Category> GetById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(a => a.CategoryId == id);
        }

        public async Task<List<Domain.CategoryEntity.Category>> GetByIdForQuery(string a, int id)
        {
            var data  =  await _context.Categories.FromSqlRaw(a + " " + id).ToListAsync();

            return data;
        }

        public async Task SaveChagnes()
        {
            await _context.SaveChangesAsync();
        }

       

    }
}
