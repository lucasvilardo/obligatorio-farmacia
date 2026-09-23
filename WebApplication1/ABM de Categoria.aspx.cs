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
    public partial class ABM_de_Categoria : System.Web.UI.Page
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

            txtCodigo.Text = "";
            txtCodigo.Enabled = true;
            txtNombre.Text = "";
            txtNombre.Enabled = false;

        }

        private void ActivoBotones(bool esAlta = true)
        {
            btnAlta.Enabled = !esAlta;
            btnEliminar.Enabled = !esAlta;
            btnModificar.Enabled = !esAlta;
            btnBuscar.Enabled = false;

            txtCodigo.Enabled = false;
            txtNombre.Enabled = true;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpioFormulario();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigoC = txtCodigo.Text.Trim();

                if (codigoC == "")
                {
                    lblError.Text = "Se debe escribir el código de la Categoría.";
                }

                Categoria cat = LogicaCategoria.Buscar(codigoC);

                if (cat != null)
                {
                    txtNombre.Text = cat.NombreCat;

                    ActivoBotones(false);

                    Session["Categoria"] = cat;

                    btnAlta.Enabled = false;
                }
                else
                {
                    ActivoBotones();
                    btnAlta.Enabled = true;

                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "No hay categorías con ese código. Puede agregar uno si desea.";

                    Session["Categoria"] = null;
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
                Categoria categoria = (Categoria)Session["Categoria"];

                categoria.NombreCat = txtNombre.Text.Trim();

                LogicaCategoria.Modificar(categoria);

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
                Categoria categorias = (Categoria)Session["Categoria"];

                LogicaCategoria.Eliminar(categorias);

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
                string codigoC = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();

                Categoria categoria = new Categoria(codigoC, nombre);

                LogicaCategoria.Agregar(categoria);

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