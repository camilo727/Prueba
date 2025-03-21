
using Modelos.Entidad;

namespace Infraestructura.Repositorio.Interfaz
{
    public interface ILibroRepo
    {
        Task<ICollection<Libro>> GetLibroRepo();
        Task<Libro> GetLibroByIdRepo(int id);
        Task<bool> DeleteLibroRepo(Libro _libro);
        Task<bool> ExisteLibroNombreRepo(string Nombre);
        Task<bool> ExisteLibroAndAutorById(int Id);
        Task<bool> AddLibroRepo(Libro _libro);
        Task<bool> UpdateLibroRepo(Libro _libro);
        Task<bool> SaveLibroRepo();
    }
}
