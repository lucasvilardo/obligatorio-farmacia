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
    public class PersistenciaArticulo
    {
        public static Articulo Buscar(string pcodigo)
        {
            string nombre, tipoPresentacion, codigoC;
            int precio, tamaño;

            Articulo oArticulo = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarArt", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigo", pcodigo);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        nombre = (string)oReader["nombreArt"];
                        tipoPresentacion = (string)oReader["tipoPresentacion"];
                        codigoC = (string)oReader["codigoC"];
                        precio = (int)oReader["precio"];
                        tamaño = (int)oReader["tamaño"];

                        Categoria unaCategoria = PersistenciaCategoria.Buscar(codigoC);

                        oArticulo = new Articulo(pcodigo, nombre, precio, tipoPresentacion, tamaño, unaCategoria);
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
            return oArticulo;
        }

        public static void Modificar(Articulo pArticulo)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarArticulos", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigo", pArticulo.Codigo);
            oComando.Parameters.AddWithValue("@nombre", pArticulo.NombreArt);
            oComando.Parameters.AddWithValue("@precio", pArticulo.Precio);
            oComando.Parameters.AddWithValue("@tipoPresentacion", pArticulo.TipoPresentacion);
            oComando.Parameters.AddWithValue("@tamaño", pArticulo.Tamaño);
            oComando.Parameters.AddWithValue("@codigoC", pArticulo.UnaCategoria.CodigoC);

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
                    throw new Exception("No se encontró el artículo.");
                }
                else if (retorno == -2)
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

        public static void Eliminar(Articulo pArticulo)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("eliminarArticulos", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigo", pArticulo.Codigo);


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
                    throw new Exception("El Artículo tiene una venta asociada.");

                else if (retorno == -1)
                    throw new Exception("No existe el Artículo.");

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

        public static void Agregar(Articulo pArticulo)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AltaArticulos", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigo", pArticulo.Codigo);
            oComando.Parameters.AddWithValue("@nombre", pArticulo.NombreArt);
            oComando.Parameters.AddWithValue("@precio", pArticulo.Precio);
            oComando.Parameters.AddWithValue("@tipoPresentacion", pArticulo.TipoPresentacion);
            oComando.Parameters.AddWithValue("@tamaño", pArticulo.Tamaño);
            oComando.Parameters.AddWithValue("@codigoC", pArticulo.UnaCategoria.CodigoC);

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
                    throw new Exception("Ya existe un Artículo con esos datos.");
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

        public static List<Articulo> ListarArticulosxCate(string codigoCategoria)
        {
            string codigo, nombre, tipoPresentacion, codigoC;
            int precio, tamaño;

            List<Articulo> colArticulos = new List<Articulo>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListaArticulosXCategorias", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigoC", codigoCategoria);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        codigoC = oReader["codigoC"].ToString();
                        nombre = oReader["nombreArt"].ToString();
                        codigo = oReader["codigo"].ToString();
                        tipoPresentacion = oReader["tipoPresentacion"].ToString();
                        precio = Convert.ToInt32(oReader["precio"]);
                        tamaño = Convert.ToInt32(oReader["tamaño"]);

                        Categoria unaCategoria = PersistenciaCategoria.Buscar(codigoC);

                        Articulo oArticulo = new Articulo(codigo, nombre, precio, tipoPresentacion, tamaño, unaCategoria);
                        colArticulos.Add(oArticulo);
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
            return colArticulos;
        }

        public static List<Articulo> ListaArtxClie(int ci)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListaArtxClie", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@ci", ci);

            string codigo, nombre, tipoPresentacion, codigoC;
            int tamaño, precio;
            List<Articulo> ListaArtxClie = new List<Articulo>();

            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        codigoC = oReader["codigoC"].ToString();
                        nombre = oReader["nombreArt"].ToString();
                        codigo = oReader["codigo"].ToString();
                        tipoPresentacion = oReader["tipoPresentacion"].ToString();
                        precio = Convert.ToInt32(oReader["precio"]);
                        tamaño = Convert.ToInt32(oReader["tamaño"]);

                        Categoria unaCategoria = PersistenciaCategoria.Buscar(codigoC);

                        Articulo oArticulo = new Articulo(codigo, nombre, precio, tipoPresentacion, tamaño, unaCategoria);
                        ListaArtxClie.Add(oArticulo);
                    }
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
            return ListaArtxClie;
        }

        public static int MontoTotal(int ci)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("MontoTotal", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@ci", ci);
            int monto = 0;

            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        if (oReader["MontoTotal"] != DBNull.Value)
                            monto = Convert.ToInt32(oReader["MontoTotal"]);

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
            return monto;

        }

    }
}
