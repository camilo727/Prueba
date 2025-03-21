using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.DTOs
{
    public class CrearAutorDTOs
    {
        [Required(ErrorMessage = "El Nombre es Obligatorio")]
        [MaxLength(100, ErrorMessage = "El Numero Maximo de Caraterese es de 100")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El Descripcion es Obligatorio")]
        [MaxLength(100, ErrorMessage = "El Numero Maximo de Caraterese es de 100")]
        public string? Descripcion { get; set; }
    }
}
