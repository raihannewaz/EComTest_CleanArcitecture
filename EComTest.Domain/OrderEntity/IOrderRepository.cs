using EComTest.Domain.ProductEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Domain.OrderEntity
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAll(string a);
        Task<Order> CreateAsync(Order order);
        Task<Order> GetById(int id);
        Task<int> UpdateAsync(int id, Order order);
        Task<int> DeleteAsync(int id);
    }
}
