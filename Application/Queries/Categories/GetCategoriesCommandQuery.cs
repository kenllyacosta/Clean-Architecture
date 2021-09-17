using Domain.Entities;
using MediatR;
using Repository.EFCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Categories
{
    public class GetCategoriesCommandQuery : IRequest<List<Category>>
    {
        internal readonly Expression<Func<Category, bool>> Expression;
        internal readonly Expression<Func<Category, object>> Includes;
        public GetCategoriesCommandQuery(Expression<Func<Category, bool>> expression, Expression<Func<Category, object>> includes = default)
        {
            Expression = expression;
            Includes = includes;
        }
    }

    public class GetCategoriesCommandQueryHandler : IRequestHandler<GetCategoriesCommandQuery, List<Category>>
    {
        readonly CategoryRepository Repository;
        public GetCategoriesCommandQueryHandler(CategoryRepository repository)
        {
            Repository = repository;
        }

        public Task<List<Category>> Handle(GetCategoriesCommandQuery request, CancellationToken cancellationToken)
        {
            return Repository.Retrieves(request.Expression, request.Includes);
        }
    }
}
