using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Seguridad
{
    public static class Validacion
    {
        // Método para verificar si la sesión de un usuario está activa.
        // Comprueba si el usuario proporcionado es válido y tiene un ID válido.
        // Devuelve true si la sesión está activa; de lo contrario, devuelve false.
        public static bool SesionActiva(object usuario)
        {
            // Convierte el objeto usuario en un objeto Usuario o establece usu en null si es nulo.
            Usuario usu = usuario != null ? (Usuario)usuario : null;

            // Comprueba si usu no es nulo y tiene un ID distinto de cero para determinar si la sesión está activa.
            if (usu != null && usu.Id != 0)
                return true; // La sesión está activa.
            else
                return false; // La sesión no está activa.
        }

        // Determina si un usuario tiene privilegios de administrador basándose en su jerarquía.
        public static bool EsAdministrador(object usuario)
        {
            // Intenta convertir el objeto a un Usuario
            Usuario usu = usuario as Usuario;

            // Verifica si el usuario no es nulo y tiene jerarquía de UsuarioAdministrador
            return usu != null && usu.AlcanceJerarquia == Jerarquia.UsuarioAdministrador; // retorna false si no se cumplen ambas condiciones
        }
    }
}
