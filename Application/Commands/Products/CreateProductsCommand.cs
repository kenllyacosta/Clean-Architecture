using Domain.Entities;
using MediatR;
using Repository.EFCore.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Products
{
    public class CreateProductsCommand : IRequest<bool>
    {
        internal readonly IEnumerable<Product> Products;
        public CreateProductsCommand(IEnumerable<Product> products)
        {
            Products = products;
        }
    }

    public class CreateProductsCommandHandler : IRequestHandler<CreateProductsCommand, bool>
    {
        private readonly ProductRepository Repository;
        public CreateProductsCommandHandler(ProductRepository repository)
        {
            Repository = repository;
        }

        public Task<bool> Handle(CreateProductsCommand request, CancellationToken cancellationToken)
        {
            //Aquí lanzamos las excepciones
            return Repository.Create(request.Products);
        }
    }
}
