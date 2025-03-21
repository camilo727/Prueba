
using System.ComponentModel.DataAnnotations;

namespace Servicio.DTOs
{
    public class CrearLibroDTOs
    {
        [Required(ErrorMessage = "El titulo es Obligatorio")]
        [MaxLength(100, ErrorMessage = "El Numero Maximo de Caraterese es de 100")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "El Descripcion es Obligatorio")]
        [MaxLength(100, ErrorMessage = "El Numero Maximo de Caraterese es de 100")]
        public string? Descripcion { get; set; }
        public int AutorId { get; set; }
    }
}
