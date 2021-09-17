using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    /// <summary>
    /// Con la implementación de  esta interface hacemos las operaciones
    /// CRUD básicas para el manejo de los datos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        //C
        Task<T> Create(T entity, CancellationToken cancellationToken = default);
        Task<bool> Create(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        //R
        Task<T> Retrieve(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> includes = null, bool noTracking = false, CancellationToken cancellationToken = default);
        Task<List<T>> Retrieves(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> includes = null, bool noTracking = false, CancellationToken cancellationToken = default);

        //U
        Task<bool> Update(T entity, CancellationToken cancellationToken = default);
        Task<bool> Update(Expression<Func<T, bool>> criteria, string propertyName, object value, CancellationToken cancellationToken = default);
        Task<bool> Update(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        //D
        Task<bool> Delete(Expression<Func<T, bool>> criteria, CancellationToken cancellationToken = default);
        Task<bool> Delete(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        //Others
        Task<int> Count(Expression<Func<T, bool>> criteria, CancellationToken cancellationToken = default);
    }
}
