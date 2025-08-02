using AiDemo.Catalog.Persistence.Context;
using AiDemo.Catalog.Persistence.Options;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiDemo.Catalog.Persistence.Extensions
{
    public static class CategoryServicePersistanceExtension
    {
        public static IServiceCollection AddCategoryPersistence(this IServiceCollection services)
        {
            services.AddSingleton<IMongoClient, MongoClient>(sp =>
            {
                var options = sp.GetRequiredService<MongoOption>();
                return new MongoClient(options.ConnectionString);
            });

            services.AddScoped(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                var options = sp.GetRequiredService<MongoOption>();
                return CategoryDbContext.Create(client.GetDatabase(options.DatabaseName));
            });

            return services;
        }
    }
}
