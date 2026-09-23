using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaCliente
    {
        public static Cliente Buscar(int pcedula)
        {
            string nombre, numTarjeta, numTelefonico;


            Cliente oClientes = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarClie", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@ci", pcedula);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        nombre = (string)oReader["nombreCli"];
                        numTarjeta = (string)oReader["numTarjeta"];
                        numTelefonico = (string)oReader["numTelefonico"];


                        oClientes = new Cliente(pcedula, numTelefonico, numTarjeta, nombre);
                    }
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return oClientes;
        }

        public static void Modificar(Cliente pclientes)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarClientes", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@ci", pclientes.Ci);
            oComando.Parameters.AddWithValue("@nombre", pclientes.NombreCli);
            oComando.Parameters.AddWithValue("@numTelefonico", pclientes.NumTelefonico);
            oComando.Parameters.AddWithValue("@numTarjeta", pclientes.NumTarjeta);

            SqlParameter oRetorno = new SqlParameter("@retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int retorno = Convert.ToInt32(oRetorno.Value);

                if (retorno == -1)
                {
                    throw new Exception("No se encontró el cliente.");
                }
                else if (retorno == -2)
                {
                    throw new Exception("Error en la base de datos al modificar el cliente.");
                }
                else if (retorno == 1)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static void Eliminar(Cliente pclientes)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("eliminarClientes", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@ci", pclientes.Ci);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int retorno = Convert.ToInt32(oRetorno.Value);

                if (retorno == -3)
                    throw new Exception("Ha ocurrido un error inesperado.");

                else if (retorno == -2)
                    throw new Exception("El Cliente tiene una venta asociada.");

                else if (retorno == -1)
                    throw new Exception("No existe el Cliente.");

                else if (retorno == 1)
                    return;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static void Agregar(Cliente pclientes)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AltaClientes", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@ci", pclientes.Ci);
            oComando.Parameters.AddWithValue("@nombre", pclientes.NombreCli);
            oComando.Parameters.AddWithValue("@numTelefonico", pclientes.NumTelefonico);
            oComando.Parameters.AddWithValue("@numTarjeta", pclientes.NumTarjeta);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int retorno = Convert.ToInt32(oRetorno.Value);

                if (retorno == -2)
                    throw new Exception("Ocurrió un error inesperado.");
                else if (retorno == -1)
                    throw new Exception("Ya existe un Cliente con esos datos.");
                else if (retorno == 1)
                    return;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static List<Cliente> ListarClientes()
        {

            Cliente unCliente = null;
            List<Cliente> colClientes = new List<Cliente>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarClientes", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        int ci = Convert.ToInt32(oReader["ci"]);
                        string numTelefonico = Convert.ToString(oReader["numTelefonico"]);
                        string numTarjeta = Convert.ToString(oReader["numTarjeta"]);
                        string nombreCli = Convert.ToString(oReader["nombreCli"]);

                        unCliente = new Cliente(ci, numTelefonico, numTarjeta, nombreCli);
                        colClientes.Add(unCliente);
                    }
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return colClientes;
        }


    }
}
