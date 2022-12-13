using ASPApp.Sources.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPApp.Sources.Pages
{
    public partial class frmMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bntSelect_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.HtmlControls.HtmlButton)sender;
            GridViewRow seleccion = (GridViewRow)(btn.NamingContainer);
            var ci = seleccion.Cells[1].Text;
            Response.Redirect("/Sources/Pages/frmMarcaCRUD.aspx?op=R&id=" + Servicio.client.FindMarcaVehiculoByMarca(ci));
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.HtmlControls.HtmlButton)sender;
            GridViewRow seleccion = (GridViewRow)(btn.NamingContainer);
            var ci = seleccion.Cells[1].Text;
            if (Servicio.client.EliminarMarcaVehiculo(Servicio.client.FindMarcaVehiculoByMarca(ci)) == 0)
            {
         //       ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Eliminación exitosa')", true);
                Response.Redirect("/Sources/Pages/frmMarca.aspx");
            }
            else
            {
         //       ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error, intente de nuevo')", true);
                Response.Redirect("/Sources/Pages/frmMarca.aspx");
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.HtmlControls.HtmlButton)sender;
            GridViewRow seleccion = (GridViewRow)(btn.NamingContainer);
            var ci = seleccion.Cells[1].Text;
            Response.Redirect("/Sources/Pages/frmMarcaCRUD.aspx?op=U&id=" + Servicio.client.FindMarcaVehiculoByMarca(ci));
            // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + Servicio.client.FindAñoVehiculoByIdAño(ci) + "')", true);
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Sources/Pages/frmMarcaCRUD.aspx?op=C");
        }
    }
}