using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SistemaDeFilmes.Data;
using SistemaDeFilmes.Repositorios;
using SistemaDeFilmes.Repositorios.Interfaces;
using SistemaDeFilmes.Services;
using SistemaDeFilmes.Services.Interfaces;
using System;

namespace SistemaDeFilmes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<SistemaDeFilmesContext>(opt => opt.UseInMemoryDatabase("FilmesDb"));

            // Add services to the container.

            builder.Services.AddScoped<IMovieModelInterface, MovieModelRepository>();

            builder.Services.AddScoped<IMovieModelService, MovieModelService>();

            builder.Services.AddControllers();

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

            CSVSeed.AppBuild(app);

            app.Run();
        }



    }

}
public partial class Program { }

