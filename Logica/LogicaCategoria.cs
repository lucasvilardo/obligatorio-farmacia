using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaCategoria
    {
        public static Categoria Buscar(string pcodigoC)
        {
            Categoria oCategoria = PersistenciaCategoria.Buscar(pcodigoC);

            return oCategoria;
        }

        public static void Modificar(Categoria pCategoria)
        {
            PersistenciaCategoria.Modificar((Categoria)pCategoria);
        }

        public static void Eliminar(Categoria pCategorias)
        {
            PersistenciaCategoria.Eliminar((Categoria)pCategorias);
        }

        public static void Agregar(Categoria pCategoria)
        {
            PersistenciaCategoria.Agregar((Categoria)pCategoria);
        }

        public static List<Categoria> ListarCategorias()
        {
            List<Categoria> colAuxiliar = new List<Categoria>();

            colAuxiliar.AddRange(PersistenciaCategoria.ListarCategorias());

            return colAuxiliar;
        }
    }
}
