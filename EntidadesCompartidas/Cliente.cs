using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Cliente
    {
        int ci;
        string numTelefonico;
        string numTarjeta;
        string nombreCli;

        public int Ci
        {
            get { return ci; }
            set
            {
                if (value.ToString().Trim().Length != 7 && value.ToString().Trim().Length != 8)
                    throw new Exception("La cedula son 7 u 8 digitos");
                else
                    ci = value;
                
            }
        }

        public string NumTelefonico
        {
            get { return numTelefonico; }
            set
            {
                if (value.Length != 9)
                    throw new Exception("El numero telefónico debe ser de 9 dígitos.");
                numTelefonico = value;
            }
        }

        public string NumTarjeta
        {
            get { return numTarjeta; }
            set
            {
                if (value.Trim().Length != 16)
                    throw new Exception("El numero de tarjeta debe ser de 16 dígitos.");
                numTarjeta = value;
            }
        }

        public string NombreCli
        {
            get { return nombreCli; }
            set
            {
                if (value.Length == 0 || value.Length > 30)
                    throw new Exception("Se debe saber el nombre completo del cliente");
                nombreCli = value;
            }
        }

        public string AMostrar
        {
            get { return "Cédula: " + ci + ", Número Telefónico: " + numTelefonico + ", Número de Tarjeta: " + numTarjeta + ", Nombre: " + nombreCli; }
        }

        public Cliente(int pci, string pnumTelefonico, string pnumTarjeta, string pnombreCli)
        {
            Ci = pci;
            NumTelefonico = pnumTelefonico;
            NumTarjeta = pnumTarjeta;
            NombreCli = pnombreCli;
        }

    }
}
