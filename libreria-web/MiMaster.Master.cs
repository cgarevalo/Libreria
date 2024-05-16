using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace libreria_web
{
    public partial class MiMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Carga la imágen por defecto de la imágen de perfíl
            imgPerfil.ImageUrl = "https://static.vecteezy.com/system/resources/previews/005/005/788/original/user-icon-in-trendy-flat-style-isolated-on-grey-background-user-symbol-for-your-web-site-design-logo-app-ui-illustration-eps10-free-vector.jpg";

            // Verificar si la página actual es la página de inicio (home), de registro, login o la de error
            if (!Seguridad.Validacion.SesionActiva(Session["usuarioIngresado"]) && !(Page is Login || Page is Default || Page is Registrar || Page is Error))
            {
                Response.Redirect("Login.aspx", false);
            }
            else if (Seguridad.Validacion.SesionActiva(Session["usuarioIngresado"]))
            {
                Usuario usuario = (Usuario)Session["usuarioIngresado"];
                lblUsuario.Text = usuario.Nombre != null ? usuario.Nombre : "";
                if (!String.IsNullOrEmpty(usuario.ImagenPerfil))
                    imgPerfil.ImageUrl = usuario.ImagenPerfil;
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}