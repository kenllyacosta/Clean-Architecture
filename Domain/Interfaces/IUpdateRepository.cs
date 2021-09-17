using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUpdateRepository<T> where T : class
    {
        //U
        Task<bool> Update(T entity, CancellationToken cancellationToken = default);
        Task<bool> Update(Expression<Func<T, bool>> criteria, string propertyName, object value, CancellationToken cancellationToken = default);
        Task<bool> Update(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    }
}
