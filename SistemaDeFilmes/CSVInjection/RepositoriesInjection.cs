using Microsoft.AspNetCore.Authentication;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeFilmes.Repositorios.Interfaces;
using SistemaDeFilmes.Repositorios;
using SistemaDeFilmes.Data;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeFilmes.CSVInjection
{
    public class RepositoriesInjection
    {
        public static void InjectRepository(IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IMovieModelInterface, MovieModelRepository>();
            services.AddScoped<SistemaDeFilmesContext>();
            services.AddScoped<DbContext();

        }
    }
}
