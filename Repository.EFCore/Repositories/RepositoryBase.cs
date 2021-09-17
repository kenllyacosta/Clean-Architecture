using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Repository.EFCore.Repositories
{
    public class RepositoryBase<T> : IReadRepository<T>, IRepository<T> where T : class
    {
        private readonly ApplicationDbContext Context;
        public RepositoryBase(ApplicationDbContext context)
        {
            Context = context;
        }

        public Task<int> Count(Expression<Func<T, bool>> criteria, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Context.Set<T>().AsNoTracking().Count(criteria));
        }

        public Task<T> Create(T entity, CancellationToken cancellationToken = default)
        {
            EntityEntry<T> Result = Context.Set<T>().Add(entity);
            _ = Context.SaveChanges();
            return Task.FromResult(Result.Entity);
        }

        public Task<bool> Create(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            Context.Set<T>().AddRange(entities);
            return Task.FromResult(Context.SaveChanges() != 0);
        }

        public Task<bool> Delete(Expression<Func<T, bool>> criteria, CancellationToken cancellationToken = default)
        {
            Context.Set<T>().Remove(Retrieve(criteria).Result);
            return Task.FromResult(Context.SaveChanges() != 0);
        }

        public Task<bool> Delete(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            Context.Set<T>().RemoveRange(entities);
            return Task.FromResult(Context.SaveChanges() != 0);
        }

        public Task<List<T>> GetList(Expression<Func<T, bool>> criteria = null, Func<T, object> orderBy = null, Expression<Func<T, object>> includes = null, int skip = 0, int take = 20, bool enableTracking = false, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Context.Set<T>().Include(includes).Where(criteria).OrderBy(orderBy).Take(take).Skip(skip).ToList());
        }

        public Task<T> GetSingleOrDefault(Expression<Func<T, bool>> criteria = null, Func<T, object> orderBy = null, Expression<Func<T, object>> includes = null, bool enableTracking = false, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Context.Set<T>().AsNoTracking().Include(includes).FirstOrDefault(criteria));
        }

        public Task<T> Retrieve(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> includes = null, bool noTracking = false, CancellationToken cancellationToken = default)
        {
            if (includes != null)
            {
                if (noTracking)
                    return Task.FromResult(Context.Set<T>().AsNoTracking().Include(includes).FirstOrDefault(criteria));
                else
                    return Task.FromResult(Context.Set<T>().Include(includes).FirstOrDefault(criteria));
            }
            else
            {
                if (noTracking)
                    return Task.FromResult(Context.Set<T>().AsNoTracking().FirstOrDefault(criteria));
                else
                    return Task.FromResult(Context.Set<T>().Include(includes).FirstOrDefault(criteria));
            }
        }

        public Task<List<T>> Retrieves(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> includes = default, bool noTracking = false, CancellationToken cancellationToken = default)
        {
            Task<List<T>> Results = default;
            if (includes != null)
            {
                if (noTracking)
                    Results = Task.FromResult(Context.Set<T>().AsNoTracking().Include(includes).Where(criteria).ToList());
                else
                    Results = Task.FromResult(Context.Set<T>().Include(includes).Where(criteria).ToList());
            }
            else
            {
                if (noTracking)
                    Results = Task.FromResult(Context.Set<T>().AsNoTracking().Where(criteria).ToList());
                else
                    Results = Task.FromResult(Context.Set<T>().Where(criteria).ToList());
            }

            return Results;
        }

        public Task<bool> Update(T entity, CancellationToken cancellationToken = default)
        {
            Context.Set<T>().Update(entity);
            return Task.FromResult(Context.SaveChanges() != 0);
        }

        public Task<bool> Update(Expression<Func<T, bool>> criteria, string propertyName, object value, CancellationToken cancellationToken = default)
        {
            Context.Entry(Context.Set<T>().AsNoTracking().FirstOrDefault(criteria)).Property(propertyName).CurrentValue = value;
            return Task.FromResult(Context.SaveChanges() != 0);
        }

        public Task<bool> Update(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            Context.Set<T>().UpdateRange(entities);
            return Task.FromResult(Context.SaveChanges() != 0);
        }
    }
}
