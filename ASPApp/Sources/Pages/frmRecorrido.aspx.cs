using ASPApp.Sources.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPApp.Sources.Pages
{
    public partial class frmRecorrido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void bntSelect_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.HtmlControls.HtmlButton)sender;
            GridViewRow seleccion = (GridViewRow)(btn.NamingContainer);
            var id =Convert.ToInt32( seleccion.Cells[7].Text);
            Response.Redirect("/Sources/Pages/frmRecorridoCRUD.aspx?op=R&id=" + Servicio.client.FindRecorridoById(id).IdRecorrido);
        }

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            if (ddlFiltro.Text != "" && txtSearch.Value != "")
            {
                var aux = Servicio.client.ListarRecorrido();
                List<ServiceReferenceInterciti.Recorrido> lista = new List<ServiceReferenceInterciti.Recorrido>();
                switch (ddlFiltro.Text)
                {
                    case "Cliente":
                        lista = Servicio.client.ListarRecorridoCliente(txtSearch.Value);
                        break;

                    case "Conductor":
                        lista = Servicio.client.ListarRecorridoConductor(txtSearch.Value);
                        break;

                    case "Origen":
                        foreach (var iterator in aux)
                        {
                            if (iterator.Origen.Contains(txtSearch.Value))
                            {
                                lista.Add(iterator);
                            }
                        }
                        break;

                    case "Destino":
                        foreach (var iterator in aux)
                        {
                            if (iterator.Destino.Contains(txtSearch.Value))
                            {
                                lista.Add(iterator);
                            }
                        }
                        break;

                    case "Fecha":
                        foreach (var iterator in aux)
                        {
                            if (iterator.FechaRecorrido.ToString().Contains(txtSearch.Value))
                            {
                                lista.Add(iterator);
                            }
                        }
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