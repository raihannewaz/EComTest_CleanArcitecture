using EComTest.Domain.OrderEntity;
using EComTest.Domain.ProductEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Application.OrderCQRS.Command.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, int>
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _product;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IProductRepository product)
        {
            _orderRepository = orderRepository;
            _product = product;
        }

        public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order();
            order.UpdateOrder(request.OrderId, request.Quantity, request.ProductId);
            

            return await _orderRepository.UpdateAsync(request.OrderId, order);
        }
    }
}
