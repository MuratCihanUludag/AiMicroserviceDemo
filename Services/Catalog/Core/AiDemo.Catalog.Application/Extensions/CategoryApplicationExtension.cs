using AiDemo.Catalog.Persistence.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiDemo.Catalog.Application.Extensions
{
    public static class CategoryApplicationExtension
    {
        public static IServiceCollection AddCategoryApplicationExtension(this IServiceCollection services)
        {
            services.AddCategoryPersistence();
            return services;
        }
    }
}
