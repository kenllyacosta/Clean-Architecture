using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    /// <summary>
    /// Esta interface sirve paracuando necesitamos obtener la cantidad de registros de una tabla
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICountRepository<T> where T : class
    {
        Task<int> Count(Expression<Func<T, bool>> criteria, CancellationToken cancellationToken = default);
    }
}
