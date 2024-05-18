using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace libreria_web
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Seguridad.Validacion.SesionActiva(Session["usuarioIngresado"]))
                {
                    Usuario usuario = (Usuario)Session["usuarioIngresado"];
                    txtNombre.Text = usuario.Nombre;
                    txtApellido.Text = usuario.Apellido;
                    txtFechaNacimiento.Text = usuario.FechaNacimiento.ToString("yyy-MM-dd");
                    if (!String.IsNullOrEmpty(usuario.ImagenPerfil))
                    {
                        // Ruta física completa del archivo en el servidor
                        string rutaFisica = Server.MapPath("~/Images/Perfiles/" + usuario.ImagenPerfil);

                        if (File.Exists(rutaFisica))
                            imgPerfil.Src = "~/Images/Perfiles/" + usuario.ImagenPerfil;
                        else
                            imgPerfil.Src = "https://static.vecteezy.com/system/resources/previews/016/916/479/original/placeholder-icon-design-free-vector.jpg";
                    }
                    else
                    {
                        imgPerfil.Src = "https://static.vecteezy.com/system/resources/previews/016/916/479/original/placeholder-icon-design-free-vector.jpg";
                    }
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio usuNegocio = new UsuarioNegocio();

            try
            {
                Usuario usuarioMod = (Usuario)Session["usuarioIngresado"];
                
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string fechaString = txtFechaNacimiento.Text;

                usuarioMod.Nombre = nombre;
                usuarioMod.Apellido = apellido;

                if (!String.IsNullOrEmpty(fechaString))
                {
                    DateTime fecha;
                    if (DateTime.TryParse(fechaString, out fecha))
                    {
                        usuarioMod.FechaNacimiento = fecha;
                    }
                }

                if (fuImagenPerfil.HasFile)
                {
                    // Obtiene la ruta de la carpeta
                    string ruta = Server.MapPath("./Images/Perfiles/");

                    // Verifica si el usuario ya tiene una imagen de perfil
                    if (!String.IsNullOrEmpty(usuarioMod.ImagenPerfil))
                    {
                        // Ruta completa de la imagen antigua
                        string rutaImgAntigua = Path.Combine(ruta, usuarioMod.ImagenPerfil);

                        if (File.Exists(rutaImgAntigua))
                        {
                            // Elimina la imagen antigua si existe
                            File.Delete(rutaImgAntigua);
                        }
                    }

                    // Generar un nombre único para la imagen
                    string nombreImagen = $"user-{usuarioMod.Id.ToString()}-.jpg";

                    // Conbina la ruta de la imagen con el nombre
                    string rutaCompleta = Path.Combine(ruta, nombreImagen);

                    // Guarda la imagen
                    fuImagenPerfil.PostedFile.SaveAs(rutaCompleta);

                    // Asigna el nombre a ImagenPerfil de Usuario
                    usuarioMod.ImagenPerfil = nombreImagen;

                    imgPerfil.Src = "~/Images/Perfiles/" + usuarioMod.ImagenPerfil;
                }

                usuNegocio.ActualizarPerfil(usuarioMod);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnVer_Click(object sender, EventArgs e)
        {
            //string rutaTemporal = GuardarImagenTemporal();
            //if (!String.IsNullOrEmpty(rutaTemporal))
            //{
            //    imgPerfil.ImageUrl = rutaTemporal;
            //}
        }

        //private bool EsImagen(string nombreArchivo)
        //{
        //    string extension = Path.GetExtension(nombreArchivo).ToLower();
        //    return extension == ".jpg" || extension == ".png" || extension == ".gif" || extension == ".jpeg" || extension == ".webp";
        //}

        //private string GuardarImagenTemporal()
        //{
        //    if (fuImagenPerfil.HasFile)
        //    {
        //        string nombreArchivo = Path.GetFileName(fuImagenPerfil.FileName);
        //        string rutaTemporal = "~/Temp/" + nombreArchivo;
        //        fuImagenPerfil.SaveAs(Server.MapPath(rutaTemporal));
        //        return rutaTemporal;
        //    }

        //    return null;
        //}
    }
}