using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MovieApi.Persistence.Context;
using MovieApi.Persistence.Identity;

namespace MovieApi.WebApi.Extensions
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>(opt => 
            {
                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireDigit = true;

                opt.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<MovieContext>()
            .AddDefaultTokenProviders();

            return services;
        }
    }
}
