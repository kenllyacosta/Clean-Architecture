using Domain.Entities;
using MediatR;
using Repository.EFCore.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Products
{
    public class UpdateProductsCommand : IRequest<bool>
    {
        internal readonly IEnumerable<Product> Products;
        public UpdateProductsCommand(IEnumerable<Product> products)
        {
            Products = products;
        }
    }

    public class UpdateProductsCommandHandler : IRequestHandler<UpdateProductsCommand, bool>
    {
        readonly ProductRepository ProductRepository;
        public UpdateProductsCommandHandler(ProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public Task<bool> Handle(UpdateProductsCommand request, CancellationToken cancellationToken)
        {
            //Aquí lanzamos las excepciones
            return ProductRepository.Update(request.Products);
        }
    }
}
