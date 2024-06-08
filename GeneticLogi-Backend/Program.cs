using Microsoft.EntityFrameworkCore;
using GeneticLogi_Backend.Data;

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

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
