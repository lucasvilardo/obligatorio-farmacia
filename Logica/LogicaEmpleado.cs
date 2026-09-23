using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaEmpleado
    {
        public static Empleado LogueoEmpleado(string usuario, string contraseña)
        {
            return PersistenciaEmpleado.LogueoEmpleado(usuario, contraseña);
        }
    }
}
