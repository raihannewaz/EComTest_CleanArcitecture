using EComTest.Domain.OrderEntity;
using EComTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
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

        public async Task<Domain.OrderEntity.Order> GetById(int id)
        {
            return await _context.Orders.Include(p=>p.Product).FirstOrDefaultAsync(a=>a.OrderId == id);
        }

        public async Task<int> UpdateAsync(int id, Domain.OrderEntity.Order updateOrder)
        {
            var order = await GetById(id);

            if (order == null)
            {
                throw new ArgumentException($"Order with ID {id} not found.");
            }

            if (updateOrder.Quantity != null)
            {
                order.UpdateQuantityAndTotal(updateOrder.Quantity);
            }

            if (updateOrder.ProductId != null)
            {
                order.UpdateProductId(updateOrder.ProductId);
            }

            await _context.SaveChangesAsync();

            return id;
        }
    }
}
