using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Dominio;

namespace Negocio
{
    public class IdiomaNegocio
    {
        public List<Idioma> ListarIdiomas()
        {
			AccesoDatos datos = new AccesoDatos();
			List<Idioma> idiomas = new List<Idioma>(); 

			try
			{
				datos.SetearConsulta("SELECT Id, Descripcion FROM Idiomas");
				datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Idioma lengua = new Idioma();
                    lengua.Id = (int)datos.Lector["Id"];
                    lengua.Descripcion = (string)datos.Lector["Descripcion"];

                    idiomas.Add(lengua);
                }

                return idiomas;

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
