using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaArticulo
    {
        public static Articulo Buscar(string pcodigo)
        {
            Articulo oArticulo = PersistenciaArticulo.Buscar(pcodigo);

            return oArticulo;
        }

        public static void Modificar(Articulo pArticulo)
        {
            PersistenciaArticulo.Modificar((Articulo)pArticulo);
        }

        public static void Eliminar(Articulo pArticulo)
        {
            PersistenciaArticulo.Eliminar((Articulo)pArticulo);
        }

        public static void Agregar(Articulo pArticulo)
        {
            PersistenciaArticulo.Agregar((Articulo)pArticulo);
        }

        public static List<Articulo> ListarArticulosxCate(string cateSeleccionada)
        {
            List<Articulo> colAuxiliar = new List<Articulo>();

            colAuxiliar.AddRange(PersistenciaArticulo.ListarArticulosxCate(cateSeleccionada));

            return colAuxiliar;
        }

        public static List<Articulo> ListaArtxClie(int ci)
        {
            return PersistenciaArticulo.ListaArtxClie(ci);
        }

        public static int MontoTotal(int ci)
        {
            return PersistenciaArticulo.MontoTotal(ci);
        }
    }
}
