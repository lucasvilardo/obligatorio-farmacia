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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    List<Venta> colVentas = LogicaVenta.ListarVentas();
                    Session["ListaVentas"] = colVentas;

                    if (colVentas != null && colVentas.Count > 0)
                    {
                        if (GrillaEstado != null)
                        {
                            GrillaEstado.DataSource = colVentas;
                            GrillaEstado.DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
                
            }

        }
    }
}