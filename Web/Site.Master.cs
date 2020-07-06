using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Microsoft.Ajax.Utilities;
using Negocio;

namespace WebApp
{
    public partial class SiteMaster : MasterPage
    {
        public static class Carrito
        {
            public static Dominio.Carrito carrito;

            static Carrito()
            {
                carrito = new Dominio.Carrito();
                carrito.Articulos = new List<Articulo>();
                carrito.DatosEnvio = new DatosEnvio();
                carrito.Monto = 0;
            }
        }

        public Usuario user { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                user = (Usuario)Session["usersession"];


            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}