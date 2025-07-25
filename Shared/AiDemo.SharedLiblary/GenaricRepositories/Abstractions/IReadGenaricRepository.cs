using ClassLibrary1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AiDemo.SharedLiblary.GenaricRepositories.Abstractions
{
    public interface IReadGenaricRepository<TEntity, TIdentifier>
        where TEntity : Entity<TIdentifier>
        where TIdentifier : IEquatable<TIdentifier>
    {
        public Task<TEntity?> GetByIdAsync(TIdentifier id);
        public Task<IEnumerable<TEntity>> GetAllAsync(
           Expression<Func<TEntity, bool>>? predicate = null, 
           params Expression<Func<TEntity, object>>[] includes);
        public Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        public Task<IEnumerable<TEntity>> GetPagedAsync(
            int pageNumber, 
            int pageSize, 
            Expression<Func<TEntity, bool>>? predicate = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);
    }
}
