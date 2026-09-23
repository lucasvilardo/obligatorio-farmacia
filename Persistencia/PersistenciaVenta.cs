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
    public class PersistenciaVenta
    {
        public static List<Venta> ListarVentas()
        {
            int numVenta, cantidad, cedula;
            string estado, direccion, codigo, usuario;
            DateTime fechaRealizada;

            Venta unaVenta = null;
            List<Venta> colVentas = new List<Venta>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("FormularioNoEnDev", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        numVenta = Convert.ToInt32(oReader["numVenta"]);
                        estado = Convert.ToString(oReader["estado"]);
                        direccion = Convert.ToString(oReader["direccion"]);
                        fechaRealizada = Convert.ToDateTime(oReader["fechaRealizada"]);
                        cantidad = Convert.ToInt32(oReader["cantidad"]);
                        codigo = Convert.ToString(oReader["codigo"]);
                        cedula = Convert.ToInt32(oReader["ci"]);
                        usuario = Convert.ToString(oReader["usuario"]);

                        Articulo unArticulo = PersistenciaArticulo.Buscar(codigo);
                        Cliente unCliente = PersistenciaCliente.Buscar(cedula);
                        Empleado unEmpleado = PersistenciaEmpleado.BuscarEmp(usuario);

                        unaVenta = new Venta(numVenta, fechaRealizada, estado, direccion, cantidad, unArticulo, unCliente, unEmpleado);
                        colVentas.Add(unaVenta);
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
            return colVentas;
        }

        public static Venta Buscar(int pnumVenta)
        {
            Venta venta = null;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("estadoActual", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@numVenta", pnumVenta);

            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        int numVenta = Convert.ToInt32(oReader["numVenta"]);
                        string estado = Convert.ToString(oReader["estado"]);
                        string direccion = Convert.ToString(oReader["direccion"]);
                        DateTime fechaRealizada = Convert.ToDateTime(oReader["fechaRealizada"]);
                        int cantidad = Convert.ToInt32(oReader["cantidad"]);
                        string codigo = Convert.ToString(oReader["codigo"]);
                        int cedula = Convert.ToInt32(oReader["ci"]);
                        string usuario = Convert.ToString(oReader["usuario"]);

                        Articulo unArticulo = PersistenciaArticulo.Buscar(codigo);
                        Cliente unCliente = PersistenciaCliente.Buscar(cedula);
                        Empleado unEmpleado = PersistenciaEmpleado.BuscarEmp(usuario);

                        venta = new Venta(numVenta, fechaRealizada, estado, direccion, cantidad, unArticulo, unCliente, unEmpleado);

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
            return venta;
        }

        public static void Cambiar(Venta pventas)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("SeguimientoVenta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@numVenta", pventas.NumVenta);

            SqlParameter oRetorno = new SqlParameter("@retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int retorno = Convert.ToInt32(oRetorno.Value);

                if (retorno == 1)
                {
                    return;
                }
                else if (retorno == -1)
                {
                    throw new Exception("Venta no encontrada.");
                }
                else if (retorno == -2)
                {
                    throw new Exception("La venta ya fue devuelta y no puede cambiar de estado.");
                }
                else if (retorno == -3)
                {
                    throw new Exception("Error al actualizar el estado.");
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

        public static void Agregar(Venta pventa)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AltaVenta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigo", pventa.UnArticulo.Codigo);
            oComando.Parameters.AddWithValue("@ci", pventa.UnCliente.Ci);
            oComando.Parameters.AddWithValue("@direccion", pventa.Direccion);
            oComando.Parameters.AddWithValue("@cantidad", pventa.Cantidad);
            oComando.Parameters.AddWithValue("@usuario", pventa.UnEmpleado.Usuario);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int retorno = Convert.ToInt32(oRetorno.Value);

                if (retorno == -3)
                    throw new Exception("Ocurrió un error inesperado.");
                else if (retorno == -2)
                    throw new Exception("Ya existe un Articulo con ese código .");
                else if (retorno == -1)
                    throw new Exception("No existe un cliente con esa cédula.");
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

        public static List<Venta> ListarVentasXArticulo(string codigo)
        {
            int numVenta, cantidad, cedula;
            string estado, direccion, codigoo;
            DateTime fechaRealizada;

            List<Venta> colVentasxArt = new List<Venta>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarVentasXArticulo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigo", codigo);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        numVenta = Convert.ToInt32(oReader["numVenta"]);
                        estado = Convert.ToString(oReader["estado"]);
                        direccion = Convert.ToString(oReader["direccion"]);
                        fechaRealizada = Convert.ToDateTime(oReader["fechaRealizada"]);
                        codigoo = Convert.ToString(oReader["codigo"]);
                        cantidad = Convert.ToInt32(oReader["cantidad"]);
                        cedula = Convert.ToInt32(oReader["ci"]);
                        string usuario = Convert.ToString(oReader["usuario"]);

                        Articulo unArticulo = PersistenciaArticulo.Buscar(codigo);
                        Cliente unCliente = PersistenciaCliente.Buscar(cedula);
                        Empleado unEmpleado = PersistenciaEmpleado.BuscarEmp(usuario);

                        Venta oVentas = new Venta(numVenta, fechaRealizada, direccion, estado, cantidad, unArticulo, unCliente, unEmpleado);
                        colVentasxArt.Add(oVentas);
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
            return colVentasxArt;
        }

        public static List<Venta> ListaVentasXCliente(int ci)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListaVentasXCliente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@ci", ci);

            
            Venta venta = null;
            List<Venta> colVentasxCliente = new List<Venta>();
            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        int numVenta = Convert.ToInt32(oReader["numVenta"]);
                        string estado = Convert.ToString(oReader["estado"]);
                        string direccion = Convert.ToString(oReader["direccion"]);
                        DateTime fechaRealizada = Convert.ToDateTime(oReader["fechaRealizada"]);
                        int cantidad = Convert.ToInt32(oReader["cantidad"]);
                        string codigo = Convert.ToString(oReader["codigo"]);
                        int cedula = Convert.ToInt32(oReader["ci"]);
                        string usuario = Convert.ToString(oReader["usuario"]);

                        Articulo unArticulo = PersistenciaArticulo.Buscar(codigo);
                        Cliente unCliente = PersistenciaCliente.Buscar(cedula);
                        Empleado unEmpleado = PersistenciaEmpleado.BuscarEmp(usuario);


                        venta = new Venta(numVenta, fechaRealizada, estado, direccion, cantidad, unArticulo, unCliente, unEmpleado);
                        colVentasxCliente.Add(venta);

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
            return colVentasxCliente;
        }


    }
}
