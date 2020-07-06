using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static WebApp.SiteMaster;
using static WebApp.SiteMaster.Carrito;
using Negocio;
using System.Text.RegularExpressions;
using Dominio;

namespace WebApp
{
    public partial class FormularioCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                Usuario user = (Usuario)Session["usersession"];

                if (user != null)
                {
                    carrito.Usuario.Nombre = user.Nombre;
                    carrito.Usuario.Mail = user.Mail;
                    carrito.Usuario.Calle = user.Calle;
                    carrito.Usuario.Provincia = user.Provincia;
                    carrito.Usuario.CodigoPostal = user.CodigoPostal;
                    carrito.Usuario.NumeroDocumento = user.NumeroDocumento;
                    carrito.Usuario.Telefono = user.Telefono;
                    carrito.Usuario.NumeroCalle = user.NumeroCalle;
                    carrito.Usuario.Localidad = user.Localidad;

                    Response.Redirect("~/FormaPago.aspx", false);
                }
                else
                {
                    Response.Redirect("~/NoEsUsuario.aspx", false);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}