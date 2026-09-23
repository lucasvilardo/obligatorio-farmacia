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
    public class PersistenciaEmpleado
    {
        public static Empleado BuscarEmp(string pusuario)
        {
            string nombre, usuario, contraseña;

            Empleado oEmpleado = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarEmp", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@usuario", pusuario);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        nombre = (string)oReader["nombreEmp"];
                        usuario = (string)oReader["usuario"];
                        contraseña = (string)oReader["contraseña"];


                        oEmpleado = new Empleado(pusuario, contraseña, nombre);
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
            return oEmpleado;
        }

        public static Empleado LogueoEmpleado(string usuario, string contraseña)
        {
            Empleado empleado = null;


            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("LogueoEmpleado", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@usuario", usuario);
            oComando.Parameters.AddWithValue("@contraseña", contraseña);

            SqlParameter resultado = new SqlParameter("@resultado", SqlDbType.Int);
            resultado.Direction = ParameterDirection.Output;
            oComando.Parameters.Add(resultado);
            SqlParameter nombre = new SqlParameter("@nombre", SqlDbType.VarChar, 30);
            nombre.Direction = ParameterDirection.Output;
            oComando.Parameters.Add(nombre);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultadoEmp = Convert.ToInt32(oComando.Parameters["@resultado"].Value);

                if (resultadoEmp == 1)
                {
                    string nombreEmp = oComando.Parameters["@nombre"].Value.ToString();

                    empleado = new Empleado(usuario, contraseña, nombreEmp);

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
            return empleado;

        }
    }
}
