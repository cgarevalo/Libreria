using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    // Enumeración que representa la fuente de la imagen del libro (URL o Local)
    public enum UrlLocal
    {
        URL,
        Local,
        Nada
    }

    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Descripcion { get; set; }
        public string ImagenPortada { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public bool Activo { get; set; }
        public Genero Genero { get; set; }
        public Idioma Idioma { get; set; }
        public int NumeroPaginas { get; set; }
        public string Editorial { get; set; }
        public string Lsbn { get; set; }
        public UrlLocal FuenteImagen { get; set; }
    }
}
