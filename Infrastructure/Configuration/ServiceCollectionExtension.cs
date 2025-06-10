using Infrastructure.Configurartion;
using Microsoft.EntityFrameworkCore;

public static class ServiceCollectionExtension
{
    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var applicationOptions = new ApplicationOptions();
        configuration.GetSection(ApplicationOptions.Section).Bind(applicationOptions);

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(applicationOptions.ConnectionString));
    }
}
