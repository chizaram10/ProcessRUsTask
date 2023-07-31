using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using ProcessRUsTask.Entities;

namespace ProcessRUsTask.Infrastructure
{
    public static class ProcessRUsTaskDbInitializer
    {
        private readonly static string DATAPATH = @"ProcessRUsTaskAPI\Infrastructure\Data\";

        public static async Task Seed(IApplicationBuilder builder, UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            using var serviceScope = builder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ProcessRUsTaskDbContext>();
            if (context!.Users.Any())
                return;
            var currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory());
            if (currentDirectory == null)
                return;
            string filePath = Path.Combine(currentDirectory.FullName, DATAPATH);
            if (context == null || await context.Database.EnsureCreatedAsync())
                return;

            // JSON seeding of database

            if (!context.Fruits.Any())
            {
                string fileName = Path.Combine(filePath, "fruits.json");
                var read = File.ReadAllText(fileName);
                var data = JsonConvert.DeserializeObject<List<Fruit>>(read);
                await context.Fruits.AddRangeAsync(data!);
                await context.SaveChangesAsync();
            }

            if (!context.Users.Any())
            {
                string fileName = Path.Combine(filePath, "usernames.json");
                var read = File.ReadAllText(fileName);
                var data = JsonConvert.DeserializeObject<List<string>>(read);
                foreach (string username in data!)
                {
                    var user = new IdentityUser { UserName = username, Email = $"{username.ToLower()}@myapp.com" };

                    await userManager.CreateAsync(user);
                    await roleManager.CreateAsync(new IdentityRole { Name = username, NormalizedName = username });

                    if (await roleManager.RoleExistsAsync(username))
                    {
                        await userManager.AddToRoleAsync(user, username);
                    }
                }
            }
        }
    }
}
