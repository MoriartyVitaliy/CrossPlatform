using Lab6API.Data;
using Lab6API.Test;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

namespace Lab6API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // JWT для API
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.Authority = $"https://{builder.Configuration["Auth0:Domain"]}";
                   options.Audience = builder.Configuration["Auth0:Audience"];
               });

            var databaseProvider = builder.Configuration["DatabaseProvider"];
            string connectionString = builder.Configuration.GetConnectionString(databaseProvider);

            // Конфігурація DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                switch (databaseProvider)
                {
                    case "MSSQL":
                        options.UseSqlServer(connectionString);
                        break;
                    case "Postgres":
                        options.UseNpgsql(connectionString);
                        break;
                    case "SQLite":
                        options.UseSqlite(connectionString);
                        break;
                    case "InMemory":
                        options.UseInMemoryDatabase("InMemoryDb");
                        break;
                    default:
                        throw new Exception("Unknown database provider.");
                }
                options.EnableSensitiveDataLogging()
                       .LogTo(Console.WriteLine);
            });

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

/*            // Test Data
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                TestDataSeeder.Seed(context);
            }
*/
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
