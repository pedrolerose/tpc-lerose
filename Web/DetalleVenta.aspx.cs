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
        public List<EstadoVenta> estados { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            CarritoNegocio negocio = new CarritoNegocio();
            EstadoNegocio en = new EstadoNegocio();
            List<Carrito> lista;
            try
            {
                lista = negocio.Listar();
                estados = en.Listar();
                
                var Seleccionado = Convert.ToInt32(Request.QueryString["idven"]);
                carrito = lista.Find(J => J.Id == Seleccionado);
                carrito.Articulos = negocio.GetArticulosCarrito(carrito.Id);


                var estado = Convert.ToInt32(Request.QueryString["idestado"]);
                if(estado != 0)
                {
                    en.Modificar(estado, carrito.Id);
                    Response.Redirect("~/DetalleVenta.aspx?idven="+ carrito.Id, false);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Response.Redirect("~/Error.aspx");
            }
        }
    }
}