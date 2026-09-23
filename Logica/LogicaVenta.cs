using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaVenta
    {
        public static List<Venta> ListarVentas()
        {
            return PersistenciaVenta.ListarVentas();
        }

        public static Venta Buscar(int pnumVenta)
        {
            Venta oventa = PersistenciaVenta.Buscar(pnumVenta);

            return oventa;
        }

        public static void Cambiar(Venta pventas)
        {
            PersistenciaVenta.Cambiar((Venta)pventas);
        }

        public static void Agregar(Venta pventa)
        {
            PersistenciaVenta.Agregar((Venta)pventa);
        }

        public static List<Venta> ListarVentasXArticulo(string codigo)
        {
            return PersistenciaVenta.ListarVentasXArticulo(codigo);
        }

        public static List<Venta> ListaVentasXCliente(int ci)
        {
            return PersistenciaVenta.ListaVentasXCliente(ci);
        }



    }
}
