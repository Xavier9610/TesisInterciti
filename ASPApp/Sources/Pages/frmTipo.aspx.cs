using ASPApp.Sources.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPApp.Sources.Pages
{
    public partial class frmTipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bntSelect_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow seleccion = (GridViewRow)(btn.NamingContainer);
            var ci = seleccion.Cells[1].Text;
            Response.Redirect("/Sources/Pages/frmTipoCRUD.aspx?op=R&id=" + Servicio.client.FindTipoVehiculoByTipo(ci));
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow seleccion = (GridViewRow)(btn.NamingContainer);
            var ci = seleccion.Cells[1].Text;
            if (Servicio.client.EliminarTipoVehiculo(Servicio.client.FindTipoVehiculoByTipo(ci)) == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Eliminación exitosa')", true);
                Response.Redirect("/Sources/Pages/frmTipo.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error, intente de nuevo')", true);
                Response.Redirect("/Sources/Pages/frmTipo.aspx");
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow seleccion = (GridViewRow)(btn.NamingContainer);
            var ci = seleccion.Cells[1].Text;
             Response.Redirect("/Sources/Pages/frmTipoCRUD.aspx?op=U&id=" + Servicio.client.FindTipoVehiculoByTipo(ci));
          //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + Servicio.client.FindTipoVehiculoByTipo(ci) + "')", true);
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Sources/Pages/frmTipoCRUD.aspx?op=C");
        }

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            if (ddlFiltro.Text != "" && txtSearch.Value != "")
            {
                List<ServiceReferenceInterciti.TipoVehiculo> lista = new List<ServiceReferenceInterciti.TipoVehiculo>();
                switch (ddlFiltro.Text)
                {
                    case "Tipo":
                        break;

                    default:
                        break;
                }
                grdVCliente.DataSourceID = null;
                grdVCliente.DataSource = null;
                grdVCliente.DataSource = lista;
            }
            else
            {
                grdVCliente.DataSourceID = "ObjectDataSource";
                ObjectDataSource.DataBind();
            }

        }
    }
}