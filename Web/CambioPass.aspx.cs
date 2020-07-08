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
    public partial class OlvidePass : System.Web.UI.Page
    {
        public string dni { get; set; }
        public List<Usuario> lista { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            lista = negocio.Listar();

            
            dni = Request.QueryString["doc"];

            var doc = Request.QueryString["dniListo"];
            if (doc != null)
            {
                Usuario aux = new Usuario();
                aux = lista.Find(a => a.NumeroDocumento == int.Parse(dni));

                negocio.CambioPass(aux.NumeroDocumento, doc);

                Response.Redirect("~/CambioPassCorrecto.aspx", false);
            }


        }

    }
}