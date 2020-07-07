using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static WebApp.SiteMaster;
using static WebApp.SiteMaster.Carrito;

namespace Web
{
    public partial class FormaPago : System.Web.UI.Page
    {
        public Dominio.FormaPago pago { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Finalizar()
        {
            if (!IsPostBack) return;
            if (!ValidarVacios() || !ValidarCampos()) return;

            Usuario user = (Usuario)Session["usersession"];

            //modelo f. pago
            ModelarPago();

            //guardo todo
            CarritoNegocio n = new CarritoNegocio();
            n.Agregar(carrito, pago, user);

            // mando mail de compra
            //MailNegocio mail = new MailNegocio();
            //var mailParams = mail.ParametrizarEnvioMail(carrito);
            //mail.EnvioMail(mailParams);


            //limpio el carrito y redirijo
            carrito.Articulos.Clear();
            carrito.Monto = 0;
            carrito.DatosEnvio = new Dominio.DatosEnvio();
            Response.Redirect("~/CompraFinalizada.aspx");
        }

        public bool ValidarVacios()
        {
            if (IsPostBack)
            {
                if (numeroTarjeta.Text == "") return false;
                if (nombreTitular.Text == "") return false;
                if (vencimientoDia.Text == "") return false;
                if (vencimientoMes.Text == "") return false;
                if (codigo.Text == "") return false;
            }
            return true;
        }

        public bool ValidarCampos()
        {
            if (IsPostBack)
            {
                Regex numerico = new Regex("^[0-9.,]+$");
                Regex sololetras = new Regex("^[a-zA-ZñÑ., ]+$");     //no borrar el espacio

                if (!numerico.IsMatch(numeroTarjeta.Text)) return false;
                if (!sololetras.IsMatch(nombreTitular.Text)) return false;
                if (!numerico.IsMatch(vencimientoDia.Text)) return false;
                if (!numerico.IsMatch(vencimientoMes.Text)) return false;
                if (!numerico.IsMatch(codigo.Text)) return false;
            }

            return true;
        }

        public void ModelarPago()
        {
            pago = new Dominio.FormaPago();

            pago.NumeroTarjeta = Convert.ToInt64(numeroTarjeta.Text.Trim());
            pago.NombreTitular = nombreTitular.Text.Trim();
            pago.VencimientoDia = Convert.ToInt32(vencimientoDia.Text.Trim());
            pago.VencimientoMes = Convert.ToInt32(vencimientoMes.Text.Trim());
            pago.CodigoSeguridad = Convert.ToInt32(codigo.Text.Trim());
        }
    }
}