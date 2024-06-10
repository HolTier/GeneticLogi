using Microsoft.EntityFrameworkCore;
using GeneticLogi_Backend.Data;
using GeneticLogi_Backend.Services;

namespace GeneticLogi_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Database connection
            builder.Services.AddDbContext<GeneticLogiDbContext>(options =>
                           options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Repositories
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();

            // Controllers
            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "GeneticLogi_Backend", Version = "v1" });
            });

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GeneticLogi_Backend v1"));

            // Top-level route registrations
            app.MapControllers();

            app.Run();
        }
    }
}
