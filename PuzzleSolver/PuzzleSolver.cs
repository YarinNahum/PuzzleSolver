using PuzzleSolverService;
using PuzzleSolver.Models;
using Database;

namespace PuzzleSolver
{
    public class PuzzleSolver
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.Configure<MongodbModelSettings>(builder.Configuration.GetSection("MongoDbAccess"));
            builder.Services.AddSingleton<IPuzzleSolverService<int>>(new PuzzleSolverService<int>());
            builder.Services.AddScoped<IDataBaseService<int>, MongoDBService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run("http://localhost:8000");

        }

    }
}
