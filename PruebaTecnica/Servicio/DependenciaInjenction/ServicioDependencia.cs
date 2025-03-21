using Infraestructura.DependenciaInjenction;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Servicio.Maper;
using Servicio.Servicios.Interfaz;
using Servicio.Servicios.Repositorio;


namespace Servicio.DependenciaInjenction
{
    public static class ServicioDependencia
    {
        public static IServiceCollection AplicacionServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(WebMaper));
            services.InfrasctureServices(configuration);

            services.AddScoped<IAutorServi, AutorServi>();
            services.AddScoped<ILibroServe, LibroServe>();

            return services;
        }
    }
}
