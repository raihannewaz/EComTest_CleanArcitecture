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
            var order = await _orderRepository.GetById(request.OrderId);

            if (order == null)
            {
                throw new ArgumentException($"Order with ID {request.OrderId} not found.");
            }

            if (request.Quantity != 0)
            {
                order.UpdateQuantityAndTotal(request.Quantity);
                await Order.CalculateTotalAsync(_product);
            }

            if (request.ProductId != 0)
            {
                order.UpdateProductId(request.ProductId);
            }

            await _orderRepository.SaveChagnes();

            return request.OrderId;
        }
    }
}
