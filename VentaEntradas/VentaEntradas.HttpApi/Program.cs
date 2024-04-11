using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using VentaEntradas.Application.AppServices;
using VentaEntradas.Application.Contracts;
using VentaEntradas.Domain.Contracts;
using VentaEntradas.Infraestructure;
using VentaEntradas.Application;
using VentaEntradas.Infraestructure.Repositories;

namespace VentaEntradas.HttpApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.AddDbContext<VentaEntradasDbContext>();

            builder.Services.AddDbContext<VentaEntradasDbContext>(options =>
            {
                options.UseSqlServer("Data Source=DESKTOP-DAN;Initial Catalog=dbVentaEntradas;Integrated Security=True;Encrypt=False");
            });

            builder.Services.AddScoped<IUnitOfWork>(provider =>
            {
                var instance = provider.GetService<VentaEntradasDbContext>();
                return instance;
            });


            builder.Services.AddScoped<IEventoRepository, EventoRepository>();

            builder.Services.AddApplication(builder.Configuration);

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:5173")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors();

            app.MapControllers();

            app.Run();
        }
    }
}
