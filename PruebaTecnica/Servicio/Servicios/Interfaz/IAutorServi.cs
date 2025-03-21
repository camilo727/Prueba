

using Servicio.DTOs;

namespace Servicio.Servicios.Interfaz
{
    public interface IAutorServi
    {
        Task<ICollection<AutorDTOs>> GetAutorServi();
        Task<AutorDTOs> GetAutorByIdServi(int Id);
        Task<string> AddAutorServi(CrearAutorDTOs _autorDTOs);
        Task<string> UpdateAutorServi(AutorDTOs _autorDTOs);
        Task<string> DeleteAutoresServi(int Id);
    }
}
