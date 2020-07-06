using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Registracion : System.Web.UI.Page
    {
        public Usuario usuario { get; set; }
        public DatosEnvio datosEnvio { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Registrar()
        {
            if (!IsPostBack) return;
            if (!ValidarVacios() || !ValidarCampos()) return;

            UsuarioNegocio negocio = new UsuarioNegocio();

            try
            {
                usuario = new Usuario();

                usuario.Nombre = nombre.Text;
                usuario.Mail = mail.Text;
                usuario.Calle = calle.Text;
                usuario.Provincia = provincia.Text;
                usuario.CodigoPostal = Convert.ToInt64(postal.Text.Trim());
                usuario.NumeroDocumento = Convert.ToInt64(documento.Text.Trim());
                usuario.Telefono = Convert.ToInt64(telefono.Text.Trim());
                usuario.NumeroCalle = Convert.ToInt64(numeroCalle.Text.Trim());
                usuario.Localidad = localidad.Text;

                usuario.Clave = clave.Text;

                var exitoso = negocio.Registrar(usuario);

                if(exitoso)
                {
                    Response.Redirect("~/RegistroExitoso.aspx", false);
                }
                else
                {
                    Response.Redirect("~/RegistroError.aspx", false);
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool ValidarVacios()
        {
            if (IsPostBack)
            {
                if (mail.Text == "") return false;
                if (nombre.Text == "") return false;
                if (calle.Text == "") return false;
                if (provincia.Text == "") return false;
                if (postal.Text == null) return false;
                if (documento.Text == null) return false;
                if (telefono.Text == "") return false;
                if (numeroCalle.Text == "") return false;
                if (localidad.Text == "") return false;
            }
            return true;
        }

        public bool ValidarCampos()
        {
            if (IsPostBack)
            {
                Regex numerico = new Regex("^[0-9.,]+$");
                Regex alfanumerico = new Regex("^[a-zA-ZñÑ0-9., ]*$");
                Regex sololetras = new Regex("^[a-zA-ZñÑ., ]+$");     //no borrar el espacio
                Regex email = new Regex("^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,3})$");

                if (!email.IsMatch(mail.Text)) return false; 
                if (!sololetras.IsMatch(nombre.Text)) return false;
                if (!alfanumerico.IsMatch(calle.Text)) return false;
                if (!sololetras.IsMatch(provincia.Text)) return false;
                if (!numerico.IsMatch(postal.Text)) return false;
                if (!numerico.IsMatch(documento.Text)) return false;
                if (!numerico.IsMatch(telefono.Text)) return false;
                if (!numerico.IsMatch(numeroCalle.Text)) return false;
                if (!alfanumerico.IsMatch(localidad.Text)) return false;
            }

            return true;
        }
    }
}