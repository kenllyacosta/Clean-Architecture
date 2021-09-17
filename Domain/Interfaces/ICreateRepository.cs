using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICreateRepository<T> where T : class
    {
        //C
        Task<T> Create(T entity, CancellationToken cancellationToken = default);
        Task<bool> Create(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    }
}
