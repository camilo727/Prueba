using AutoMapper;
using Infraestructura.Repositorio.Interfaz;
using Modelos.Entidad;
using Servicio.DTOs;
using Servicio.Servicios.Interfaz;

namespace Servicio.Servicios.Repositorio
{
    public class AutorServi : IAutorServi
    {
        private readonly ILibroRepo _libroRepo;
        private readonly IMapper _mapper;
        private readonly IAutorRepo _autorRepo;
        public AutorServi(IAutorRepo autorRepo,IMapper mapper, ILibroRepo libroRepo)
        {
            _autorRepo = autorRepo;
            _mapper = mapper;
          _libroRepo = libroRepo;
        }

        public async Task<string> AddAutorServi(CrearAutorDTOs _autorDTOs)
        {
             string Respueta = string.Empty;
            if (await _autorRepo.ExisteAutoByNombreRepo(_autorDTOs.Nombre)== false)
            {
                Autores autores= _mapper.Map<Autores>(_autorDTOs);

                if (await _autorRepo.AddAutoresRepo(autores) == true) {
                    Respueta = "guardado";
                }
                else
                {
                    Respueta = "error";
                }

            }
            else
            {
                Respueta = "existe";
            }
            return Respueta;
        }

        public async Task<string> DeleteAutoresServi(int Id)
        {
            string Repuesta = string.Empty;
            if (Id>0)
            {
                Autores _autores = await _autorRepo.GetAutoresByIdRepo(Id);
                if (_autores != null)
                {
                    bool Validar = await _libroRepo.ExisteLibroAndAutorById(Id);
                    if (Validar == true)
                    {
                        Repuesta = "YaExisteTable";
                    }
                    else {
                        bool Resul = await _autorRepo.DeleteAutoresRepo(_autores);
                        if (Resul == true) {

                            Repuesta = "Eliminado";
                        }
                        else
                        {
                            Repuesta = "Error";
                        }

                    }
                   
                }
               
            }
            return Repuesta;



        }

        public async Task<AutorDTOs> GetAutorByIdServi(int Id)
        {
            AutorDTOs _autorDTOs = new AutorDTOs();
            if (Id > 0) {
                Autores _autores = await _autorRepo.GetAutoresByIdRepo(Id);
                _autorDTOs = _mapper.Map<AutorDTOs>(_autores);
            }
            return _autorDTOs;
        }

        public async Task<ICollection<AutorDTOs>> GetAutorServi()
        {
            ICollection<Autores> ListaAutore =await _autorRepo.GetAutoresRepo();
            ICollection<AutorDTOs> ListaAutorDTOs = ListaAutore.Select(a => new AutorDTOs { 
                Id = a.Id,
                Nombre = a.Nombre,
                Descripcion= a.Descripcion
            }).ToList();
            return ListaAutorDTOs;
        }

        public async Task<string> UpdateAutorServi(AutorDTOs _autorDTOs)
        {
            string Respueta= string.Empty;
            if (await _autorRepo.ExisteAutoByNombreRepo(_autorDTOs.Nombre)==false)
            {
               
                    Autores autores = _mapper.Map<Autores>(_autorDTOs);
                if (await _autorRepo.AddAutoresRepo(autores) == true)
                {
                    Respueta = "guardado";
                }
                else {
                    Respueta = "error";
                }
            }
            else
            {
                Respueta = "existe";
            }
            return Respueta;
        }

    }
}
