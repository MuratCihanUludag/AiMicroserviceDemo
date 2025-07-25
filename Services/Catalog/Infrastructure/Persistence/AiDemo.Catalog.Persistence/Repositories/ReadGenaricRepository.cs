using AiDemo.Catalog.Persistence.Context;
using AiDemo.SharedLiblary.GenaricRepositories.Abstractions;
using ClassLibrary1.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AiDemo.Catalog.Persistence.Repositories
{
    public class ReadGenaricRepository<TEntity, TIdentifier> : IReadGenaricRepository<TEntity, TIdentifier> where TEntity : Entity<TIdentifier>
        where TIdentifier : IEquatable<TIdentifier>
    {
        private readonly CatalogDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public ReadGenaricRepository(CatalogDbContext context)
        {
            _context = context;
            _dbSet = _dbSet = _context.Set<TEntity>();
        }
        protected IQueryable<TEntity> GetQueryable()
        {
            return _dbSet.AsNoTracking();
        }
        public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = GetQueryable();
            query = query.Where(predicate);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = GetQueryable();

            foreach (var include in includes)
                query = query.Include(include);

            if (predicate != null)
                query = query.Where(predicate);

            return await query.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TIdentifier id)
        {
            IQueryable<TEntity> query = GetQueryable();
            return await query.FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public async Task<IEnumerable<TEntity>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
        {
            IQueryable<TEntity> query = GetQueryable();
            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = orderBy(query);
            else
                query = query.OrderBy(e => e.Id);

            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return await query.ToListAsync();
        }
    }
}
