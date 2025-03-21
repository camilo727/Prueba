
using Servicio.DTOs;


namespace Servicio.Servicios.Interfaz
{
    public interface ILibroServe
    {
        Task<ICollection<LibroDTOs>> GetLibroServe();
        Task<LibroDTOs> GetLibroByIdServe(int Id);
        Task<bool> DeleteLibroServe(int Id);
        Task<string> AddLibroServe(CrearLibroDTOs _CrearLibroDTOs);
        Task<string> UpdateLibroServe(LibroDTOs _libroDTOs);

    }
}
