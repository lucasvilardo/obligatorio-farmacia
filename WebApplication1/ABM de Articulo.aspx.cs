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
    public partial class ABM_de_Articulo : System.Web.UI.Page
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
            txtPrecio.Text = "";
            txtPrecio.Enabled = false;
            txtPresentacion.Text = "";
            txtPresentacion.Enabled = false;
            txtTamaño.Text = "";
            txtTamaño.Enabled = false;
            txtCodigoC.Text = "";
            txtCodigoC.Enabled = false;
        }

        private void ActivoBotones(bool esAlta = true)
        {
            btnAlta.Enabled = !esAlta;
            btnEliminar.Enabled = !esAlta;
            btnModificar.Enabled = !esAlta;
            btnBuscar.Enabled = false;

            txtCodigo.Enabled = false;
            txtNombre.Enabled = true;
            txtPrecio.Enabled = true;
            txtPresentacion.Enabled = true;
            txtTamaño.Enabled = true;
            txtCodigoC.Enabled = true;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpioFormulario();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();

            if (codigo == "")
            {
                lblError.Text = "Se debe escribir el código de la Categoría.";
            }

            Articulo art = LogicaArticulo.Buscar(codigo);

            if (art != null)
            {
                txtNombre.Text = art.NombreArt;
                txtPresentacion.Text = art.TipoPresentacion;
                txtCodigoC.Text = art.UnaCategoria.CodigoC;
                txtPrecio.Text = art.Precio.ToString();
                txtTamaño.Text = art.Tamaño.ToString();

                ActivoBotones(false);
                btnAlta.Enabled = false;

                Session["Articulo"] = art;
            }
            else
            {
                ActivoBotones();
                btnAlta.Enabled = true;

                lblError.ForeColor = Color.Blue;
                lblError.Text = "No hay Artículos con ese código. Puede agregar uno si desea.";

                Session["Categoria"] = null;
            
             }
         }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo articulo = (Articulo)Session["Articulo"];

                articulo.NombreArt = txtNombre.Text.Trim();
                articulo.Precio = int.Parse(txtPrecio.Text.Trim());
                articulo.TipoPresentacion = txtPresentacion.Text.Trim();
                articulo.Tamaño = int.Parse(txtTamaño.Text.Trim());
                articulo.UnaCategoria.CodigoC = txtCodigoC.Text.Trim();

                LogicaArticulo.Modificar(articulo);

                LimpioFormulario();

                lblError.ForeColor = Color.Green;
                lblError.Text = "Modificación realizada con éxito.";

               
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
                Articulo articulo = (Articulo)Session["Articulo"];

                LogicaArticulo.Eliminar(articulo);

                LimpioFormulario();

                lblError.ForeColor = Color.Green;
                lblError.Text = "Eliminación exitosa";

                
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
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                int precio = int.Parse(txtPrecio.Text.Trim());
                string tipoPresentacion = txtPresentacion.Text.Trim();
                int tamaño = int.Parse(txtTamaño.Text.Trim());
                string codigoC = txtCodigoC.Text.Trim();

                Categoria cat = LogicaCategoria.Buscar(codigoC);

                

                Articulo articulo = new Articulo(codigo, nombre, precio, tipoPresentacion, tamaño, cat);

                LogicaArticulo.Agregar(articulo);

                LimpioFormulario();


                lblError.ForeColor = Color.Green;
                lblError.Text = "Alta con éxito";

            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }
        }
    }
}