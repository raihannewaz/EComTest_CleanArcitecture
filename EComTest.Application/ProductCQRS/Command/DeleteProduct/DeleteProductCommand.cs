using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Application.ProductCQRS.Command.DeleteProduct
{
    public class DeleteProductCommand: IRequest<int>
    {
        public int prodId { get; set; }
    }
}
