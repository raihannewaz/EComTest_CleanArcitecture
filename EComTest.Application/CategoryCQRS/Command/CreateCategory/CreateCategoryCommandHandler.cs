
using EComTest.Domain.CategoryEntity;
using MediatR;


namespace EComTest.Application.CategoryCQRS.Command.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Category>
    {
        private readonly ICategoryRepository _repository;

        public CreateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }


        public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
           

            if (string.IsNullOrEmpty(request.CategoryName))
            {
                throw new InvalidDataException("Category Name Required!");
            }

            var category = Category.Create(request.CategoryName);

            var result = await _repository.CreateAsync(category);
            return result;
        }
    }
}
