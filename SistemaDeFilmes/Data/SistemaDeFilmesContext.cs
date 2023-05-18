using Microsoft.EntityFrameworkCore;
using SistemaDeFilmes.Models;

namespace SistemaDeFilmes.Data
{
    public class SistemaDeFilmesContext : DbContext
    {
        public SistemaDeFilmesContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring
      (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "FilmesDb");
        }
        public DbSet<MovieModel> Movies { get; set; }
    }
}
