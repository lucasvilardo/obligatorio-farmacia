using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Venta
    {
        int numVenta;
        DateTime fechaRealizada;
        string estado;
        string direccion;
        int cantidad;
        Articulo unArticulo;
        Cliente unCliente;
        Empleado unEmpleado;

        public int NumVenta
        {
            get { return numVenta; }
            set
            {
                numVenta = value;
            }
        }

        public DateTime FechaRealizada
        {
            get { return fechaRealizada; }
            set
            {
                fechaRealizada = value;
            }
        }

        public string Estado
        {
            get { return estado; }
            set
            {
                estado = value;
            }
        }

        public string Direccion
        {
            get { return direccion; }
            set
            {
                if (value.Length == 0 || value.Length > 50)
                    throw new Exception("La venta debe tener una dirección.");
                direccion = value;
            }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                if (value < 1)
                    throw new Exception("La cantidad de la venta debe ser mayor a 0");
                else
                    cantidad = value;
            }
        }

        public Articulo UnArticulo
        {
            get { return unArticulo; }
            set
            {
                if (value == null)
                    throw new Exception("La venta debe tener un artículo asociado.");
                else
                    unArticulo = value;
            }
        }

        public Cliente UnCliente
        {
            get { return unCliente; }
            set
            {
                if (value == null)
                    throw new Exception("La venta debe tener un cliente asociado.");
                else
                    unCliente = value;
            }
        }

        public Empleado UnEmpleado
        {
            get { return unEmpleado; }
            set
            {
                if (value == null)
                    throw new Exception("La venta debe tener un empleado asociado.");
                else
                    unEmpleado = value;
            }
        }

        public string AMostrar
        {
            get
            {
                return "Número de Venta: " + numVenta + ", Fecha de Realizada: " + fechaRealizada + ", Estado: " + estado +
                  ", Dirección: " + direccion + " Cantidad: " + cantidad + ", Código de Venta: " + unArticulo.Codigo + 
                  ", Cédula de quien hizo la compra: " + unCliente.Ci + " y Empelado que gestionó la venta: " + unEmpleado.Usuario;
            }
        }


        public Venta(int pnumVenta, DateTime pfechaRealizadad, string pestado, string pdireccion, int pcantidad,
            Articulo punArticulo, Cliente punCliente, Empleado punEmpleado)
        {
            NumVenta = pnumVenta;
            FechaRealizada = pfechaRealizadad;
            Estado = pestado;
            Direccion = pdireccion;
            Cantidad = pcantidad;
            UnArticulo = punArticulo;
            UnCliente = punCliente;
            UnEmpleado = punEmpleado;
        }
    }
}
