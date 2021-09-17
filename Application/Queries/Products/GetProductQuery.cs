using Domain.Entities;
using MediatR;
using Repository.EFCore.Repositories;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Products
{
    public class GetProductQuery : IRequest<Product>
    {
        internal readonly Expression<Func<Product, bool>> Expression;
        internal readonly Expression<Func<Product, object>> Includes;
        public GetProductQuery(Expression<Func<Product, bool>> expression, Expression<Func<Product, object>> includes = default)
        {
            Expression = expression;
            Includes = includes;
        }
    }

    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
    {
        readonly ProductRepository Repository;
        public GetProductQueryHandler(ProductRepository repository)
        {
            Repository = repository;
        }
        public Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            //Aquí lanzamos  las excepciones
            return Repository.Retrieve(request.Expression, request.Includes);
        }
    }
}
