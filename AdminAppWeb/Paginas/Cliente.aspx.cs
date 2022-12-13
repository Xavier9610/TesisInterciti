using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdminAppWeb.ServiceReferenceInterciti;
namespace AdminAppWeb.Paginas
{
    public partial class Cliente : System.Web.UI.Page
    {
        ServiceClient service = new ServiceClient();

        private static Cliente[] clientes;
        private static Cliente seleccionado;
        private static string id;
        public Cliente Seleccionado { get => seleccionado; set => seleccionado = value; }
        public string Id { get => id; set => id = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            clientes = service.ListarClientes();
            //   aAdd.Visible = false;
            tblBotones.Enabled = true;
            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }
        protected void lbxClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //aAdd.Visible = true;
            tblBotones.Enabled = true;
            btnAgregar.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;

            var filaSeleccionada = grdVCliente.SelectedRow;
            Id = filaSeleccionada.Cells[0].Text;
            //CRUDCliente cliente = new CRUDCliente();
            seleccionado = service.FindClienteByID(Int32.Parse(Id));
            // cliente.
            //SiteMaster master = new SiteMaster();
            // cliente.Cliente = seleccionado;
            
        }
        protected void btnEliminar_Clicked(object sender, EventArgs e)
        {
            Response.Redirect("CRUDCliente.aspx?id=" + Id + "&op=D");
        }
        protected void btnAgregar_Clicked(object sender, EventArgs e)
        {
            Response.Redirect("CRUDCliente.aspx?id=" + Id+"&op=C");
        }
        protected void btnEditar_Clicked(object sender, EventArgs e)
        {
            Response.Redirect("CRUDCliente.aspx?id=" + Id + "&op=U");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            clientes = service.ListarClientes();
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
        

        protected void ddlFlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFiltro.Enabled = true;
            btnFiltrar.Enabled = true;

        }
    }
}