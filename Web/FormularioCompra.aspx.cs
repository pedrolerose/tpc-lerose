using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static WebApp.SiteMaster;
using static WebApp.SiteMaster.Carrito;

namespace WebApp
{
    public partial class FormularioCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Finalizar()
        {
            if (!IsPostBack) return;
            carrito.Clear();
            Response.Redirect("~/CompraFinalizada.aspx");
            //aca estoy viendo como mandarme la info por mail
        }
    }
}