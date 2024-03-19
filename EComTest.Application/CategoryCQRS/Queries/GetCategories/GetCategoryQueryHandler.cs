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
        public Task<List<Category>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
