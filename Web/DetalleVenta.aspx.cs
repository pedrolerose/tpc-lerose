using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Web
{
    public partial class DetalleVenta : System.Web.UI.Page
    {
        public Carrito carrito { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            CarritoNegocio negocio = new CarritoNegocio();
            List<Carrito> lista;
            try
            {
                lista = negocio.Listar();
                
                var Seleccionado = Convert.ToInt32(Request.QueryString["idven"]);
                carrito = lista.Find(J => J.Id == Seleccionado);
                carrito.Articulos = negocio.GetArticulosCarrito(carrito.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Response.Redirect("~/Error.aspx");
            }
        }
    }
}