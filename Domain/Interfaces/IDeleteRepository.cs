using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDeleteRepository<T>
    {
        //D
        Task<bool> Delete(Expression<Func<T, bool>> criteria, CancellationToken cancellationToken = default);
        Task<bool> Delete(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    }
}
