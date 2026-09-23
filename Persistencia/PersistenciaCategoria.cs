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
    public class PersistenciaCategoria
    {
        public static Categoria Buscar(string pcodigoC)
        {
            string nombre;

            Categoria oCategorias = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarCat", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigoC", pcodigoC);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        nombre = (string)oReader["nombreCat"];

                        oCategorias = new Categoria(pcodigoC, nombre);
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
            return oCategorias;
        }

        public static void Modificar(Categoria pCategoria)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarCategorias", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigoC", pCategoria.CodigoC);
            oComando.Parameters.AddWithValue("@nombre", pCategoria.NombreCat);

            SqlParameter oRetorno = new SqlParameter("@retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int retorno = Convert.ToInt32(oRetorno.Value);

                if (retorno == -2)
                {
                    throw new Exception("No se encontró la categoría o no se realizaron cambios.");
                }
                else if (retorno == -1)
                {
                    throw new Exception("Error en la base de datos al modificar la categoría.");
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

        public static void Eliminar(Categoria pCategorias)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("eliminarCategorias", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigoC", pCategorias.CodigoC);



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
                    throw new Exception("La categoría tiene una venta asociada.");

                else if (retorno == -1)
                    throw new Exception("No existe la categoría.");

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

        public static void Agregar(Categoria pCategorias)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AltaCategorias", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigoC", pCategorias.CodigoC);
            oComando.Parameters.AddWithValue("@nombre", pCategorias.NombreCat);

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
                    throw new Exception("Ya existe una Categoría con esos datos.");
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

        public static List<Categoria> ListarCategorias()
        {
            string codigoC, nombre;

            List<Categoria> colCategorias = new List<Categoria>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListaCategorias", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        codigoC = oReader["codigoC"].ToString();
                        nombre = oReader["nombreCat"].ToString();

                        Categoria oCategoria = new Categoria(codigoC, nombre);
                        colCategorias.Add(oCategoria);
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
            return colCategorias;
        }
    }
}
