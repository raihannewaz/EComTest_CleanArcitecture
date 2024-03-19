using MediatR;
using EComTest.Domain.CategoryEntity;

namespace EComTest.Application.CategoryCQRS.Queries.GetCategories
{
    public class GetCategoryQuery : IRequest<List<Category>>
    {
    }
}
