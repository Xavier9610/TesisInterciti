using ASPApp.Sources.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPApp.Sources.Pages
{
    public partial class frmAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bntSelect_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.HtmlControls.HtmlButton)sender;
            GridViewRow seleccion = (GridViewRow)(btn.NamingContainer);
            var ci = seleccion.Cells[2].Text;
            Response.Redirect("/Sources/Pages/frmAdminCRUD.aspx?op=R&id=" + Servicio.client.FindAdminByCI(ci).IdAdmin);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.HtmlControls.HtmlButton)sender;
            GridViewRow seleccion = (GridViewRow)(btn.NamingContainer);
            var ci = seleccion.Cells[2].Text;
            if (Servicio.client.EliminarAdmin(Servicio.client.FindAdminByCI(ci).IdAdmin) == 0)
            {
                Response.Redirect("/Sources/Pages/frmAdmin.aspx");
            }
            else
            {
           //     ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error intente de nuevo')", true);
                Response.Redirect("/Sources/Pages/frmAdmin.aspx");
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.HtmlControls.HtmlButton)sender;
            GridViewRow seleccion = (GridViewRow)(btn.NamingContainer);
            var ci = seleccion.Cells[2].Text;
            Response.Redirect("/Sources/Pages/frmAdminCRUD.aspx?op=U&id=" + Servicio.client.FindAdminByCI(ci).IdAdmin);
         }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Sources/Pages/frmAdminCRUD.aspx?op=C");
        }

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            if (ddlFiltro.Text != "" && txtSearch.Value != "")
            {
                List<ServiceReferenceInterciti.Admin> lista = new List<ServiceReferenceInterciti.Admin>();
                switch (ddlFiltro.Text)
                {
                    case "Nombre":
                        lista = Servicio.client.ListarAdminNombre(txtSearch.Value);
                        break;

                    case "Apellido":
                        lista = Servicio.client.ListarAdminApellido(txtSearch.Value);
                        break;

                    case "Cédula":
                        lista = Servicio.client.ListarAdminCedula(txtSearch.Value);
                        break;

                    case "E-mail":
                        lista = Servicio.client.ListarAdminCorreo(txtSearch.Value);
                        break;

                    case "Fecha":
                        lista = Servicio.client.ListarAdminFecha(txtSearch.Value);
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