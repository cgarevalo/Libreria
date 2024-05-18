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

            // Verifica si no hay una sesión activa y la página actual no es una página de acceso sin estár logueado
            if (!Seguridad.Validacion.SesionActiva(Session["usuarioIngresado"]) && !(Page is Login || Page is Default || Page is Registrar || Page is Error))
            {
                // Redirige al usuario a la página de login si no hay sesión activa y no está logueado
                Response.Redirect("Login.aspx", false);
            }
            else if (Seguridad.Validacion.SesionActiva(Session["usuarioIngresado"]))
            {
                // Si hay una sesión activa, obtiene los datos del usuario de la sesión y configura la interfaz de usuario
                Usuario usuario = (Usuario)Session["usuarioIngresado"];

                // Establece el nombre de usuario en el label
                lblUsuario.Text = usuario.Nombre != null ? usuario.Nombre : "";

                // Establece la imagen de perfil del usuario si está disponible
                if (!String.IsNullOrEmpty(usuario.ImagenPerfil))
                    imgPerfil.ImageUrl = "~/Images/Perfiles/" + usuario.ImagenPerfil;
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}