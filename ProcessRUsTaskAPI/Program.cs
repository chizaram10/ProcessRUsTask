using ProcessRUsTask.Extensions;
using ProcessRUsTask.Infrastructure.Respositories;
using ProcessRUsTask.Services;
using ProcessRUsTaskAPI.Extensions;

namespace ProcessRUsTask
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbConnectionExtension(builder.Configuration);
            // For Identity  
            builder.Services.AddIdentityextension();
            // Adding Authentication  
            builder.Services.AddAuthenticationExtension(builder.Configuration);
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IFruitRepository, FruitRepository>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerExtension();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

            // Seed database with data.
            await ProcessRUsTaskDbInitializerExtension.DbInitialization(app);

            app.Run();
        }
    }
}