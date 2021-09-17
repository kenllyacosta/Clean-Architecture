using Domain.Entities;
using MediatR;
using Repository.EFCore.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Products
{
    public class UpdateProductCommand : IRequest<bool>
    {
        internal readonly Product Product;
        public UpdateProductCommand(Product product)
        {
            Product = product;
        }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        readonly ProductRepository ProductRepository;
        public UpdateProductCommandHandler(ProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            //Aquí lanzamos las excepciones
            return ProductRepository.Update(request.Product);
        }
    }
}
