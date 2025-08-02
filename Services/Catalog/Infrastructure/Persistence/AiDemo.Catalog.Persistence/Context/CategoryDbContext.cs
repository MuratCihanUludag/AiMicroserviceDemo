using AiDemo.Catalog.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AiDemo.Catalog.Persistence.Context
{
    public class CategoryDbContext : DbContext
    {
        public CategoryDbContext(DbContextOptions<CategoryDbContext> options) : base(options) { }
        public static CategoryDbContext Create(IMongoDatabase database)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CategoryDbContext>()
                .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName);
            return new CategoryDbContext(optionsBuilder.Options);
        }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        }

    }
}
