using Microsoft.Extensions.DependencyInjection;

namespace AutoMapperConfigs
{
    public static class MapperConfig
    {
        public static IServiceCollection AddAutoMapperApi(this IServiceCollection services, Type assemblyContainingMappers)
        {
            services.AddAutoMapper(expression =>
            {
                expression.AllowNullCollections = true;
            },
            assemblyContainingMappers);

            return services;
        }
    }
}
