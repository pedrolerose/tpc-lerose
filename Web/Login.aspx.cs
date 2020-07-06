using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Loguear()
        {
            if (!IsPostBack) return;

            Usuario usuario = new Usuario();
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();

                usuario.Mail = txtMail.Text;
                usuario.Clave = txtPass.Text;
                usuario = negocio.Loguear(usuario);
                if (usuario.Id != 0)
                {
                    Session.Add("usersession", usuario);
                    Response.Redirect("Listado.aspx");
                }
                else
                {
                    Session["Error" + Session.SessionID] = "Usuario o Pass incorrectos.";
                    Response.Redirect("Error.aspx");
                }

            }
            catch (Exception ex)
            {
                //Session["Error" + Session.SessionID] = ex.ToString();
                //Response.Redirect("Error.aspx");
            }
        }
    }
}