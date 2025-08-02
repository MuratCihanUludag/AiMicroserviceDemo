using AiDemo.Catalog.Application.Extensions;

namespace AiDemi.Catalog.PresentationAPI.Extensions
{
    public static class CategoryApiExtension
    {
        public static IServiceCollection AddCategoryApiExtension(this IServiceCollection services)
        {
            services.AddCategoryApplicationExtension();
            return services;
        }
    }
}
