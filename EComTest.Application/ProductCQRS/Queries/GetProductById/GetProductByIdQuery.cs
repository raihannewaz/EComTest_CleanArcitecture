﻿using EComTest.Domain.ProductEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Application.ProductCQRS.Queries.GetProductById
{
    public class GetProductByIdQuery:IRequest<List<Product>>
    {
        public int ProdId { get; set; }

        public string sqlProc = "EXEC GetProductById";
    }
}
