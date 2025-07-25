using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiDemo.SharedLiblary.GenaricRepositories.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesWithEventsAsync();
        Task<int> SaveChangesWithEventsAndTransactionAsync();
        Task<int> SaveChangesWithTransactionAsync();
        Task Rollback();
        Task Commit();
    }
}
