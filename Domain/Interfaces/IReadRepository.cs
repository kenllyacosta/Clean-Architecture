using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IReadRepository<T> where T : class
    {
        Task<T> GetSingleOrDefault(Expression<Func<T, bool>> criteria = null,
            Func<T, object> orderBy = null,
            Expression<Func<T, object>> includes = null,
            bool enableTracking = false, CancellationToken cancellationToken = default);

        Task<List<T>> GetList(Expression<Func<T, bool>> criteria = null,
            Func<T, object> orderBy = null,
            Expression<Func<T, object>> includes = null,
            int skip = 0,
            int take = 20,
            bool enableTracking = false, CancellationToken cancellationToken = default);

        Task<int> Count(Expression<Func<T, bool>> criteria, CancellationToken cancellationToken = default);
    }
}
