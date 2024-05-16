using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Dominio;

namespace Negocio
{
    public class LibroNegocio
    {
        // Método para listar libros mediante un procedimiento almacenado
        public List<Libro> ListarSP()
        {
            List<Libro> libros = new List<Libro>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearProcedimiento("storedListarLibros");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Libro lib = new Libro();
                    lib.Id = (int)datos.Lector["Id"];
                    lib.Titulo = (string)datos.Lector["Titulo"];
                    if (!(datos.Lector["Autor"] is DBNull))
                        lib.Autor = (string)datos.Lector["Autor"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        lib.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["FechaPublicacion"] is DBNull))
                        lib.FechaPublicacion = (DateTime)datos.Lector["FechaPublicacion"];
                    if (!(datos.Lector["ImagenPortada"] is DBNull))
                        lib.ImagenPortada = (string)datos.Lector["ImagenPortada"];
                    if (!(datos.Lector["NumeroPaginas"] is DBNull))
                        lib.NumeroPaginas = (int)datos.Lector["NumeroPaginas"];
                    if (!(datos.Lector["Editorial"] is DBNull))
                        lib.Editorial = (string)datos.Lector["Editorial"];
                    if (!(datos.Lector["Lsbn"] is DBNull))
                        lib.Lsbn = (string)datos.Lector["Lsbn"];

                    if (!(datos.Lector["OrigenImagen"] is DBNull))
                    {
                        if ((string)datos.Lector["OrigenImagen"] == "URL")
                            lib.FuenteImagen = UrlLocal.URL;
                        else
                            lib.FuenteImagen = UrlLocal.Local;
                    }

                    //if (!(datos.Lector["OrigenImagen"] is DBNull))
                    //    lib.FuenteImagen = (UrlLocal)datos.Lector["OrigenImagen"];

                    lib.Idioma = new Idioma();
                    lib.Idioma.Id = (int)datos.Lector["IdIdioma"];
                    lib.Idioma.Descripcion = (string)datos.Lector["descIdioma"];

                    lib.Genero = new Genero();
                    lib.Genero.Id = (int)datos.Lector["IdGenero"];
                    lib.Genero.Descripcion = (string)datos.Lector["descGenero"];

                    lib.Activo = (bool)datos.Lector["Activo"];

                    libros.Add(lib);
                }

                return libros;
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

        public List<Libro> ListarCompletoSP()
        {
            List<Libro> libros = new List<Libro>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearProcedimiento("storedListarCompleto");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Libro lib = new Libro();
                    lib.Id = (int)datos.Lector["Id"];
                    lib.Titulo = (string)datos.Lector["Titulo"];
                    if (!(datos.Lector["Autor"] is DBNull))
                        lib.Autor = (string)datos.Lector["Autor"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        lib.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["FechaPublicacion"] is DBNull))
                        lib.FechaPublicacion = (DateTime)datos.Lector["FechaPublicacion"];
                    if (!(datos.Lector["ImagenPortada"] is DBNull))
                        lib.ImagenPortada = (string)datos.Lector["ImagenPortada"];
                    if (!(datos.Lector["NumeroPaginas"] is DBNull))
                        lib.NumeroPaginas = (int)datos.Lector["NumeroPaginas"];
                    if (!(datos.Lector["Editorial"] is DBNull))
                        lib.Editorial = (string)datos.Lector["Editorial"];
                    if (!(datos.Lector["Lsbn"] is DBNull))
                        lib.Lsbn = (string)datos.Lector["Lsbn"];

                    if (!(datos.Lector["OrigenImagen"] is DBNull))
                    {
                        if ((string)datos.Lector["OrigenImagen"] == "URL")
                            lib.FuenteImagen = UrlLocal.URL;
                        else
                            lib.FuenteImagen = UrlLocal.Local;
                    }

                    //if (!(datos.Lector["OrigenImagen"] is DBNull))
                    //    lib.FuenteImagen = (UrlLocal)datos.Lector["OrigenImagen"];

                    lib.Idioma = new Idioma();
                    lib.Idioma.Id = (int)datos.Lector["IdIdioma"];
                    lib.Idioma.Descripcion = (string)datos.Lector["descIdioma"];

