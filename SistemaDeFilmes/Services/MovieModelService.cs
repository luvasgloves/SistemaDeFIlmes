using SistemaDeFilmes.Models;
using SistemaDeFilmes.Repositorios.Interfaces;
using SistemaDeFilmes.Services.Interfaces;

namespace SistemaDeFilmes.Services
{
    public class MovieModelService : IMovieModelService
    {
        private readonly IMovieModelInterface repositorio;
        public MovieModelService(IMovieModelInterface repository)
        {
            repositorio = repository;
        }
        public ProducerAwardsModel GetIntervaloPremios()
        {
            return repositorio.AwardSearch();
        }
      
    }
}

