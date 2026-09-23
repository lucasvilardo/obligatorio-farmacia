using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaCliente
    {
        public static Cliente Buscar(int pcedula)
        {
            Cliente oClientes = PersistenciaCliente.Buscar(pcedula);

            return oClientes;
        }

        public static void Modificar(Cliente pclientes)
        {
            PersistenciaCliente.Modificar((Cliente)pclientes);
        }

        public static void Eliminar(Cliente pclientes)
        {
            PersistenciaCliente.Eliminar((Cliente)pclientes);
        }

        public static void Agregar(Cliente pclientes)
        {
            PersistenciaCliente.Agregar((Cliente)pclientes);
        }

        public static List<Cliente> ListarClientes()
        {
            return PersistenciaCliente.ListarClientes();
        }

        public static List<Venta> ListaVentasXCliente(int ci)
        {
            return PersistenciaVenta.ListaVentasXCliente(ci);
        }
    }
}
