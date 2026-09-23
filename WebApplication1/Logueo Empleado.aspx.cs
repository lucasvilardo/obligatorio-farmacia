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
    public partial class Logueo_Empleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Session["Empleado"] = null;

            if (!IsPostBack)
            {
                lblError.Text = "";
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = txtUsuario.Text;
                string contraseña = txtContraseña.Text;

                Empleado emp = LogicaEmpleado.LogueoEmpleado(usuario, contraseña);

                if (emp != null)
                {
                    Session["Empleado"] = emp;
                    Response.Redirect("~/Principal.aspx");
                }
                else
                {
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "Usuario o contraseña incorrectos.";

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