                    lib.Genero = new Genero();
                    lib.Genero.Id = (int)datos.Lector["IdGenero"];
                    lib.Genero.Descripcion = (string)datos.Lector["descGenero"];

                    lib.Activo = (bool)datos.Lector["Activo"];

                    libros.Add(lib);
                }

                return libros;
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

        // Método para listar un único libro mediante una consulta en bebida, dado un ID
        public List<Libro> ListarLibroUnico(string id)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Libro> libro = new List<Libro>();

            try
            {
                datos.SetearConsulta("SELECT Titulo, Autor, L.Descripcion, Editorial, Activo, Lsbn, NumeroPaginas, I.Descripcion AS descIdioma, G.Descripcion AS descGenero, L.IdGenero , L.IdIdioma, L.Id, FechaPublicacion, ImagenPortada, OrigenImagen FROM Libros L, Generos G, Idiomas I\r\nWHERE G.Id = L.IdGenero AND I.Id = L.IdIdioma AND L.Id = " + id);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Libro lib = new Libro();
                    lib.Id = (int)datos.Lector["Id"];
                    lib.Titulo = (string)datos.Lector["Titulo"];
                    if (!(datos.Lector["Autor"] is DBNull))
                        lib.Autor = (string)datos.Lector["Autor"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        lib.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["FechaPublicacion"] is DBNull))
                        lib.FechaPublicacion = (DateTime)datos.Lector["FechaPublicacion"];
                    if (!(datos.Lector["ImagenPortada"] is DBNull))
                        lib.ImagenPortada = (string)datos.Lector["ImagenPortada"];
                    if (!(datos.Lector["NumeroPaginas"] is DBNull))
                        lib.NumeroPaginas = (int)datos.Lector["NumeroPaginas"];
                    if (!(datos.Lector["Editorial"] is DBNull))
                        lib.Editorial = (string)datos.Lector["Editorial"];
                    if (!(datos.Lector["Lsbn"] is DBNull))
                        lib.Lsbn = (string)datos.Lector["Lsbn"];

                    // Verifica si el campo "OrigenImagen" no es nulo en la base de datos
                    if (!(datos.Lector["OrigenImagen"] is DBNull))
                    {
                        // Si el valor del campo es "URL", asigna UrlLocal.URL a la propiedad FuenteImagen del objeto Libro
                        if ((string)datos.Lector["OrigenImagen"] == "URL")
                            lib.FuenteImagen = UrlLocal.URL; // La imagen del libro proviene de una URL
                        // Si no es "URL", se asigna UrlLocal.Local a la propiedad de FuenteImagen del objeto libro
                        else
                            lib.FuenteImagen = UrlLocal.Local; // La imagen del libro es local (almacenada en el servidor)
                    }

                    lib.Idioma = new Idioma();
                    lib.Idioma.Id = (int)datos.Lector["IdIdioma"];
                    lib.Idioma.Descripcion = (string)datos.Lector["descIdioma"];

                    lib.Genero = new Genero();
                    lib.Genero.Id = (int)datos.Lector["IdGenero"];
                    lib.Genero.Descripcion = (string)datos.Lector["descGenero"];

                    lib.Activo = (bool)datos.Lector["Activo"];

                    libro.Add(lib);
                }

                return libro;

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

        // Método para agregar un nuevo libro mediante un procedimiento almacenado
        public void AgregarLibroSP(Libro libro)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearProcedimiento("storedAltaLibro");

                datos.SetearParametro("@titulo", libro.Titulo);
                datos.SetearParametro("@autor", libro.Autor);
                datos.SetearParametro("@descripcion", libro.Descripcion);
                datos.SetearParametro("@imagenPortada", libro.ImagenPortada ?? (object)DBNull.Value);

                // Utiliza una expresión condicional ternaria para determinar el valor a pasar a @fechaPublicacion
                // Determina si la fecha de publicación del libro es válida y asigna un valor adecuado para el parámetro de la base de datos
                //Si la fecha es válida, se asigna el valor de libro.FechaPublicacion al parámetro valorFecha. Si la fecha no es válida (es igual a DateTime.MinValue, porque un DateTime no puede ser null), se asigna DBNull.Value al parámetro valorFecha
                object valorFecha = libro.FechaPublicacion != DateTime.MinValue ? (object)libro.FechaPublicacion : DBNull.Value;

                datos.SetearParametro("@fechaPublicacion", valorFecha);
                datos.SetearParametro("@idGenero", libro.Genero.Id);
                datos.SetearParametro("@idIdioma", libro.Idioma.Id);
                datos.SetearParametro("@numeroPaginas", libro.NumeroPaginas);
                datos.SetearParametro("@editorial", libro.Editorial);
                datos.SetearParametro("@lsbn", libro.Lsbn);

                // Determina el origen de la imagen del libro (URL o Local) y lo asigna a origenImgParametro
                string origenImgParametro = null;
                switch (libro.FuenteImagen)
                {
                    // Si libro.FuenteImagen es UrlLocal.URL, se le asigna una cadena de texto "URL" a origenImgParametro
                    case UrlLocal.URL:
                        origenImgParametro = "URL"; // La imagen del libro proviene de una URL
                        break;

                    // Si libro.FuenteImagen es UrlLocal.Local, se le asigna una cadena de texto "Local" a origenImgParametro
                    case UrlLocal.Local:
                        origenImgParametro = "Local"; // La imagen del libro es local (almacenada en el servidor)
                        break;
                }
                // Asigna el parámetro de origen de imagen para su uso en un procedimiento almacenado
                datos.SetearParametro("@origenImagen", origenImgParametro);

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

        // Método para modificar un libro existente mediante un procedimiento almacenado
        public void ModificarLibroSP(Libro libro)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearProcedimiento("storedModificarLibro");

                datos.SetearParametro("@id", libro.Id);
                datos.SetearParametro("@titulo", libro.Titulo);
                datos.SetearParametro("@autor", libro.Autor);
                datos.SetearParametro("@descripcion", libro.Descripcion);
                datos.SetearParametro("@imagenPortada", libro.ImagenPortada ?? (object)DBNull.Value);

                // Utiliza una expresión condicional ternaria para determinar el valor a pasar a @fechaPublicacion
                // Determina si la fecha de publicación del libro es válida y asigna un valor adecuado para el parámetro de la base de datos
                //Si la fecha es válida, se asigna el valor de libro.FechaPublicacion al parámetro valorFecha. Si la fecha no es válida (es igual a DateTime.MinValue, porque un DateTime no puede ser null), se asigna DBNull.Value al parámetro valorFecha
                object valorFecha = libro.FechaPublicacion != DateTime.MinValue ? (object)libro.FechaPublicacion : DBNull.Value;
                datos.SetearParametro("@fechaPublicacion", valorFecha);

                datos.SetearParametro("@idGenero", libro.Genero.Id);
                datos.SetearParametro("@idIdioma", libro.Idioma.Id);
                datos.SetearParametro("@numeroPaginas", libro.NumeroPaginas);
                datos.SetearParametro("@editorial", libro.Editorial);
                datos.SetearParametro("@lsbn", libro.Lsbn);

                // Determina el origen de la imagen del libro (URL o Local) y lo asigna a origenImgParametro
                string origenImgParametro = null;
                switch (libro.FuenteImagen)
                {
                    // Si libro.FuenteImagen es UrlLocal.URL, se le asigna una cadena de texto "URL" a origenImgParametro
                    case UrlLocal.URL:
                        origenImgParametro = "URL"; // La imagen del libro proviene de una URL
                        break;

                    // Si libro.FuenteImagen es UrlLocal.Local, se le asigna una cadena de texto "Local" a origenImgParametro
                    case UrlLocal.Local:
                        origenImgParametro = "Local"; // La imagen del libro es local (almacenada en el servidor)
                        break;
                }
                // Asigna el parámetro de origen de imagen para su uso en un procedimiento almacenado
                datos.SetearParametro("@origenImagen", origenImgParametro ?? (object)DBNull.Value);

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

        // Método para desactivar un libro
        public void EliminarLogico(int id, bool activo = false)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("UPDATE Libros SET Activo = @activo WHERE Id = @id");
                datos.SetearParametro("@id", id);
                datos.SetearParametro("@activo", activo);
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
