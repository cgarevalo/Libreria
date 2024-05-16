using System;
using System.Collections.Generic;
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
                        imgPerfil.ImageUrl = usuario.ImagenPerfil;
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
                    
                }

                usuNegocio.ActualizarPerfil(usuarioMod);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}