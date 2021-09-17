using Domain.Entities;
using MediatR;
using Repository.EFCore.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Categories
{
    public class CreateCategoryCommand : IRequest<Category>
    {
        //Lo necesario para crear el registro
        internal readonly Category Category;
        public CreateCategoryCommand(Category category)
        {
            Category = category;
        }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Category>
    {
        readonly CategoryRepository Repository;
        public CreateCategoryCommandHandler(CategoryRepository repository)
        {
            Repository = repository;
        }

        public Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            return Repository.Create(request.Category, cancellationToken);
        }
    }
}
