using Application.Validators.Products;
using Domain.Entities;
using MediatR;
using Repository.EFCore.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Products
{
    public class CreateProductCommand : IRequest<Product>
    {
        //Lo necesario para crear el registro
        internal readonly Product Product;
        public CreateProductCommand(Product product)
        {
            Product = product;
        }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        readonly ProductRepository Repository;
        public CreateProductCommandHandler(ProductRepository repository)
        {
            Repository = repository;
        }

        public Task<Product> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            return Repository.Create(command.Product, cancellationToken);
        }
    }
}
