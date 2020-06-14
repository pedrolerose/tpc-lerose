using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Microsoft.Ajax.Utilities;
using Negocio;
using static WebApp.SiteMaster;
using static WebApp.SiteMaster.Carrito;

namespace WebApp
{
    public partial class MiCarrito : System.Web.UI.Page
    {
        public List<Articulo> miCarrito { get; set; }
        public decimal total { get; set; }
        public List<Articulo> carritoFront { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            miCarrito = carrito;
            total = 0;
            //lista auxiliar para no repetir items en el foreach
            carritoFront = carrito.DistinctBy(i => i.Codigo).DistinctBy(i => i.Id).ToList();
            
            try
            {

                //calculo total $$
                foreach (var item in carrito)
                {
                    total += item.Precio;
                }

                //quitar 1
                var idQuitar = Request.QueryString["idQuitar"];
                if (idQuitar != null)
                {
                    Articulo artQuitar = miCarrito.Find(a => a.Id == int.Parse(idQuitar));
                    miCarrito.Remove(artQuitar);
                    carrito = miCarrito;
                    Response.Redirect("~/MiCarrito.aspx");
                }

                //agregar 1
                var idAgregar = Request.QueryString["idAgregar"];
                if (idAgregar != null)
                {
                    Articulo artAgregar = miCarrito.Find(a => a.Id == int.Parse(idAgregar));
                    miCarrito.Add(artAgregar);
                    carrito = miCarrito;
                    Response.Redirect("~/MiCarrito.aspx");
                }

                //borrar toda cantidad de articulo
                var idBorrar = Request.QueryString["idBorrar"];
                if (idBorrar != null)
                {
                    miCarrito.RemoveAll(a => a.Codigo == (idBorrar));
                    carrito = miCarrito;
                    Response.Redirect("~/MiCarrito.aspx");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Response.Redirect("~/Listado.aspx");
            }
        }

        //cuento total de cada item
        public int ContarCant(Articulo art)
        {
            int c = 0;
            foreach (var item in carrito)
            {
                if (item.Codigo == art.Codigo) c++;
            }
            return c;
        }

        //vacio el carrito
        public void TirarTodo()
        {
            if (!IsPostBack) return;
            miCarrito.Clear();
            carrito.Clear();
            carritoFront.Clear();
            Response.Redirect(Request.RawUrl);
        }
    }
}