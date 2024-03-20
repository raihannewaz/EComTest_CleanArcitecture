using EComTest.Domain.ProductEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Application.ProductCQRS.Command.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var product = await _productRepository.GetById(request.ProdId);

            if (product == null)
            {
                throw new ArgumentException($"Product with ID {request.ProdId} not found.");
            }

            if (!string.IsNullOrWhiteSpace(request.ProductName))
            {
                product.UpdateProductName(request.ProductName);
            }

            if (request.Price != 0)
            {
                product.UpdateProductPrice(request.Price);
            }

            if (request.CategoryId != 0)
            {
                product.UpdateCategoryId(request.CategoryId);
            }

            await _productRepository.SaveChagnes();

            return request.ProdId;
        }


       
    }
}
