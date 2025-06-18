using Apllication.Interfaces.Repository;
using Infrastructure.Services.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped<IClientRepository, ClientRepository>();

            return services;
        }
    }
}