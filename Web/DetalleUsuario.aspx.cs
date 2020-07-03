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
    public partial class DetalleUsuario : System.Web.UI.Page
    {
        public Usuario usuario { get; set; }
        public List<Carrito> compras { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            List<Usuario> lista;
            try
            {
                lista = negocio.Listar();

                var Seleccionado = Convert.ToInt32(Request.QueryString["idusu"]);
                usuario = lista.Find(J => J.Id == Seleccionado);

                compras = negocio.GetComprasUsuario(usuario.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Response.Redirect("~/Error.aspx");
            }
        }
    }
}