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
    public partial class ListaLibros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Seguridad.Validacion.EsAdministrador(Session["usuarioIngresado"])))
            {
                Session.Add("error", "Se requieren permisos de administrador para estár en la página.");
                Response.Redirect("Error.aspx", false);
                return;
            }

            if (!IsPostBack)
            {
                LibroNegocio negocio = new LibroNegocio();
                Session.Add("listaLibros", negocio.ListarSP());
                dgvLibros.DataSource = Session["listaLibros"];
                dgvLibros.DataBind();
            }
        }

        protected void dgvLibros_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvLibros.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioAgregarLibro.aspx?id=" +  id, false);
        }

        // Este evento se activa cuando se cambia de página en el control GridView (dgvLibros).
        protected void dgvLibros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Establece la fuente de datos del GridView a la lista de libros almacenada en la sesión.
            dgvLibros.DataSource = Session["listaLibros"];
            dgvLibros.DataBind(); // Vuelve a enlazar los datos para reflejar la nueva página seleccionada.

            // Establece el índice de página del GridView al nuevo índice de página especificado en el evento.
            dgvLibros.PageIndex = e.NewPageIndex;
            dgvLibros.DataBind(); // Vuelve a enlazar los datos después de cambiar el índice de página para mostrar los datos de la nueva página.
        }
    }
}