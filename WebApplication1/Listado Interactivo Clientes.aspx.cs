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
    public partial class Listado_Interactivo_Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                List<Cliente> colClientes = LogicaCliente.ListarClientes();
                Session["ListaClientes"] = colClientes;

                if (colClientes != null && colClientes.Count > 0)
                {
                    if (GrillaClientes != null)
                    {
                        GrillaClientes.DataSource = colClientes;
                        GrillaClientes.DataBind();
                    }
                }
            }
        }

        protected void GrillaClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (GrillaClientes.SelectedIndex > 0)
                {
                    int cliSeleccionado = Convert.ToInt32(GrillaClientes.SelectedValue);
                    List<Venta> listaVenta = LogicaVenta.ListaVentasXCliente(cliSeleccionado);
                    List<Articulo> listaArticulos = LogicaArticulo.ListaArtxClie(cliSeleccionado);
                    int monto = LogicaArticulo.MontoTotal(cliSeleccionado);

                    lblMonto.Text = "$" + monto.ToString();


                    if (listaVenta.Count >= 0)
                    {

                        ddlVentas.DataSource = listaVenta;
                        ddlVentas.DataTextField = "AMostrar";
                        ddlVentas.DataValueField = "numVenta";
                        ddlVentas.DataBind();
                        ddlVentas.Enabled = true;
                    }

                    if (listaArticulos.Count >= 0)
                    {
                        ddlArticulos.DataSource = listaArticulos;
                        ddlArticulos.DataTextField = "AMostrar";
                        ddlArticulos.DataValueField = "codigo";
                        ddlArticulos.DataBind();
                        ddlArticulos.Enabled = true;
                    }


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