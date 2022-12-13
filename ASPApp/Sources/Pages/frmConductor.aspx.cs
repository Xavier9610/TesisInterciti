using ASPApp.Sources.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPApp.Sources.Pages
{
    public partial class frmConductor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bntSelect_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.HtmlControls.HtmlButton)sender;
            GridViewRow seleccion = (GridViewRow)(btn.NamingContainer);
            var ci = seleccion.Cells[2].Text;
            Response.Redirect("/Sources/Pages/frmConductorCRUD.aspx?op=R&id=" + Servicio.client.FindConductorByCI(ci).IdConductor);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.HtmlControls.HtmlButton)sender;
            GridViewRow seleccion = (GridViewRow)(btn.NamingContainer);
            var ci = seleccion.Cells[2].Text;
            if (Servicio.client.EliminarConductor(Servicio.client.FindConductorByCI(ci).IdConductor) == 0)
            {
              //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Eliminación exitosa')", true);
                Response.Redirect("/Sources/Pages/frmConductor.aspx");
            }
            else
            {
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error intente de nuevo')", true);
                Response.Redirect("/Sources/Pages/frmConductor.aspx");
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.HtmlControls.HtmlButton)sender;
            GridViewRow seleccion = (GridViewRow)(btn.NamingContainer);
            var ci = seleccion.Cells[2].Text;
            Response.Redirect("/Sources/Pages/frmConductorCRUD.aspx?op=U&id=" + Servicio.client.FindConductorByCI(ci).IdConductor);
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + Servicio.client.FindConductorByCI(ci).IdConductor + "')", true);
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Sources/Pages/frmConductorCRUD.aspx?op=C");
        }
        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            if (ddlFiltro.Text != "" && txtSearch.Value != "")
            {
                List<ServiceReferenceInterciti.Conductor> lista = new List<ServiceReferenceInterciti.Conductor>();
                switch (ddlFiltro.Text)
                {
                    case "Nombre":
                        lista = Servicio.client.ListarConductorNombre(txtSearch.Value);
                        break;

                    case "Apellido":
                        lista = Servicio.client.ListarConductorApellido(txtSearch.Value);
                        break;

                    case "Cédula":
                        lista = Servicio.client.ListarConductorCedula(txtSearch.Value);
                        break;

                    case "E-mail":
                        lista = Servicio.client.ListarConductorCorreo(txtSearch.Value);
                        break;

                    case "Fecha":
                        lista = Servicio.client.ListarConductorFecha(txtSearch.Value);
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