using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Empleado
    {
        string usuario;
        string contraseña;
        string nombreEmp;

        public string Usuario
        {
            get { return usuario; }
            set
            {
                if (value.Length == 0 || value.Length > 30)
                    throw new Exception("Se debe saber el usuario del empleado");
                usuario = value;
            }
        }

        public string Contraseña
        {
            get { return usuario; }
            set
            {
                if (value.Length == 0 || value.Length > 30)
                    throw new Exception("Se debe saber la contraseña del empleado");
                contraseña = value;
            }
        }

        public string NombreEmp
        {
            get { return nombreEmp; }
            set
            {
                if (value.Length == 0 || value.Length > 30)
                    throw new Exception("Se debe saber el nombre completo del empleado");
                nombreEmp = value;
            }
        }

        public string AMostrar
        {
            get { return "Usuario: " + usuario + ", Contraseña: " + contraseña + ", Nombre: " + nombreEmp; }
        }

        public Empleado(string pusuario, string pcontraseña, string pnombreEmp)
        {
            Usuario = pusuario;
            Contraseña = pcontraseña;
            NombreEmp = pnombreEmp;
        }
    }
}
