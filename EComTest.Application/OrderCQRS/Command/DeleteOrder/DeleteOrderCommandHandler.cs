using EComTest.Domain.OrderEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Application.OrderCQRS.Command.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        public DeleteOrderCommandHandler(IOrderRepository order)
        {
            _orderRepository = order;
        }

        public Task<int> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            return _orderRepository.DeleteAsync(request.OrdId);
        }
    }
}
