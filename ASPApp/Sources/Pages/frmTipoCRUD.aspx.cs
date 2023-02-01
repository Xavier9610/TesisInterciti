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
    public partial class frmTipoCRUD : System.Web.UI.Page
    {
        private TipoVehiculo tipo;
        private ServiceClient client = new ServiceClient("BasicHttpBinding_IService", "https://wcfappservice.azurewebsites.net/Service.svc");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + Request.QueryString["id"].ToString() + "')", true);
                    tipo = client.FindTipoVehiculoById(Convert.ToInt32(Request.QueryString["id"].ToString()));
                }
                if (Request.QueryString["op"] != null)
                {
                    var op = Request.QueryString["op"];
                    switch (op)
                    {
                        case "C":
                            txtTipo.Enabled = true;
                            btnRegistrar.Visible = true;
                            btnRegistrar.Enabled = true;
                            lblTitulo.Text = "Nuevo Tipo";
                            btnRegistrar.Text = "Nuevo";
                            break;
                        case "R":
                            txtTipo.Enabled = false;
                            btnRegistrar.Visible = false;
                            btnRegistrar.Enabled = false;
                            txtTipo.Text = tipo.Tipo;
                            lblTitulo.Text = "Mostrar Tipo";

                            break;
                        case "U":
                            txtTipo.Enabled = true;
                            btnRegistrar.Visible = true;
                            btnRegistrar.Enabled = true;
                            txtTipo.Text = tipo.Tipo;
                            lblTitulo.Text = "Actualizar Tipo";
                            btnRegistrar.Text = "Guardar Cambios";
                            break;
                    }
                }
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtTipo != null )
            {
                if (txtTipo.Text != "")
                {
                    switch (lblTitulo.Text)
                    {
                        case "Nuevo Tipo":
                            var aux = Servicio.client.GenerarPass();
                            if (Servicio.client.AgregarTipoVehiculo(txtTipo.Text ) == 0)
                            {
                               Response.Redirect("/Sources/Pages/frmTipo.aspx");
                            }
                            else
                            {
                                //no registrado
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro erroneo')", true);
                            }
                            break;
                        case "Actualizar Tipo":
                            tipo = client.FindTipoVehiculoById(Convert.ToInt32(Request.QueryString["id"].ToString()));
                            tipo.Tipo = txtTipo.Text;
                            
                            if (Servicio.client.ActualizarTipo(tipo) == 0)
                            {
                                //exitoso
                                //           ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro exitoso')", true);
                                Response.Redirect("/Sources/Pages/frmTipo.aspx");
                            }
                            else
                            {
                                //no registrado
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro erroneo')", true);
                            }
                            break;
                    }
                }
                else
                {
                    //datos mal
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos vacios')", true);
                }
            }
            else
            {
                //datos mal
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos vacios')", true);
            }


        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Sources/Pages/frmTipo.aspx");
        }
    }
}