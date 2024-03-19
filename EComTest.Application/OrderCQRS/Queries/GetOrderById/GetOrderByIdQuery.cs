using EComTest.Domain.OrderEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Application.OrderCQRS.Queries.GetOrderById
{
    public class GetOrderByIdQuery: IRequest<Order>
    {
        public int OrdId { get; set; }
    }
}
