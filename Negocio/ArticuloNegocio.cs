using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            Articulo aux;
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = @"data source =.\SQLEXPRESS; initial catalog=LEROSE_DB; integrated security=sspi;";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT a.Id, a.Codigo AS Codigo, a.Nombre AS Nombre, a.Descripcion AS Descripcion, m.Descripcion AS MarcaDescripcion, c.Descripcion AS CategoriaDescripcion,a.Id_Marca AS IdMarca, a.Id_Categoria AS IdCategoria,a.Imagen AS Imagen, a.Precio AS Precio FROM Articulos a LEFT JOIN Marcas m ON m.Id = a.Id_Marca LEFT JOIN Categorias c ON c.Id = a.Id_Categoria WHERE a.borradoLogico = 0";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    aux = new Articulo();
                    aux.Id = lector.GetInt32(0);
                    aux.Nombre = lector["Nombre"].ToString();
                    aux.Codigo = lector["Codigo"].ToString();
                    aux.Descripcion = lector["Descripcion"].ToString();
                    aux.Imagen = lector["Imagen"].ToString();
                    aux.Precio = (decimal)lector["Precio"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)lector["IdMarca"];
                    aux.Marca.Descripcion = lector["MarcaDescripcion"].ToString();
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)lector["IdCategoria"];
                    aux.Categoria.Descripcion = lector["CategoriaDescripcion"].ToString();

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
        public void Agregar(Articulo articulo)
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion.ConnectionString = @"data source =.\SQLEXPRESS; initial catalog=LEROSE_DB; integrated security=sspi;";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "INSERT INTO Articulos VALUES (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @imagen, @precio, @fecha, @usuario, @borrado)";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@codigo", articulo.Codigo);
                comando.Parameters.AddWithValue("@nombre", articulo.Nombre);
                comando.Parameters.AddWithValue("@descripcion", articulo.Descripcion);
                comando.Parameters.AddWithValue("@idMarca", articulo.Marca.Id);
                comando.Parameters.AddWithValue("@idCategoria", articulo.Categoria.Id);
                comando.Parameters.AddWithValue("@imagen", articulo.Imagen);
                comando.Parameters.AddWithValue("@precio", articulo.Precio);
                comando.Parameters.AddWithValue("@fecha", articulo.Fecha);
                comando.Parameters.AddWithValue("@usuario", articulo.Usuario.Id);
                comando.Parameters.AddWithValue("@borrado", articulo.BorradoLogico);

                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Modificar(Articulo articulo)
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion.ConnectionString = @"data source =.\SQLEXPRESS; initial catalog=LEROSE_DB; integrated security=sspi;";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "UPDATE Articulos set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, Id_Marca = @idMarca, Id_Categoria = @idCategoria, Imagen = @imagen, Precio = @precio WHERE Id = @id";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@codigo", articulo.Codigo);
                comando.Parameters.AddWithValue("@nombre", articulo.Nombre);
                comando.Parameters.AddWithValue("@descripcion", articulo.Descripcion);
                comando.Parameters.AddWithValue("@idMarca", articulo.Marca.Id);
                comando.Parameters.AddWithValue("@idCategoria", articulo.Categoria.Id);
                comando.Parameters.AddWithValue("@imagen", articulo.Imagen);
                comando.Parameters.AddWithValue("@precio", articulo.Precio);
                comando.Parameters.AddWithValue("@id", articulo.Id);

                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Eliminar(int id)
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = @"data source =.\SQLEXPRESS; initial catalog=LEROSE_DB; integrated security=sspi;";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "UPDATE Articulos SET BorradoLogico = 1 WHERE Id =" + id;

                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
