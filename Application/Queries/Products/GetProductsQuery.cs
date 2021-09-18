using Domain.Entities;
using MediatR;
using Repository.EFCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Products
{
    public class GetProductsQuery : IRequest<List<Product>>
    {
        internal readonly Expression<Func<Product, bool>> Expression;
        internal readonly Expression<Func<Product, object>> Includes;
        public GetProductsQuery(Expression<Func<Product, bool>> expression, Expression<Func<Product, object>> includes = default)
        {
            Expression = expression;
            Includes = includes;
        }
    }

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<Product>>
    {
        readonly ProductRepository Repository;
        public GetProductsQueryHandler(ProductRepository repository)
        {
            Repository = repository;
        }

        public Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            //Aquí lanzamos  las excepciones
            return Repository.GetList(request.Expression, request.Includes, false, cancellationToken);
        }
    }
}
