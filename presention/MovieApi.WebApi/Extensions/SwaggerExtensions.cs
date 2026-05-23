namespace MovieApi.WebApi.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
           services.AddSwaggerGen();
            return services;
        }

    }
}
