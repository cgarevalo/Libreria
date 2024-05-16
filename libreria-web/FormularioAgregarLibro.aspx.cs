using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using static System.Net.WebRequestMethods;

namespace libreria_web
{
    // Página para agregar o modificar libros en la aplicación web
    public partial class FormularioAgregarLibro : System.Web.UI.Page
    {
        // Propiedades de la página
        public bool ConfirmarDesactivacion { get; set; }
        public bool OrigenImagen { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica si es un administrador el que accedio a la página
            if (!(Seguridad.Validacion.EsAdministrador(Session["usuarioIngresado"])))
            {
                Session.Add("error", "Se requieren permisos de administrador para estár en la página.");
                Response.Redirect("Error.aspx", false);
                return;
            }

            // Actualizar OrigenImagen en cada carga de página, incluidos los postbacks
            OrigenImagen = chkOrigen.Checked;

            try
            {
                // Configuración inicial de la pantalla si no es una carga posterior a una acción del usuario (PostBack)
                if (!IsPostBack)
                {
                    // Configuración de variables de estado
                    ConfirmarDesactivacion = false; // Indica que la confirmación de desactivación no está habilitada por defecto                    

                    //OrigenImagen = false; // Indica que el origen de la imagen es local por defecto

                    // Carga la lista de idiomas desde la capa de negocio
                    IdiomaNegocio idiomaNegocio = new IdiomaNegocio();
                    List<Idioma> idiomas = idiomaNegocio.ListarIdiomas();

                    // Carga la lista de géneros desde la capa de negocio
                    GeneroNegocio genNegocio = new GeneroNegocio();
                    List<Genero> generos = genNegocio.ListarGeneros();

                    // Asigna la lista de idiomas al control DropDownList ddlIdioma
                    ddlIdioma.DataSource = idiomas;
                    ddlIdioma.DataValueField = "Id";
                    ddlIdioma.DataTextField = "Descripcion";
                    ddlIdioma.DataBind();

                    // Asigna la lista de géneros al control DropDownList ddlGenero
                    ddlGenero.DataSource = generos;
                    ddlGenero.DataValueField = "Id";
                    ddlGenero.DataTextField = "Descripcion";
                    ddlGenero.DataBind();

                    // Asigna una imagen de marcador de posición al control imgCargarPortada
                    imgCargarPortada.ImageUrl = "https://static.vecteezy.com/system/resources/previews/016/916/479/original/placeholder-icon-design-free-vector.jpg";
                }

                // Configuración específica si se está modificando un libro existente
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : "";
                // El operador ternario se utiliza para verificar si el parámetro "id" está presente en la URL.
                // Si Request.QueryString["id"] no es nulo, se asigna su valor a la variable 'id', de lo contrario, 'id' se establece como una cadena vacía ("").
                // Esto permite verificar si se está editando un libro existente basado en el valor del parámetro 'id' en la URL.


                // Verifica si el parámetro 'id' no está vacío y si la página no se está cargando como resultado de un postback
                if (id != "" && !IsPostBack)
                {
                    // Obtiene el libro seleccionado para su modificación
                    LibroNegocio negocio = new LibroNegocio();
                    Libro libroSeleccionado = (negocio.ListarLibroUnico(id))[0];

                    // Guarda el libro seleccionado en la sesión para uso posterior
                    Session.Add("libroSeleccionado", libroSeleccionado);

                    // Carga los campos del formulario con los datos del libro seleccionado
                    txtTitulo.Text = libroSeleccionado.Titulo;
                    txtAutor.Text = libroSeleccionado.Autor;
                    txtDescripcion.Text = libroSeleccionado.Descripcion;

                    // Verifica si la fecha de publicación no es nula ni una fecha mínima
                    if (libroSeleccionado.FechaPublicacion != null && libroSeleccionado.FechaPublicacion != DateTime.MinValue)
                        txtFechaPublicacion.Text = libroSeleccionado.FechaPublicacion.ToString("yyyy-MM-dd");

                    // Selecciona el género del libro en el DropDownList ddlGenero
                    ddlGenero.SelectedValue = libroSeleccionado.Genero.Id.ToString();
                    // Selecciona el idioma del libro en el DropDownList ddlIdioma
                    ddlIdioma.SelectedValue = libroSeleccionado.Idioma.Id.ToString();

                    // Asigna el número de páginas al campo de texto txtNumeroPaginas si es distinto de cero
                    if (libroSeleccionado.NumeroPaginas != 0)
                        txtNumeroPaginas.Text = libroSeleccionado.NumeroPaginas.ToString();

                    // Asigna la editorial y el ISBN del libro a los campos de texto correspondientes
                    txtEditorial.Text = libroSeleccionado.Editorial;
                    txtLsbn.Text = libroSeleccionado.Lsbn;

                    // Verifica si la propiedad ImagenPortada del libro seleccionado no es nula
                    if (libroSeleccionado.ImagenPortada != null)
                    {
                        // Utiliza un switch para determinar el origen de la imagen de portada
                        switch (libroSeleccionado.FuenteImagen)
                        {
                            // Si la imagen proviene de una URL, asigna directamente la URL a la propiedad ImageUrl del control imgCargarPortada
                            case UrlLocal.URL:
                                imgCargarPortada.ImageUrl = libroSeleccionado.ImagenPortada;
                                txtUrlImagen.Text = libroSeleccionado.ImagenPortada; //carga la url de la imagen en el txtUrlImagen
                                chkOrigen.Checked = true; // Marca el chkOrigen como seleccionado
                                OrigenImagen = chkOrigen.Checked; // Sincroniza OrigenImagen con el estado de chkOrigen
                                break;

                            // Si la imagen es local, construye la URL relativa a la carpeta de imágenes en el servidor y luego asigna la URL al control imgCargarPortada
                            case UrlLocal.Local:
                                imgCargarPortada.ImageUrl = "~/Images/Portadas/" + libroSeleccionado.ImagenPortada;
                                break;
                        }
                    }

                    // Si el libro está desactivado, cambia el texto de btnDesactivar, de Desactivar a Reactivar, por si se lo quiere reactivar
                    if (!libroSeleccionado.Activo)
                    {
                        btnDesactivar.Text = "Reactivar";
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        // Evento para manejar el clic en el botón "Agregar" para agregar un nuevo libro o modificarlo
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Libro nuevoLibro = new Libro();
            LibroNegocio negocio = new LibroNegocio();

            // Valida la página antes de realizar la operación de agregar o modificar
            Page.Validate();

            // Si la página no es válida según las reglas de validación definidas, se interrumpe el flujo y se sale del método
            if (!Page.IsValid)
                return;

            // Si la página es válida, continúa con la lógica de agregar o modificar el libro
            try
            {
                // Obtiene el valor de txtFechaPublicacion.Text
                string fechaString = txtFechaPublicacion.Text;

                // Verifica si la fecha no está vacía
                if (!String.IsNullOrEmpty(fechaString))
                {
                    // Intenta convertir la cadena de texto de la fecha en un objeto DateTime
                    DateTime fecha;
                    if (DateTime.TryParse(fechaString, out fecha))
                    {
                        // La conversión fue exitosa, asigna la fecha a nuevoLibro.FechaPublicacion
                        nuevoLibro.FechaPublicacion = fecha;
                    }
                }

                // Asigna los valores de los controles de entrada a las propiedades del nuevo libro
                nuevoLibro.Titulo = txtTitulo.Text;
                nuevoLibro.Autor = txtAutor.Text;
                nuevoLibro.Descripcion = txtDescripcion.Text;
                if (!String.IsNullOrEmpty(txtNumeroPaginas.Text))
                    nuevoLibro.NumeroPaginas = int.Parse(txtNumeroPaginas.Text);
                nuevoLibro.Editorial = txtEditorial.Text;
                nuevoLibro.Lsbn = txtLsbn.Text;
                nuevoLibro.Genero = new Genero();
                nuevoLibro.Genero.Id = int.Parse(ddlGenero.SelectedValue);
                nuevoLibro.Idioma = new Idioma();
                nuevoLibro.Idioma.Id = int.Parse(ddlIdioma.SelectedValue);

                // Condición que verifica si se seleccionó una imagen del imgPortada
                if (fuImagenPortada.HasFile)
                {
                    // Obtiene la ruta de la carpeta
                    string ruta = Server.MapPath("./Images/Portadas/");

                    // Generar un nombre único para la imagen
                    string nombreImagen = Guid.NewGuid().ToString() + ".jpg";
                    string rutaCompleta = Path.Combine(ruta, nombreImagen);

                    // Guarda la imagen
                    fuImagenPortada.PostedFile.SaveAs(rutaCompleta);
                    //imgPortada.PostedFile.SaveAs(ruta + "libro-" + nuevoLibro.Id + ".jpg");
                    //nuevoLibro.ImagenPortada = "libro-" + nuevoLibro.Id + ".jpg";

                    nuevoLibro.ImagenPortada = nombreImagen;

                    nuevoLibro.FuenteImagen = UrlLocal.Local; // Indica que la imagen es local, y se le asigna el enum UrlLocal.Local a FuenteImagen

                    // Mostrar la imagen cargada
                    //imgCargarPortada.ImageUrl = "~/Images/Portadas/" + nuevoLibro.ImagenPortada;
                    //imgCargarPortada.Visible = true;
                }
                // Condición que verifica si se escribió algo en txtUrlImagen
                else if (!String.IsNullOrEmpty(txtUrlImagen.Text))
                {
                    nuevoLibro.ImagenPortada = txtUrlImagen.Text;
                    nuevoLibro.FuenteImagen = UrlLocal.URL; // Indica que la imagen es desde URL, y se le asigna el enum UrlLocal.URL a FuenteImagen
                }
                
                // Si se está modificando un libro existente (ya tiene ID), llama al método de negocio para modificarlo
                if (Request.QueryString["id"] != null)
                {
                    // Le asigna como id el id que se mando por url para que se pueda modificar
                    string id = Request.QueryString["id"];
                    nuevoLibro.Id = int.Parse(id);

                    // Conserva la imagen existente y su fuente de origen si no se seleccionó una imagen nueva al momento de modificar
                    if (!fuImagenPortada.HasFile)
                    {
                        Libro libroSeleccionado = (Libro)Session["libroSeleccionado"];
                        nuevoLibro.ImagenPortada = libroSeleccionado.ImagenPortada;
                        nuevoLibro.FuenteImagen = libroSeleccionado.FuenteImagen;
                    }

                    negocio.ModificarLibroSP(nuevoLibro);
                }
                else
                {
                    // Si no se está modificando (es una inserción nueva), llama al método de negocio para agregar el libro
                    negocio.AgregarLibroSP(nuevoLibro);
                }

                // Redirige al usuario a la página de lista de libros después de agregar/modificar exitosamente
                Response.Redirect("ListaLibros.aspx", false);
            }
            catch (Exception ex)
            {
                // En caso de error, redirige a la página de error y muestra el mensaje de error
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        // Evento para manejar el clic en el botón "Desactivar" para desactivar un libro existente
        protected void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                LibroNegocio negocio = new LibroNegocio();
                // Recupera al libro en session
                Libro seleccionado = (Libro)Session["libroSeleccionado"];

                negocio.EliminarLogico(seleccionado.Id, !seleccionado.Activo);

                Response.Redirect("ListaLibros.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCargarImagen_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        // Evento para manejar el cambio en el campo de texto de la URL de la imagen
        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgCargarPortada.ImageUrl = txtUrlImagen.Text;
        }

        // Evento para manejar el cambio en el estado del checkbox "Origen"
        protected void chkOrigen_CheckedChanged(object sender, EventArgs e)
        {
            // Sincroniza OrigenImagen con el estado de chkOrigen
            OrigenImagen = chkOrigen.Checked;
        }
    }
}