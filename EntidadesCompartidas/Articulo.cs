using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Articulo
    {
        string codigo;
        string nombreArt;
        int precio;
        string tipoPresentacion;
        int tamaño;
        Categoria unaCategoria;

        public string Codigo
        {
            get { return codigo; }
            set
            {
                if (value.Length != 10)
                    throw new Exception("El código debe de ser de 10 caracteres");
                codigo = value;
            }
        }

        public string NombreArt
        {
            get { return nombreArt; }
            set
            {
                if (value.Length == 0 || value.Length > 15)
                    throw new Exception("Se debe saber el nombre completo del artículo");
                nombreArt = value;
            }
        }

        public int Precio
        {
            get { return precio; }
            set
            {
                if (value < 0)
                    throw new Exception("El precio debe ser mayor a 0");
                precio = value;
            }
        }

        public string TipoPresentacion
        {
            get { return tipoPresentacion; }
            set
            {
                tipoPresentacion = value;
            }
        }

        public int Tamaño
        {
            get { return tamaño; }
            set
            {
                tamaño = value;
            }
        }

        public Categoria UnaCategoria
        {
            get { return unaCategoria; }
            set
            {
                if (value == null)
                    throw new Exception("El artículo debe estar asociada a una Categoría.");
                else
                    unaCategoria = value;
            }
        }

        public string AMostrar
        {
            get { return "Código: " + codigo + ", Nombre: " + nombreArt + ", Precio: " + precio + ", Tipo de Presentación: " + tipoPresentacion + " con " + tamaño + ", Código de Categoría: " + unaCategoria.CodigoC; }
        }

        public Articulo(string pcodigo, string pnombreArt, int pprecio, string ptipoPresentacion, int ptamaño, Categoria punaCategoria )
        {
            Codigo = pcodigo;
            NombreArt = pnombreArt;
            Precio = pprecio;
            TipoPresentacion = ptipoPresentacion;
            Tamaño = ptamaño;
            UnaCategoria = punaCategoria;

        }
    }
}
