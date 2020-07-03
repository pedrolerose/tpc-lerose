using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static WebApp.SiteMaster;
using static WebApp.SiteMaster.Carrito;
using Negocio;

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

            ModelarEnvio();

            CarritoNegocio n = new CarritoNegocio();
            n.Agregar(carrito);

            carrito.Articulos.Clear();
            carrito.Monto = 0;
            carrito.DatosEnvio = new Dominio.DatosEnvio();
            Response.Redirect("~/CompraFinalizada.aspx");
            //aca estoy viendo como mandarme la info por mail
        }

        public void ModelarEnvio()
        {
            if (!IsPostBack) return;

            try
            {

                carrito.DatosEnvio.Nombre = nombre.Text;
                carrito.DatosEnvio.Mail = mail.Text;
                carrito.DatosEnvio.Calle = calle.Text;
                carrito.DatosEnvio.Provincia = provincia.Text;
                carrito.DatosEnvio.CodigoPostal = Convert.ToInt64(postal.Text.Trim());
                carrito.DatosEnvio.NumeroDocumento = Convert.ToInt64(documento.Text.Trim());
                carrito.DatosEnvio.Telefono = Convert.ToInt64(telefono.Text.Trim());
                carrito.DatosEnvio.NumeroCalle = Convert.ToInt64(numeroCalle.Text.Trim());
                carrito.DatosEnvio.Localidad = localidad.Text;
                carrito.DatosEnvio.Notas = notas.Text;



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}