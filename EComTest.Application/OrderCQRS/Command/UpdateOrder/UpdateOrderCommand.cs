using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Application.OrderCQRS.Command.UpdateOrder
{
    public class UpdateOrderCommand: IRequest<int>
    {
        public int OrderId { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }
    }
}
