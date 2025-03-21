

using AutoMapper;
using Modelos.Entidad;
using Servicio.DTOs;

namespace Servicio.Maper
{
    public class WebMaper : Profile
    {
        public WebMaper()
        {
            CreateMap<Libro,LibroDTOs>().ReverseMap();
            CreateMap<Libro,CrearLibroDTOs>().ReverseMap();

            CreateMap<Autores, AutorDTOs>().ReverseMap();
            CreateMap<Autores, CrearAutorDTOs>().ReverseMap();


        }
    }
}
