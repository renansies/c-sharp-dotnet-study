using ContosoPizza.Data;
using ContosoPizza.Services;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddDbContext<PizzaContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("PizzaContext"), builder =>
                        builder.MigrationsAssembly("ContosoPizza")));
            builder.Services.AddScoped<PizzaService, PizzaService>();
            builder.Services.AddControllers();
            builder.Logging.AddJsonConsole();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
        }
    }
}
