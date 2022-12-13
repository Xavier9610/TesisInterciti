using ASPApp.Sources.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPApp.Sources.Pages
{
    public partial class frmVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {  
        }

        protected void bntSelect_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.HtmlControls.HtmlButton)sender;
            GridViewRow seleccion = (GridViewRow)(btn.NamingContainer);
            var ci = Convert.ToInt32(seleccion.Cells[1].Text);
            Response.Redirect("/Sources/Pages/frmVehiculoCRUD.aspx?op=R&id=" + ci);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.HtmlControls.HtmlButton)sender;
            GridViewRow seleccion = (GridViewRow)(btn.NamingContainer);
            var ci = Convert.ToInt32(seleccion.Cells[1].Text);
            if (Servicio.client.EliminarVehiculo(ci) == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Eliminación exitosa')", true);
                Response.Redirect("/Sources/Pages/frmVehiculo.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error intente de nuevo')", true);
                Response.Redirect("/Sources/Pages/frmVehiculo.aspx");
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.HtmlControls.HtmlButton)sender;
            GridViewRow seleccion = (GridViewRow)(btn.NamingContainer);
            var ci =Convert.ToInt32( seleccion.Cells[1].Text);
            Response.Redirect("/Sources/Pages/frmVehiculoCRUD.aspx?op=U&id=" + ci);
           // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + Servicio.client.FindAdminByCI(ci).IdAdmin + "')", true);
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Sources/Pages/frmVehiculoCRUD.aspx?op=C");
        }

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            if ( ddlFiltro.Text != "" && txtSearch.Value != "")
            {
                List<ServiceReferenceInterciti.Vehiculo> lista = new List<ServiceReferenceInterciti.Vehiculo>();
                switch (ddlFiltro.Text)
                {
                    case "Tipo":
                        lista = Servicio.client.ListarVehiculoTipo(txtSearch.Value);
                        break;

                    case "Año":
                        lista = Servicio.client.ListarVehiculoAnio(txtSearch.Value);
                        break;

                    case "Modelo":
                        lista = Servicio.client.ListarVehiculoModelo(txtSearch.Value);
                        break;

                    case "Marca":
                        lista = Servicio.client.ListarVehiculoMarca(txtSearch.Value);
                        break;

                    case "Placa":
                        lista = Servicio.client.ListarVehiculoPlaca(txtSearch.Value);
                        break;
                    case "Todo":
                        break;
                    default:
                        break;
                }
                grdVCliente.DataSourceID = null;
                grdVCliente.DataSource = null;
                grdVCliente.DataSource = lista;
                grdVCliente.DataBind();
            }
            else
            {
                grdVCliente.DataSourceID = "ObjectDataSource";
                ObjectDataSource.DataBind();
            }
            
        }
    }
}