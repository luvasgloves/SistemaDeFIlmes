using SistemaDeFilmes.Services;
using SistemaDeFilmes.Services.Interfaces;

namespace SistemaDeFilmes.CSVInjection
{
    public class ServicesInjection
    {
        public static void InjectService(IServiceCollection services)
        {
            services.AddTransient<IMovieModelService, MovieModelService>();
        }
    }
}
