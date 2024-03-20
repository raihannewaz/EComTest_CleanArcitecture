using EComTest.Domain.CategoryEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Application.CategoryCQRS.Queries.GetCategories
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetAll(request.sqlProc);
        }
    }
}
