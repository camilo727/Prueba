using Infraestructura.Repositorio.Interfaz;
using Infraestructura.Repositorio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modelos.Datos;


namespace Infraestructura.DependenciaInjenction
{
    public static class InfraestructuraDependencia
    {
        public static IServiceCollection InfrasctureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContexts>(options => options.UseSqlServer(configuration.GetConnectionString("Default"),
            b => b.MigrationsAssembly(typeof(InfraestructuraDependencia).Assembly.FullName)),
            ServiceLifetime.Scoped);

            services.AddScoped<IAutorRepo, AutorRepo>();
            services.AddScoped<ILibroRepo, LibroRepo>();
            return services;
        }
    }
}
