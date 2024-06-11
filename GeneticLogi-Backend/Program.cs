using Microsoft.EntityFrameworkCore;
using GeneticLogi_Backend.Data;
using GeneticLogi_Backend.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

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
            builder.Services.AddScoped<IUserService, UserService>();

            // Controllers
            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "GeneticLogi_Backend", Version = "v1" });
            });

            // Authentication
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/api/Auth/Login";
                    options.ExpireTimeSpan = TimeSpan.FromDays(1);
                    options.SlidingExpiration = true;
                });

            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapGet("/", () => "Hello World!");

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GeneticLogi_Backend v1"));

            // Top-level route registrations
            app.MapControllers();

            app.Run();
        }
    }
}
