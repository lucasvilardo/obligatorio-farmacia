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
    public partial class Seguimiento_de_Venta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblEstado.Text = "";
            lblProxEstado.Text = "";

            if (!IsPostBack)
            {
                LimpioFormulario();

            }
        }

        private void LimpioFormulario()
        {
            btnBuscar.Enabled = true;
            btnCambiar.Enabled = false;

            txtNumVenta.Text = "";
            txtNumVenta.Enabled = true;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpioFormulario();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int numVenta = int.Parse(txtNumVenta.Text.Trim());

                Venta ven = LogicaVenta.Buscar(numVenta);

                if (ven != null)
                {
                    btnCambiar.Enabled = true;
                    txtNumVenta.Text = ven.NumVenta.ToString();

                    Session["Venta"] = ven;

                    lblEstado.Text = ven.Estado;

                    if (ven.Estado == "Armado")
                        lblProxEstado.Text = "Envío";
                    else if (ven.Estado == "Envío")
                        lblProxEstado.Text = "Entregado";
                    else if (ven.Estado == "Entregado")
                        lblProxEstado.Text = "Devuelto";
                    else if (ven.Estado == "Devuelto")
                    {
                        lblProxEstado.Text = "No puede cambiar.";
                        btnCambiar.Enabled = false;
                    }
                }
                else
                {
                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "No hay Ventas con ese Número de Venta.";

                    Session["Venta"] = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["Venta"] != null)
                {
                    Venta ven = (Venta)Session["Venta"];

                    LogicaVenta.Cambiar(ven);

                    Session["Venta"] = LogicaVenta.Buscar(ven.NumVenta);

                    lblError.ForeColor = Color.Green;
                    lblError.Text = "Estado actualizado correctamente.";

                }
                else
                {
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "Debe buscar una venta antes de cambiar su estado.";
                }
            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }
        }
    }
}