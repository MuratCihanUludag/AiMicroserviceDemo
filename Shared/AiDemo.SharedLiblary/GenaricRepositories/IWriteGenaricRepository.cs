using ClassLibrary1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiDemo.SharedLiblary.GenaricRepositories
{
    public interface IWriteGenaricRepository<TEntity, TIdentifier> where TEntity : Entity<TIdentifier>
                                                         where TIdentifier : IEquatable<TIdentifier>
    {
        public Task<TEntity> AddAsync(TEntity entity);
        public Task<TEntity> UpdateAsync(TEntity entity);
        public Task DeleteAsync(TIdentifier id);
        public Task<bool> ExistsAsync(TIdentifier id);
    }
}
