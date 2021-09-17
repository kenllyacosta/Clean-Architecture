using Domain.Entities;
using MediatR;
using Repository.EFCore.Repositories;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Products
{
    public class DeleteProductCommand : IRequest<bool>
    {
        internal readonly Expression<Func<Product, bool>> Expression;
        public DeleteProductCommand(Expression<Func<Product, bool>> expression)
        {
            Expression = expression;
        }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        readonly ProductRepository ProductRepository;
        public DeleteProductCommandHandler(ProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            //Aquí lanzamos las excepciones
            return ProductRepository.Delete(request.Expression);
        }
    }
}
