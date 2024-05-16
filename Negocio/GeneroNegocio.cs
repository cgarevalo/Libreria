using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Datos;

namespace Negocio
{
    public class GeneroNegocio
    {
        public List<Genero> ListarGeneros()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Genero> generos = new List<Genero>();

            try
            {
                datos.SetearConsulta("SELECT Id, Descripcion FROM Generos");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Genero gen = new Genero();
                    gen.Id = (int)datos.Lector["Id"];
                    gen.Descripcion = (string)datos.Lector["Descripcion"];

                    generos.Add(gen);
                }

                return generos;

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
