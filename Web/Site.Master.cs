using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace WebApp
{
    public partial class SiteMaster : MasterPage
    {
        public static class Carrito
        {
            public static List<Articulo> carrito;

            static Carrito()
            {
                carrito = new List<Articulo>();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}