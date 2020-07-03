using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using static WebApp.SiteMaster;
using static WebApp.SiteMaster.Carrito;

namespace WebApp
{
    public partial class Detalle : System.Web.UI.Page
    {
        public Articulo articulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> lista;
            try
            {
                lista = negocio.Listar();
                //
                // int numeroPokemon = Convert.ToInt32(Session["NumeroPokemon" + Session.SessionID]);
                var Seleccionado = Convert.ToInt32(Request.QueryString["idart"]);
                articulo = lista.Find(J => J.Id == Seleccionado);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Response.Redirect("~/Listado.aspx");
            }
        }

        public void AgregarCarrito(Articulo art)
        {
            if (!IsPostBack) return;

            if(art != null)
            carrito.Articulos.Add(art);
            Response.Redirect(Request.RawUrl);
        }
    }
}