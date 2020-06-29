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
    public partial class AltaMarca : System.Web.UI.Page
    {
        public bool flagVacios { get; set; }
        public bool flagCampos { get; set; }
        public string leyenda { get; set; }
        public List<Marca> marcas { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            leyenda = "Agregar";
            try
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                marcas = marcaNegocio.Listar();

                if (!IsPostBack)
                {
                    var ItemModificar = Request.QueryString["idModificar"];
                    if (ItemModificar != null)
                    {
                        leyenda = "Modificar";
                        Marca marca = marcas.Find(a => a.Id == int.Parse(ItemModificar));

                        input.Text = marca.Descripcion;
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

        public void AgregarMarca()
        {
            if (!IsPostBack) return;
            MarcaNegocio negocio = new MarcaNegocio();
            try
            {
                Marca marca = new Marca();
                var ItemModificar = Request.QueryString["idModificar"];
                if (ItemModificar != null)
                {
                    marca.Id = Convert.ToInt32(ItemModificar);
                }

                marca.Descripcion = input.Text;


                if (marca.Id != 0)
                { negocio.Modificar(marca); }
                else
                { negocio.Agregar(marca); }

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
                    AgregarMarca();
                    Response.Redirect("~/AltaMarca.aspx");
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