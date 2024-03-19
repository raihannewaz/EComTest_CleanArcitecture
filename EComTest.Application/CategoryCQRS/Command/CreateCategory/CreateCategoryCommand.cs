using EComTest.Domain.CategoryEntity;
using MediatR;


namespace EComTest.Application.CategoryCQRS.Command.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Category>
    {
        public string CategoryName { get; set; }
    }
}
