using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Datos;

namespace Negocio
{
    public class UsuarioNegocio
    {
        // Método para registrar a un nuevo usuario
        public int InsertarNuevoUser(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearProcedimiento("storedAltaUsuario");

                datos.SetearParametro("@user", usuario.User);
                datos.SetearParametro("@pass", usuario.Pass);

                switch (usuario.AlcanceJerarquia)
                {
                    case Jerarquia.UsuarioNormal:
                        datos.SetearParametro("@jerarquia", 0);
                        break;
                    case Jerarquia.UsuarioAdministrador:
                        datos.SetearParametro("@jerarquia", 1);
                        break;
                }
                
                return datos.EjecutarAccionScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        // Método para que un usuario inice sesión
        public bool Login(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT Id, Usuario, Contraseña, Nombre, Apellido, FechaNacimiento, ImagenPerfil, Jerarquia FROM Usuarios WHERE Usuario = @usuario AND Contraseña = @contraseña");

                datos.SetearParametro("@usuario", usuario.User);
                datos.SetearParametro("@contraseña", usuario.Pass);
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.User = (string)datos.Lector["Usuario"];
                    // Verifica el valor booleano 'Jerarquia' y asigna el valor de 'AlcanceJerarquia' en consecuencia.
                    if ((bool)datos.Lector["Jerarquia"])
                        usuario.AlcanceJerarquia = Jerarquia.UsuarioAdministrador;
                    else
                        usuario.AlcanceJerarquia = Jerarquia.UsuarioNormal;

                    if (!(datos.Lector["Nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Apellido"] is DBNull))
                        usuario.Apellido = (string)datos.Lector["Apellido"];
                    if (!(datos.Lector["FechaNacimiento"] is DBNull))
                        usuario.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    if (!(datos.Lector["ImagenPerfil"] is DBNull))
                        usuario.ImagenPerfil = (string)datos.Lector["ImagenPerfil"];

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void ActualizarPerfil(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("UPDATE Usuarios SET Nombre = @nombre, Apellido = @apellido, FechaNacimiento = @fechaNacimiento, ImagenPerfil = @imagenPerfil WHERE Id = @id");

                datos.SetearParametro("@id", usuario.Id);
                datos.SetearParametro("@nombre", usuario.Nombre);
                datos.SetearParametro("@apellido", usuario.Apellido);
                datos.SetearParametro("@imagenPerfil", usuario.ImagenPerfil ?? (object)DBNull.Value);

                object valorFecha = usuario.FechaNacimiento != DateTime.MinValue ? (object)usuario.FechaNacimiento : DBNull.Value;
                datos.SetearParametro("@fechaNacimiento", valorFecha);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
