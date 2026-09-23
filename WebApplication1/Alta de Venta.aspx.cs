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
    public partial class Alta_de_Venta : System.Web.UI.Page
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

            txtCI.Text = "";
            txtCI.Enabled = true;
            txtCantidad.Text = "";
            txtCantidad.Enabled = true;
            txtCI.Text = "";
            txtCI.Enabled = true;
            txtDireccion.Text = "";
            txtDireccion.Enabled = true;
            txtCodigo.Text = "";
            txtCodigo.Enabled = true;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpioFormulario();
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {

                int cantidad = int.Parse(txtCantidad.Text.Trim());
                int cedula = int.Parse(txtCI.Text.Trim());
                string direccion = txtDireccion.Text.Trim();
                string codigo = txtCodigo.Text.Trim();

                Empleado unEmpleado = (Empleado)Session["Empleado"];
                Articulo unArticulo = LogicaArticulo.Buscar(codigo);
                Cliente unCliente = LogicaCliente.Buscar(cedula);

                Venta venta = new Venta(0, DateTime.Now, "Armado", direccion, cantidad, unArticulo, unCliente, unEmpleado);

                LogicaVenta.Agregar(venta);

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