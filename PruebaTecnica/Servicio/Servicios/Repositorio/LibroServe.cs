using AutoMapper;
using Infraestructura.Repositorio.Interfaz;
using Modelos.Entidad;
using Servicio.DTOs;
using Servicio.Servicios.Interfaz;

namespace Servicio.Servicios.Repositorio
{
    public class LibroServe : ILibroServe
    {
        private readonly IMapper _mapper;
        private readonly ILibroRepo _libroRepo;
        public LibroServe(ILibroRepo libroRepo, IMapper mapper)
        {
            _libroRepo = libroRepo;
            _mapper = mapper;
        }
        public async Task<string> AddLibroServe(CrearLibroDTOs _libroDTOs)
        {
            string Respuesta = string.Empty;
            if (await _libroRepo.ExisteLibroNombreRepo(_libroDTOs.Titulo)==false)
            {
                Libro _libro = _mapper.Map<Libro>(_libroDTOs);
                if (await _libroRepo.AddLibroRepo(_libro)==true)
                {
                    Respuesta = "guardado";
                }
                else
                {
                    Respuesta = "error";
                }
            }
            else {
                Respuesta = "existe";
            }
            return Respuesta;
        }

        public async Task<bool> DeleteLibroServe(int Id)
        {
           bool Respuesta = false;
            if (Id>0)
            {
                Libro _libro = await _libroRepo.GetLibroByIdRepo(Id);
                if (_libro!= null) {
                    Respuesta = await _libroRepo.DeleteLibroRepo(_libro);
                }
            }
            return Respuesta;
        }

        public async Task<LibroDTOs> GetLibroByIdServe(int Id)
        {
            LibroDTOs libroDTOs = new LibroDTOs();
            if (Id>0)
            {
                Libro Libros = await _libroRepo.GetLibroByIdRepo(Id);
                libroDTOs = _mapper.Map<LibroDTOs>(Libros);
            }
            return libroDTOs;
        }

        public async Task<ICollection<LibroDTOs>> GetLibroServe()
        {
            ICollection<Libro> lista =await _libroRepo.GetLibroRepo();
            ICollection<LibroDTOs>  ListaLibroDTOs = lista.Select(a=> new LibroDTOs
            {
                Id = a.Id,
                Titulo = a.Titulo,
                Descripcion = a.Descripcion,
                AutorId = a.AutorId,
                NombreAutor = a.Autores.Nombre

            }).ToList();
            return ListaLibroDTOs;
        }

        public async Task<string> UpdateLibroServe(LibroDTOs _libroDTOs)
        {
            string Respuesta = string.Empty;
            Libro _libro = _mapper.Map<Libro>(_libroDTOs);
            if (await _libroRepo.UpdateLibroRepo(_libro) == true)
            {
                Respuesta = "guardado";
            }
            else
            {
                Respuesta = "error";
            }
            return Respuesta;
        }
    }
}
