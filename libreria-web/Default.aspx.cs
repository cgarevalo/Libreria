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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            List<Libro> listaLibros = new List<Libro>();
            LibroNegocio negocio = new LibroNegocio();
            listaLibros = negocio.ListarCompletoSP();

            foreach (Libro libro in listaLibros)
            {
                if (libro.FuenteImagen == UrlLocal.Local)
                {
                    libro.ImagenPortada = "./Images/Portadas/" + libro.ImagenPortada;
                }
            }

            if (!IsPostBack)
            {
                repRepetidor1.DataSource = listaLibros;
                repRepetidor1.DataBind();
            }
        }
    }
}