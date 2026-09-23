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
    public partial class Listado_Interactivo_Articulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    List<Categoria> colCategorias = LogicaCategoria.ListarCategorias();
                    Session["TodasLasCategorias"] = colCategorias;

                    if (colCategorias.Count > 0)
                    {
                        lbxDatos.Items.Clear();
                        lbxVenta.Items.Clear();
                        ddlCategorias.Items.Clear();
                        ddlCategorias.DataSource = colCategorias;
                        ddlCategorias.DataTextField = "AMostrar";
                        ddlCategorias.DataValueField = "codigoC";
                        ddlCategorias.DataBind();

                        ddlCategorias.Items.Insert(0, new ListItem("Seleccione una categoría", "0"));
                    }
                    else
                    {
                        ddlArticulos.Enabled = false;
                        throw new Exception("No hay categorías disponibles.");
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }
        }

        protected void ddlCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbxDatos.Items.Clear();

                lbxVenta.Items.Clear();

                GrillaVentasdArticulo.DataSource = null;
                GrillaVentasdArticulo.DataBind();

                if (ddlCategorias.SelectedIndex >= 0)
                {
                    string cateSeleccionada = Convert.ToString(ddlCategorias.SelectedValue);
                    List<Categoria> colCategorias = (List<Categoria>)Session["TodasLasCategorias"];
                    Categoria categoria = null;


                    foreach (var cat in colCategorias)
                    {
                        if (cat.CodigoC == cateSeleccionada)
                        {
                            categoria = cat;
                            break;
                        }
                    }

                    if (categoria != null)
                    {

                        List<Articulo> articulos = LogicaArticulo.ListarArticulosxCate(cateSeleccionada);
                        Session["ArticulosxCategoria"] = articulos;

                        if (articulos.Count > 0)
                        {
                            ddlArticulos.Items.Clear();
                            ddlArticulos.DataSource = articulos;
                            ddlArticulos.DataTextField = "AMostrar";
                            ddlArticulos.DataValueField = "codigo";
                            ddlArticulos.DataBind();
                            ddlArticulos.Enabled = true;

                            ddlArticulos.Items.Insert(0, new ListItem("Seleccione un artículo", "0"));
                        }
                        else
                        {
                            ddlArticulos.Items.Clear();
                            ddlArticulos.Items.Add(new ListItem("No hay artículos asociados.", "0"));
                            ddlArticulos.Enabled = false;
                        }
                    }
                    else
                    {
                        throw new Exception("Categoría no encontrada.");
                    }



                }
                else
                {
                    ddlArticulos.Items.Clear();
                    ddlArticulos.Items.Add(new ListItem("Seleccione una categoría primero.", "0"));
                    ddlArticulos.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }
        }

        protected void ddlArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlArticulos.SelectedIndex >= 0)
                {
                    string artSeleccionado = Convert.ToString(ddlArticulos.SelectedValue);

                    List<Articulo> articulos = (List<Articulo>)Session["ArticulosxCategoria"];
                    Articulo articulo = null;

                    foreach (Articulo art in articulos)
                    {
                        if (art.Codigo == artSeleccionado)
                        {
                            articulo = art;
                            break;
                        }
                    }

                    if (articulo != null)
                    {
                        List<Articulo> listaTemporal = new List<Articulo>();
                        listaTemporal.Add(articulo);

                        lbxDatos.Items.Clear();
                        lbxDatos.DataSource = listaTemporal;
                        lbxDatos.DataTextField = "AMostrar";
                        lbxDatos.DataValueField = "codigo";
                        lbxDatos.DataBind();
                        lbxDatos.Enabled = true;

                        List<Venta> colVentasxArticulo = LogicaVenta.ListarVentasXArticulo(ddlArticulos.SelectedValue);
                        Session["ListaVentas"] = colVentasxArticulo;

                        if (colVentasxArticulo != null && colVentasxArticulo.Count > 0)
                        {
                            GrillaVentasdArticulo.DataSource = null;
                            GrillaVentasdArticulo.DataSource = colVentasxArticulo;
                            GrillaVentasdArticulo.DataBind();
                        }
                    }
                    else
                    {
                        lbxDatos.Items.Clear();
                        lbxDatos.Items.Add(new ListItem("No hay artículo asociado.", "0"));
                        lbxDatos.Enabled = false;
                    }

                        
                    } 
                    
                
            }
            catch (Exception ex)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }
        }

        protected void GrillaVentasdArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (GrillaVentasdArticulo.SelectedIndex >= 0)
                {
                    int venSeleccionada = Convert.ToInt32(GrillaVentasdArticulo.SelectedDataKey.Value);

                    List<Venta> ventasS = (List<Venta>)Session["ListaVentas"];
                    Venta ventas = null;

                    foreach (Venta v in ventasS)
                    {
                        if (v.NumVenta == venSeleccionada)
                        {
                            ventas = v;
                            break;
                        }
                    }

                    if (ventas != null)
                    {
                        List<Venta> listaTemporal = new List<Venta>();
                        listaTemporal.Add(ventas);


                        lbxVenta.DataSource = listaTemporal;

                        lbxVenta.DataTextField = "AMostrar";
                        lbxVenta.DataValueField = "numVenta";

                        lbxVenta.DataBind();
                        lbxVenta.Enabled = true;
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