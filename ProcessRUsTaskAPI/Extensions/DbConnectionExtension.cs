using Microsoft.EntityFrameworkCore;
using ProcessRUsTask.Configurations;
using ProcessRUsTask.Infrastructure;

namespace ProcessRUsTask.Extensions
{
    public static class DbConnectionExtension
    {
        public static void AddDbConnectionExtension(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionStrings = new ConnectionStrings();

            configuration.Bind(nameof(connectionStrings), connectionStrings);

            services.AddDbContext<ProcessRUsTaskDbContext>(options =>
                options.UseSqlite(connectionStrings.DefaultConnection)
            );
        }
    }
}
