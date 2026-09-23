using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Categoria
    {
        string codigoC;
        string nombreCat;

        public string CodigoC
        {
            get { return codigoC; }
            set
            {
                if (value.Length != 6)
                    throw new Exception("El código debe de ser de 6 caracteres");
                codigoC = value;
                
            }
        }

        public string NombreCat
        {
            get { return nombreCat; }
            set
            {
                if (value.Length == 0 || value.Length > 30)
                    throw new Exception("Se debe saber el nombre completo de la categoría");
                nombreCat = value;
            }
        }

        public string AMostrar
        {
            get { return "Código: " + codigoC + ", Nombre: " + nombreCat; }
        } 

        public Categoria(string pcodigoC, string pnombre)
        {
            CodigoC = pcodigoC;
            NombreCat = pnombre;
        }
    }
}
