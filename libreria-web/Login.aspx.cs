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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;

            Usuario usuarioIngresante = new Usuario();
            UsuarioNegocio userNegocio = new UsuarioNegocio();

            string email = txtEmailUser.Text;
            string pass = txtPassword.Text;

            if (String.IsNullOrWhiteSpace(email) && String.IsNullOrWhiteSpace(pass))
            {
                Session.Add("error", "Debe cargar ambos campos");
                Response.Redirect("Error.aspx", false);
                return;
            }

            try
            {
                usuarioIngresante.User = email;
                usuarioIngresante.Pass = pass;

                if (userNegocio.Login(usuarioIngresante))
                {
                    Session.Add("usuarioIngresado", usuarioIngresante);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Session.Add("error", "Usuario o contraseña incorrectos");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}