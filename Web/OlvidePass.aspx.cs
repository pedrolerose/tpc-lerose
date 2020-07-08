using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class OlvidePass1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var mail = Request.QueryString["mail"];
            var doc = Request.QueryString["doc"];
            if (doc != null && mail != null)
            {
                MailNegocio negocio = new MailNegocio();

                MailParametros parametros = negocio.ParametrizarEnvioMailOlvide(mail, Convert.ToInt64(doc));
                negocio.EnvioMail(parametros);

                Response.Redirect("~/EnvioMailPass.aspx", false);
            }

        }
    }
}