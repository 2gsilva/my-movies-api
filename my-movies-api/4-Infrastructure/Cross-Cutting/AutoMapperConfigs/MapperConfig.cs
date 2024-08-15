namespace my_movies_api.Infrastructure.Cross_Cutting.AutoMapperConfigs
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
