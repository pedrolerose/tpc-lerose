using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            Usuario aux;
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = @"data source =.\SQLEXPRESS; initial catalog=LEROSE_DB; integrated security=sspi;";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT * FROM ConsultaUsuarios";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    aux = new Usuario();
                    aux.Id = lector.GetInt32(0);
                    aux.Fecha = (DateTime)lector["Fecha"];
                    aux.Nombre = lector["Nombre"].ToString();
                    aux.NumeroDocumento = (long)lector["NumeroDocumento"];
                    aux.Mail = lector["Mail"].ToString();
                    aux.SuperUsuario = (bool)lector["SuperUsuario"];

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
        public List<Carrito> GetComprasUsuario(int id)
        {
            List<Carrito> carritos = new List<Carrito>(); ;
            Carrito aux = new Carrito();
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = @"data source =.\SQLEXPRESS; initial catalog=LEROSE_DB; integrated security=sspi;";
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "GetComprasUsuario";
                comando.Connection = conexion;

                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@id", id);

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    aux.Id = lector.GetInt32(0);
                    aux.Monto = (decimal)lector["Monto"];
                    aux.Fecha = (DateTime)lector["Fecha"];

                    carritos.Add(aux);
                }
                return carritos;
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

