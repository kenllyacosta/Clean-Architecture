using Domain.Entities;
using MediatR;
using Repository.EFCore.Repositories;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Products
{
    public class CountProductsQuery : IRequest<int>
    {
        internal readonly Expression<Func<Product, bool>> Expression;
        public CountProductsQuery(Expression<Func<Product, bool>> expression)
        {
            Expression = expression;
        }
    }

    public class CountProductsQueryHandler : IRequestHandler<CountProductsQuery, int>
    {
        readonly ProductRepository Repository;
        public CountProductsQueryHandler(ProductRepository repository)
        {
            Repository = repository;
        }

        public Task<int> Handle(CountProductsQuery request, CancellationToken cancellationToken)
        {
            return Repository.Count(request.Expression);
        }
    }
}
