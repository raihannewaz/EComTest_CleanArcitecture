using EComTest.Domain.OrderEntity;
using EComTest.Domain.ProductEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Application.OrderCQRS.Command.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _product;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IProductRepository product)
        {
            _orderRepository = orderRepository;
            _product = product; 
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
           
            var order = Order.CreateOrder(request.Quantity, request.ProductId);
            await Order.CalculateTotalAsync(_product);

            return await _orderRepository.CreateAsync(order);
        }
    }
}
