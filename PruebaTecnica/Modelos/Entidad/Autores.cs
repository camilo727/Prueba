﻿
using System.ComponentModel.DataAnnotations;

namespace Modelos.Entidad
{
    public class Autores
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

        public ICollection<Libro>? Libros { get; set; }
    }
}
