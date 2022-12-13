using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPApp.Sources.Validaciones;
namespace ASPApp.Sources.Pages
{
    public partial class frmCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bntSelect_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.HtmlControls.HtmlButton)sender;
            GridViewRow seleccion = (GridViewRow)(btn.NamingContainer);
            var ci = seleccion.Cells[2].Text;
            Response.Redirect("/Sources/Pages/frmClienteCRUD.aspx?op=R&id=" +Servicio.client.FindClienteByCI(ci).IdCliente);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.HtmlControls.HtmlButton)sender;
            GridViewRow seleccion = (GridViewRow)(btn.NamingContainer);
            var ci = seleccion.Cells[2].Text;
            if (Servicio.client.EliminarCliente(Servicio.client.FindClienteByCI(ci).IdCliente) == 0)
            {
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Eliminación exitosa')", true);
                Response.Redirect("/Sources/Pages/frmIndex.aspx");
            }
            else
            {
             //   ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error intente de nuevo')", true);
                Response.Redirect("/Sources/Pages/frmIndex.aspx");
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.HtmlControls.HtmlButton)sender;
            GridViewRow seleccion = (GridViewRow)(btn.NamingContainer);
            var ci = seleccion.Cells[2].Text;
          //  Response.Redirect("/Sources/Pages/frmClienteCRUD.aspx?op=U&id=" + Servicio.client.FindClienteByCI(ci).IdCliente);
           // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+ Servicio.client.FindClienteByCI(ci).IdCliente + "')", true);
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Sources/Pages/frmClienteCRUD.aspx?op=C");
        }

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            if (ddlFiltro.Text != "" && txtSearch.Value != "")
            {
                List<ServiceReferenceInterciti.Cliente> lista = new List<ServiceReferenceInterciti.Cliente>();
                switch (ddlFiltro.Text)
                {
                    case "Nombre":
                        lista = Servicio.client.ListarClientesNombre(txtSearch.Value);
                        break;

                    case "Apellido":
                        lista = Servicio.client.ListarClientesApellido(txtSearch.Value);
                        break;

                    case "Cédula":
                        lista = Servicio.client.ListarClientesCedula(txtSearch.Value);
                        break;

                    case "E-mail":
                        lista = Servicio.client.ListarClientesCorreo(txtSearch.Value);
                        break;

                    case "Fecha":
                        lista = Servicio.client.ListarClientesFecha(txtSearch.Value);
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