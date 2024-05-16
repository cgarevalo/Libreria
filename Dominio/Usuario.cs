using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum Jerarquia
    {
        UsuarioNormal,
        UsuarioAdministrador
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string ImagenPerfil { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Jerarquia AlcanceJerarquia { get; set; }
    }
}
