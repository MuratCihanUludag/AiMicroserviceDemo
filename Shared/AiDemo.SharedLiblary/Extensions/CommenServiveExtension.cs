using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AiDemo.SharedLiblary.Extensions
{
    public static class CommenServiveExtension
    {
        public static IServiceCollection AddCommenServiceExtension<TMarker>(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<TMarker>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<TMarker>());
            return services;
        }
    }
}
