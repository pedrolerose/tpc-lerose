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
    public partial class Listado : System.Web.UI.Page
    {
        public List<Articulo> listaArticulos { get; set; }
        public List<Categoria> categorias { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                categorias = categoriaNegocio.Listar();

                ArticuloNegocio negocio = new ArticuloNegocio();
                listaArticulos = negocio.Listar();

                var CatSeleccionada = Request.QueryString["idcat"];
                if (CatSeleccionada != null)
                {
                    List<Articulo> aux = new List<Articulo>();
                    foreach (var item in listaArticulos)
                    {
                        if (item.Categoria.Id == int.Parse(CatSeleccionada))
                        {
                            aux.Add(item);
                        }
                    }
                    listaArticulos = aux;
                }


                var Seleccionado = Request.QueryString["idart"];
                if(Seleccionado != null)
                {
                Articulo articulo = listaArticulos.Find(a => a.Id == int.Parse(Seleccionado));
                    carrito.Articulos.Add(articulo);
                    Response.Redirect("~/Listado.aspx");
                }

                var logout = Request.QueryString["logout"];
                if (logout != null)
                {
                    Session.Add("usersession", null);
                    Response.Redirect("~/Listado.aspx");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Response.Redirect("~/Listado.aspx");
            }
        }
    }
}