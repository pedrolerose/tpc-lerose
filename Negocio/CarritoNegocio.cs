using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class CarritoNegocio
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
        public void Agregar(Carrito carrito)
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();


            try
            {

                // guardo primero carrito
                conexion.ConnectionString = @"data source =.\SQLEXPRESS; initial catalog=LEROSE_DB; integrated security=sspi;";
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "GuardarCarrito";
                comando.Connection = conexion;

                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@fecha", carrito.Fecha);
                comando.Parameters.AddWithValue("@usuario", carrito.Usuario.Id);
                comando.Parameters.AddWithValue("@borrado", carrito.BorradoLogico);
                comando.Parameters.AddWithValue("@monto", carrito.Monto);

                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();


                // leo el id del carrito para vincular los articulos
                SqlDataReader lector;
                conexion.ConnectionString = @"data source =.\SQLEXPRESS; initial catalog=LEROSE_DB; integrated security=sspi;";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT * FROM LeerCarritoId";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();
                var CarritoId = 0;
                while (lector.Read())
                {
                    CarritoId = lector.GetInt32(0);
                }
                conexion.Close();


                // guardo datos envio 
                conexion.ConnectionString = @"data source =.\SQLEXPRESS; initial catalog=LEROSE_DB; integrated security=sspi;";
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "GuardarEnvio";
                comando.Connection = conexion;

                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@calle", carrito.DatosEnvio.Calle);
                comando.Parameters.AddWithValue("@postal", carrito.DatosEnvio.CodigoPostal);
                comando.Parameters.AddWithValue("@localidad", carrito.DatosEnvio.Localidad);
                comando.Parameters.AddWithValue("@mail", carrito.DatosEnvio.Mail);
                comando.Parameters.AddWithValue("@nombre", carrito.DatosEnvio.Nombre);
                comando.Parameters.AddWithValue("@notas", carrito.DatosEnvio.Notas);
                comando.Parameters.AddWithValue("@nrCalle", carrito.DatosEnvio.NumeroCalle);
                comando.Parameters.AddWithValue("@documento", carrito.DatosEnvio.NumeroDocumento);
                comando.Parameters.AddWithValue("@provincia", carrito.DatosEnvio.Provincia);
                comando.Parameters.AddWithValue("@telefono", carrito.DatosEnvio.Telefono);
                comando.Parameters.AddWithValue("@fecha", carrito.Fecha);
                comando.Parameters.AddWithValue("@usuario", carrito.Usuario.Id);
                comando.Parameters.AddWithValue("@borrado", carrito.BorradoLogico);
                comando.Parameters.AddWithValue("@id", CarritoId);

                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();



                // Ahora Guardo la lista de articulos
                conexion.ConnectionString = @"data source =.\SQLEXPRESS; initial catalog=LEROSE_DB; integrated security=sspi;";
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "GuardarListaArticulos";
                comando.Connection = conexion;

                conexion.Open();

                foreach (var item in carrito.Articulos)
                {
                    comando.Parameters.Clear();

                    comando.Parameters.AddWithValue("@articulo", item.Id);
                    comando.Parameters.AddWithValue("@carrito", CarritoId);
                    comando.Parameters.AddWithValue("@precio", item.Precio);

                    comando.ExecuteNonQuery();
                }

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
    }
}

