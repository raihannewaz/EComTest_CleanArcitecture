using EComTest.Domain.CategoryEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Application.CategoryCQRS.Command.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, int>
    {
        private readonly ICategoryRepository _repository;

        public UpdateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }


        public async Task<int> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {

            var category = new Category();

            category.UpdateCategory(request.CategoryId, request.CategoryName);

            return await _repository.UpdateAsync(request.CategoryId, category);
            

        }
    }
}
