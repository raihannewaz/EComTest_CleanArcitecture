
using MediatR;


namespace EComTest.Application.CategoryCQRS.Command.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<int>
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
