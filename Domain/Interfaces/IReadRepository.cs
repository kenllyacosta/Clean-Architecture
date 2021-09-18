using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IReadRepository<T> where T : class
    {
        //R
        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> includes = null, bool enableTracking = false, CancellationToken cancellationToken = default);
        Task<List<T>> GetList(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> includes = null, bool enableTracking = false, CancellationToken cancellationToken = default);
        Task<List<T>> GetList(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> includes = null, bool enableTracking = false, Func<T, object> orderBy = null, int skip = 0, int take = 20, CancellationToken cancellationToken = default);
    }
}
