
using Modelos.Entidad;

namespace Infraestructura.Repositorio.Interfaz
{
    public interface IAutorRepo
    {
        Task<ICollection<Autores>> GetAutoresRepo();
        Task<Autores> GetAutoresByIdRepo(int Id);
        Task<bool> ExisteAutoByNombreRepo(string Nombre);
        Task<bool> AddAutoresRepo(Autores _autores);
        Task<bool> DeleteAutoresRepo(Autores _autores);
        Task<bool> UpdateAutoresByIdRepo( Autores _autores);
        Task<bool> SaveAutors();
    }
}
