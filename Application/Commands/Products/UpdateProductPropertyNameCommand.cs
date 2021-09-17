using MediatR;
using Repository.EFCore.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Products
{
    public class UpdateProductPropertyNameCommand : IRequest<bool>
    {
        internal readonly int Id;
        internal readonly string PropertyName;
        internal readonly object Value;
        public UpdateProductPropertyNameCommand(int id, string propertyName, object value) => (Id, PropertyName, Value) = (id, propertyName, value);
    }

    public class UpdateProductPropertyNameCommandHandler : IRequestHandler<UpdateProductPropertyNameCommand, bool>
    {
        readonly ProductRepository ProductRepository;
        public UpdateProductPropertyNameCommandHandler(ProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public Task<bool> Handle(UpdateProductPropertyNameCommand request, CancellationToken cancellationToken)
        {
            //Aquí lanzamos las excepciones
            return ProductRepository.Update(x => x.Id == request.Id, request.PropertyName, request.Value);
        }
    }
}
