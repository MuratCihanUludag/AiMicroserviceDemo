using ClassLibrary1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AiDemo.SharedLiblary.GenaricRepositories.Abstractions
{
    public interface IWriteGenaricRepository<TEntity, TIdentifier> 
        where TEntity : Entity<TIdentifier>
        where TIdentifier : IEquatable<TIdentifier>
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);
        Task DeleteAsync(TIdentifier id);
        Task DeleteRangeAsync(IEnumerable<TIdentifier> ids);
        Task DeleteWhereAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> ExistsAsync(TIdentifier id);
    }
}
