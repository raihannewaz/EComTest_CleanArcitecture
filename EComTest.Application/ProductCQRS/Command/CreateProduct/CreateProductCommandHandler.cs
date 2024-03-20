﻿using EComTest.Domain.ProductEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Application.ProductCQRS.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            if (string.IsNullOrEmpty(request.ProductName))
            {
                throw new InvalidDataException("Product Name Required");
            }

            if (request.Price == 0)
            {
                throw new InvalidDataException("Product price Required");
            }

            if (request.CategoryId == 0)
            {
                throw new InvalidDataException("Product Category Required");
            }

            var product = Product.CreateProduct(request.ProductName, request.Price, request.CategoryId);

            var result = _productRepository.CreateAsync(product);
            return result;
        }
    }
}
