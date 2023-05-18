using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeFilmes.Data;
using SistemaDeFilmes.Models;
using SistemaDeFilmes.Services.Interfaces;
using System.Globalization;

namespace SistemaDeFilmes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly SistemaDeFilmesContext _dbContext;

        public MoviesController(SistemaDeFilmesContext dbContext)
        {
            _dbContext = dbContext;
        }
        

        [HttpGet]
        public ProducerAwardsModel Get([FromServices] IMovieModelService moviesService)
        {
            return moviesService.GetIntervaloPremios();
        }
    }
}
