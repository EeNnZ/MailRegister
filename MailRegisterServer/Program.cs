using Microsoft.EntityFrameworkCore;

namespace MailRegisterServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<CompanyDbContext>(op =>
            {
                op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}