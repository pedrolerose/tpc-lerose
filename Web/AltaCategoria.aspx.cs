using Dominio;
using Microsoft.Ajax.Utilities;
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
    public partial class AltaCategoria : System.Web.UI.Page
    {
        public List<Categoria> categorias { get; set; }
        public bool flagVacios { get; set; }
        public bool flagCampos { get; set; }
        public string leyenda { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            leyenda = "Agregar";
            try
            {
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                categorias = categoriaNegocio.Listar();

                if (!IsPostBack)
                {
                    var ItemModificar = Request.QueryString["idModificar"];
                    if (ItemModificar != null)
                    {
                        leyenda = "Modificar";
                        Categoria categoria = categorias.Find(a => a.Id == int.Parse(ItemModificar));

                        input.Text = categoria.Descripcion;
                    }
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
                if (input.Text == "") return false;
            }
            return true;
        }

        public bool ValidarCampos()
        {
            if (IsPostBack)
            {
                Regex sololetras = new Regex("^[a-zA-ZñÑ., ]+$");     //no borrar el espacio

                if (!sololetras.IsMatch(input.Text)) return false;
            }

            return true;
        }

        public void AgregarCategoria()
        {
            if (!IsPostBack) return;
            CategoriaNegocio negocio = new CategoriaNegocio();
            try
            {
                Categoria categoria = new Categoria();
                var ItemModificar = Request.QueryString["idModificar"];
                if (ItemModificar != null)
                {
                    categoria.Id = Convert.ToInt32(ItemModificar);
                }

                categoria.Descripcion = input.Text;


                if (categoria.Id != 0)
                { negocio.Modificar(categoria); }
                else
                { negocio.Agregar(categoria); }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Agregar()
        {
            if (!IsPostBack) return;
            if (ValidarVacios())
            {
                flagVacios = false;

                if (ValidarCampos())
                {

                    flagCampos = false;
                    AgregarCategoria();
                    Response.Redirect("~/AltaCategoria.aspx");
                }
                else
                {
                    flagCampos = true;
                }
            }
            else
            {
                flagVacios = true;
            }
        }
    }
}