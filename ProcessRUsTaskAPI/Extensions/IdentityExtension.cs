using Microsoft.AspNetCore.Identity;
using ProcessRUsTask.Infrastructure;

namespace ProcessRUsTaskAPI.Extensions
{
    public static class IdentityExtension
    {
        public static void AddIdentityextension(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                            .AddEntityFrameworkStores<ProcessRUsTaskDbContext>()
                            .AddDefaultTokenProviders();
        }
    }
}
