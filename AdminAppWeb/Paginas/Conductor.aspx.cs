using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminAppWeb.Paginas
{
    public partial class Conductor : System.Web.UI.Page
    {
        ServiceReferenceInterciti.ServiceClient service = new ServiceReferenceInterciti.ServiceClient();

        private static ServiceReferenceInterciti.Conductor[] clientes;
        private static ServiceReferenceInterciti.Conductor seleccionado;
        private static string id;
        public ServiceReferenceInterciti.Conductor Seleccionado { get => seleccionado; set => seleccionado = value; }
        public string Id { get => id; set => id = value; }
        protected void Page_Load(object sender, EventArgs e)
        {
            clientes = service.ListarConductores();
            //   aAdd.Visible = false;
            tblBotones.Enabled = true;
            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }
        protected void lbxConductores_SelectedIndexChanged(object sender, EventArgs e)
        {
            //aAdd.Visible = true;
            tblBotones.Enabled = true;
            btnAgregar.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;

            var filaSeleccionada = grdVConductor.SelectedRow;
            Id = filaSeleccionada.Cells[0].Text;
            //CRUDCliente cliente = new CRUDCliente();
            seleccionado = service.FindConductorByID(Int32.Parse(Id));
            // cliente.
            //SiteMaster master = new SiteMaster();
            // cliente.Cliente = seleccionado;
        }

        protected void btnEliminar_Clicked(object sender, EventArgs e)
        {
            Response.Redirect("CRUDConductor.aspx?id=" + Id + "&op=D");
        }
      
        protected void btnAgregar_Clicked(object sender, EventArgs e)
        {
            Response.Redirect("CRUDConductor.aspx?id=" + Id + "&op=C");
        }
        protected void btnEditar_Clicked(object sender, EventArgs e)
        {
            Response.Redirect("CRUDConductor.aspx?id=" + Id + "&op=U");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            clientes = service.ListarConductores();
            foreach (var iter in clientes)
            {
                if (iter.Nombre.Contains(txtFiltro.Text))
                {

                }
            }
            //if (txtFiltro.Text != "")

            //{

            //    ODSCliente.FilterExpression = "ID LIKE '%" + txtFiltro.Text + "%'";

            //}
        }
        
    }
}