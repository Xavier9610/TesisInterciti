using ASPApp.ServiceReferenceInterciti;
using ASPApp.Sources.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPApp.Sources.Pages
{
    public partial class frmRecorridoCRUD : System.Web.UI.Page
    {
        private Recorrido recorrido;
        private ServiceClient client = new ServiceClient("BasicHttpBinding_IService", "https://wcfappservice.azurewebsites.net/Service.svc");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + Request.QueryString["id"].ToString() + "')", true);
                    recorrido = client.FindRecorridoById(Convert.ToInt32(Request.QueryString["id"].ToString()));
                }
                if (Request.QueryString["op"] != null)
                {
                    var op = Request.QueryString["op"];
                    switch (op)
                    {
                        case "C":
                            ActivarControles();
                            lblTitulo.Text = "Nuevo Recorrido";
                            break;
                        case "R":
                            DesactivarControles();
                            LlenarDatos();
                            lblTitulo.Text = "Mostrar Recorrido";

                            break;
                        case "U":
                            ActivarControles();
                            LlenarDatos();
                            lblTitulo.Text = "Actualizar Recorrido";
                            break;
                    }
                }
            }
        }

        private void LlenarDatos()
        {
            txtCalificacion.Text = recorrido.Calificacion.ToString();
            txtComentario.Text = recorrido.Comentario;
            txtClienteApellido.Text = recorrido.IdCliente.Apellido;
            txtClienteNombre.Text = recorrido.IdCliente.Nombre;
            txtConductorApellido.Text = recorrido.IdConductor.Apellido;
            txtConductorNombre.Text = recorrido.IdConductor.Nombre;
            txtDestino.Text = recorrido.Destino;
            txtOrigen.Text = recorrido.Origen;
            txtValor.Text = recorrido.ValorRecorrido.ToString();
        }

        private void DesactivarControles()
        {
            txtCalificacion.Enabled = false;
            txtComentario.Enabled = false;
            txtClienteApellido.Enabled = false;
            txtClienteNombre.Enabled = false;
            txtConductorApellido.Enabled = false;
            txtConductorNombre.Enabled = false;
            txtDestino.Enabled = false;
            txtOrigen.Enabled = false;
            txtValor.Enabled = false;
            fotoConductor.Src= "data:image;base64," + Convert.ToBase64String(Servicio.Decompress(recorrido.IdConductor.Picture));
            fotoCliente.Src = "data:image;base64," + Convert.ToBase64String(Servicio.Decompress(recorrido.IdCliente.Picture));
        }

        private void ActivarControles()
        {

        }

        protected void btnCliente_Click(object sender, EventArgs e)
        {

        }

        protected void btnConductor_Click(object sender, EventArgs e)
        {

        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Sources/Pages/frmRecorrido.aspx");
        }
    }
}