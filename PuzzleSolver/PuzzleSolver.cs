using PuzzleSolverService;

namespace PuzzleSolver
{
    public class PuzzleSolver
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddScoped<IPuzzleSolverService<int>,PuzzleSolverService<int>>();
            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();
            app.Run("http://localhost:8000");

        }

    }
}
