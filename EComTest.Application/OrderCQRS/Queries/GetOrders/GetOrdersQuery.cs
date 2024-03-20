using EComTest.Domain.OrderEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Application.OrderCQRS.Queries.GetOrders
{
    public class GetOrdersQuery :  IRequest<List<Order>>
    {
        public string sqlQuery = @"SELECT o.OrderId, o.Quantity, o.Total,p.ProductId, p.ProductName, p.Price,c.CategoryId, c.CategoryName
                                    FROM Orders o
                                    INNER JOIN Products p ON o.ProductId = p.ProductId
                                    INNER JOIN Categories c ON p.CategoryId = c.CategoryId";
    }
}
