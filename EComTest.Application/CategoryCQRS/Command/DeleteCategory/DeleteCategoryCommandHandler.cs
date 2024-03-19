using EComTest.Domain.CategoryEntity;
using MediatR;


namespace EComTest.Application.CategoryCQRS.Command.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, int>
    {
        private readonly ICategoryRepository _repository;

        public DeleteCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }


        public async Task<int> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(request.CatId);
        }
    }
}
