using Domain.Entities;
using MediatR;
using Repository.EFCore.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Products
{
    public class DeleteProductsCommand : IRequest<bool>
    {
        internal readonly IEnumerable<Product> Products;
        public DeleteProductsCommand(IEnumerable<Product> products)
        {
            Products = products;
        }
    }

    public class DeleteProductsCommandHandler : IRequestHandler<DeleteProductsCommand, bool>
    {
        readonly ProductRepository ProductRepository;
        public DeleteProductsCommandHandler(ProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }
        public Task<bool> Handle(DeleteProductsCommand request, CancellationToken cancellationToken)
        {
            //Aquí lanzamos las excepciones
            return ProductRepository.Delete(request.Products);
        }
    }
}
