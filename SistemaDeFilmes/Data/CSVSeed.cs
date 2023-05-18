using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using SistemaDeFilmes.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace SistemaDeFilmes.Data
{
    public static class CSVSeed
    {
        public static void AppBuild(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedMovies(serviceScope.ServiceProvider.GetService<SistemaDeFilmesContext>());
            }
        }
        public static List<MovieModel> SeedMovies(SistemaDeFilmesContext? context)
        {
            var movieAwardsPerProducer = new List<MovieModel>();
            //alterar para caminho onde está o arquivo
            var reader = new StreamReader(File.OpenRead(@"C:\Users\lucas.ribeiro\Downloads\movielist.csv"));
            var line = reader.ReadLine();
            var values = line.Split(';');
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                values = line.Split(';');
                var producers = values[3].Replace(" and ", ",").Split(',');
                foreach (var producer in producers)
                {
                    movieAwardsPerProducer.Add(
                        new MovieModel()
                        {
                            Year = values[0],
                            Title = values[1],
                            Studios = values[2],
                            Producer = producer.Trim(),
                            Winner = !string.IsNullOrWhiteSpace(values[4])
                        }) ;                   
                }
            }
            context.Movies.AddRange(movieAwardsPerProducer);

            context.SaveChanges();
            return movieAwardsPerProducer;
        }
    }
}
