﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Application.OrderCQRS.Command.UpdateOrder
{
    public class UpdateOrderCommand: IRequest<int>
    {
        public int OrderId { get; private set; }

        public int Quantity { get; private set; }

        public int ProductId { get; private set; }
    }
}
