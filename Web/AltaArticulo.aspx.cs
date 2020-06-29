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
    public partial class AltaArticulo : System.Web.UI.Page
    {
        public Articulo articulo { get; set; }
        public List<Categoria> categorias { get; set; }
        public List<Marca> marcas { get; set; }
        public bool flagVacios { get; set; }
        public bool flagCampos { get; set; }
        public string leyenda { get; set; }
        public List<Articulo> listaArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            leyenda = "Agregar";
            try
            {
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                categorias = categoriaNegocio.Listar();
                DropCategoria.DataSource = categorias;
                DropCategoria.DataBind();
                DropCategoria.DataTextField = "Descripcion";
                DropCategoria.DataValueField = "Id";
                DropCategoria.DataBind();

                MarcaNegocio marcaNegocio = new MarcaNegocio();
                marcas = marcaNegocio.Listar();
                DropMarca.DataSource = marcas;
                DropMarca.DataBind();
                DropMarca.DataTextField = "Descripcion";
                DropMarca.DataValueField = "Id";
                DropMarca.DataBind();

                ArticuloNegocio negocio = new ArticuloNegocio();
                listaArticulos = negocio.Listar();

                if (!IsPostBack)
                {
                    var ItemModificar = Request.QueryString["idModificar"];
                    if (ItemModificar != null)
                    {
                        leyenda = "Modificar";
                        Articulo articulo = listaArticulos.Find(a => a.Id == int.Parse(ItemModificar));

                        codigo.Text = articulo.Codigo;
                        nombre.Text = articulo.Nombre;
                        descripcion.Text = articulo.Descripcion;
                        precio.Text = articulo.Precio.ToString();
                        imagen.Text = articulo.Imagen;
                        DropCategoria.SelectedValue = articulo.Categoria.Id.ToString();
                        DropMarca.SelectedValue = articulo.Marca.Id.ToString();
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
                if (codigo.Text == "") return false;
                if (nombre.Text == "") return false;
                if (descripcion.Text == "") return false;
                if (precio.Text == "") return false;
                if (DropCategoria.SelectedItem == null) return false;
                if (DropMarca.SelectedItem == null) return false;
                if (imagen.Text == "") return false;
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

                if (!alfanumerico.IsMatch(codigo.Text)) return false;
                if (!sololetras.IsMatch(nombre.Text)) return false;
                if (!numerico.IsMatch(precio.Text)) return false;
            }

            return true;
        }

        public void AgregarArticulo()
        {
            if (!IsPostBack) return;
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                articulo = new Articulo();
                var ItemModificar = Request.QueryString["idModificar"];
                if (ItemModificar != null)
                {
                    articulo.Id = Convert.ToInt32(ItemModificar);
                }

                articulo.Codigo = codigo.Text;
                articulo.Nombre = nombre.Text;
                articulo.Descripcion = descripcion.Text;
                articulo.Imagen = imagen.Text;

                var p = precio.Text.Trim();
                articulo.Precio = Convert.ToDecimal(p);

                var m = DropMarca.SelectedItem;
                articulo.Marca = new Marca
                {
                    Id = Convert.ToInt32(m.Value)
                };

                var c = DropCategoria.SelectedItem;
                articulo.Categoria = new Categoria
                {
                    Id = Convert.ToInt32(c.Value)
                };

                if (articulo.Id != 0)
                { negocio.Modificar(articulo); }
                else
                { negocio.Agregar(articulo); }

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
                    AgregarArticulo();
                    Response.Redirect("~/AltaArticulo.aspx");
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