
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos.Entidad
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public int AutorId { get; set; }
        [ForeignKey("AutorId")]
        public Autores Autores { get; set; }
    }
}
