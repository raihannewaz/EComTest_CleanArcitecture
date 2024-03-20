using EComTest.Domain.OrderEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Application.OrderCQRS.Command.CreateOrder
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}
