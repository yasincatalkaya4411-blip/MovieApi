using MovieApi.Application.Features.CQRS_design_pattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRS_design_pattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRS_design_pattern.Handlers.SeriesHandlers;
using MovieApi.Application.Features.CQRS_design_pattern.Handlers.UserRegisterHandlers;

namespace MovieApi.WebApi.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Category handlers
            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();

            // Movie handlers
            services.AddScoped<GetMovieQueryHandler>();
            services.AddScoped<GetMovieByIdQueryHandler>();
            services.AddScoped<CreateMovieCommandHandler>();
            services.AddScoped<RemoveMovieCommandHandler>();
            services.AddScoped<UpdateMovieCommandHandler>();
            services.AddScoped<GetMovieWithCategoryQueryHandler>();
            // Series handlers
            services.AddScoped<GetSeriesQueryHandler>();
            services.AddScoped<GetSeriesByIdQueryHandler>();
            services.AddScoped<CreateSeriesCommandHandler>();
            services.AddScoped<RemoveSeriesCommandHandler>();
            services.AddScoped<UpdateSeriesCommandHandler>();
            services.AddScoped<GetSeriesWithCategoryQueryHandler>();


           services.AddScoped<CreateUserRegisterCommandHandler>();

            return services;

        }
    }
}
