using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;
using System.Drawing;

namespace WebApplication1
{
    public partial class ABM_de_Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (!IsPostBack)
            {
                LimpioFormulario();

            }

        }

        private void LimpioFormulario()
        {
            btnAlta.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnBuscar.Enabled = true;

            txtCI.Text = "";
            txtCI.Enabled = true;
            txtNombre.Text = "";
            txtNombre.Enabled = false;
            txtTarjeta.Text = "";
            txtTarjeta.Enabled = false;
            txtTelefono.Text = "";
            txtTelefono.Enabled = false;

        }

        private void ActivoBotones(bool esAlta = true)
        {
            btnAlta.Enabled = !esAlta;
            btnEliminar.Enabled = !esAlta;
            btnModificar.Enabled = !esAlta;
            btnBuscar.Enabled = false;

            txtCI.Enabled = false;
            txtNombre.Enabled = true;
            txtTarjeta.Enabled = true;
            txtTelefono.Enabled = true;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpioFormulario();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int cedula = int.Parse(txtCI.Text.Trim());

                if (cedula == 0)
                {
                    lblError.Text = "Se debe escribir la cédula del cliente.";
                }
                else
                {
                    Cliente cli = LogicaCliente.Buscar(cedula);

                    if (cli != null)
                    {
                        txtNombre.Text = cli.NombreCli;
                        txtTarjeta.Text = cli.NumTarjeta.ToString();
                        txtTelefono.Text = cli.NumTelefonico.ToString();

                        ActivoBotones(false);
                        btnAlta.Enabled = false;

                        Session["Cliente"] = cli;
                    }
                    else
                    {
                        ActivoBotones();
                        btnAlta.Enabled = true;

                        lblError.ForeColor = Color.Blue;
                        lblError.Text = "No hay Clientes con esa cédula. Puede agregar uno si desea.";

                        Session["Cliente"] = null;
                    }
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = (Cliente)Session["Cliente"];

                cliente.NombreCli = txtNombre.Text.Trim();
                cliente.NumTarjeta = txtTarjeta.Text.Trim();
                cliente.NumTelefonico = txtTelefono.Text.Trim();

                LogicaCliente.Modificar(cliente);

                lblError.ForeColor = Color.Green;
                lblError.Text = "Modificación realizada con éxito.";

                LimpioFormulario();
            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente clientes = (Cliente)Session["Cliente"];

                LogicaCliente.Eliminar(clientes);

                lblError.ForeColor = Color.Green;
                lblError.Text = "Eliminación exitosa";

                LimpioFormulario();
            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                int cedula = int.Parse(txtCI.Text.Trim());
                string nombre = txtNombre.Text.Trim();
                string numTarjeta = txtTarjeta.Text.Trim();
                string numTelefono = txtTelefono.Text.Trim();

                Cliente cliente = new Cliente(cedula, numTelefono, numTarjeta, nombre);

                LogicaCliente.Agregar(cliente);

                lblError.ForeColor = Color.Green;
                lblError.Text = "Alta con éxito";

                LimpioFormulario();
            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }
        }
    }
}