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
        public List<Carrito> Listar()
        {
            List<Carrito> lista = new List<Carrito>();
            Carrito aux;
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = @"data source =.\SQLEXPRESS; initial catalog=LEROSE_DB; integrated security=sspi;";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT * FROM ConsultaVentas";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    aux = new Carrito();
                    aux.Id = lector.GetInt32(0);
                    aux.Fecha = (DateTime)lector["Fecha"];
                    aux.Monto = (decimal)lector["Monto"];
                    aux.EstadoVenta.Id = (int)lector["IdEstado"];
                    aux.EstadoVenta.Descripcion = lector["Estado"].ToString();

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
        public void Agregar(Carrito carrito, FormaPago pago, Usuario user)
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
                comando.Parameters.AddWithValue("@usuario", user.Id); // el user ya tiene datos de envio
                comando.Parameters.AddWithValue("@borrado", carrito.BorradoLogico);
                comando.Parameters.AddWithValue("@monto", carrito.Monto);
                comando.Parameters.AddWithValue("@estado", carrito.EstadoVenta.Id);

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

                
                // guardo el pago
                conexion.ConnectionString = @"data source =.\SQLEXPRESS; initial catalog=LEROSE_DB; integrated security=sspi;";
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "GuardarPago";
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.Parameters.AddWithValue("@numeroTarjeta", pago.NumeroTarjeta);
                comando.Parameters.AddWithValue("@nombreTitular", pago.NombreTitular);
                comando.Parameters.AddWithValue("@vencimientoDia", pago.VencimientoDia);
                comando.Parameters.AddWithValue("@vencimientoMes", pago.VencimientoMes);
                comando.Parameters.AddWithValue("@codigoSeguridad", pago.CodigoSeguridad);

                comando.Parameters.AddWithValue("@fecha", pago.Fecha);
                comando.Parameters.AddWithValue("@usuario", user.Id);
                comando.Parameters.AddWithValue("@borrado", pago.BorradoLogico);
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
        public List<Articulo> GetArticulosCarrito(int id)
        {
            List<Articulo> articulos = new List<Articulo>(); ;
            Articulo aux = new Articulo();
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = @"data source =.\SQLEXPRESS; initial catalog=LEROSE_DB; integrated security=sspi;";
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "GetArticulosCarrito";
                comando.Connection = conexion;

                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@id", id);

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    aux = new Articulo();
                    aux.Id = lector.GetInt32(0);
                    aux.Codigo = lector["Codigo"].ToString();
                    aux.Nombre = lector["Nombre"].ToString();
                    aux.Imagen = lector["Imagen"].ToString();
                    aux.Precio = (decimal)lector["Precio"];

                    articulos.Add(aux);
                }
                return articulos;
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

