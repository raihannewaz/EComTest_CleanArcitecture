using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Application.OrderCQRS.Command.DeleteOrder
{
    public class DeleteOrderCommand: IRequest<int>
    {
        public int OrdId { get; set; }
    }
}
