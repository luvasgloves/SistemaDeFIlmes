using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeFilmes.Data;
using SistemaDeFilmes.Models;
using System.Globalization;

namespace SistemaDeFilmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly SistemaDeFilmesContext _dbContext;

        public MoviesController(SistemaDeFilmesContext dbContext)
        {
            _dbContext = dbContext;
        }
        private void SeedData()
        {
            var csv = new CsvReader(new StreamReader("SistemaDeFilmes.Data.movielist.csv"), CultureInfo.InvariantCulture);
            var movies = csv.GetRecords<MovieModel>().ToList();
            _dbContext.AddRange(movies);
            _dbContext.SaveChanges();
        }
    }
}
