using Microsoft.AspNetCore.Identity;
using ProcessRUsTask.Infrastructure;

namespace ProcessRUsTask.Extensions
{
    public static class ProcessRUsTaskDbInitializerExtension
    {
        public static async Task DbInitialization(IApplicationBuilder builder)
        {
            using var serviceScope = builder.ApplicationServices.CreateScope();

            var serviceProvider = serviceScope.ServiceProvider;
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await ProcessRUsTaskDbInitializer.Seed(builder, userManager, roleManager);
        }
    }
}
