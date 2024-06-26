﻿using EComTest.Domain.ProductEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Application.ProductCQRS.Queries.GetProducts
{
    public class GetProductQuery: IRequest<List<Product>>
    {
        public string sqlProc = "EXEC GetProduct";
    }
}
