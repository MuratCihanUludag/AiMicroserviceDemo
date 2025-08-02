using AiDemo.Catalog.Persistence.Context;
using AiDemo.SharedLiblary.GenaricRepositories.Abstractions;
using ClassLibrary1.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AiDemo.Catalog.Persistence.Repositories
{
    public class WriteGenaricRepository<TEntity, TIdentifier> : IWriteGenaricRepository<TEntity, TIdentifier>
        where TEntity : Entity<TIdentifier>
        where TIdentifier : IEquatable<TIdentifier>
    {
        private readonly CategoryDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public WriteGenaricRepository(CategoryDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TIdentifier id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<TIdentifier> ids)
        {
            throw new NotImplementedException();
        }

        public Task DeleteWhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(TIdentifier id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
