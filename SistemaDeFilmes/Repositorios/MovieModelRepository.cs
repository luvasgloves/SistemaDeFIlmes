using SistemaDeFilmes.Data;
using SistemaDeFilmes.Models;
using SistemaDeFilmes.Repositorios.Interfaces;

namespace SistemaDeFilmes.Repositorios
{
    public class MovieModelRepository : IMovieModelInterface
    {
        private readonly SistemaDeFilmesContext _ctx;
        public MovieModelRepository(SistemaDeFilmesContext ctx)
        {
            _ctx = ctx;
        }
      
        public ProducerAwardsModel AwardSearch()
        {
            //obtem os vencedores ordenados por ano
            var filmes = from films in _ctx.Movies.ToList()
                         where films.Winner
                         orderby films.Year
                         select films;
            var producerMinMax = new List<ProducerMinMax>();
            var max = 0;
            var min = 0;
            var firstInterval = 0;
            var gotFirstInterval = false;

            //obtém valor do primeiro intervalo
            foreach (var a in filmes)
            {
                if (gotFirstInterval) break;
                foreach (var b in filmes)
                {
                    int yearA = int.Parse(a.Year);
                    int yearB = int.Parse(b.Year);
                    if (a.Producer.ToUpper().Equals(b.Producer.ToUpper()) &&
                        yearA < yearB)
                    { 
                    firstInterval = yearB - yearA;                       
                         gotFirstInterval = true;                        
                        break;
                    }
                }
            }

            //calcula intervalos restantes
             foreach (var a in filmes)
            {
                foreach (var b in filmes)
                {
                    int yearA = int.Parse(a.Year);
                    int yearB = int.Parse(b.Year);
                    if (a.Producer.ToUpper().Equals(b.Producer.ToUpper()) &&
                        yearA < yearB)
                    {
                        var intervalo = yearB - yearA;
                        //intervalo é maior ou menor que o menor e maior já encontrado?
                        if (intervalo < firstInterval)
                        {
                            min = intervalo;
                        }
                        if (intervalo > max)
                        {
                            max = intervalo;
                        }

                        producerMinMax.Add(
                            new ProducerMinMax
                            {
                                Producer = a.Producer,
                                Interval = intervalo,
                                PreviousWin = yearA,
                                FollowingWin = yearB
                            });
                    }
                }
            }

             //lista todos os produtores com o intervalo menor e maior
            return new()
            {
                Min = producerMinMax.Where(intervalo => intervalo.Interval == min).ToList(),
                Max = producerMinMax.Where(intervalo => intervalo.Interval == max).ToList()
               
            };
        }
      
    }
}

