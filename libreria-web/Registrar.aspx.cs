using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace libreria_web
{
    public partial class Registrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Usuario nuevoUsuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();

            try
            {
                string email = txtEmailUser.Text;
                string pass = txtPassword.Text;

                if (!String.IsNullOrWhiteSpace(email) && !String.IsNullOrWhiteSpace(pass))
                {
                    nuevoUsuario.User = email;
                    nuevoUsuario.Pass = pass;
                    nuevoUsuario.AlcanceJerarquia = Jerarquia.UsuarioNormal;
                }
                else
                {
                    Session.Add("error", "Debe llenar ambos campos.");
                    Response.Redirect("Error.aspx", false);
                    return;
                }

                negocio.InsertarNuevoUser(nuevoUsuario);

                Response.Redirect("Login.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}