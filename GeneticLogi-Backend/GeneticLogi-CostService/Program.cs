using GeneticLogi_Backend.Data;
using GeneticLogi_CostService.Services;

namespace GeneticLogi_CostService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Dependency injection
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddSingleton<ICostService, CostService>();

            // Add controllers
            builder.Services.AddControllers();



            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
