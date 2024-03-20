using EComTest.Domain.OrderEntity;
using EComTest.Domain.ProductEntity;
using EComTest.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Infrastructure.Order
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductRepository _productRepository;

        public OrderRepository(ApplicationDbContext context, IProductRepository product)
        {
            _context = context;
            _productRepository = product;
        }

        public async Task<Domain.OrderEntity.Order> CreateAsync(Domain.OrderEntity.Order order)
        {

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var o = await _context.Orders.FindAsync(id);
            if (o != null)
            {
                _context.Orders.Remove(o);
                _context.SaveChanges();
            }

            return id;
        }

        public async Task<List<Domain.OrderEntity.Order>> GetAll(string a)
        {

            var orders = await _context.Orders.FromSqlRaw(a).ToListAsync();

            foreach (var order in orders)
            {
                await _context.Entry(order).Reference(o => o.Product).Query().Include(p => p.Category).ToListAsync();
            }

            return orders;

        }

        public async Task<Domain.OrderEntity.Order> GetById(int id)
        {
            return await _context.Orders.Include(p=>p.Product).FirstOrDefaultAsync(a=>a.OrderId == id);
        }

        public async Task<List<Domain.OrderEntity.Order>> GetByIdForQuery(string a, int id)
        {

            var orders = await _context.Orders.FromSqlRaw(a + " " + id).ToListAsync();

            foreach (var order in orders)
            {
                await _context.Entry(order).Reference(o => o.Product).Query().Include(p => p.Category).ToListAsync();
            }

            return orders;


        }

        public async Task<int> UpdateAsync(int id, Domain.OrderEntity.Order updateOrder)
        {
            var order = await GetById(id);

            if (order == null)
            {
                throw new ArgumentException($"Order with ID {id} not found.");
            }

            if (updateOrder.Quantity != 0)
            {
                order.UpdateQuantityAndTotal(updateOrder.Quantity);
                await order.CalculateTotalAsync(_productRepository);
            }


            if (updateOrder.ProductId != 0)
            {
                order.UpdateProductId(updateOrder.ProductId);
            }

            await _context.SaveChangesAsync();

            return id;
        }


    }
}
