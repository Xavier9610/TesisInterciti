using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminAppWeb.Paginas
{
    public partial class Vehiculo : System.Web.UI.Page
    {
       // ServiceReferenceInterciti.Service1Client service = new ServiceReferenceInterciti.Service1Client();

        private static ServiceReferenceInterciti.Vehiculo[] Vehiculos;
        private static ServiceReferenceInterciti.Vehiculo seleccionado;
        private static string id;
        public ServiceReferenceInterciti.Vehiculo Seleccionado { get => seleccionado; set => seleccionado = value; }
        public string Id { get => id; set => id = value; }
        protected void Page_Load(object sender, EventArgs e)
        {
       //     Vehiculos = service.ListarVehiculo();
            //   aAdd.Visible = false;
            tblBotones.Enabled = true;
            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }
        protected void lbxVehiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //aAdd.Visible = true;
            tblBotones.Enabled = true;
            btnAgregar.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;

            var filaSeleccionada = grdVVehiculo.SelectedRow;
            Id = filaSeleccionada.Cells[0].Text;
            //CRUDCliente cliente = new CRUDCliente();
           // seleccionado = service.FindClienteByID(Int32.Parse(Id));
            // cliente.
            //SiteMaster master = new SiteMaster();
            // cliente.Cliente = seleccionado;
        }
        protected void btnEliminar_Clicked(object sender, EventArgs e)
        {
            Response.Redirect("CRUDVehiculo.aspx?id=" + Id + "&op=D");
        }

        protected void btnAgregar_Clicked(object sender, EventArgs e)
        {
            Response.Redirect("CRUDVehiculo.aspx?id=" + Id + "&op=C");
        }
        protected void btnEditar_Clicked(object sender, EventArgs e)
        {
            Response.Redirect("CRUDVehiculo.aspx?id=" + Id + "&op=U");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Vehiculos = service.ListarVehiculo();
            //foreach (var iter in Vehiculos)
            //{
            //    if (iter.Modelo.Contains(txtFiltro.Text))
            //    {

            //    }
            //}
            //if (txtFiltro.Text != "")

            //{

            //    ODSCliente.FilterExpression = "ID LIKE '%" + txtFiltro.Text + "%'";

            //}
        }

    }
}