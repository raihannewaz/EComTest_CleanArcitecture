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
    }
}
