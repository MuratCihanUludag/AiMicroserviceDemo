using ClassLibrary1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiDemo.SharedLiblary.GenaricRepositories
{
    public interface IReadGenaricRepository<TEntity, TIdentifier> where TEntity : Entity<TIdentifier>
                                                         where TIdentifier : IEquatable<TIdentifier>
    {
        public Task<TEntity?> GetByIdAsync(TIdentifier id);
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<IEnumerable<TEntity>> FindAsync(Func<TEntity, bool> predicate);

    }
}
