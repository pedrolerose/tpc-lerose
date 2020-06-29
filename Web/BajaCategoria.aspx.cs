using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class BajaCategoria : System.Web.UI.Page
    {
        public List<Articulo> listaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                listaArticulos = negocio.Listar();

                var ItemBorrar = Request.QueryString["idBorrar"];
                if (ItemBorrar != null)
                {
                    Articulo articulo = listaArticulos.Find(a => a.Id == int.Parse(ItemBorrar));
                    negocio.Eliminar(articulo.Id);
                    Response.Redirect("~/BajaArticulo.aspx");
                }

                var ItemModificar = Request.QueryString["idModificar"];
                if (ItemModificar != null)
                {
                    Articulo articulo = listaArticulos.Find(a => a.Id == int.Parse(ItemModificar));
                    Response.Redirect("~/AltaArticulo.aspx?idModificar="+ articulo.Id);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}