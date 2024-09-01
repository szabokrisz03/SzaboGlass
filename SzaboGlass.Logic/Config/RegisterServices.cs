using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using SzaboGlass.Data;
using SzaboGlass.Logic.Config.MapperConfigurations;
using SzaboGlass.Logic.Interfaces;
using SzaboGlass.Logic.Services;

namespace SzaboGlass.Logic.Config
{
    public static class RegisterServices
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString("default");
            serviceDescriptors.AddDbContext<Program>(options =>
            {
                options.UseSqlite(connString);
            });

            return serviceDescriptors;
        }

        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddAutoMapper(typeof(MapperConfiguration));
            services.AddTransient<IGlassService, GlassService>();
            
            return services;
        }
    }
}
