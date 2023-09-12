using Geocode.Data;
using Geocode.Interfaces;
using Geocode.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;

namespace Geocode
{
    public class Program
    {
        public static IConfiguration Configuration { get; }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseSerilog((ctx, lc)
                                    => lc.ReadFrom.Configuration(ctx.Configuration));

            // Add services to the container.
            builder.Services.AddSingleton<IGeoDataImport, GeoDataImport>();
            builder.Services.AddSingleton<IGeocode, GeocodeService>();
            builder.Services.AddSingleton(typeof(IServiceScopeFactory<>), typeof(ServiceScopeFactory<>));

            builder.Services.AddDbContext<GeoDataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Database")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opt => opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Geocode API",
                Version = "v1",
                Description = "Datasource: https://simplemaps.com/data/us-zips"
            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<SerilogRequestLogger>();

            app.MapControllers();

            app.Run();
        }
    }
}