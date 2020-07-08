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

                    aux.Calle = lector["Calle"].ToString();
                    aux.NumeroCalle = (long)lector["NumeroCalle"];
                    aux.Localidad = lector["Localidad"].ToString();
                    aux.Provincia = lector["Provincia"].ToString();
                    aux.CodigoPostal = (long)lector["CodigoPostal"];
                    aux.Telefono = (long)lector["Telefono"];

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
        public bool Registrar(Usuario u)
        {
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();


            try
            {

                conexion.ConnectionString = @"data source =.\SQLEXPRESS; initial catalog=LEROSE_DB; integrated security=sspi;";
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "Registrar";
                comando.Connection = conexion;

                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@fecha", u.Fecha);
                comando.Parameters.AddWithValue("@borrado", u.BorradoLogico);
                comando.Parameters.AddWithValue("@super", u.SuperUsuario);

                comando.Parameters.AddWithValue("@calle", u.Calle);
                comando.Parameters.AddWithValue("@postal", u.CodigoPostal);
                comando.Parameters.AddWithValue("@localidad", u.Localidad);
                comando.Parameters.AddWithValue("@mail", u.Mail);
                comando.Parameters.AddWithValue("@nombre", u.Nombre);
                comando.Parameters.AddWithValue("@nrCalle", u.NumeroCalle);
                comando.Parameters.AddWithValue("@documento", u.NumeroDocumento);
                comando.Parameters.AddWithValue("@provincia", u.Provincia);
                comando.Parameters.AddWithValue("@telefono", u.Telefono);

                comando.Parameters.AddWithValue("@clave", u.Clave);


                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();

                return true;

            }
            catch (Exception)
            {
                return false;
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
        public Usuario Loguear(Usuario usuario)
        {

            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = @"data source =.\SQLEXPRESS; initial catalog=LEROSE_DB; integrated security=sspi;";
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "Loguear";
                comando.Connection = conexion;

                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@mail", usuario.Mail);
                comando.Parameters.AddWithValue("@clave", usuario.Clave);

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    usuario.Id = (int)lector["Id"];
                    usuario.Fecha = (DateTime)lector["Fecha"];
                    usuario.Nombre = lector["Nombre"].ToString();
                    usuario.NumeroDocumento = (long)lector["NumeroDocumento"];
                    usuario.SuperUsuario = (bool)lector["SuperUsuario"];
                    usuario.Calle = lector["Calle"].ToString();
                    usuario.NumeroCalle = (long)lector["NumeroCalle"];
                    usuario.Provincia = lector["Provincia"].ToString();
                    usuario.Localidad = lector["Localidad"].ToString();
                    usuario.CodigoPostal = (long)lector["CodigoPostal"];

                }

                return usuario;

            }
            catch (Exception ex)
            {
                usuario.Id = 0;
                return usuario;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
        public void CambioPass(long dni,string pass)
        {
            Usuario usuario = new Usuario();

            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = @"data source =.\SQLEXPRESS; initial catalog=LEROSE_DB; integrated security=sspi;";
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "CambioPass";
                comando.Connection = conexion;

                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@dni", dni);
                comando.Parameters.AddWithValue("@pass", pass);

                conexion.Open();
                lector = comando.ExecuteReader();


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

