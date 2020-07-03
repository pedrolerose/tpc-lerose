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
    public partial class ConsultaUsuarios : System.Web.UI.Page
    {
        public List<Usuario> usuarios { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            usuarios = negocio.Listar();

        }
    }
}