using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Web
{
    public partial class ConsultaVentas : System.Web.UI.Page
    {
        public List<Dominio.Carrito> ventas { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            CarritoNegocio negocio = new CarritoNegocio();
            ventas = negocio.Listar();

        }
    }
}